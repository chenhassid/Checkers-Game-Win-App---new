namespace GameUI05
{
    public partial class StartGameForm
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
            this.radioButtonSize6 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize8 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize10 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonSize6
            // 
            this.radioButtonSize6.AutoSize = true;
            this.radioButtonSize6.Location = new System.Drawing.Point(32, 59);
            this.radioButtonSize6.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButtonSize6.Name = "radioButtonSize6";
            this.radioButtonSize6.Size = new System.Drawing.Size(64, 23);
            this.radioButtonSize6.TabIndex = 0;
            this.radioButtonSize6.Text = "6 X 6";
            this.radioButtonSize6.UseVisualStyleBackColor = true;
            this.radioButtonSize6.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonSize8
            // 
            this.radioButtonSize8.AutoSize = true;
            this.radioButtonSize8.Location = new System.Drawing.Point(160, 59);
            this.radioButtonSize8.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButtonSize8.Name = "radioButtonSize8";
            this.radioButtonSize8.Size = new System.Drawing.Size(64, 23);
            this.radioButtonSize8.TabIndex = 1;
            this.radioButtonSize8.Text = "8 X 8";
            this.radioButtonSize8.UseVisualStyleBackColor = true;
            // 
            // radioButtonSize10
            // 
            this.radioButtonSize10.AutoSize = true;
            this.radioButtonSize10.Location = new System.Drawing.Point(270, 59);
            this.radioButtonSize10.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButtonSize10.Name = "radioButtonSize10";
            this.radioButtonSize10.Size = new System.Drawing.Size(82, 23);
            this.radioButtonSize10.TabIndex = 2;
            this.radioButtonSize10.Text = "10 X 10";
            this.radioButtonSize10.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Board Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Players:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player 1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Player 2:";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(45, 194);
            this.checkBoxPlayer2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPlayer2.TabIndex = 7;
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.Click += new System.EventHandler(this.checkBoxPlayer2_Click);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(199, 148);
            this.textBoxPlayer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(164, 26);
            this.textBoxPlayer1.TabIndex = 8;
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.AcceptsReturn = true;
            this.textBoxPlayer2.AcceptsTab = true;
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(199, 191);
            this.textBoxPlayer2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(164, 26);
            this.textBoxPlayer2.TabIndex = 9;
            this.textBoxPlayer2.Text = "[Computer]";
            this.textBoxPlayer2.TextChanged += new System.EventHandler(this.textBoxPlayer2_TextChanged);
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(238, 245);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(125, 34);
            this.buttonDone.TabIndex = 10;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // StartGameForm
            // 
            this.AcceptButton = this.buttonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 296);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonSize10);
            this.Controls.Add(this.radioButtonSize8);
            this.Controls.Add(this.radioButtonSize6);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.StartGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButtonSize6;
        private System.Windows.Forms.RadioButton radioButtonSize8;
        private System.Windows.Forms.RadioButton radioButtonSize10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Button buttonDone;
    }
}
