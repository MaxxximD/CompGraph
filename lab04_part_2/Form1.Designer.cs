namespace Lab4
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_stop_adding = new System.Windows.Forms.Button();
            this.button_make = new System.Windows.Forms.Button();
            this.label_dx = new System.Windows.Forms.Label();
            this.label_dy = new System.Windows.Forms.Label();
            this.textBox_dx = new System.Windows.Forms.TextBox();
            this.textBox_dy = new System.Windows.Forms.TextBox();
            this.textBox_angle = new System.Windows.Forms.TextBox();
            this.label_angle = new System.Windows.Forms.Label();
            this.textBox_turn_around_x = new System.Windows.Forms.TextBox();
            this.label_turn_around_x = new System.Windows.Forms.Label();
            this.label__turn_around_y = new System.Windows.Forms.Label();
            this.textBox_turn_around_y = new System.Windows.Forms.TextBox();
            this.checkBox_center1 = new System.Windows.Forms.CheckBox();
            this.label_or = new System.Windows.Forms.Label();
            this.label_x_axis_scaling = new System.Windows.Forms.Label();
            this.label_y_axis_scaling = new System.Windows.Forms.Label();
            this.textBox_x_axis_scaling = new System.Windows.Forms.TextBox();
            this.textBox_y_axis_scaling = new System.Windows.Forms.TextBox();
            this.label_point1 = new System.Windows.Forms.Label();
            this.label_point2 = new System.Windows.Forms.Label();
            this.label_or2 = new System.Windows.Forms.Label();
            this.checkBox_center2 = new System.Windows.Forms.CheckBox();
            this.textBox_turn_around_y2 = new System.Windows.Forms.TextBox();
            this.label_turn_around_y2 = new System.Windows.Forms.Label();
            this.label_turn_around_x2 = new System.Windows.Forms.Label();
            this.textBox_turn_around_x2 = new System.Windows.Forms.TextBox();
            this.checkBox_move = new System.Windows.Forms.CheckBox();
            this.checkBox_turn_around_point = new System.Windows.Forms.CheckBox();
            this.checkBox_point_scaling = new System.Windows.Forms.CheckBox();
            this.button_template_3_2 = new System.Windows.Forms.Button();
            this.button_template_3_1 = new System.Windows.Forms.Button();
            this.button_template_2_1 = new System.Windows.Forms.Button();
            this.button_template_2_2 = new System.Windows.Forms.Button();
            this.button_template_1_1 = new System.Windows.Forms.Button();
            this.button_template_1_2 = new System.Windows.Forms.Button();
            this.comboBox_polygon = new System.Windows.Forms.ComboBox();
            this.label_polygon = new System.Windows.Forms.Label();
            this.label_line = new System.Windows.Forms.Label();
            this.comboBox_line = new System.Windows.Forms.ComboBox();
            this.label_point = new System.Windows.Forms.Label();
            this.comboBox_point = new System.Windows.Forms.ComboBox();
            this.button_line_rotate = new System.Windows.Forms.Button();
            this.button_line_intersection = new System.Windows.Forms.Button();
            this.comboBox_line_intersection1 = new System.Windows.Forms.ComboBox();
            this.comboBox_line_intersection2 = new System.Windows.Forms.ComboBox();
            this.label_line_1 = new System.Windows.Forms.Label();
            this.label_line_2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(323, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 546);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Point";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 105);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Line";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 154);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "Polygon";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Point";
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(792, 572);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 5;
            this.button_clear.Text = "clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_stop_adding
            // 
            this.button_stop_adding.Location = new System.Drawing.Point(113, 157);
            this.button_stop_adding.Name = "button_stop_adding";
            this.button_stop_adding.Size = new System.Drawing.Size(102, 23);
            this.button_stop_adding.TabIndex = 6;
            this.button_stop_adding.Text = "stop adding points";
            this.button_stop_adding.UseVisualStyleBackColor = true;
            this.button_stop_adding.Click += new System.EventHandler(this.button_stop_adding_Click);
            // 
            // button_make
            // 
            this.button_make.Location = new System.Drawing.Point(471, 572);
            this.button_make.Name = "button_make";
            this.button_make.Size = new System.Drawing.Size(75, 23);
            this.button_make.TabIndex = 7;
            this.button_make.Text = "make";
            this.button_make.UseVisualStyleBackColor = true;
            this.button_make.Click += new System.EventHandler(this.button_make_Click);
            // 
            // label_dx
            // 
            this.label_dx.AutoSize = true;
            this.label_dx.Location = new System.Drawing.Point(10, 229);
            this.label_dx.Name = "label_dx";
            this.label_dx.Size = new System.Drawing.Size(18, 13);
            this.label_dx.TabIndex = 8;
            this.label_dx.Text = "dx";
            // 
            // label_dy
            // 
            this.label_dy.AutoSize = true;
            this.label_dy.Location = new System.Drawing.Point(10, 262);
            this.label_dy.Name = "label_dy";
            this.label_dy.Size = new System.Drawing.Size(18, 13);
            this.label_dy.TabIndex = 9;
            this.label_dy.Text = "dy";
            // 
            // textBox_dx
            // 
            this.textBox_dx.Location = new System.Drawing.Point(36, 226);
            this.textBox_dx.Name = "textBox_dx";
            this.textBox_dx.Size = new System.Drawing.Size(100, 20);
            this.textBox_dx.TabIndex = 10;
            // 
            // textBox_dy
            // 
            this.textBox_dy.Location = new System.Drawing.Point(36, 259);
            this.textBox_dy.Name = "textBox_dy";
            this.textBox_dy.Size = new System.Drawing.Size(100, 20);
            this.textBox_dy.TabIndex = 11;
            // 
            // textBox_angle
            // 
            this.textBox_angle.Location = new System.Drawing.Point(49, 357);
            this.textBox_angle.Name = "textBox_angle";
            this.textBox_angle.Size = new System.Drawing.Size(57, 20);
            this.textBox_angle.TabIndex = 12;
            // 
            // label_angle
            // 
            this.label_angle.AutoSize = true;
            this.label_angle.Location = new System.Drawing.Point(10, 360);
            this.label_angle.Name = "label_angle";
            this.label_angle.Size = new System.Drawing.Size(33, 13);
            this.label_angle.TabIndex = 13;
            this.label_angle.Text = "angle";
            // 
            // textBox_turn_around_x
            // 
            this.textBox_turn_around_x.Location = new System.Drawing.Point(239, 356);
            this.textBox_turn_around_x.Name = "textBox_turn_around_x";
            this.textBox_turn_around_x.Size = new System.Drawing.Size(57, 20);
            this.textBox_turn_around_x.TabIndex = 15;
            // 
            // label_turn_around_x
            // 
            this.label_turn_around_x.AutoSize = true;
            this.label_turn_around_x.Location = new System.Drawing.Point(221, 359);
            this.label_turn_around_x.Name = "label_turn_around_x";
            this.label_turn_around_x.Size = new System.Drawing.Size(12, 13);
            this.label_turn_around_x.TabIndex = 16;
            this.label_turn_around_x.Text = "x";
            // 
            // label__turn_around_y
            // 
            this.label__turn_around_y.AutoSize = true;
            this.label__turn_around_y.Location = new System.Drawing.Point(221, 389);
            this.label__turn_around_y.Name = "label__turn_around_y";
            this.label__turn_around_y.Size = new System.Drawing.Size(12, 13);
            this.label__turn_around_y.TabIndex = 17;
            this.label__turn_around_y.Text = "y";
            // 
            // textBox_turn_around_y
            // 
            this.textBox_turn_around_y.Location = new System.Drawing.Point(239, 386);
            this.textBox_turn_around_y.Name = "textBox_turn_around_y";
            this.textBox_turn_around_y.Size = new System.Drawing.Size(57, 20);
            this.textBox_turn_around_y.TabIndex = 18;
            // 
            // checkBox_center1
            // 
            this.checkBox_center1.AutoSize = true;
            this.checkBox_center1.Location = new System.Drawing.Point(213, 434);
            this.checkBox_center1.Name = "checkBox_center1";
            this.checkBox_center1.Size = new System.Drawing.Size(92, 17);
            this.checkBox_center1.TabIndex = 20;
            this.checkBox_center1.Text = "around center";
            this.checkBox_center1.UseVisualStyleBackColor = true;
            // 
            // label_or
            // 
            this.label_or.AutoSize = true;
            this.label_or.Location = new System.Drawing.Point(252, 418);
            this.label_or.Name = "label_or";
            this.label_or.Size = new System.Drawing.Size(16, 13);
            this.label_or.TabIndex = 21;
            this.label_or.Text = "or";
            // 
            // label_x_axis_scaling
            // 
            this.label_x_axis_scaling.AutoSize = true;
            this.label_x_axis_scaling.Location = new System.Drawing.Point(10, 509);
            this.label_x_axis_scaling.Name = "label_x_axis_scaling";
            this.label_x_axis_scaling.Size = new System.Drawing.Size(69, 13);
            this.label_x_axis_scaling.TabIndex = 23;
            this.label_x_axis_scaling.Text = "x-axis scaling";
            // 
            // label_y_axis_scaling
            // 
            this.label_y_axis_scaling.AutoSize = true;
            this.label_y_axis_scaling.Location = new System.Drawing.Point(10, 542);
            this.label_y_axis_scaling.Name = "label_y_axis_scaling";
            this.label_y_axis_scaling.Size = new System.Drawing.Size(69, 13);
            this.label_y_axis_scaling.TabIndex = 24;
            this.label_y_axis_scaling.Text = "y-axis scaling";
            // 
            // textBox_x_axis_scaling
            // 
            this.textBox_x_axis_scaling.Location = new System.Drawing.Point(85, 506);
            this.textBox_x_axis_scaling.Name = "textBox_x_axis_scaling";
            this.textBox_x_axis_scaling.Size = new System.Drawing.Size(57, 20);
            this.textBox_x_axis_scaling.TabIndex = 25;
            // 
            // textBox_y_axis_scaling
            // 
            this.textBox_y_axis_scaling.Location = new System.Drawing.Point(85, 539);
            this.textBox_y_axis_scaling.Name = "textBox_y_axis_scaling";
            this.textBox_y_axis_scaling.Size = new System.Drawing.Size(57, 20);
            this.textBox_y_axis_scaling.TabIndex = 26;
            // 
            // label_point1
            // 
            this.label_point1.AutoSize = true;
            this.label_point1.Location = new System.Drawing.Point(181, 359);
            this.label_point1.Name = "label_point1";
            this.label_point1.Size = new System.Drawing.Size(34, 13);
            this.label_point1.TabIndex = 27;
            this.label_point1.Text = "Point:";
            // 
            // label_point2
            // 
            this.label_point2.AutoSize = true;
            this.label_point2.Location = new System.Drawing.Point(181, 508);
            this.label_point2.Name = "label_point2";
            this.label_point2.Size = new System.Drawing.Size(34, 13);
            this.label_point2.TabIndex = 34;
            this.label_point2.Text = "Point:";
            // 
            // label_or2
            // 
            this.label_or2.AutoSize = true;
            this.label_or2.Location = new System.Drawing.Point(261, 562);
            this.label_or2.Name = "label_or2";
            this.label_or2.Size = new System.Drawing.Size(16, 13);
            this.label_or2.TabIndex = 33;
            this.label_or2.Text = "or";
            // 
            // checkBox_center2
            // 
            this.checkBox_center2.AutoSize = true;
            this.checkBox_center2.Location = new System.Drawing.Point(222, 578);
            this.checkBox_center2.Name = "checkBox_center2";
            this.checkBox_center2.Size = new System.Drawing.Size(92, 17);
            this.checkBox_center2.TabIndex = 32;
            this.checkBox_center2.Text = "around center";
            this.checkBox_center2.UseVisualStyleBackColor = true;
            // 
            // textBox_turn_around_y2
            // 
            this.textBox_turn_around_y2.Location = new System.Drawing.Point(239, 535);
            this.textBox_turn_around_y2.Name = "textBox_turn_around_y2";
            this.textBox_turn_around_y2.Size = new System.Drawing.Size(57, 20);
            this.textBox_turn_around_y2.TabIndex = 31;
            // 
            // label_turn_around_y2
            // 
            this.label_turn_around_y2.AutoSize = true;
            this.label_turn_around_y2.Location = new System.Drawing.Point(221, 538);
            this.label_turn_around_y2.Name = "label_turn_around_y2";
            this.label_turn_around_y2.Size = new System.Drawing.Size(12, 13);
            this.label_turn_around_y2.TabIndex = 30;
            this.label_turn_around_y2.Text = "y";
            // 
            // label_turn_around_x2
            // 
            this.label_turn_around_x2.AutoSize = true;
            this.label_turn_around_x2.Location = new System.Drawing.Point(221, 508);
            this.label_turn_around_x2.Name = "label_turn_around_x2";
            this.label_turn_around_x2.Size = new System.Drawing.Size(12, 13);
            this.label_turn_around_x2.TabIndex = 29;
            this.label_turn_around_x2.Text = "x";
            // 
            // textBox_turn_around_x2
            // 
            this.textBox_turn_around_x2.Location = new System.Drawing.Point(239, 505);
            this.textBox_turn_around_x2.Name = "textBox_turn_around_x2";
            this.textBox_turn_around_x2.Size = new System.Drawing.Size(57, 20);
            this.textBox_turn_around_x2.TabIndex = 28;
            // 
            // checkBox_move
            // 
            this.checkBox_move.AutoSize = true;
            this.checkBox_move.Location = new System.Drawing.Point(13, 203);
            this.checkBox_move.Name = "checkBox_move";
            this.checkBox_move.Size = new System.Drawing.Size(52, 17);
            this.checkBox_move.TabIndex = 37;
            this.checkBox_move.Text = "move";
            this.checkBox_move.UseVisualStyleBackColor = true;
            // 
            // checkBox_turn_around_point
            // 
            this.checkBox_turn_around_point.AutoSize = true;
            this.checkBox_turn_around_point.Location = new System.Drawing.Point(13, 334);
            this.checkBox_turn_around_point.Name = "checkBox_turn_around_point";
            this.checkBox_turn_around_point.Size = new System.Drawing.Size(106, 17);
            this.checkBox_turn_around_point.TabIndex = 38;
            this.checkBox_turn_around_point.Text = "turn around point";
            this.checkBox_turn_around_point.UseVisualStyleBackColor = true;
            // 
            // checkBox_point_scaling
            // 
            this.checkBox_point_scaling.AutoSize = true;
            this.checkBox_point_scaling.Location = new System.Drawing.Point(13, 483);
            this.checkBox_point_scaling.Name = "checkBox_point_scaling";
            this.checkBox_point_scaling.Size = new System.Drawing.Size(85, 17);
            this.checkBox_point_scaling.TabIndex = 39;
            this.checkBox_point_scaling.Text = "point scaling";
            this.checkBox_point_scaling.UseVisualStyleBackColor = true;
            // 
            // button_template_3_2
            // 
            this.button_template_3_2.Location = new System.Drawing.Point(103, 572);
            this.button_template_3_2.Name = "button_template_3_2";
            this.button_template_3_2.Size = new System.Drawing.Size(88, 23);
            this.button_template_3_2.TabIndex = 40;
            this.button_template_3_2.Text = "template 3.2 (+)";
            this.button_template_3_2.UseVisualStyleBackColor = true;
            this.button_template_3_2.Click += new System.EventHandler(this.button_template_3_2_Click);
            // 
            // button_template_3_1
            // 
            this.button_template_3_1.Location = new System.Drawing.Point(10, 572);
            this.button_template_3_1.Name = "button_template_3_1";
            this.button_template_3_1.Size = new System.Drawing.Size(87, 23);
            this.button_template_3_1.TabIndex = 41;
            this.button_template_3_1.Text = "template 3.1 (-)";
            this.button_template_3_1.UseVisualStyleBackColor = true;
            this.button_template_3_1.Click += new System.EventHandler(this.button_template_3_1_Click_1);
            // 
            // button_template_2_1
            // 
            this.button_template_2_1.Location = new System.Drawing.Point(13, 430);
            this.button_template_2_1.Name = "button_template_2_1";
            this.button_template_2_1.Size = new System.Drawing.Size(87, 23);
            this.button_template_2_1.TabIndex = 42;
            this.button_template_2_1.Text = "template 2.1 (-)";
            this.button_template_2_1.UseVisualStyleBackColor = true;
            this.button_template_2_1.Click += new System.EventHandler(this.button_template_2_1_Click);
            // 
            // button_template_2_2
            // 
            this.button_template_2_2.Location = new System.Drawing.Point(103, 430);
            this.button_template_2_2.Name = "button_template_2_2";
            this.button_template_2_2.Size = new System.Drawing.Size(88, 23);
            this.button_template_2_2.TabIndex = 43;
            this.button_template_2_2.Text = "template 2.2 (+)";
            this.button_template_2_2.UseVisualStyleBackColor = true;
            this.button_template_2_2.Click += new System.EventHandler(this.button_template_2_2_Click);
            // 
            // button_template_1_1
            // 
            this.button_template_1_1.Location = new System.Drawing.Point(10, 295);
            this.button_template_1_1.Name = "button_template_1_1";
            this.button_template_1_1.Size = new System.Drawing.Size(87, 23);
            this.button_template_1_1.TabIndex = 44;
            this.button_template_1_1.Text = "template 1.1 (-)";
            this.button_template_1_1.UseVisualStyleBackColor = true;
            this.button_template_1_1.Click += new System.EventHandler(this.button_template_1_1_Click);
            // 
            // button_template_1_2
            // 
            this.button_template_1_2.Location = new System.Drawing.Point(103, 295);
            this.button_template_1_2.Name = "button_template_1_2";
            this.button_template_1_2.Size = new System.Drawing.Size(88, 23);
            this.button_template_1_2.TabIndex = 45;
            this.button_template_1_2.Text = "template 1.2 (+)";
            this.button_template_1_2.UseVisualStyleBackColor = true;
            this.button_template_1_2.Click += new System.EventHandler(this.button_template_1_2_Click);
            // 
            // comboBox_polygon
            // 
            this.comboBox_polygon.FormattingEnabled = true;
            this.comboBox_polygon.Location = new System.Drawing.Point(193, 21);
            this.comboBox_polygon.Name = "comboBox_polygon";
            this.comboBox_polygon.Size = new System.Drawing.Size(121, 21);
            this.comboBox_polygon.TabIndex = 46;
            // 
            // label_polygon
            // 
            this.label_polygon.AutoSize = true;
            this.label_polygon.Location = new System.Drawing.Point(147, 24);
            this.label_polygon.Name = "label_polygon";
            this.label_polygon.Size = new System.Drawing.Size(44, 13);
            this.label_polygon.TabIndex = 47;
            this.label_polygon.Text = "polygon";
            // 
            // label_line
            // 
            this.label_line.AutoSize = true;
            this.label_line.Location = new System.Drawing.Point(147, 60);
            this.label_line.Name = "label_line";
            this.label_line.Size = new System.Drawing.Size(23, 13);
            this.label_line.TabIndex = 48;
            this.label_line.Text = "line";
            // 
            // comboBox_line
            // 
            this.comboBox_line.FormattingEnabled = true;
            this.comboBox_line.Location = new System.Drawing.Point(193, 57);
            this.comboBox_line.Name = "comboBox_line";
            this.comboBox_line.Size = new System.Drawing.Size(121, 21);
            this.comboBox_line.TabIndex = 49;
            // 
            // label_point
            // 
            this.label_point.AutoSize = true;
            this.label_point.Location = new System.Drawing.Point(147, 97);
            this.label_point.Name = "label_point";
            this.label_point.Size = new System.Drawing.Size(30, 13);
            this.label_point.TabIndex = 50;
            this.label_point.Text = "point";
            // 
            // comboBox_point
            // 
            this.comboBox_point.FormattingEnabled = true;
            this.comboBox_point.Location = new System.Drawing.Point(193, 94);
            this.comboBox_point.Name = "comboBox_point";
            this.comboBox_point.Size = new System.Drawing.Size(121, 21);
            this.comboBox_point.TabIndex = 51;
            // 
            // button_line_rotate
            // 
            this.button_line_rotate.Location = new System.Drawing.Point(896, 14);
            this.button_line_rotate.Name = "button_line_rotate";
            this.button_line_rotate.Size = new System.Drawing.Size(92, 23);
            this.button_line_rotate.TabIndex = 52;
            this.button_line_rotate.Text = "line rotate";
            this.button_line_rotate.UseVisualStyleBackColor = true;
            this.button_line_rotate.Click += new System.EventHandler(this.button_line_rotate_Click);
            // 
            // button_line_intersection
            // 
            this.button_line_intersection.Location = new System.Drawing.Point(896, 87);
            this.button_line_intersection.Name = "button_line_intersection";
            this.button_line_intersection.Size = new System.Drawing.Size(92, 23);
            this.button_line_intersection.TabIndex = 53;
            this.button_line_intersection.Text = "line intersection";
            this.button_line_intersection.UseVisualStyleBackColor = true;
            this.button_line_intersection.Click += new System.EventHandler(this.button_line_intersection_Click);
            // 
            // comboBox_line_intersection1
            // 
            this.comboBox_line_intersection1.FormattingEnabled = true;
            this.comboBox_line_intersection1.Location = new System.Drawing.Point(873, 138);
            this.comboBox_line_intersection1.Name = "comboBox_line_intersection1";
            this.comboBox_line_intersection1.Size = new System.Drawing.Size(63, 21);
            this.comboBox_line_intersection1.TabIndex = 54;
            // 
            // comboBox_line_intersection2
            // 
            this.comboBox_line_intersection2.FormattingEnabled = true;
            this.comboBox_line_intersection2.Location = new System.Drawing.Point(948, 138);
            this.comboBox_line_intersection2.Name = "comboBox_line_intersection2";
            this.comboBox_line_intersection2.Size = new System.Drawing.Size(63, 21);
            this.comboBox_line_intersection2.TabIndex = 55;
            // 
            // label_line_1
            // 
            this.label_line_1.AutoSize = true;
            this.label_line_1.Location = new System.Drawing.Point(893, 120);
            this.label_line_1.Name = "label_line_1";
            this.label_line_1.Size = new System.Drawing.Size(32, 13);
            this.label_line_1.TabIndex = 56;
            this.label_line_1.Text = "line 1";
            // 
            // label_line_2
            // 
            this.label_line_2.AutoSize = true;
            this.label_line_2.Location = new System.Drawing.Point(956, 120);
            this.label_line_2.Name = "label_line_2";
            this.label_line_2.Size = new System.Drawing.Size(32, 13);
            this.label_line_2.TabIndex = 57;
            this.label_line_2.Text = "line 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 607);
            this.Controls.Add(this.label_line_2);
            this.Controls.Add(this.label_line_1);
            this.Controls.Add(this.comboBox_line_intersection2);
            this.Controls.Add(this.comboBox_line_intersection1);
            this.Controls.Add(this.button_line_intersection);
            this.Controls.Add(this.button_line_rotate);
            this.Controls.Add(this.comboBox_point);
            this.Controls.Add(this.label_point);
            this.Controls.Add(this.comboBox_line);
            this.Controls.Add(this.label_line);
            this.Controls.Add(this.label_polygon);
            this.Controls.Add(this.comboBox_polygon);
            this.Controls.Add(this.button_template_1_2);
            this.Controls.Add(this.button_template_1_1);
            this.Controls.Add(this.button_template_2_2);
            this.Controls.Add(this.button_template_2_1);
            this.Controls.Add(this.button_template_3_1);
            this.Controls.Add(this.button_template_3_2);
            this.Controls.Add(this.checkBox_point_scaling);
            this.Controls.Add(this.checkBox_turn_around_point);
            this.Controls.Add(this.checkBox_move);
            this.Controls.Add(this.label_point2);
            this.Controls.Add(this.label_or2);
            this.Controls.Add(this.checkBox_center2);
            this.Controls.Add(this.textBox_turn_around_y2);
            this.Controls.Add(this.label_turn_around_y2);
            this.Controls.Add(this.label_turn_around_x2);
            this.Controls.Add(this.textBox_turn_around_x2);
            this.Controls.Add(this.label_point1);
            this.Controls.Add(this.textBox_y_axis_scaling);
            this.Controls.Add(this.textBox_x_axis_scaling);
            this.Controls.Add(this.label_y_axis_scaling);
            this.Controls.Add(this.label_x_axis_scaling);
            this.Controls.Add(this.label_or);
            this.Controls.Add(this.checkBox_center1);
            this.Controls.Add(this.textBox_turn_around_y);
            this.Controls.Add(this.label__turn_around_y);
            this.Controls.Add(this.label_turn_around_x);
            this.Controls.Add(this.textBox_turn_around_x);
            this.Controls.Add(this.label_angle);
            this.Controls.Add(this.textBox_angle);
            this.Controls.Add(this.textBox_dy);
            this.Controls.Add(this.textBox_dx);
            this.Controls.Add(this.label_dy);
            this.Controls.Add(this.label_dx);
            this.Controls.Add(this.button_make);
            this.Controls.Add(this.button_stop_adding);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_stop_adding;
        private System.Windows.Forms.Button button_make;
        private System.Windows.Forms.Label label_dx;
        private System.Windows.Forms.Label label_dy;
        private System.Windows.Forms.TextBox textBox_dx;
        private System.Windows.Forms.TextBox textBox_dy;
        private System.Windows.Forms.TextBox textBox_angle;
        private System.Windows.Forms.Label label_angle;
        private System.Windows.Forms.TextBox textBox_turn_around_x;
        private System.Windows.Forms.Label label_turn_around_x;
        private System.Windows.Forms.Label label__turn_around_y;
        private System.Windows.Forms.TextBox textBox_turn_around_y;
        private System.Windows.Forms.CheckBox checkBox_center1;
        private System.Windows.Forms.Label label_or;
        private System.Windows.Forms.Label label_x_axis_scaling;
        private System.Windows.Forms.Label label_y_axis_scaling;
        private System.Windows.Forms.TextBox textBox_x_axis_scaling;
        private System.Windows.Forms.TextBox textBox_y_axis_scaling;
        private System.Windows.Forms.Label label_point1;
        private System.Windows.Forms.Label label_point2;
        private System.Windows.Forms.Label label_or2;
        private System.Windows.Forms.CheckBox checkBox_center2;
        private System.Windows.Forms.TextBox textBox_turn_around_y2;
        private System.Windows.Forms.Label label_turn_around_y2;
        private System.Windows.Forms.Label label_turn_around_x2;
        private System.Windows.Forms.TextBox textBox_turn_around_x2;
        private System.Windows.Forms.CheckBox checkBox_move;
        private System.Windows.Forms.CheckBox checkBox_turn_around_point;
        private System.Windows.Forms.CheckBox checkBox_point_scaling;
        private System.Windows.Forms.Button button_template_3_2;
        private System.Windows.Forms.Button button_template_3_1;
        private System.Windows.Forms.Button button_template_2_1;
        private System.Windows.Forms.Button button_template_2_2;
        private System.Windows.Forms.Button button_template_1_1;
        private System.Windows.Forms.Button button_template_1_2;
        private System.Windows.Forms.ComboBox comboBox_polygon;
        private System.Windows.Forms.Label label_polygon;
        private System.Windows.Forms.Label label_line;
        private System.Windows.Forms.ComboBox comboBox_line;
        private System.Windows.Forms.Label label_point;
        private System.Windows.Forms.ComboBox comboBox_point;
        private System.Windows.Forms.Button button_line_rotate;
        private System.Windows.Forms.Button button_line_intersection;
        private System.Windows.Forms.ComboBox comboBox_line_intersection1;
        private System.Windows.Forms.ComboBox comboBox_line_intersection2;
        private System.Windows.Forms.Label label_line_1;
        private System.Windows.Forms.Label label_line_2;
    }
}

