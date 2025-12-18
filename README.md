# FitNotFat - Système de gestion de salle de sport

Projet académique visant à concevoir et développer une application de gestion pour une salle de sport.

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
   - `database/seed.sql` (optionnel)
3. Mettre à jour la chaîne de connexion dans `SalleSportApp/App.config` (`DefaultConnection`).
4. Ouvrir `SalleSportApp/SalleSportApp.csproj` dans Visual Studio.
5. Restaurer les packages NuGet (clic droit sur la solution => Restore NuGet Packages).
6. Compiler et lancer l'application (F5).

## Visualisation UML de la gestion de la BDD

![Texte alternatif](images/UML.png)
