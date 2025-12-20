namespace SalleSportApp.Forms
{
    partial class ReservationCoursForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnReserver;
        private System.Windows.Forms.DataGridView dgvCours;

        private void InitializeComponent()
        {
            this.btnReserver = new System.Windows.Forms.Button();
            this.dgvCours = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCours)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReserver
            // 
            this.btnReserver.Location = new System.Drawing.Point(623, 386);
            this.btnReserver.Name = "btnReserver";
            this.btnReserver.Size = new System.Drawing.Size(165, 52);
            this.btnReserver.TabIndex = 0;
            this.btnReserver.Text = "Réserver";
            this.btnReserver.Click += new System.EventHandler(this.btnReserver_Click);
            // 
            // dgvCours
            // 
            this.dgvCours.AllowUserToAddRows = false;
            this.dgvCours.AllowUserToDeleteRows = false;
            this.dgvCours.AllowUserToResizeColumns = false;
            this.dgvCours.AllowUserToResizeRows = false;
            this.dgvCours.ColumnHeadersHeight = 29;
            this.dgvCours.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCours.Location = new System.Drawing.Point(0, 0);
            this.dgvCours.MultiSelect = false;
            this.dgvCours.Name = "dgvCours";
            this.dgvCours.ReadOnly = true;
            this.dgvCours.RowHeadersWidth = 51;
            this.dgvCours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCours.Size = new System.Drawing.Size(800, 352);
            this.dgvCours.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "Revenir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReservationCoursForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReserver);
            this.Controls.Add(this.dgvCours);
            this.Name = "ReservationCoursForm";
            this.Text = "Réserver un cours";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCours)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button button1;
    }
}
