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
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInfos = new System.Windows.Forms.Panel();
            this.lblMessageStatut = new System.Windows.Forms.Label();
            this.btnDeconnexion = new System.Windows.Forms.Button();
            this.btnMesReservations = new System.Windows.Forms.Button();
            this.btnReserverCours = new System.Windows.Forms.Button();
            this.BtnMesInfos = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.btnInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Espace Membre – Salle de Sport";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.LightGray;
            this.panelHeader.Controls.Add(this.label3);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(882, 100);
            this.panelHeader.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(30, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Statut : En attente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenue Prénom Nom";
            // 
            // btnInfos
            // 
            this.btnInfos.Controls.Add(this.lblMessageStatut);
            this.btnInfos.Controls.Add(this.btnDeconnexion);
            this.btnInfos.Controls.Add(this.btnMesReservations);
            this.btnInfos.Controls.Add(this.btnReserverCours);
            this.btnInfos.Controls.Add(this.BtnMesInfos);
            this.btnInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInfos.Location = new System.Drawing.Point(0, 100);
            this.btnInfos.Name = "btnInfos";
            this.btnInfos.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnInfos.Size = new System.Drawing.Size(882, 453);
            this.btnInfos.TabIndex = 4;
            // 
            // lblMessageStatut
            // 
            this.lblMessageStatut.AutoSize = true;
            this.lblMessageStatut.ForeColor = System.Drawing.Color.Red;
            this.lblMessageStatut.Location = new System.Drawing.Point(50, 320);
            this.lblMessageStatut.Name = "lblMessageStatut";
            this.lblMessageStatut.Size = new System.Drawing.Size(0, 16);
            this.lblMessageStatut.TabIndex = 4;
            // 
            // btnDeconnexion
            // 
            this.btnDeconnexion.Location = new System.Drawing.Point(300, 180);
            this.btnDeconnexion.Name = "btnDeconnexion";
            this.btnDeconnexion.Size = new System.Drawing.Size(180, 80);
            this.btnDeconnexion.TabIndex = 3;
            this.btnDeconnexion.Text = "🚪 Déconnexion";
            this.btnDeconnexion.UseVisualStyleBackColor = true;
            this.btnDeconnexion.Click += new System.EventHandler(this.btnDeconnexion_Click);
            // 
            // btnMesReservations
            // 
            this.btnMesReservations.Location = new System.Drawing.Point(50, 180);
            this.btnMesReservations.Name = "btnMesReservations";
            this.btnMesReservations.Size = new System.Drawing.Size(180, 80);
            this.btnMesReservations.TabIndex = 2;
            this.btnMesReservations.Text = "🕒 Mes réservations";
            this.btnMesReservations.UseVisualStyleBackColor = true;
            this.btnMesReservations.Click += new System.EventHandler(this.btnMesReservations_Click);
            // 
            // btnReserverCours
            // 
            this.btnReserverCours.Location = new System.Drawing.Point(300, 50);
            this.btnReserverCours.Name = "btnReserverCours";
            this.btnReserverCours.Size = new System.Drawing.Size(180, 80);
            this.btnReserverCours.TabIndex = 1;
            this.btnReserverCours.Text = "📅 Réserver un cours";
            this.btnReserverCours.UseVisualStyleBackColor = true;
            this.btnReserverCours.Click += new System.EventHandler(this.btnReserverCours_Click);
            // 
            // BtnMesInfos
            // 
            this.BtnMesInfos.Location = new System.Drawing.Point(50, 50);
            this.BtnMesInfos.Name = "BtnMesInfos";
            this.BtnMesInfos.Size = new System.Drawing.Size(180, 80);
            this.BtnMesInfos.TabIndex = 0;
            this.BtnMesInfos.Text = "👤 Mes informations";
            this.BtnMesInfos.UseVisualStyleBackColor = true;
            this.BtnMesInfos.Click += new System.EventHandler(this.btnInfos_Click);
            // 
            // MembreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.btnInfos);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.label2);
            this.Name = "MembreForm";
            this.Text = "Form1";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.btnInfos.ResumeLayout(false);
            this.btnInfos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel btnInfos;
        private System.Windows.Forms.Button btnDeconnexion;
        private System.Windows.Forms.Button btnMesReservations;
        private System.Windows.Forms.Button btnReserverCours;
        private System.Windows.Forms.Button BtnMesInfos;
        private System.Windows.Forms.Label lblMessageStatut;
    }
}