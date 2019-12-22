namespace CheckSymbolsNeuroWeb {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.inputPictureBox = new System.Windows.Forms.PictureBox();
            this.letterPictureBox = new System.Windows.Forms.PictureBox();
            this.newValueTextBox = new System.Windows.Forms.TextBox();
            this.newValueLabel = new System.Windows.Forms.Label();
            this.valuesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.InstrumentsGroupBox = new System.Windows.Forms.GroupBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.addNameButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.addDataButton = new System.Windows.Forms.Button();
            this.compressedPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterPictureBox)).BeginInit();
            this.InstrumentsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // inputPictureBox
            // 
            this.inputPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.inputPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPictureBox.Location = new System.Drawing.Point(12, 12);
            this.inputPictureBox.Name = "inputPictureBox";
            this.inputPictureBox.Size = new System.Drawing.Size(300, 300);
            this.inputPictureBox.TabIndex = 0;
            this.inputPictureBox.TabStop = false;
            this.inputPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inputPictureBox_MouseDown);
            this.inputPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.inputPictureBox_MouseMove);
            // 
            // letterPictureBox
            // 
            this.letterPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.letterPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.letterPictureBox.Location = new System.Drawing.Point(318, 12);
            this.letterPictureBox.Name = "letterPictureBox";
            this.letterPictureBox.Size = new System.Drawing.Size(140, 140);
            this.letterPictureBox.TabIndex = 1;
            this.letterPictureBox.TabStop = false;
            // 
            // newValueTextBox
            // 
            this.newValueTextBox.Location = new System.Drawing.Point(6, 138);
            this.newValueTextBox.Name = "newValueTextBox";
            this.newValueTextBox.Size = new System.Drawing.Size(182, 22);
            this.newValueTextBox.TabIndex = 3;
            // 
            // newValueLabel
            // 
            this.newValueLabel.AutoSize = true;
            this.newValueLabel.Location = new System.Drawing.Point(6, 118);
            this.newValueLabel.Name = "newValueLabel";
            this.newValueLabel.Size = new System.Drawing.Size(182, 17);
            this.newValueLabel.TabIndex = 4;
            this.newValueLabel.Text = "Добавить новое значение";
            // 
            // valuesComboBox
            // 
            this.valuesComboBox.FormattingEnabled = true;
            this.valuesComboBox.Location = new System.Drawing.Point(6, 51);
            this.valuesComboBox.Name = "valuesComboBox";
            this.valuesComboBox.Size = new System.Drawing.Size(182, 24);
            this.valuesComboBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Доступные значения";
            // 
            // recognizeButton
            // 
            this.recognizeButton.Location = new System.Drawing.Point(12, 318);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(94, 34);
            this.recognizeButton.TabIndex = 7;
            this.recognizeButton.Text = "Распознать";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            // 
            // InstrumentsGroupBox
            // 
            this.InstrumentsGroupBox.Controls.Add(this.drawButton);
            this.InstrumentsGroupBox.Controls.Add(this.addNameButton);
            this.InstrumentsGroupBox.Controls.Add(this.valuesComboBox);
            this.InstrumentsGroupBox.Controls.Add(this.label1);
            this.InstrumentsGroupBox.Controls.Add(this.newValueTextBox);
            this.InstrumentsGroupBox.Controls.Add(this.newValueLabel);
            this.InstrumentsGroupBox.Location = new System.Drawing.Point(464, 12);
            this.InstrumentsGroupBox.Name = "InstrumentsGroupBox";
            this.InstrumentsGroupBox.Size = new System.Drawing.Size(200, 300);
            this.InstrumentsGroupBox.TabIndex = 8;
            this.InstrumentsGroupBox.TabStop = false;
            this.InstrumentsGroupBox.Text = "Инструменты";
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(6, 204);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(182, 34);
            this.drawButton.TabIndex = 10;
            this.drawButton.Text = "Нарисовать";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // addNameButton
            // 
            this.addNameButton.Location = new System.Drawing.Point(6, 166);
            this.addNameButton.Name = "addNameButton";
            this.addNameButton.Size = new System.Drawing.Size(182, 32);
            this.addNameButton.TabIndex = 7;
            this.addNameButton.Text = "Добавить";
            this.addNameButton.UseVisualStyleBackColor = true;
            this.addNameButton.Click += new System.EventHandler(this.addNameButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(112, 318);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(94, 34);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addDataButton
            // 
            this.addDataButton.Location = new System.Drawing.Point(212, 318);
            this.addDataButton.Name = "addDataButton";
            this.addDataButton.Size = new System.Drawing.Size(126, 34);
            this.addDataButton.TabIndex = 11;
            this.addDataButton.Text = "Добавить образ";
            this.addDataButton.UseVisualStyleBackColor = true;
            this.addDataButton.Click += new System.EventHandler(this.addDataButton_Click);
            // 
            // compressedPictureBox
            // 
            this.compressedPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.compressedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compressedPictureBox.Location = new System.Drawing.Point(318, 171);
            this.compressedPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.compressedPictureBox.Name = "compressedPictureBox";
            this.compressedPictureBox.Size = new System.Drawing.Size(139, 140);
            this.compressedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.compressedPictureBox.TabIndex = 12;
            this.compressedPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 364);
            this.Controls.Add(this.compressedPictureBox);
            this.Controls.Add(this.addDataButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.InstrumentsGroupBox);
            this.Controls.Add(this.recognizeButton);
            this.Controls.Add(this.letterPictureBox);
            this.Controls.Add(this.inputPictureBox);
            this.Name = "MainForm";
            this.Text = "Моя Нейроночка <3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterPictureBox)).EndInit();
            this.InstrumentsGroupBox.ResumeLayout(false);
            this.InstrumentsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressedPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox inputPictureBox;
        private System.Windows.Forms.PictureBox letterPictureBox;
        private System.Windows.Forms.TextBox newValueTextBox;
        private System.Windows.Forms.Label newValueLabel;
        private System.Windows.Forms.ComboBox valuesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.GroupBox InstrumentsGroupBox;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button addNameButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button addDataButton;
        private System.Windows.Forms.PictureBox compressedPictureBox;
    }
}

