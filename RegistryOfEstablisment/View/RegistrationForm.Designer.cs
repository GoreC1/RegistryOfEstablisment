
namespace RegistryOfEstablisment.View
{
    partial class RegistrationForm
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
            this.PetTypeTextBox = new System.Windows.Forms.TextBox();
            this.AdressTextBox = new System.Windows.Forms.TextBox();
            this.TelephoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.PetNameTextBox = new System.Windows.Forms.TextBox();
            this.OwnerTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.DateBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TimeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // PetTypeTextBox
            // 
            this.PetTypeTextBox.Location = new System.Drawing.Point(186, 104);
            this.PetTypeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PetTypeTextBox.Name = "PetTypeTextBox";
            this.PetTypeTextBox.Size = new System.Drawing.Size(157, 23);
            this.PetTypeTextBox.TabIndex = 48;
            // 
            // AdressTextBox
            // 
            this.AdressTextBox.Location = new System.Drawing.Point(14, 66);
            this.AdressTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdressTextBox.Name = "AdressTextBox";
            this.AdressTextBox.Size = new System.Drawing.Size(157, 23);
            this.AdressTextBox.TabIndex = 44;
            // 
            // TelephoneNumberTextBox
            // 
            this.TelephoneNumberTextBox.Location = new System.Drawing.Point(186, 66);
            this.TelephoneNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TelephoneNumberTextBox.Name = "TelephoneNumberTextBox";
            this.TelephoneNumberTextBox.Size = new System.Drawing.Size(157, 23);
            this.TelephoneNumberTextBox.TabIndex = 43;
            // 
            // PetNameTextBox
            // 
            this.PetNameTextBox.Location = new System.Drawing.Point(14, 104);
            this.PetNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PetNameTextBox.Name = "PetNameTextBox";
            this.PetNameTextBox.Size = new System.Drawing.Size(157, 23);
            this.PetNameTextBox.TabIndex = 42;
            // 
            // OwnerTextBox
            // 
            this.OwnerTextBox.Location = new System.Drawing.Point(14, 26);
            this.OwnerTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OwnerTextBox.Name = "OwnerTextBox";
            this.OwnerTextBox.Size = new System.Drawing.Size(330, 23);
            this.OwnerTextBox.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Место жительства";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 36;
            this.label4.Text = "Телефон";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Кличка питомца";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Вид животного";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 9);
            this.label1.MaximumSize = new System.Drawing.Size(150, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "ФИО";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(42, 182);
            this.acceptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(101, 28);
            this.acceptButton.TabIndex = 49;
            this.acceptButton.Text = "Подтвердить";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // DateBox
            // 
            this.DateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DateBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DateBox.FormattingEnabled = true;
            this.DateBox.Location = new System.Drawing.Point(14, 146);
            this.DateBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateBox.Name = "DateBox";
            this.DateBox.Size = new System.Drawing.Size(157, 23);
            this.DateBox.TabIndex = 50;
            this.DateBox.SelectedIndexChanged += new System.EventHandler(this.DateBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 51;
            this.label6.Text = "День записи";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(202, 182);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 28);
            this.cancelButton.TabIndex = 54;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 53;
            this.label7.Text = "Время записи";
            // 
            // TimeBox
            // 
            this.TimeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TimeBox.FormattingEnabled = true;
            this.TimeBox.Location = new System.Drawing.Point(186, 146);
            this.TimeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(154, 23);
            this.TimeBox.TabIndex = 52;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 221);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DateBox);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.PetTypeTextBox);
            this.Controls.Add(this.AdressTextBox);
            this.Controls.Add(this.TelephoneNumberTextBox);
            this.Controls.Add(this.PetNameTextBox);
            this.Controls.Add(this.OwnerTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PetTypeTextBox;
        private System.Windows.Forms.TextBox AdressTextBox;
        private System.Windows.Forms.TextBox TelephoneNumberTextBox;
        private System.Windows.Forms.TextBox PetNameTextBox;
        private System.Windows.Forms.TextBox OwnerTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.ComboBox DateBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TimeBox;
    }
}