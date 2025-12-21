using System;
using System.Collections.Generic;
using System.Globalization;
using Npgsql;

namespace SalleSportApp.Data
{
    /// <summary>
    /// Exécute les requêtes exigées par le cahier des charges et renvoie des lignes lisibles pour l'UI.
    /// </summary>
    public class ReportingDAO
    {
        private readonly Database db = new Database();

        public List<string> GetRequetesDemo()
        {
            List<string> lignes = new List<string>();
            using (var conn = db.CreateConnection())
            {
                conn.Open();
                lignes.AddRange(GetMembresAvecReservations(conn));
                lignes.AddRange(GetCoursAvecPlaces(conn));
                lignes.AddRange(GetEmailsUnion(conn));
                lignes.AddRange(GetReservationsDetail(conn));
                lignes.AddRange(GetCoursAvecSalle(conn));
                lignes.AddRange(GetReservationsRightJoin(conn));
                lignes.AddRange(GetAggregations(conn));
            }
            return lignes;
        }

        private IEnumerable<string> GetMembresAvecReservations(NpgsqlConnection conn)
        {
            const string sql = @"
                SELECT m.id, m.nom, m.prenom
                FROM membre m
                WHERE m.statut_inscription = 'valide'
                  AND m.id IN (
                    SELECT ic.membre_id
                    FROM inscription_cours ic
                    GROUP BY ic.membre_id
                    HAVING COUNT(*) >= 1
                );";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            List<string> lignes = new List<string> { "[Sous-requête] Membres validés ayant au moins 1 réservation :" };
            if (!reader.HasRows)
            {
                lignes.Add("  - Aucun membre réservé pour le moment");
                return lignes;
            }
            while (reader.Read())
            {
                lignes.Add($"  - #{reader.GetInt32(0)} : {reader.GetString(1)} {reader.GetString(2)}");
            }
            return lignes;
        }

        private IEnumerable<string> GetCoursAvecPlaces(NpgsqlConnection conn)
        {
            const string sql = @"
                SELECT c.id, c.nom, c.capacite_max,
                       (SELECT COUNT(*) FROM inscription_cours ic WHERE ic.cours_id = c.id) AS inscrits
                FROM cours c
                WHERE c.capacite_max > (
                    SELECT COUNT(*) FROM inscription_cours ic WHERE ic.cours_id = c.id
                );";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            List<string> lignes = new List<string> { "[Sous-requête] Cours avec capacité restante :" };
            if (!reader.HasRows)
            {
                lignes.Add("  - Aucun cours disponible (plein ou inexistant)");
                return lignes;
            }
            while (reader.Read())
            {
                int inscrits = reader.GetInt32(3);
                int capacite = reader.GetInt32(2);
                lignes.Add($"  - {reader.GetString(1)} (ID {reader.GetInt32(0)}) : {capacite - inscrits} places restantes");
            }
            return lignes;
        }

        private IEnumerable<string> GetEmailsUnion(NpgsqlConnection conn)
        {
            const string sql = @"
                SELECT email, 'membre' AS source FROM membre
                UNION
                SELECT email, 'coach' AS source FROM coach;";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            List<string> lignes = new List<string> { "[Ensemble UNION] Emails combinés membres & coachs :" };
            if (!reader.HasRows)
            {
                lignes.Add("  - Aucun email trouvé");
                return lignes;
            }
            while (reader.Read())
            {
                lignes.Add($"  - {reader.GetString(0)} ({reader.GetString(1)})");
            }
            return lignes;
        }

        private IEnumerable<string> GetReservationsDetail(NpgsqlConnection conn)
        {
            const string sql = @"
                SELECT ic.id AS reservation_id, m.nom AS membre_nom, c.nom AS cours_nom, ic.date_inscription
                FROM inscription_cours ic
                JOIN membre m ON m.id = ic.membre_id
                JOIN cours c ON c.id = ic.cours_id;";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            List<string> lignes = new List<string> { "[Join] Réservations avec membre & cours :" };
            if (!reader.HasRows)
            {
                lignes.Add("  - Aucune réservation");
                return lignes;
            }
            while (reader.Read())
            {
                lignes.Add($"  - Resa #{reader.GetInt32(0)} : {reader.GetString(1)} -> {reader.GetString(2)} ({reader.GetDateTime(3):yyyy-MM-dd})");
            }
            return lignes;
        }

        private IEnumerable<string> GetCoursAvecSalle(NpgsqlConnection conn)
        {
            const string sql = @"
                SELECT c.id, c.nom, s.nom AS salle_nom, s.capacite
                FROM cours c
                LEFT JOIN salle s ON s.id = c.salle_id;";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            List<string> lignes = new List<string> { "[LEFT JOIN] Cours et salles associées (ou non) :" };
            if (!reader.HasRows)
            {
                lignes.Add("  - Aucun cours");
                return lignes;
            }
            while (reader.Read())
            {
                string salleNom = reader.IsDBNull(2) ? "(pas de salle)" : reader.GetString(2);
                string capacite = reader.IsDBNull(3) ? "n/a" : reader.GetInt32(3).ToString();
                lignes.Add($"  - {reader.GetString(1)} (ID {reader.GetInt32(0)}) -> {salleNom} (capacité {capacite})");
            }
            return lignes;
        }

        private IEnumerable<string> GetReservationsRightJoin(NpgsqlConnection conn)
        {
            const string sql = @"
                SELECT m.id AS membre_id, m.nom, ic.id AS reservation_id, ic.cours_id
                FROM membre m
                RIGHT JOIN inscription_cours ic ON ic.membre_id = m.id;";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            List<string> lignes = new List<string> { "[RIGHT JOIN] Réservations et membres (inclut réservations orphelines) :" };
            if (!reader.HasRows)
            {
                lignes.Add("  - Aucune réservation");
                return lignes;
            }
            while (reader.Read())
            {
                string membreLabel = reader.IsDBNull(0) ? "(membre inconnu)" : $"#{reader.GetInt32(0)} {reader.GetString(1)}";
                lignes.Add($"  - Resa #{reader.GetInt32(2)} -> {membreLabel}, cours {reader.GetInt32(3)}");
            }
            return lignes;
        }

        private IEnumerable<string> GetAggregations(NpgsqlConnection conn)
        {
            List<string> lignes = new List<string> { "[Agrégations] Statistiques rapides :" };
            lignes.Add($"  - Nombre total de membres : {ExecuteScalarInt(conn, "SELECT COUNT(*) FROM membre")}");
            lignes.Add($"  - Total paiements encaissés : {ExecuteScalarDecimal(conn, "SELECT COALESCE(SUM(montant),0) FROM paiement_adhesion WHERE statut = 'paye'"):0.00} €");
            lignes.Add($"  - Capacité moyenne des salles : {ExecuteScalarDecimal(conn, "SELECT COALESCE(AVG(capacite),0) FROM salle"):0.00}");
            lignes.Add($"  - Premier cours (horaire min) : {ExecuteScalarDateTime(conn, "SELECT MIN(horaire) FROM cours")}");
            lignes.Add($"  - Dernier cours (horaire max) : {ExecuteScalarDateTime(conn, "SELECT MAX(horaire) FROM cours")}");
            lignes.Add($"  - Coachs distincts affectés : {ExecuteScalarInt(conn, "SELECT COUNT(DISTINCT coach_id) FROM cours")}");
            return lignes;
        }

        private int ExecuteScalarInt(NpgsqlConnection conn, string query)
        {
            using var cmd = new NpgsqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt32(result, CultureInfo.InvariantCulture);
        }

        private decimal ExecuteScalarDecimal(NpgsqlConnection conn, string query)
        {
            using var cmd = new NpgsqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
            {
                return 0m;
            }
            return Convert.ToDecimal(result, CultureInfo.InvariantCulture);
        }

        private string ExecuteScalarDateTime(NpgsqlConnection conn, string query)
        {
            using var cmd = new NpgsqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
            {
                return "n/a";
            }
            return Convert.ToDateTime(result, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm");
        }
    }
}
