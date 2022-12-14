
namespace RegistryOfEstablisment.View
{
    partial class FilterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ITNBox = new System.Windows.Forms.TextBox();
            this.checkpointBox = new System.Windows.Forms.TextBox();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.legalEntityBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.realAddressBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "ИНН";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "КПП";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Адрес регистрации";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Тип организации";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "ИП/Юр.Лицо";
            // 
            // ITNBox
            // 
            this.ITNBox.Location = new System.Drawing.Point(151, 48);
            this.ITNBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ITNBox.Name = "ITNBox";
            this.ITNBox.Size = new System.Drawing.Size(290, 23);
            this.ITNBox.TabIndex = 7;
            this.ITNBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ITNBox_KeyPress);
            // 
            // checkpointBox
            // 
            this.checkpointBox.Location = new System.Drawing.Point(151, 81);
            this.checkpointBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkpointBox.Name = "checkpointBox";
            this.checkpointBox.Size = new System.Drawing.Size(290, 23);
            this.checkpointBox.TabIndex = 8;
            this.checkpointBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkpointBox_KeyPress);
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(151, 111);
            this.addressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(290, 23);
            this.addressBox.TabIndex = 9;
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(151, 170);
            this.typeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(290, 23);
            this.typeBox.TabIndex = 10;
            // 
            // legalEntityBox
            // 
            this.legalEntityBox.Location = new System.Drawing.Point(151, 199);
            this.legalEntityBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.legalEntityBox.Name = "legalEntityBox";
            this.legalEntityBox.Size = new System.Drawing.Size(290, 23);
            this.legalEntityBox.TabIndex = 11;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(333, 235);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(108, 35);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(187, 235);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(95, 33);
            this.clearButton.TabIndex = 14;
            this.clearButton.Text = "Сбросить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(11, 236);
            this.acceptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(112, 33);
            this.acceptButton.TabIndex = 15;
            this.acceptButton.Text = "Применить";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Фактический адрес";
            // 
            // realAddressBox
            // 
            this.realAddressBox.Location = new System.Drawing.Point(151, 140);
            this.realAddressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.realAddressBox.Name = "realAddressBox";
            this.realAddressBox.Size = new System.Drawing.Size(290, 23);
            this.realAddressBox.TabIndex = 17;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(151, 13);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(290, 23);
            this.nameBox.TabIndex = 18;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 280);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.realAddressBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.legalEntityBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.checkpointBox);
            this.Controls.Add(this.ITNBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FilterForm";
            this.Text = "Фильтры";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ITNBox;
        private System.Windows.Forms.TextBox checkpointBox;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.TextBox legalEntityBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox realAddressBox;
        private System.Windows.Forms.TextBox nameBox;
    }
}