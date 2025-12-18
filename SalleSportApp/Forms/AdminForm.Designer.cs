namespace SalleSportApp.Forms
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblAdminHeader = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabMembres = new System.Windows.Forms.TabPage();
            this.btnValiderMembre = new System.Windows.Forms.Button();
            this.btnRefreshMembres = new System.Windows.Forms.Button();
            this.dgvMembres = new System.Windows.Forms.DataGridView();
            this.tabCours = new System.Windows.Forms.TabPage();
            this.btnSupprimerCours = new System.Windows.Forms.Button();
            this.btnAjouterCours = new System.Windows.Forms.Button();
            this.dgvCours = new System.Windows.Forms.DataGridView();
            this.tabCoachs = new System.Windows.Forms.TabPage();
            this.btnSupprimerCoach = new System.Windows.Forms.Button();
            this.btnAjouterCoach = new System.Windows.Forms.Button();
            this.dgvCoachs = new System.Windows.Forms.DataGridView();
            this.tabRapports = new System.Windows.Forms.TabPage();
            this.btnGenererRapport = new System.Windows.Forms.Button();
            this.lstRapports = new System.Windows.Forms.ListBox();
            this.tabAdmin.SuspendLayout();
            this.tabMembres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembres)).BeginInit();
            this.tabCours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCours)).BeginInit();
            this.tabCoachs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoachs)).BeginInit();
            this.tabRapports.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAdminHeader
            // 
            this.lblAdminHeader.AutoSize = true;
            this.lblAdminHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminHeader.Location = new System.Drawing.Point(12, 9);
            this.lblAdminHeader.Name = "lblAdminHeader";
            this.lblAdminHeader.Size = new System.Drawing.Size(208, 20);
            this.lblAdminHeader.TabIndex = 0;
            this.lblAdminHeader.Text = "Espace Administrateur";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(697, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(91, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Déconnexion";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabAdmin.Controls.Add(this.tabMembres);
            this.tabAdmin.Controls.Add(this.tabCours);
            this.tabAdmin.Controls.Add(this.tabCoachs);
            this.tabAdmin.Controls.Add(this.tabRapports);
            this.tabAdmin.Location = new System.Drawing.Point(12, 38);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(776, 400);
            this.tabAdmin.TabIndex = 2;
            // 
            // tabMembres
            // 
            this.tabMembres.Controls.Add(this.btnValiderMembre);
            this.tabMembres.Controls.Add(this.btnRefreshMembres);
            this.tabMembres.Controls.Add(this.dgvMembres);
            this.tabMembres.Location = new System.Drawing.Point(4, 22);
            this.tabMembres.Name = "tabMembres";
            this.tabMembres.Padding = new System.Windows.Forms.Padding(3);
            this.tabMembres.Size = new System.Drawing.Size(768, 374);
            this.tabMembres.TabIndex = 0;
            this.tabMembres.Text = "Membres";
            this.tabMembres.UseVisualStyleBackColor = true;
            // 
            // btnValiderMembre
            // 
            this.btnValiderMembre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValiderMembre.Location = new System.Drawing.Point(625, 6);
            this.btnValiderMembre.Name = "btnValiderMembre";
            this.btnValiderMembre.Size = new System.Drawing.Size(137, 23);
            this.btnValiderMembre.TabIndex = 2;
            this.btnValiderMembre.Text = "Valider adhésion";
            this.btnValiderMembre.UseVisualStyleBackColor = true;
            this.btnValiderMembre.Click += new System.EventHandler(this.btnValiderMembre_Click);
            // 
            // btnRefreshMembres
            // 
            this.btnRefreshMembres.Location = new System.Drawing.Point(6, 6);
            this.btnRefreshMembres.Name = "btnRefreshMembres";
            this.btnRefreshMembres.Size = new System.Drawing.Size(127, 23);
            this.btnRefreshMembres.TabIndex = 1;
            this.btnRefreshMembres.Text = "Rafraîchir";
            this.btnRefreshMembres.UseVisualStyleBackColor = true;
            this.btnRefreshMembres.Click += new System.EventHandler(this.btnRefreshMembres_Click);
            // 
            // dgvMembres
            // 
            this.dgvMembres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembres.Location = new System.Drawing.Point(6, 35);
            this.dgvMembres.Name = "dgvMembres";
            this.dgvMembres.Size = new System.Drawing.Size(756, 333);
            this.dgvMembres.TabIndex = 0;
            // 
            // tabCours
            // 
            this.tabCours.Controls.Add(this.btnSupprimerCours);
            this.tabCours.Controls.Add(this.btnAjouterCours);
            this.tabCours.Controls.Add(this.dgvCours);
            this.tabCours.Location = new System.Drawing.Point(4, 22);
            this.tabCours.Name = "tabCours";
            this.tabCours.Padding = new System.Windows.Forms.Padding(3);
            this.tabCours.Size = new System.Drawing.Size(768, 374);
            this.tabCours.TabIndex = 1;
            this.tabCours.Text = "Cours";
            this.tabCours.UseVisualStyleBackColor = true;
            // 
            // btnSupprimerCours
            // 
            this.btnSupprimerCours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimerCours.Location = new System.Drawing.Point(625, 6);
            this.btnSupprimerCours.Name = "btnSupprimerCours";
            this.btnSupprimerCours.Size = new System.Drawing.Size(137, 23);
            this.btnSupprimerCours.TabIndex = 2;
            this.btnSupprimerCours.Text = "Supprimer cours";
            this.btnSupprimerCours.UseVisualStyleBackColor = true;
            this.btnSupprimerCours.Click += new System.EventHandler(this.btnSupprimerCours_Click);
            // 
            // btnAjouterCours
            // 
            this.btnAjouterCours.Location = new System.Drawing.Point(6, 6);
            this.btnAjouterCours.Name = "btnAjouterCours";
            this.btnAjouterCours.Size = new System.Drawing.Size(127, 23);
            this.btnAjouterCours.TabIndex = 1;
            this.btnAjouterCours.Text = "Ajouter cours";
            this.btnAjouterCours.UseVisualStyleBackColor = true;
            this.btnAjouterCours.Click += new System.EventHandler(this.btnAjouterCours_Click);
            // 
            // dgvCours
            // 
            this.dgvCours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCours.Location = new System.Drawing.Point(6, 35);
            this.dgvCours.Name = "dgvCours";
            this.dgvCours.Size = new System.Drawing.Size(756, 333);
            this.dgvCours.TabIndex = 0;
            // 
            // tabCoachs
            // 
            this.tabCoachs.Controls.Add(this.btnSupprimerCoach);
            this.tabCoachs.Controls.Add(this.btnAjouterCoach);
            this.tabCoachs.Controls.Add(this.dgvCoachs);
            this.tabCoachs.Location = new System.Drawing.Point(4, 22);
            this.tabCoachs.Name = "tabCoachs";
            this.tabCoachs.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoachs.Size = new System.Drawing.Size(768, 374);
            this.tabCoachs.TabIndex = 2;
            this.tabCoachs.Text = "Coachs";
            this.tabCoachs.UseVisualStyleBackColor = true;
            // 
            // btnSupprimerCoach
            // 
            this.btnSupprimerCoach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimerCoach.Location = new System.Drawing.Point(625, 6);
            this.btnSupprimerCoach.Name = "btnSupprimerCoach";
            this.btnSupprimerCoach.Size = new System.Drawing.Size(137, 23);
            this.btnSupprimerCoach.TabIndex = 2;
            this.btnSupprimerCoach.Text = "Supprimer coach";
            this.btnSupprimerCoach.UseVisualStyleBackColor = true;
            this.btnSupprimerCoach.Click += new System.EventHandler(this.btnSupprimerCoach_Click);
            // 
            // btnAjouterCoach
            // 
            this.btnAjouterCoach.Location = new System.Drawing.Point(6, 6);
            this.btnAjouterCoach.Name = "btnAjouterCoach";
            this.btnAjouterCoach.Size = new System.Drawing.Size(127, 23);
            this.btnAjouterCoach.TabIndex = 1;
            this.btnAjouterCoach.Text = "Ajouter coach";
            this.btnAjouterCoach.UseVisualStyleBackColor = true;
            this.btnAjouterCoach.Click += new System.EventHandler(this.btnAjouterCoach_Click);
            // 
            // dgvCoachs
            // 
            this.dgvCoachs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCoachs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoachs.Location = new System.Drawing.Point(6, 35);
            this.dgvCoachs.Name = "dgvCoachs";
            this.dgvCoachs.Size = new System.Drawing.Size(756, 333);
            this.dgvCoachs.TabIndex = 0;
            // 
            // tabRapports
            // 
            this.tabRapports.Controls.Add(this.btnGenererRapport);
            this.tabRapports.Controls.Add(this.lstRapports);
            this.tabRapports.Location = new System.Drawing.Point(4, 22);
            this.tabRapports.Name = "tabRapports";
            this.tabRapports.Padding = new System.Windows.Forms.Padding(3);
            this.tabRapports.Size = new System.Drawing.Size(768, 374);
            this.tabRapports.TabIndex = 3;
            this.tabRapports.Text = "Rapports";
            this.tabRapports.UseVisualStyleBackColor = true;
            // 
            // btnGenererRapport
            // 
            this.btnGenererRapport.Location = new System.Drawing.Point(6, 6);
            this.btnGenererRapport.Name = "btnGenererRapport";
            this.btnGenererRapport.Size = new System.Drawing.Size(127, 23);
            this.btnGenererRapport.TabIndex = 1;
            this.btnGenererRapport.Text = "Générer rapport";
            this.btnGenererRapport.UseVisualStyleBackColor = true;
            this.btnGenererRapport.Click += new System.EventHandler(this.btnGenererRapport_Click);
            // 
            // lstRapports
            // 
            this.lstRapports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRapports.FormattingEnabled = true;
            this.lstRapports.Location = new System.Drawing.Point(6, 35);
            this.lstRapports.Name = "lstRapports";
            this.lstRapports.Size = new System.Drawing.Size(756, 329);
            this.lstRapports.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblAdminHeader);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "AdminForm";
            this.Text = "Administration";
            this.tabAdmin.ResumeLayout(false);
            this.tabMembres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembres)).EndInit();
            this.tabCours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCours)).EndInit();
            this.tabCoachs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoachs)).EndInit();
            this.tabRapports.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAdminHeader;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabMembres;
        private System.Windows.Forms.DataGridView dgvMembres;
        private System.Windows.Forms.Button btnValiderMembre;
        private System.Windows.Forms.Button btnRefreshMembres;
        private System.Windows.Forms.TabPage tabCours;
        private System.Windows.Forms.Button btnSupprimerCours;
        private System.Windows.Forms.Button btnAjouterCours;
        private System.Windows.Forms.DataGridView dgvCours;
        private System.Windows.Forms.TabPage tabCoachs;
        private System.Windows.Forms.Button btnSupprimerCoach;
        private System.Windows.Forms.Button btnAjouterCoach;
        private System.Windows.Forms.DataGridView dgvCoachs;
        private System.Windows.Forms.TabPage tabRapports;
        private System.Windows.Forms.Button btnGenererRapport;
        private System.Windows.Forms.ListBox lstRapports;
    }
}
