
namespace CG_Lesson_5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button_next_step = new System.Windows.Forms.Button();
            this.label_step_help = new System.Windows.Forms.Label();
            this.label_step = new System.Windows.Forms.Label();
            this.textBox_roughness = new System.Windows.Forms.TextBox();
            this.label_roughness = new System.Windows.Forms.Label();
            this.button_clean = new System.Windows.Forms.Button();
            this.label_water_level = new System.Windows.Forms.Label();
            this.textBox_water_level = new System.Windows.Forms.TextBox();
            this.button_pattern = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 9);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(512, 512);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // button_next_step
            // 
            this.button_next_step.Location = new System.Drawing.Point(537, 40);
            this.button_next_step.Name = "button_next_step";
            this.button_next_step.Size = new System.Drawing.Size(75, 23);
            this.button_next_step.TabIndex = 1;
            this.button_next_step.Text = "next step";
            this.button_next_step.UseVisualStyleBackColor = true;
            this.button_next_step.Click += new System.EventHandler(this.button_next_step_Click);
            // 
            // label_step_help
            // 
            this.label_step_help.AutoSize = true;
            this.label_step_help.Location = new System.Drawing.Point(537, 9);
            this.label_step_help.Name = "label_step_help";
            this.label_step_help.Size = new System.Drawing.Size(75, 15);
            this.label_step_help.TabIndex = 2;
            this.label_step_help.Text = "Current step:";
            // 
            // label_step
            // 
            this.label_step.AutoSize = true;
            this.label_step.Location = new System.Drawing.Point(618, 9);
            this.label_step.Name = "label_step";
            this.label_step.Size = new System.Drawing.Size(31, 15);
            this.label_step.TabIndex = 3;
            this.label_step.Text = "Start";
            // 
            // textBox_roughness
            // 
            this.textBox_roughness.Location = new System.Drawing.Point(687, 100);
            this.textBox_roughness.Name = "textBox_roughness";
            this.textBox_roughness.Size = new System.Drawing.Size(100, 23);
            this.textBox_roughness.TabIndex = 4;
            // 
            // label_roughness
            // 
            this.label_roughness.AutoSize = true;
            this.label_roughness.Location = new System.Drawing.Point(538, 100);
            this.label_roughness.Name = "label_roughness";
            this.label_roughness.Size = new System.Drawing.Size(65, 15);
            this.label_roughness.TabIndex = 5;
            this.label_roughness.Text = "Roughness";
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(541, 498);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 8;
            this.button_clean.Text = "clean";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // label_water_level
            // 
            this.label_water_level.AutoSize = true;
            this.label_water_level.Location = new System.Drawing.Point(538, 132);
            this.label_water_level.Name = "label_water_level";
            this.label_water_level.Size = new System.Drawing.Size(134, 15);
            this.label_water_level.TabIndex = 9;
            this.label_water_level.Text = "Water level (from 0 to...)";
            // 
            // textBox_water_level
            // 
            this.textBox_water_level.Location = new System.Drawing.Point(687, 129);
            this.textBox_water_level.Name = "textBox_water_level";
            this.textBox_water_level.Size = new System.Drawing.Size(100, 23);
            this.textBox_water_level.TabIndex = 10;
            // 
            // button_pattern
            // 
            this.button_pattern.Location = new System.Drawing.Point(712, 214);
            this.button_pattern.Name = "button_pattern";
            this.button_pattern.Size = new System.Drawing.Size(75, 23);
            this.button_pattern.TabIndex = 11;
            this.button_pattern.Text = "pattern";
            this.button_pattern.UseVisualStyleBackColor = true;
            this.button_pattern.Click += new System.EventHandler(this.button_pattern_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 530);
            this.Controls.Add(this.button_pattern);
            this.Controls.Add(this.textBox_water_level);
            this.Controls.Add(this.label_water_level);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.label_roughness);
            this.Controls.Add(this.textBox_roughness);
            this.Controls.Add(this.label_step);
            this.Controls.Add(this.label_step_help);
            this.Controls.Add(this.button_next_step);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button_next_step;
        private System.Windows.Forms.Label label_step_help;
        private System.Windows.Forms.Label label_step;
        private System.Windows.Forms.TextBox textBox_roughness;
        private System.Windows.Forms.Label label_roughness;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Label label_water_level;
        private System.Windows.Forms.TextBox textBox_water_level;
        private System.Windows.Forms.Button button_pattern;
    }
}

