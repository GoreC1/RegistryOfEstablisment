
namespace RegistryOfEstablisment.View
{
    partial class RegistryForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filterButton = new System.Windows.Forms.Button();
            this.OpenESButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.changeESButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paginationBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pageBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ExportButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(974, 250);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // filterButton
            // 
            this.filterButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.filterButton.Location = new System.Drawing.Point(892, 0);
            this.filterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(82, 37);
            this.filterButton.TabIndex = 1;
            this.filterButton.Text = "Фильтр";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // OpenESButton
            // 
            this.OpenESButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.OpenESButton.Location = new System.Drawing.Point(486, 0);
            this.OpenESButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenESButton.Name = "OpenESButton";
            this.OpenESButton.Size = new System.Drawing.Size(122, 49);
            this.OpenESButton.TabIndex = 2;
            this.OpenESButton.Text = "Открыть";
            this.OpenESButton.UseVisualStyleBackColor = true;
            this.OpenESButton.Click += new System.EventHandler(this.OpenESButton_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Location = new System.Drawing.Point(852, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 49);
            this.button3.TabIndex = 3;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.AddESButton_Click);
            // 
            // changeESButton
            // 
            this.changeESButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.changeESButton.Location = new System.Drawing.Point(730, 0);
            this.changeESButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changeESButton.Name = "changeESButton";
            this.changeESButton.Size = new System.Drawing.Size(122, 49);
            this.changeESButton.TabIndex = 4;
            this.changeESButton.Text = "Изменить";
            this.changeESButton.UseVisualStyleBackColor = true;
            this.changeESButton.Click += new System.EventHandler(this.ChangeESButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteButton.Location = new System.Drawing.Point(608, 0);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(122, 49);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(15);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Реестр организаций";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(209, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество отображаемых записей:";
            // 
            // paginationBox
            // 
            this.paginationBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.paginationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paginationBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.paginationBox.FormattingEnabled = true;
            this.paginationBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.paginationBox.Location = new System.Drawing.Point(209, 0);
            this.paginationBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.paginationBox.Name = "paginationBox";
            this.paginationBox.Size = new System.Drawing.Size(92, 23);
            this.paginationBox.TabIndex = 8;
            this.paginationBox.SelectionChangeCommitted += new System.EventHandler(this.paginationBox_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(301, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Страница:";
            // 
            // pageBox
            // 
            this.pageBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pageBox.FormattingEnabled = true;
            this.pageBox.Location = new System.Drawing.Point(364, 0);
            this.pageBox.Name = "pageBox";
            this.pageBox.Size = new System.Drawing.Size(70, 23);
            this.pageBox.TabIndex = 10;
            this.pageBox.SelectionChangeCommitted += new System.EventHandler(this.PageBox_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OpenESButton);
            this.panel1.Controls.Add(this.pageBox);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.changeESButton);
            this.panel1.Controls.Add(this.paginationBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 49);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ExportButton);
            this.panel2.Controls.Add(this.filterButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 37);
            this.panel2.TabIndex = 12;
            // 
            // ExportButton
            // 
            this.ExportButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExportButton.Location = new System.Drawing.Point(817, 0);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 37);
            this.ExportButton.TabIndex = 7;
            this.ExportButton.Text = "Экспорт";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(974, 250);
            this.panel3.TabIndex = 13;
            // 
            // RegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(974, 336);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegistryForm";
            this.Text = "Реестр";
            this.Load += new System.EventHandler(this.RegistryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button OpenESButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button changeESButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox paginationBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox pageBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ExportButton;
    }
}