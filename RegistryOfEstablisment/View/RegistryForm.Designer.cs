
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 42);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(952, 250);
            this.dataGridView1.TabIndex = 0;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(880, 11);
            this.filterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(82, 22);
            this.filterButton.TabIndex = 1;
            this.filterButton.Text = "Фильтр";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // OpenESButton
            // 
            this.OpenESButton.Location = new System.Drawing.Point(840, 295);
            this.OpenESButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenESButton.Name = "OpenESButton";
            this.OpenESButton.Size = new System.Drawing.Size(122, 32);
            this.OpenESButton.TabIndex = 2;
            this.OpenESButton.Text = "Открыть";
            this.OpenESButton.UseVisualStyleBackColor = true;
            this.OpenESButton.Click += new System.EventHandler(this.OpenESButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(457, 295);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.addESButton_Click);
            // 
            // changeESButton
            // 
            this.changeESButton.Location = new System.Drawing.Point(585, 295);
            this.changeESButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changeESButton.Name = "changeESButton";
            this.changeESButton.Size = new System.Drawing.Size(122, 32);
            this.changeESButton.TabIndex = 4;
            this.changeESButton.Text = "Изменить";
            this.changeESButton.UseVisualStyleBackColor = true;
            this.changeESButton.Click += new System.EventHandler(this.changeESButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(712, 295);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(122, 32);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Реестр организаций";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество отображаемых записей:";
            // 
            // paginationBox
            // 
            this.paginationBox.FormattingEnabled = true;
            this.paginationBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.paginationBox.Location = new System.Drawing.Point(359, 300);
            this.paginationBox.Name = "paginationBox";
            this.paginationBox.Size = new System.Drawing.Size(92, 23);
            this.paginationBox.TabIndex = 8;
            this.paginationBox.SelectedIndexChanged += new System.EventHandler(this.paginationBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Страница:";
            // 
            // pageBox
            // 
            this.pageBox.FormattingEnabled = true;
            this.pageBox.Location = new System.Drawing.Point(73, 301);
            this.pageBox.Name = "pageBox";
            this.pageBox.Size = new System.Drawing.Size(70, 23);
            this.pageBox.TabIndex = 10;
            // 
            // RegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 336);
            this.Controls.Add(this.pageBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.paginationBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.changeESButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.OpenESButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegistryForm";
            this.Text = "Реестр";
            this.Load += new System.EventHandler(this.RegistryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}