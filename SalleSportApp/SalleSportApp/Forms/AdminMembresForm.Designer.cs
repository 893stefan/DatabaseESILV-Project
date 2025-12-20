namespace SalleSportApp.Forms
{
    partial class AdminMembresForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembres)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMembres
            // 
            this.dgvMembres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembres.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMembres.Location = new System.Drawing.Point(0, 0);
            this.dgvMembres.MultiSelect = false;
            this.dgvMembres.Name = "dgvMembres";
            this.dgvMembres.RowHeadersWidth = 51;
            this.dgvMembres.RowTemplate.Height = 24;
            this.dgvMembres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembres.Size = new System.Drawing.Size(800, 302);
            this.dgvMembres.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Revenir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(369, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ajouter";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(505, 349);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 48);
            this.button3.TabIndex = 3;
            this.button3.Text = "Modifier";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(641, 349);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 48);
            this.button4.TabIndex = 4;
            this.button4.Text = "Supprimer";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // AdminMembresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvMembres);
            this.Name = "AdminMembresForm";
            this.Text = "AdminMembresForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMembres;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}