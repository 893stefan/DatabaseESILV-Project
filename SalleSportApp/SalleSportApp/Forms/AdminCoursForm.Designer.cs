namespace SalleSportApp.Forms
{
    partial class AdminCoursForm
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
            this.dgvCours = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtCapacite = new System.Windows.Forms.TextBox();
            this.txtHoraire = new System.Windows.Forms.TextBox();
            this.txtCoachId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCours)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCours
            // 
            this.dgvCours.AllowUserToAddRows = false;
            this.dgvCours.AllowUserToDeleteRows = false;
            this.dgvCours.AllowUserToOrderColumns = true;
            this.dgvCours.AllowUserToResizeColumns = false;
            this.dgvCours.AllowUserToResizeRows = false;
            this.dgvCours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCours.Location = new System.Drawing.Point(0, 0);
            this.dgvCours.MultiSelect = false;
            this.dgvCours.Name = "dgvCours";
            this.dgvCours.ReadOnly = true;
            this.dgvCours.RowHeadersWidth = 51;
            this.dgvCours.RowTemplate.Height = 24;
            this.dgvCours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCours.Size = new System.Drawing.Size(523, 358);
            this.dgvCours.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(637, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(539, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 58);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modifier";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(537, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 58);
            this.button3.TabIndex = 3;
            this.button3.Text = "Supprimer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 364);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 74);
            this.button4.TabIndex = 4;
            this.button4.Text = "Revenir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(623, 74);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 22);
            this.txtNom.TabIndex = 19;
            // 
            // txtCapacite
            // 
            this.txtCapacite.Location = new System.Drawing.Point(623, 102);
            this.txtCapacite.Name = "txtCapacite";
            this.txtCapacite.Size = new System.Drawing.Size(100, 22);
            this.txtCapacite.TabIndex = 18;
            // 
            // txtHoraire
            // 
            this.txtHoraire.Location = new System.Drawing.Point(623, 130);
            this.txtHoraire.Name = "txtHoraire";
            this.txtHoraire.Size = new System.Drawing.Size(100, 22);
            this.txtHoraire.TabIndex = 17;
            // 
            // txtCoachId
            // 
            this.txtCoachId.Location = new System.Drawing.Point(623, 161);
            this.txtCoachId.Name = "txtCoachId";
            this.txtCoachId.Size = new System.Drawing.Size(100, 22);
            this.txtCoachId.TabIndex = 16;
            this.txtCoachId.TextChanged += new System.EventHandler(this.txtCoachId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nom";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Capacite";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Horaire";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Coach Id";
            // 
            // AdminCoursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtCapacite);
            this.Controls.Add(this.txtHoraire);
            this.Controls.Add(this.txtCoachId);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvCours);
            this.Name = "AdminCoursForm";
            this.Text = "AdminCoursForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCours;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtCapacite;
        private System.Windows.Forms.TextBox txtHoraire;
        private System.Windows.Forms.TextBox txtCoachId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}