namespace DDD.WinForm.Views
{
    partial class WeatherListView
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
            this.WeathersDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.WeathersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WeathersDataGrid
            // 
            this.WeathersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeathersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeathersDataGrid.Location = new System.Drawing.Point(0, 0);
            this.WeathersDataGrid.Name = "WeathersDataGrid";
            this.WeathersDataGrid.RowHeadersWidth = 72;
            this.WeathersDataGrid.RowTemplate.Height = 30;
            this.WeathersDataGrid.Size = new System.Drawing.Size(1300, 587);
            this.WeathersDataGrid.TabIndex = 0;
            this.WeathersDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // WeatherListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 587);
            this.Controls.Add(this.WeathersDataGrid);
            this.Name = "WeatherListView";
            this.Text = "WeatherListView";
            ((System.ComponentModel.ISupportInitialize)(this.WeathersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WeathersDataGrid;
    }
}