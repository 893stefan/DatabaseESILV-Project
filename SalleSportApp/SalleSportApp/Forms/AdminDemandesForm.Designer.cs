namespace SalleSportApp.Forms
{
    partial class AdminDemandesForm
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
            this.dgvMembres = new System.Windows.Forms.DataGridView();
            this.btnValider = new System.Windows.Forms.Button();
            this.btn_revenir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembres)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMembres
            // 
            this.dgvMembres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembres.Location = new System.Drawing.Point(12, 12);
            this.dgvMembres.Name = "dgvMembres";
            this.dgvMembres.RowHeadersWidth = 51;
            this.dgvMembres.RowTemplate.Height = 24;
            this.dgvMembres.Size = new System.Drawing.Size(776, 274);
            this.dgvMembres.TabIndex = 1;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(611, 353);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(130, 45);
            this.btnValider.TabIndex = 2;
            this.btnValider.Text = "Valider l\'adhésion";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btn_revenir
            // 
            this.btn_revenir.Location = new System.Drawing.Point(34, 353);
            this.btn_revenir.Name = "btn_revenir";
            this.btn_revenir.Size = new System.Drawing.Size(130, 45);
            this.btn_revenir.TabIndex = 3;
            this.btn_revenir.Text = "Revenir";
            this.btn_revenir.UseVisualStyleBackColor = true;
            this.btn_revenir.Click += new System.EventHandler(this.btn_revenir_Click);
            // 
            // AdminDemandesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_revenir);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.dgvMembres);
            this.Name = "AdminDemandesForm";
            this.Text = "AdminDemandesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMembres;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btn_revenir;
    }
}