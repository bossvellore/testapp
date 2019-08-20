namespace WallInfo
{
    partial class WallsForm
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
            this.wallsGridView = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wallDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wallsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // wallsGridView
            // 
            this.wallsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wallsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.count,
            this.area});
            this.wallsGridView.Location = new System.Drawing.Point(12, 12);
            this.wallsGridView.Name = "wallsGridView";
            this.wallsGridView.Size = new System.Drawing.Size(412, 426);
            this.wallsGridView.TabIndex = 0;
            this.wallsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.wallsGridView_CellContentClick);
            // 
            // type
            // 
            this.type.DataPropertyName = "Type";
            this.type.HeaderText = "Wall Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "Count";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // area
            // 
            this.area.DataPropertyName = "area";
            this.area.HeaderText = "Area";
            this.area.Name = "area";
            this.area.ReadOnly = true;
            // 
            // wallDataBindingSource
            // 
            this.wallDataBindingSource.DataSource = typeof(WallInfo.WallData);
            this.wallDataBindingSource.CurrentChanged += new System.EventHandler(this.wallDataBindingSource_CurrentChanged);
            // 
            // WallsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 450);
            this.Controls.Add(this.wallsGridView);
            this.Name = "WallsForm";
            this.Text = "Walls";
            this.Load += new System.EventHandler(this.WallsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wallsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView wallsGridView;
        private System.Windows.Forms.BindingSource wallDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
    }
}