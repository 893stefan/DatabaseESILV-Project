-- =========================================
-- Base de données : Gestion de salle de sport
-- SGBD : PostgreSQL
-- =========================================

-- ---------- ENUMS ----------

CREATE TYPE role_admin_enum AS ENUM (
    'admin_principal',
    'admin_secondaire'
);

CREATE TYPE statut_inscription_membre_enum AS ENUM (
    'en_attente',
    'valide',
    'refuse'
);

CREATE TYPE statut_inscription_cours_enum AS ENUM (
    'reserve',
    'annule_membre',
    'annule_admin'
);

CREATE TYPE statut_paiement_enum AS ENUM (
    'en_attente',
    'paye',
    'echoue'
);

CREATE TYPE intensite_enum AS ENUM (
    'faible',
    'moyenne',
    'elevee'
);

CREATE TYPE niveau_difficulte_enum AS ENUM (
    'debutant',
    'intermediaire',
    'avance'
);

-- ---------- UTILISATEUR (admins) ----------

CREATE TABLE utilisateur (
    id SERIAL PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    mot_de_passe_hash VARCHAR(255) NOT NULL,
    role role_admin_enum NOT NULL,
    telephone VARCHAR(20)
);

-- ---------- MEMBRE ----------

CREATE TABLE membre (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    prenom VARCHAR(100) NOT NULL,
    adresse VARCHAR(255),
    telephone VARCHAR(20),
    email VARCHAR(255),
    date_inscription DATE NOT NULL DEFAULT CURRENT_DATE,
    statut_inscription statut_inscription_membre_enum NOT NULL DEFAULT 'en_attente',
    date_validation DATE,
    valide_par_admin_id INTEGER,

    CONSTRAINT fk_membre_admin_validation
        FOREIGN KEY (valide_par_admin_id)
        REFERENCES utilisateur(id)
);

-- ---------- COACH ----------

CREATE TABLE coach (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    prenom VARCHAR(100) NOT NULL,
    specialite VARCHAR(100),
    telephone VARCHAR(20),
    email VARCHAR(255),
    formations TEXT,
    certifications TEXT,
    date_embauche DATE NOT NULL
);

-- ---------- SALLE ----------

CREATE TABLE salle (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    capacite INTEGER NOT NULL CHECK (capacite > 0),
    localisation VARCHAR(255),
    equipements TEXT
);

-- ---------- COURS ----------

CREATE TABLE cours (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    description TEXT,
    duree_min INTEGER NOT NULL CHECK (duree_min > 0),
    intensite intensite_enum NOT NULL,
    niveau_difficulte niveau_difficulte_enum NOT NULL,
    capacite_max INTEGER NOT NULL CHECK (capacite_max > 0),
    horaire TIMESTAMP NOT NULL,
    coach_id INTEGER NOT NULL,
    salle_id INTEGER NOT NULL,

    CONSTRAINT fk_cours_coach
        FOREIGN KEY (coach_id)
        REFERENCES coach(id),

    CONSTRAINT fk_cours_salle
        FOREIGN KEY (salle_id)
        REFERENCES salle(id)
);

-- ---------- INSCRIPTION COURS ----------

CREATE TABLE inscription_cours (
    id SERIAL PRIMARY KEY,
    membre_id INTEGER NOT NULL,
    cours_id INTEGER NOT NULL,
    date_inscription DATE NOT NULL DEFAULT CURRENT_DATE,
    statut statut_inscription_cours_enum NOT NULL DEFAULT 'reserve',
    annule_par_admin_id INTEGER,
    date_annulation DATE,

    CONSTRAINT fk_inscription_membre
        FOREIGN KEY (membre_id)
        REFERENCES membre(id),

    CONSTRAINT fk_inscription_cours
        FOREIGN KEY (cours_id)
        REFERENCES cours(id),

    CONSTRAINT fk_inscription_admin_annulation
        FOREIGN KEY (annule_par_admin_id)
        REFERENCES utilisateur(id),

    CONSTRAINT unique_inscription UNIQUE (membre_id, cours_id)
);

-- ---------- PAIEMENT ADHESION ----------

CREATE TABLE paiement_adhesion (
    id SERIAL PRIMARY KEY,
    membre_id INTEGER NOT NULL,
    montant DECIMAL(10,2) NOT NULL CHECK (montant > 0),
    date_paiement DATE NOT NULL DEFAULT CURRENT_DATE,
    methode VARCHAR(50) NOT NULL,
    statut statut_paiement_enum NOT NULL DEFAULT 'en_attente',

    CONSTRAINT fk_paiement_membre
        FOREIGN KEY (membre_id)
        REFERENCES membre(id)
);

-- ---------- STATISTIQUE / RAPPORT ----------

CREATE TABLE statistique_rapport (
    id SERIAL PRIMARY KEY,
    type_rapport VARCHAR(100) NOT NULL,
    periode_debut DATE NOT NULL,
    periode_fin DATE NOT NULL,
    genere_par INTEGER NOT NULL,
    date_generation TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    parametres_json TEXT,
    url_rapport VARCHAR(255),

    CONSTRAINT fk_rapport_admin
        FOREIGN KEY (genere_par)
        REFERENCES utilisateur(id)
);

-- ---------- ROLES / UTILISATEURS BDD ----------
-- Crée des rôles applicatifs distincts avec des privilèges différents.
-- ⚠️ Adaptez les mots de passe avant exécution.

-- Administrateur principal : droits complets sur le schéma public.
CREATE ROLE gym_admin_principal LOGIN PASSWORD 'AdminPrincipal123!';
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO gym_admin_principal;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO gym_admin_principal;

-- Administrateur secondaire : CRUD sur les tables, mais pas de droits sur les séquences globales.
CREATE ROLE gym_admin_secondaire LOGIN PASSWORD 'AdminSecondaire123!';
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO gym_admin_secondaire;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO gym_admin_secondaire;

-- Membre : lecture des référentiels + réservation limitée.
CREATE ROLE gym_membre LOGIN PASSWORD 'Membre123!';
GRANT SELECT ON cours, salle, coach TO gym_membre;
GRANT SELECT ON membre TO gym_membre; -- pour consultation de son compte (à restreindre si besoin)
GRANT SELECT, INSERT ON inscription_cours TO gym_membre;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO gym_membre;

-- =========================================
-- Fin du schéma
-- =========================================
