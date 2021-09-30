
namespace CG_Lesson_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.convert_button = new System.Windows.Forms.Button();
            this.Hue_textBox = new System.Windows.Forms.TextBox();
            this.Saturation_textBox = new System.Windows.Forms.TextBox();
            this.Value_textBox = new System.Windows.Forms.TextBox();
            this.Hue_label = new System.Windows.Forms.Label();
            this.Saturation_label = new System.Windows.Forms.Label();
            this.Value_label = new System.Windows.Forms.Label();
            this.choose_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.save_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // convert_button
            // 
            this.convert_button.Location = new System.Drawing.Point(761, 572);
            this.convert_button.Name = "convert_button";
            this.convert_button.Size = new System.Drawing.Size(116, 23);
            this.convert_button.TabIndex = 0;
            this.convert_button.Text = "Convert picture";
            this.convert_button.UseVisualStyleBackColor = true;
            this.convert_button.Click += new System.EventHandler(this.convert_button_Click);
            // 
            // Hue_textBox
            // 
            this.Hue_textBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Hue_textBox.Location = new System.Drawing.Point(777, 494);
            this.Hue_textBox.Name = "Hue_textBox";
            this.Hue_textBox.Size = new System.Drawing.Size(100, 20);
            this.Hue_textBox.TabIndex = 1;
            this.Hue_textBox.Text = "[-360, 360]";
            this.Hue_textBox.Enter += new System.EventHandler(this.Hue_Enter);
            this.Hue_textBox.Leave += new System.EventHandler(this.Hue_Leave);
            // 
            // Saturation_textBox
            // 
            this.Saturation_textBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Saturation_textBox.Location = new System.Drawing.Point(777, 520);
            this.Saturation_textBox.Name = "Saturation_textBox";
            this.Saturation_textBox.Size = new System.Drawing.Size(100, 20);
            this.Saturation_textBox.TabIndex = 2;
            this.Saturation_textBox.Text = "[-1, 1]";
            this.Saturation_textBox.Enter += new System.EventHandler(this.Saturation_Enter);
            this.Saturation_textBox.Leave += new System.EventHandler(this.Saturation_Leave);
            // 
            // Value_textBox
            // 
            this.Value_textBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Value_textBox.Location = new System.Drawing.Point(777, 546);
            this.Value_textBox.Name = "Value_textBox";
            this.Value_textBox.Size = new System.Drawing.Size(100, 20);
            this.Value_textBox.TabIndex = 3;
            this.Value_textBox.Text = "[-1, 1]";
            this.Value_textBox.Enter += new System.EventHandler(this.Value_Enter);
            this.Value_textBox.Leave += new System.EventHandler(this.Value_Leave);
            // 
            // Hue_label
            // 
            this.Hue_label.AutoSize = true;
            this.Hue_label.Location = new System.Drawing.Point(696, 497);
            this.Hue_label.Name = "Hue_label";
            this.Hue_label.Size = new System.Drawing.Size(47, 13);
            this.Hue_label.TabIndex = 4;
            this.Hue_label.Text = "Add hue";
            // 
            // Saturation_label
            // 
            this.Saturation_label.AutoSize = true;
            this.Saturation_label.Location = new System.Drawing.Point(696, 523);
            this.Saturation_label.Name = "Saturation_label";
            this.Saturation_label.Size = new System.Drawing.Size(75, 13);
            this.Saturation_label.TabIndex = 5;
            this.Saturation_label.Text = "Add saturation";
            // 
            // Value_label
            // 
            this.Value_label.AutoSize = true;
            this.Value_label.Location = new System.Drawing.Point(696, 549);
            this.Value_label.Name = "Value_label";
            this.Value_label.Size = new System.Drawing.Size(55, 13);
            this.Value_label.TabIndex = 6;
            this.Value_label.Text = "Add value";
            // 
            // choose_button
            // 
            this.choose_button.Location = new System.Drawing.Point(38, 508);
            this.choose_button.Name = "choose_button";
            this.choose_button.Size = new System.Drawing.Size(120, 23);
            this.choose_button.TabIndex = 7;
            this.choose_button.Text = "Choose a picture";
            this.choose_button.UseVisualStyleBackColor = true;
            this.choose_button.Click += new System.EventHandler(this.choose_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(38, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(511, 417);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(248, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Original picture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(758, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Result picture";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(555, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(493, 416);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // save_button
            // 
            this.save_button.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.save_button.Location = new System.Drawing.Point(918, 572);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(116, 23);
            this.save_button.TabIndex = 12;
            this.save_button.Text = "Save picture";
            this.save_button.UseVisualStyleBackColor = false;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(33, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Work with HSV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 608);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.choose_button);
            this.Controls.Add(this.Value_label);
            this.Controls.Add(this.Saturation_label);
            this.Controls.Add(this.Hue_label);
            this.Controls.Add(this.Value_textBox);
            this.Controls.Add(this.Saturation_textBox);
            this.Controls.Add(this.Hue_textBox);
            this.Controls.Add(this.convert_button);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button convert_button;
        private System.Windows.Forms.TextBox Hue_textBox;
        private System.Windows.Forms.TextBox Saturation_textBox;
        private System.Windows.Forms.TextBox Value_textBox;
        private System.Windows.Forms.Label Hue_label;
        private System.Windows.Forms.Label Saturation_label;
        private System.Windows.Forms.Label Value_label;
        private System.Windows.Forms.Button choose_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label label3;
    }
}

