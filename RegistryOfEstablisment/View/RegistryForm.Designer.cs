
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(776, 333);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(694, 12);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(94, 29);
            this.filterButton.TabIndex = 1;
            this.filterButton.Text = "Фильтр";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // OpenESButton
            // 
            this.OpenESButton.Location = new System.Drawing.Point(648, 395);
            this.OpenESButton.Name = "OpenESButton";
            this.OpenESButton.Size = new System.Drawing.Size(140, 43);
            this.OpenESButton.TabIndex = 2;
            this.OpenESButton.Text = "Открыть";
            this.OpenESButton.UseVisualStyleBackColor = true;
            this.OpenESButton.Click += new System.EventHandler(this.openESButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(210, 394);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.addESButton_Click);
            // 
            // changeESButton
            // 
            this.changeESButton.Location = new System.Drawing.Point(356, 394);
            this.changeESButton.Name = "changeESButton";
            this.changeESButton.Size = new System.Drawing.Size(140, 43);
            this.changeESButton.TabIndex = 4;
            this.changeESButton.Text = "Изменить";
            this.changeESButton.UseVisualStyleBackColor = true;
            this.changeESButton.Click += new System.EventHandler(this.changeESButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(502, 394);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(140, 43);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Реестр организаций";
            // 
            // RegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 448);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.changeESButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.OpenESButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RegistryForm";
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
    }
}