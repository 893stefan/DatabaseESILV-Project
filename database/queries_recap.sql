-- =========================================
-- Requêtes récapitulatives (cahier des charges)
-- Toutes ces requêtes sont basées sur les tables définies dans schema.sql
-- et peuvent être utilisées dans les DAO ou pour des rapports.
-- =========================================

-- 1) Sous-requête #1 : membres validés avec au moins 1 réservation
SELECT m.id, m.nom, m.prenom
FROM membre m
WHERE m.statut_inscription = 'valide'
  AND m.id IN (
    SELECT ic.membre_id
    FROM inscription_cours ic
    GROUP BY ic.membre_id
    HAVING COUNT(*) >= 1
  );

-- 2) Sous-requête #2 : cours dont la capacité n'est pas encore atteinte
SELECT c.id, c.nom, c.capacite_max,
       (SELECT COUNT(*) FROM inscription_cours ic WHERE ic.cours_id = c.id) AS inscrits
FROM cours c
WHERE c.capacite_max > (
    SELECT COUNT(*) FROM inscription_cours ic WHERE ic.cours_id = c.id
);

-- 3) Requête ensemble (UNION) : emails combinés des membres et des coachs
SELECT email, 'membre' AS source
FROM membre
UNION
SELECT email, 'coach' AS source
FROM coach;

-- 4) Jointure INNER (sql1) : réservations avec cours et membre
SELECT ic.id AS reservation_id, m.nom AS membre_nom, c.nom AS cours_nom, ic.date_inscription
FROM inscription_cours ic
JOIN membre m ON m.id = ic.membre_id
JOIN cours c ON c.id = ic.cours_id;

-- 5) Jointure INNER (sql2) : cours et coach affecté
SELECT c.id, c.nom, co.nom AS coach_nom, co.prenom AS coach_prenom, c.horaire
FROM cours c
JOIN coach co ON co.id = c.coach_id;

-- 6) LEFT JOIN : cours avec salle (y compris cours sans salle définie)
SELECT c.id, c.nom, s.nom AS salle_nom, s.capacite
FROM cours c
LEFT JOIN salle s ON s.id = c.salle_id;

-- 7) RIGHT JOIN : membres et leurs réservations (montre aussi les réservations orphelines si FK désactivée)
SELECT m.id AS membre_id, m.nom, ic.id AS reservation_id, ic.cours_id
FROM membre m
RIGHT JOIN inscription_cours ic ON ic.membre_id = m.id;

-- 8) Agrégations (COUNT, SUM, AVG, MIN, MAX, et COUNT DISTINCT ici comme 6e)

-- COUNT : nombre total de membres
SELECT COUNT(*) AS total_membres FROM membre;

-- SUM : total des paiements encaissés
SELECT SUM(montant) AS total_encaisse FROM paiement_adhesion WHERE statut = 'paye';

-- AVG : capacité moyenne des salles
SELECT AVG(capacite) AS capacite_moyenne FROM salle;

-- MIN : cours le plus tôt (horaire minimal)
SELECT MIN(horaire) AS premier_cours FROM cours;

-- MAX : horaire maximal d'un cours
SELECT MAX(horaire) AS dernier_cours FROM cours;

-- COUNT DISTINCT (6e fonction d'agrégation choisie) : nombre de coachs distincts affectés
SELECT COUNT(DISTINCT coach_id) AS coachs_actifs FROM cours;

-- =========================================
-- Fin du fichier
-- =========================================
