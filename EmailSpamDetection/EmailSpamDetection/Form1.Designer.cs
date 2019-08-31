namespace EmailSpamDetection
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_accurency = new System.Windows.Forms.TextBox();
            this.button_predict = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_testPredict = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_run = new System.Windows.Forms.Button();
            this.button_browse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_pathFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_splitTrain = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 322);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_accurency);
            this.groupBox2.Controls.Add(this.button_predict);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_testPredict);
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(766, 269);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // textBox_accurency
            // 
            this.textBox_accurency.Location = new System.Drawing.Point(79, 23);
            this.textBox_accurency.Name = "textBox_accurency";
            this.textBox_accurency.ReadOnly = true;
            this.textBox_accurency.Size = new System.Drawing.Size(100, 20);
            this.textBox_accurency.TabIndex = 2;
            // 
            // button_predict
            // 
            this.button_predict.Location = new System.Drawing.Point(674, 237);
            this.button_predict.Name = "button_predict";
            this.button_predict.Size = new System.Drawing.Size(75, 23);
            this.button_predict.TabIndex = 4;
            this.button_predict.Text = "Predict";
            this.button_predict.UseVisualStyleBackColor = true;
            this.button_predict.Click += new System.EventHandler(this.Button_predict_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Accurency:";
            // 
            // textBox_testPredict
            // 
            this.textBox_testPredict.Location = new System.Drawing.Point(15, 59);
            this.textBox_testPredict.Multiline = true;
            this.textBox_testPredict.Name = "textBox_testPredict";
            this.textBox_testPredict.Size = new System.Drawing.Size(734, 172);
            this.textBox_testPredict.TabIndex = 3;
            this.textBox_testPredict.Text = "Test Predict";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_run);
            this.groupBox1.Controls.Add(this.button_browse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_pathFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_splitTrain);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(660, 17);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(89, 23);
            this.button_run.TabIndex = 5;
            this.button_run.Text = "Run";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.Button_run_Click);
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(574, 17);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(75, 23);
            this.button_browse.TabIndex = 4;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.Button_browse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Path Folder:";
            // 
            // textBox_pathFolder
            // 
            this.textBox_pathFolder.Location = new System.Drawing.Point(295, 19);
            this.textBox_pathFolder.Name = "textBox_pathFolder";
            this.textBox_pathFolder.Size = new System.Drawing.Size(273, 20);
            this.textBox_pathFolder.TabIndex = 2;
            this.textBox_pathFolder.Text = "D:\\LearningC#\\page\\Naive bayes\\Email Spam\\EmailSpamDetection\\EmailSpamDetection\\e" +
    "nron";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Split Train (percent): ";
            // 
            // textBox_splitTrain
            // 
            this.textBox_splitTrain.Location = new System.Drawing.Point(116, 19);
            this.textBox_splitTrain.Name = "textBox_splitTrain";
            this.textBox_splitTrain.Size = new System.Drawing.Size(100, 20);
            this.textBox_splitTrain.TabIndex = 0;
            this.textBox_splitTrain.Text = "80";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 352);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Spam Detection";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_splitTrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_pathFolder;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_accurency;
        private System.Windows.Forms.TextBox textBox_testPredict;
        private System.Windows.Forms.Button button_predict;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

