# FitNotFat - Système de gestion de salle de sport

Projet académique visant à concevoir et développer une application de gestion pour une salle de sport.
Alexander SLEZACK - Stefan STINCA - Rafaël SCHOEN _(voir LICENSE)_

## Description rapide
Application WinForms (.NET Framework 4.7.2) pour gérer une salle de sport : création de membres, gestion des coachs et des cours, réservations, suivi des demandes et rôles (administrateur vs membre). La base de données PostgreSQL stocke les informations principales (utilisateurs, cours, réservations, etc.).

## Objectif
Mettre en place une base de données et une application permettant de gérer :
- les membres et leurs adhésions  
- les coachs  
- les cours et les réservations  
- les rôles et privilèges des utilisateurs  

## Fonctionnalités principales
- Gestion des membres, coachs et cours  
- Réservations et annulations de cours  
- Authentification sécurisée (administrateurs / membres)  
- Statistiques et rapports  

---

## Guide d'installation

### Prérequis
- Windows (application WinForms)
- Visual Studio 2019+ avec support .NET Framework 4.7.2
- PostgreSQL 13+
- NuGet (inclus avec Visual Studio)

### Installation
1. Cloner le dépôt.
2. Créer la base de données PostgreSQL et exécuter :
   - `database/schema.sql`
3. Mettre à jour la chaîne de connexion dans `SalleSportApp/App.config` (`DefaultConnection`).
4. Ouvrir `SalleSportApp/SalleSportApp.csproj` dans Visual Studio.
5. Restaurer les packages NuGet (clic droit sur la solution => Restore NuGet Packages).
6. Compiler et lancer l'application (F5).

## Utilisation
- Au premier lancement, connectez-vous avec l'administrateur pour gérer les comptes.
  - Identifiant : `admin@test.com`
  - Mot de passe : `1234`
- Pour les nouveaux membres :
  1. Créez un compte via le formulaire d'inscription.
  2. L'administrateur doit ensuite approuver le compte pour que le membre puisse se connecter et réserver des cours.
- L'administrateur peut créer/éditer les coachs, cours et créneaux, et consulter les réservations.
- Les membres peuvent consulter les cours disponibles et réserver/annuler leurs réservations une fois approuvés.
- Les requêtes exigées par le cahier des charges sont listées dans `database/queries_recap.sql` (sous-requêtes, ensemble, LEFT/RIGHT JOIN, agrégations).

## Requêtes SQL (récapitulatif)
- L’ensemble des requêtes demandées par le cahier des charges est regroupé dans `database/queries_recap.sql`.
- Le fichier couvre : sous-requêtes, opérations ensemblistes (UNION), jointures (INNER, LEFT, RIGHT) et agrégations (COUNT, SUM, AVG, MIN, MAX, COUNT DISTINCT).
- Ces requêtes sont également consommées dans l’application via le module de reporting (formulaire Admin).

## Choix techniques
- Interface : client lourd WinForms (.NET Framework 4.7.2) pour disposer rapidement d’une GUI riche sans passer par une TUI/console.
- Base de données : PostgreSQL avec enums typés, contraintes `CHECK` sur les capacités/montants et `UNIQUE` sur l’email utilisateur et le couple (membre, cours).
- Accès données : DAO par entité (`AdminDAO`, `MembreDAO`, `CoursDAO`, `CoachDAO`, `ReservationDAO`) + `ReportingDAO` pour les requêtes du cahier des charges.
- Sécurité BDD : rôles applicatifs distincts créés dans `database/schema.sql` (`gym_admin_principal`, `gym_admin_secondaire`, `gym_membre`) avec privilèges différenciés.
- Reporting : le formulaire Admin charge un résumé + les requêtes avancées (sous-requêtes, UNION, LEFT/RIGHT JOIN, agrégations).
- Schéma E/A : modifiable/visualisable via `images/er_diagram.puml` (PlantUML) et `images/UML.png`.

## Rôles et accès BDD
- `gym_admin_principal` : droits complets sur les tables et séquences.
- `gym_admin_secondaire` : SELECT/INSERT/UPDATE/DELETE sur les tables, USAGE/SELECT sur les séquences.
- `gym_membre` : lecture des référentiels (cours, salle, coach, membre) et INSERT/SELECT sur `inscription_cours`.
- Les mots de passe sont définis dans `database/schema.sql` (à adapter avant déploiement).

## Visualisation UML de la gestion de la BDD

![Diagramme E/A](images/UML.png)
