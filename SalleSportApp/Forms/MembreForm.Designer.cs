namespace SalleSportApp.Forms
{
    partial class MembreForm
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
            this.lblMembreHeader = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabMembre = new System.Windows.Forms.TabControl();
            this.tabCours = new System.Windows.Forms.TabPage();
            this.btnReserver = new System.Windows.Forms.Button();
            this.btnRefreshCours = new System.Windows.Forms.Button();
            this.dgvCours = new System.Windows.Forms.DataGridView();
            this.tabReservations = new System.Windows.Forms.TabPage();
            this.btnAnnulerReservation = new System.Windows.Forms.Button();
            this.btnRefreshReservations = new System.Windows.Forms.Button();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.tabProfil = new System.Windows.Forms.TabPage();
            this.lblProfilInfo = new System.Windows.Forms.Label();
            this.tabMembre.SuspendLayout();
            this.tabCours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCours)).BeginInit();
            this.tabReservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.tabProfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMembreHeader
            // 
            this.lblMembreHeader.AutoSize = true;
            this.lblMembreHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembreHeader.Location = new System.Drawing.Point(12, 9);
            this.lblMembreHeader.Name = "lblMembreHeader";
            this.lblMembreHeader.Size = new System.Drawing.Size(129, 20);
            this.lblMembreHeader.TabIndex = 0;
            this.lblMembreHeader.Text = "Espace Membre";
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
            // tabMembre
            // 
            this.tabMembre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMembre.Controls.Add(this.tabCours);
            this.tabMembre.Controls.Add(this.tabReservations);
            this.tabMembre.Controls.Add(this.tabProfil);
            this.tabMembre.Location = new System.Drawing.Point(12, 38);
            this.tabMembre.Name = "tabMembre";
            this.tabMembre.SelectedIndex = 0;
            this.tabMembre.Size = new System.Drawing.Size(776, 400);
            this.tabMembre.TabIndex = 2;
            // 
            // tabCours
            // 
            this.tabCours.Controls.Add(this.btnReserver);
            this.tabCours.Controls.Add(this.btnRefreshCours);
            this.tabCours.Controls.Add(this.dgvCours);
            this.tabCours.Location = new System.Drawing.Point(4, 22);
            this.tabCours.Name = "tabCours";
            this.tabCours.Padding = new System.Windows.Forms.Padding(3);
            this.tabCours.Size = new System.Drawing.Size(768, 374);
            this.tabCours.TabIndex = 0;
            this.tabCours.Text = "Cours";
            this.tabCours.UseVisualStyleBackColor = true;
            // 
            // btnReserver
            // 
            this.btnReserver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReserver.Location = new System.Drawing.Point(625, 6);
            this.btnReserver.Name = "btnReserver";
            this.btnReserver.Size = new System.Drawing.Size(137, 23);
            this.btnReserver.TabIndex = 2;
            this.btnReserver.Text = "Réserver";
            this.btnReserver.UseVisualStyleBackColor = true;
            this.btnReserver.Click += new System.EventHandler(this.btnReserver_Click);
            // 
            // btnRefreshCours
            // 
            this.btnRefreshCours.Location = new System.Drawing.Point(6, 6);
            this.btnRefreshCours.Name = "btnRefreshCours";
            this.btnRefreshCours.Size = new System.Drawing.Size(127, 23);
            this.btnRefreshCours.TabIndex = 1;
            this.btnRefreshCours.Text = "Rafraîchir";
            this.btnRefreshCours.UseVisualStyleBackColor = true;
            this.btnRefreshCours.Click += new System.EventHandler(this.btnRefreshCours_Click);
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
            // tabReservations
            // 
            this.tabReservations.Controls.Add(this.btnAnnulerReservation);
            this.tabReservations.Controls.Add(this.btnRefreshReservations);
            this.tabReservations.Controls.Add(this.dgvReservations);
            this.tabReservations.Location = new System.Drawing.Point(4, 22);
            this.tabReservations.Name = "tabReservations";
            this.tabReservations.Padding = new System.Windows.Forms.Padding(3);
            this.tabReservations.Size = new System.Drawing.Size(768, 374);
            this.tabReservations.TabIndex = 1;
            this.tabReservations.Text = "Réservations";
            this.tabReservations.UseVisualStyleBackColor = true;
            // 
            // btnAnnulerReservation
            // 
            this.btnAnnulerReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulerReservation.Location = new System.Drawing.Point(625, 6);
            this.btnAnnulerReservation.Name = "btnAnnulerReservation";
            this.btnAnnulerReservation.Size = new System.Drawing.Size(137, 23);
            this.btnAnnulerReservation.TabIndex = 2;
            this.btnAnnulerReservation.Text = "Annuler";
            this.btnAnnulerReservation.UseVisualStyleBackColor = true;
            this.btnAnnulerReservation.Click += new System.EventHandler(this.btnAnnulerReservation_Click);
            // 
            // btnRefreshReservations
            // 
            this.btnRefreshReservations.Location = new System.Drawing.Point(6, 6);
            this.btnRefreshReservations.Name = "btnRefreshReservations";
            this.btnRefreshReservations.Size = new System.Drawing.Size(127, 23);
            this.btnRefreshReservations.TabIndex = 1;
            this.btnRefreshReservations.Text = "Rafraîchir";
            this.btnRefreshReservations.UseVisualStyleBackColor = true;
            this.btnRefreshReservations.Click += new System.EventHandler(this.btnRefreshReservations_Click);
            // 
            // dgvReservations
            // 
            this.dgvReservations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Location = new System.Drawing.Point(6, 35);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.Size = new System.Drawing.Size(756, 333);
            this.dgvReservations.TabIndex = 0;
            // 
            // tabProfil
            // 
            this.tabProfil.Controls.Add(this.lblProfilInfo);
            this.tabProfil.Location = new System.Drawing.Point(4, 22);
            this.tabProfil.Name = "tabProfil";
            this.tabProfil.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfil.Size = new System.Drawing.Size(768, 374);
            this.tabProfil.TabIndex = 2;
            this.tabProfil.Text = "Profil";
            this.tabProfil.UseVisualStyleBackColor = true;
            // 
            // lblProfilInfo
            // 
            this.lblProfilInfo.AutoSize = true;
            this.lblProfilInfo.Location = new System.Drawing.Point(6, 9);
            this.lblProfilInfo.Name = "lblProfilInfo";
            this.lblProfilInfo.Size = new System.Drawing.Size(175, 13);
            this.lblProfilInfo.TabIndex = 0;
            this.lblProfilInfo.Text = "Informations du profil indisponibles.";
            // 
            // MembreForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabMembre);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblMembreHeader);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MembreForm";
            this.Text = "Espace Membre";
            this.tabMembre.ResumeLayout(false);
            this.tabCours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCours)).EndInit();
            this.tabReservations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.tabProfil.ResumeLayout(false);
            this.tabProfil.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMembreHeader;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabMembre;
        private System.Windows.Forms.TabPage tabCours;
        private System.Windows.Forms.Button btnReserver;
        private System.Windows.Forms.Button btnRefreshCours;
        private System.Windows.Forms.DataGridView dgvCours;
        private System.Windows.Forms.TabPage tabReservations;
        private System.Windows.Forms.Button btnAnnulerReservation;
        private System.Windows.Forms.Button btnRefreshReservations;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.TabPage tabProfil;
        private System.Windows.Forms.Label lblProfilInfo;
    }
}
