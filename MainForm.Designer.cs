namespace HyperCrypt
{
    partial class MainForm
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
            label30 = new Label();
            label29 = new Label();
            label25 = new Label();
            panel6 = new Panel();
            label23 = new Label();
            label22 = new Label();
            textNumAcmP = new TextBox();
            label21 = new Label();
            panel5 = new Panel();
            label15 = new Label();
            label14 = new Label();
            txtParamA = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txtParamB = new TextBox();
            label12 = new Label();
            txtParamC = new TextBox();
            label13 = new Label();
            txtParamH = new TextBox();
            label16 = new Label();
            txtParamTransient = new TextBox();
            panel4 = new Panel();
            label8 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtnumx0 = new TextBox();
            txtNumy0 = new TextBox();
            txtNumz0 = new TextBox();
            txtNumw0 = new TextBox();
            label9 = new Label();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            lblInputImagepath = new Label();
            picInput = new PictureBox();
            btnBrowse = new Button();
            txtNumACMQ = new TextBox();
            label17 = new Label();
            txtNumAcmIter = new TextBox();
            label18 = new Label();
            txtNumLogisticLambda = new TextBox();
            label19 = new Label();
            lblLogidticX0Value = new Label();
            lblDnaKeyRule = new Label();
            btnSave = new Button();
            panel7 = new Panel();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            btnAnalysis = new Button();
            btnReset = new Button();
            panel8 = new Panel();
            label28 = new Label();
            label32 = new Label();
            btnSaveKey = new Button();
            btnLoadKey = new Button();
            panel9 = new Panel();
            label20 = new Label();
            label27 = new Label();
            label31 = new Label();
            panel10 = new Panel();
            panel11 = new Panel();
            panel12 = new Panel();
            panel13 = new Panel();
            panel14 = new Panel();
            panel15 = new Panel();
            label24 = new Label();
            label26 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            label37 = new Label();
            label38 = new Label();
            label39 = new Label();
            label40 = new Label();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInput).BeginInit();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel15.SuspendLayout();
            SuspendLayout();
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label30.ForeColor = Color.DarkBlue;
            label30.Location = new Point(16, 15);
            label30.Name = "label30";
            label30.Size = new Size(287, 20);
            label30.TabIndex = 4;
            label30.Text = "Derived Values (terisi setelah Encrypt)";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label29.ForeColor = Color.DarkBlue;
            label29.Location = new Point(16, 50);
            label29.Name = "label29";
            label29.Size = new Size(158, 20);
            label29.TabIndex = 5;
            label29.Text = "DNA rule (key matrix)";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label25.ForeColor = Color.DarkBlue;
            label25.Location = new Point(16, 104);
            label25.Name = "label25";
            label25.Size = new Size(207, 20);
            label25.TabIndex = 18;
            label25.Text = "Logistic Map x₀ (dari Lorenz)";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(lblDnaKeyRule);
            panel6.Controls.Add(lblLogidticX0Value);
            panel6.Controls.Add(label25);
            panel6.Controls.Add(label29);
            panel6.Controls.Add(label30);
            panel6.Location = new Point(12, 1252);
            panel6.Name = "panel6";
            panel6.Size = new Size(551, 153);
            panel6.TabIndex = 22;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.ForeColor = Color.DarkBlue;
            label23.Location = new Point(16, 15);
            label23.Name = "label23";
            label23.Size = new Size(238, 20);
            label23.TabIndex = 4;
            label23.Text = "Arnold Cat Map + Logistic Map";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.DarkBlue;
            label22.Location = new Point(16, 50);
            label22.Name = "label22";
            label22.Size = new Size(58, 20);
            label22.TabIndex = 5;
            label22.Text = "ACM p";
            // 
            // textNumAcmP
            // 
            textNumAcmP.BorderStyle = BorderStyle.FixedSingle;
            textNumAcmP.Location = new Point(16, 83);
            textNumAcmP.Name = "textNumAcmP";
            textNumAcmP.Size = new Size(149, 27);
            textNumAcmP.TabIndex = 9;
            // 
            // label21
            // 
            label21.Font = new Font("72 Monospace", 8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.DarkBlue;
            label21.Location = new Point(16, 219);
            label21.Name = "label21";
            label21.Size = new Size(532, 29);
            label21.TabIndex = 13;
            label21.Text = "LM X₀ otomatis adalah Lorenz Seq. 1 (unified key gen)";
            label21.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(txtNumLogisticLambda);
            panel5.Controls.Add(label19);
            panel5.Controls.Add(txtNumAcmIter);
            panel5.Controls.Add(label18);
            panel5.Controls.Add(txtNumACMQ);
            panel5.Controls.Add(label17);
            panel5.Controls.Add(label21);
            panel5.Controls.Add(textNumAcmP);
            panel5.Controls.Add(label22);
            panel5.Controls.Add(label23);
            panel5.Location = new Point(12, 970);
            panel5.Name = "panel5";
            panel5.Size = new Size(551, 259);
            panel5.TabIndex = 22;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.DarkBlue;
            label15.Location = new Point(16, 15);
            label15.Name = "label15";
            label15.Size = new Size(285, 20);
            label15.TabIndex = 4;
            label15.Text = "Lorenz 4D - System Paramater (fixed)";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.DarkBlue;
            label14.Location = new Point(16, 50);
            label14.Name = "label14";
            label14.Size = new Size(91, 20);
            label14.TabIndex = 5;
            label14.Text = "a (coupling)";
            // 
            // txtParamA
            // 
            txtParamA.BorderStyle = BorderStyle.FixedSingle;
            txtParamA.Location = new Point(123, 50);
            txtParamA.Name = "txtParamA";
            txtParamA.PlaceholderText = "NumX0";
            txtParamA.ReadOnly = true;
            txtParamA.Size = new Size(149, 27);
            txtParamA.TabIndex = 9;
            // 
            // label10
            // 
            label10.Font = new Font("72 Monospace", 8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.DarkBlue;
            label10.Location = new Point(16, 219);
            label10.Name = "label10";
            label10.Size = new Size(532, 29);
            label10.TabIndex = 13;
            label10.Text = "Read only - tidak bisa diubah ( agar tetap hyperchaotic )";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.DarkBlue;
            label11.Location = new Point(16, 103);
            label11.Name = "label11";
            label11.Size = new Size(93, 20);
            label11.TabIndex = 14;
            label11.Text = "b (damping)";
            // 
            // txtParamB
            // 
            txtParamB.BorderStyle = BorderStyle.FixedSingle;
            txtParamB.Location = new Point(123, 103);
            txtParamB.Name = "txtParamB";
            txtParamB.PlaceholderText = "NumX0";
            txtParamB.ReadOnly = true;
            txtParamB.Size = new Size(149, 27);
            txtParamB.TabIndex = 15;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.DarkBlue;
            label12.Location = new Point(16, 154);
            label12.Name = "label12";
            label12.Size = new Size(106, 20);
            label12.TabIndex = 16;
            label12.Text = "c (bifurcation)";
            // 
            // txtParamC
            // 
            txtParamC.BorderStyle = BorderStyle.FixedSingle;
            txtParamC.Location = new Point(123, 154);
            txtParamC.Name = "txtParamC";
            txtParamC.PlaceholderText = "NumX0";
            txtParamC.ReadOnly = true;
            txtParamC.Size = new Size(149, 27);
            txtParamC.TabIndex = 17;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.DarkBlue;
            label13.Location = new Point(278, 50);
            label13.Name = "label13";
            label13.Size = new Size(62, 20);
            label13.TabIndex = 18;
            label13.Text = "h (step)";
            // 
            // txtParamH
            // 
            txtParamH.BorderStyle = BorderStyle.FixedSingle;
            txtParamH.Location = new Point(385, 50);
            txtParamH.Name = "txtParamH";
            txtParamH.PlaceholderText = "NumX0";
            txtParamH.ReadOnly = true;
            txtParamH.Size = new Size(149, 27);
            txtParamH.TabIndex = 19;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.DarkBlue;
            label16.Location = new Point(278, 103);
            label16.Name = "label16";
            label16.Size = new Size(69, 20);
            label16.TabIndex = 20;
            label16.Text = "N (tans.)";
            // 
            // txtParamTransient
            // 
            txtParamTransient.BorderStyle = BorderStyle.FixedSingle;
            txtParamTransient.Location = new Point(385, 103);
            txtParamTransient.Name = "txtParamTransient";
            txtParamTransient.PlaceholderText = "NumX0";
            txtParamTransient.ReadOnly = true;
            txtParamTransient.Size = new Size(149, 27);
            txtParamTransient.TabIndex = 21;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(txtParamTransient);
            panel4.Controls.Add(label16);
            panel4.Controls.Add(txtParamH);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(txtParamC);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(txtParamB);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(txtParamA);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label15);
            panel4.Location = new Point(12, 688);
            panel4.Name = "panel4";
            panel4.Size = new Size(551, 259);
            panel4.TabIndex = 14;
            panel4.Paint += this.panel4_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DarkBlue;
            label8.Location = new Point(16, 15);
            label8.Name = "label8";
            label8.Size = new Size(277, 20);
            label8.TabIndex = 4;
            label8.Text = "Lorenz 4D - Secret Key ( wajib diisi )";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkBlue;
            label3.Location = new Point(16, 50);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 5;
            label3.Text = "x₀ =";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkBlue;
            label4.Location = new Point(16, 104);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 6;
            label4.Text = "y₀ =";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkBlue;
            label6.Location = new Point(290, 52);
            label6.Name = "label6";
            label6.Size = new Size(38, 20);
            label6.TabIndex = 7;
            label6.Text = "z₀ =";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DarkBlue;
            label7.Location = new Point(290, 104);
            label7.Name = "label7";
            label7.Size = new Size(42, 20);
            label7.TabIndex = 8;
            label7.Text = "w₀ =";
            // 
            // txtnumx0
            // 
            txtnumx0.BorderStyle = BorderStyle.FixedSingle;
            txtnumx0.Location = new Point(57, 50);
            txtnumx0.Name = "txtnumx0";
            txtnumx0.PlaceholderText = "NumX0";
            txtnumx0.Size = new Size(188, 27);
            txtnumx0.TabIndex = 9;
            // 
            // txtNumy0
            // 
            txtNumy0.BorderStyle = BorderStyle.FixedSingle;
            txtNumy0.Location = new Point(57, 102);
            txtNumy0.Name = "txtNumy0";
            txtNumy0.PlaceholderText = "NumY0";
            txtNumy0.Size = new Size(188, 27);
            txtNumy0.TabIndex = 10;
            // 
            // txtNumz0
            // 
            txtNumz0.BorderStyle = BorderStyle.FixedSingle;
            txtNumz0.Location = new Point(346, 50);
            txtNumz0.Name = "txtNumz0";
            txtNumz0.PlaceholderText = "NumZ0";
            txtNumz0.Size = new Size(188, 27);
            txtNumz0.TabIndex = 11;
            // 
            // txtNumw0
            // 
            txtNumw0.BorderStyle = BorderStyle.FixedSingle;
            txtNumw0.Location = new Point(346, 102);
            txtNumw0.Name = "txtNumw0";
            txtNumw0.PlaceholderText = "NumW0";
            txtNumw0.Size = new Size(188, 27);
            txtNumw0.TabIndex = 12;
            // 
            // label9
            // 
            label9.Font = new Font("72 Monospace", 8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DarkBlue;
            label9.Location = new Point(16, 155);
            label9.Name = "label9";
            label9.Size = new Size(277, 70);
            label9.TabIndex = 13;
            label9.Text = "ℹ️ Tooltip aktif di setiap input (hover untuk lihat fungsi Key Space = 10⁶⁰ . Kunci ini HARUS Identik saat dekripsi";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label9);
            panel3.Controls.Add(txtNumw0);
            panel3.Controls.Add(txtNumz0);
            panel3.Controls.Add(txtNumy0);
            panel3.Controls.Add(txtnumx0);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(12, 432);
            panel3.Name = "panel3";
            panel3.Size = new Size(551, 235);
            panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Cursor = Cursors.No;
            pictureBox1.Location = new Point(16, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(926, 738);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkBlue;
            label5.Location = new Point(16, 15);
            label5.Name = "label5";
            label5.Size = new Size(110, 20);
            label5.TabIndex = 4;
            label5.Text = "Output Image";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(583, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(954, 805);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkBlue;
            label2.Location = new Point(16, 15);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 4;
            label2.Text = "Input Image";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblInputImagepath);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(picInput);
            panel1.Controls.Add(btnBrowse);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(551, 402);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 368);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 3;
            label1.Text = "Image Path :";
            // 
            // lblInputImagepath
            // 
            lblInputImagepath.AutoSize = true;
            lblInputImagepath.Location = new Point(109, 368);
            lblInputImagepath.Name = "lblInputImagepath";
            lblInputImagepath.Size = new Size(240, 20);
            lblInputImagepath.TabIndex = 2;
            lblInputImagepath.Text = "Image Path Info will be shown here";
            // 
            // picInput
            // 
            picInput.BorderStyle = BorderStyle.FixedSingle;
            picInput.Cursor = Cursors.No;
            picInput.Location = new Point(16, 49);
            picInput.Name = "picInput";
            picInput.Size = new Size(518, 274);
            picInput.SizeMode = PictureBoxSizeMode.CenterImage;
            picInput.TabIndex = 0;
            picInput.TabStop = false;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.DarkBlue;
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(16, 336);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(124, 29);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse Image";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // txtNumACMQ
            // 
            txtNumACMQ.BorderStyle = BorderStyle.FixedSingle;
            txtNumACMQ.Location = new Point(196, 83);
            txtNumACMQ.Name = "txtNumACMQ";
            txtNumACMQ.Size = new Size(149, 27);
            txtNumACMQ.TabIndex = 15;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.DarkBlue;
            label17.Location = new Point(196, 50);
            label17.Name = "label17";
            label17.Size = new Size(58, 20);
            label17.TabIndex = 14;
            label17.Text = "ACM q";
            // 
            // txtNumAcmIter
            // 
            txtNumAcmIter.BorderStyle = BorderStyle.FixedSingle;
            txtNumAcmIter.Location = new Point(385, 83);
            txtNumAcmIter.Name = "txtNumAcmIter";
            txtNumAcmIter.Size = new Size(149, 27);
            txtNumAcmIter.TabIndex = 17;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.DarkBlue;
            label18.Location = new Point(385, 50);
            label18.Name = "label18";
            label18.Size = new Size(71, 20);
            label18.TabIndex = 16;
            label18.Text = "ACM iter";
            // 
            // txtNumLogisticLambda
            // 
            txtNumLogisticLambda.BorderStyle = BorderStyle.FixedSingle;
            txtNumLogisticLambda.Location = new Point(16, 163);
            txtNumLogisticLambda.Name = "txtNumLogisticLambda";
            txtNumLogisticLambda.Size = new Size(149, 27);
            txtNumLogisticLambda.TabIndex = 19;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.DarkBlue;
            label19.Location = new Point(16, 130);
            label19.Name = "label19";
            label19.Size = new Size(110, 20);
            label19.TabIndex = 18;
            label19.Text = "LM λ (lambda)";
            // 
            // lblLogidticX0Value
            // 
            lblLogidticX0Value.BorderStyle = BorderStyle.FixedSingle;
            lblLogidticX0Value.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogidticX0Value.ForeColor = Color.DarkBlue;
            lblLogidticX0Value.Location = new Point(258, 103);
            lblLogidticX0Value.Name = "lblLogidticX0Value";
            lblLogidticX0Value.Size = new Size(276, 33);
            lblLogidticX0Value.TabIndex = 19;
            // 
            // lblDnaKeyRule
            // 
            lblDnaKeyRule.BorderStyle = BorderStyle.FixedSingle;
            lblDnaKeyRule.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDnaKeyRule.ForeColor = Color.DarkBlue;
            lblDnaKeyRule.Location = new Point(258, 50);
            lblDnaKeyRule.Name = "lblDnaKeyRule";
            lblDnaKeyRule.Size = new Size(276, 33);
            lblDnaKeyRule.TabIndex = 21;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkBlue;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(583, 823);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 39);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnReset);
            panel7.Controls.Add(btnAnalysis);
            panel7.Controls.Add(btnDecrypt);
            panel7.Controls.Add(btnEncrypt);
            panel7.Location = new Point(583, 875);
            panel7.Name = "panel7";
            panel7.Size = new Size(719, 72);
            panel7.TabIndex = 23;
            // 
            // btnEncrypt
            // 
            btnEncrypt.BackColor = Color.DarkBlue;
            btnEncrypt.ForeColor = Color.White;
            btnEncrypt.Location = new Point(16, 10);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(166, 52);
            btnEncrypt.TabIndex = 24;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = false;
            // 
            // btnDecrypt
            // 
            btnDecrypt.BackColor = Color.DarkBlue;
            btnDecrypt.ForeColor = Color.White;
            btnDecrypt.Location = new Point(188, 10);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(166, 52);
            btnDecrypt.TabIndex = 25;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = false;
            // 
            // btnAnalysis
            // 
            btnAnalysis.BackColor = Color.DarkBlue;
            btnAnalysis.ForeColor = Color.White;
            btnAnalysis.Location = new Point(360, 10);
            btnAnalysis.Name = "btnAnalysis";
            btnAnalysis.Size = new Size(166, 52);
            btnAnalysis.TabIndex = 26;
            btnAnalysis.Text = "Analysis";
            btnAnalysis.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.DarkBlue;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(532, 10);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(166, 52);
            btnReset.TabIndex = 27;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(btnLoadKey);
            panel8.Controls.Add(btnSaveKey);
            panel8.Controls.Add(label28);
            panel8.Controls.Add(label32);
            panel8.Location = new Point(583, 970);
            panel8.Name = "panel8";
            panel8.Size = new Size(719, 156);
            panel8.TabIndex = 22;
            // 
            // label28
            // 
            label28.Font = new Font("72 Monospace", 8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label28.ForeColor = Color.DarkBlue;
            label28.Location = new Point(16, 116);
            label28.Name = "label28";
            label28.Size = new Size(532, 29);
            label28.TabIndex = 13;
            label28.Text = "Export/import 8 parameter ke .txt (Lorenzx4, ACMx3, LM λ)";
            label28.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label32.ForeColor = Color.DarkBlue;
            label32.Location = new Point(16, 15);
            label32.Name = "label32";
            label32.Size = new Size(138, 20);
            label32.TabIndex = 4;
            label32.Text = "Key Management";
            // 
            // btnSaveKey
            // 
            btnSaveKey.BackColor = Color.White;
            btnSaveKey.FlatStyle = FlatStyle.Flat;
            btnSaveKey.ForeColor = Color.DarkSlateBlue;
            btnSaveKey.Location = new Point(16, 51);
            btnSaveKey.Name = "btnSaveKey";
            btnSaveKey.Size = new Size(166, 52);
            btnSaveKey.TabIndex = 28;
            btnSaveKey.Text = "Save Key";
            btnSaveKey.UseVisualStyleBackColor = false;
            // 
            // btnLoadKey
            // 
            btnLoadKey.BackColor = Color.White;
            btnLoadKey.FlatStyle = FlatStyle.Flat;
            btnLoadKey.ForeColor = Color.DarkSlateBlue;
            btnLoadKey.Location = new Point(206, 51);
            btnLoadKey.Name = "btnLoadKey";
            btnLoadKey.Size = new Size(166, 52);
            btnLoadKey.TabIndex = 29;
            btnLoadKey.Text = "Load Key";
            btnLoadKey.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(panel15);
            panel9.Controls.Add(panel14);
            panel9.Controls.Add(panel13);
            panel9.Controls.Add(panel12);
            panel9.Controls.Add(panel11);
            panel9.Controls.Add(panel10);
            panel9.Controls.Add(label31);
            panel9.Location = new Point(583, 1153);
            panel9.Name = "panel9";
            panel9.Size = new Size(1043, 252);
            panel9.TabIndex = 23;
            // 
            // label20
            // 
            label20.BorderStyle = BorderStyle.FixedSingle;
            label20.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.DarkBlue;
            label20.Location = new Point(3, 77);
            label20.Name = "label20";
            label20.Size = new Size(156, 32);
            label20.TabIndex = 21;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label27.ForeColor = Color.DarkBlue;
            label27.Location = new Point(47, 11);
            label27.Name = "label27";
            label27.Size = new Size(63, 20);
            label27.TabIndex = 5;
            label27.Text = "Entropy";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("SF Pro Display", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label31.ForeColor = Color.DarkBlue;
            label31.Location = new Point(16, 15);
            label31.Name = "label31";
            label31.Size = new Size(300, 20);
            label31.TabIndex = 4;
            label31.Text = "Security Analysis Results (panelResults)";
            // 
            // panel10
            // 
            panel10.Controls.Add(label20);
            panel10.Controls.Add(label27);
            panel10.Location = new Point(16, 70);
            panel10.Name = "panel10";
            panel10.Size = new Size(163, 126);
            panel10.TabIndex = 22;
            // 
            // panel11
            // 
            panel11.Controls.Add(label36);
            panel11.Controls.Add(label24);
            panel11.Location = new Point(191, 70);
            panel11.Name = "panel11";
            panel11.Size = new Size(163, 126);
            panel11.TabIndex = 23;
            // 
            // panel12
            // 
            panel12.Controls.Add(label37);
            panel12.Controls.Add(label26);
            panel12.Location = new Point(363, 70);
            panel12.Name = "panel12";
            panel12.Size = new Size(163, 126);
            panel12.TabIndex = 23;
            // 
            // panel13
            // 
            panel13.Controls.Add(label38);
            panel13.Controls.Add(label33);
            panel13.Location = new Point(535, 70);
            panel13.Name = "panel13";
            panel13.Size = new Size(163, 126);
            panel13.TabIndex = 24;
            // 
            // panel14
            // 
            panel14.Controls.Add(label39);
            panel14.Controls.Add(label34);
            panel14.Location = new Point(704, 70);
            panel14.Name = "panel14";
            panel14.Size = new Size(163, 126);
            panel14.TabIndex = 24;
            // 
            // panel15
            // 
            panel15.Controls.Add(label40);
            panel15.Controls.Add(label35);
            panel15.Location = new Point(873, 70);
            panel15.Name = "panel15";
            panel15.Size = new Size(163, 126);
            panel15.TabIndex = 25;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.DarkBlue;
            label24.Location = new Point(47, 11);
            label24.Name = "label24";
            label24.Size = new Size(78, 20);
            label24.TabIndex = 22;
            label24.Text = "NPCR (%)";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.DarkBlue;
            label26.Location = new Point(45, 11);
            label26.Name = "label26";
            label26.Size = new Size(73, 20);
            label26.TabIndex = 23;
            label26.Text = "UACI (%)";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label33.ForeColor = Color.DarkBlue;
            label33.Location = new Point(58, 11);
            label33.Name = "label33";
            label33.Size = new Size(57, 20);
            label33.TabIndex = 24;
            label33.Text = "Corr. H";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.ForeColor = Color.DarkBlue;
            label34.Location = new Point(50, 11);
            label34.Name = "label34";
            label34.Size = new Size(56, 20);
            label34.TabIndex = 25;
            label34.Text = "Corr. V";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label35.ForeColor = Color.DarkBlue;
            label35.Location = new Point(50, 11);
            label35.Name = "label35";
            label35.Size = new Size(57, 20);
            label35.TabIndex = 26;
            label35.Text = "Corr. D";
            // 
            // label36
            // 
            label36.BorderStyle = BorderStyle.FixedSingle;
            label36.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label36.ForeColor = Color.DarkBlue;
            label36.Location = new Point(4, 77);
            label36.Name = "label36";
            label36.Size = new Size(156, 32);
            label36.TabIndex = 22;
            // 
            // label37
            // 
            label37.BorderStyle = BorderStyle.FixedSingle;
            label37.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label37.ForeColor = Color.DarkBlue;
            label37.Location = new Point(4, 77);
            label37.Name = "label37";
            label37.Size = new Size(156, 32);
            label37.TabIndex = 23;
            // 
            // label38
            // 
            label38.BorderStyle = BorderStyle.FixedSingle;
            label38.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label38.ForeColor = Color.DarkBlue;
            label38.Location = new Point(4, 77);
            label38.Name = "label38";
            label38.Size = new Size(156, 32);
            label38.TabIndex = 24;
            // 
            // label39
            // 
            label39.BorderStyle = BorderStyle.FixedSingle;
            label39.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label39.ForeColor = Color.DarkBlue;
            label39.Location = new Point(3, 79);
            label39.Name = "label39";
            label39.Size = new Size(156, 32);
            label39.TabIndex = 25;
            // 
            // label40
            // 
            label40.BorderStyle = BorderStyle.FixedSingle;
            label40.Font = new Font("SF Pro Display", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label40.ForeColor = Color.DarkBlue;
            label40.Location = new Point(4, 78);
            label40.Name = "label40";
            label40.Size = new Size(156, 32);
            label40.TabIndex = 26;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1659, 953);
            ControlBox = false;
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(btnSave);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hyperchaotic DNA Image Encryption — Lorenz 4D + ACM + DNA + Logistic Map";
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picInput).EndInit();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label30;
        private Label label29;
        private Label label25;
        private Panel panel6;
        private Label label23;
        private Label label22;
        private TextBox textNumAcmP;
        private Label label21;
        private Panel panel5;
        private Label label15;
        private Label label14;
        private TextBox txtParamA;
        private Label label10;
        private Label label11;
        private TextBox txtParamB;
        private Label label12;
        private TextBox txtParamC;
        private Label label13;
        private TextBox txtParamH;
        private Label label16;
        private TextBox txtParamTransient;
        private Panel panel4;
        private Label label8;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private TextBox txtnumx0;
        private TextBox txtNumy0;
        private TextBox txtNumz0;
        private TextBox txtNumw0;
        private Label label9;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label label5;
        private Panel panel2;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private Label lblInputImagepath;
        private PictureBox picInput;
        private Button btnBrowse;
        private TextBox txtNumAcmIter;
        private Label label18;
        private TextBox txtNumACMQ;
        private Label label17;
        private TextBox txtNumLogisticLambda;
        private Label label19;
        private Label lblDnaKeyRule;
        private Label lblLogidticX0Value;
        private Button btnSave;
        private Panel panel7;
        private Button btnReset;
        private Button btnAnalysis;
        private Button btnDecrypt;
        private Button btnEncrypt;
        private Panel panel8;
        private Button btnLoadKey;
        private Button btnSaveKey;
        private Label label28;
        private Label label32;
        private Panel panel9;
        private Panel panel10;
        private Label label20;
        private Label label27;
        private Label label31;
        private Panel panel15;
        private Panel panel14;
        private Panel panel13;
        private Panel panel12;
        private Panel panel11;
        private Label label40;
        private Label label35;
        private Label label39;
        private Label label34;
        private Label label38;
        private Label label33;
        private Label label37;
        private Label label26;
        private Label label36;
        private Label label24;
    }
}
