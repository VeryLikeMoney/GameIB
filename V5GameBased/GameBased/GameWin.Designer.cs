
namespace GameBased
{
    partial class GameWin
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btncontinuegame = new System.Windows.Forms.Button();
            this.btnnewgame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.richTextBox1.Location = new System.Drawing.Point(128, 133);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(547, 193);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(256, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 62);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поздравляю";
            // 
            // btncontinuegame
            // 
            this.btncontinuegame.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btncontinuegame.Location = new System.Drawing.Point(128, 349);
            this.btncontinuegame.Name = "btncontinuegame";
            this.btncontinuegame.Size = new System.Drawing.Size(241, 80);
            this.btncontinuegame.TabIndex = 2;
            this.btncontinuegame.Text = "Продолжить";
            this.btncontinuegame.UseVisualStyleBackColor = true;
            this.btncontinuegame.Click += new System.EventHandler(this.btncontinuegame_Click);
            // 
            // btnnewgame
            // 
            this.btnnewgame.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnnewgame.Location = new System.Drawing.Point(434, 349);
            this.btnnewgame.Name = "btnnewgame";
            this.btnnewgame.Size = new System.Drawing.Size(241, 80);
            this.btnnewgame.TabIndex = 3;
            this.btnnewgame.Text = "Новая Игра";
            this.btnnewgame.UseVisualStyleBackColor = true;
            this.btnnewgame.Click += new System.EventHandler(this.btnnewgame_Click);
            // 
            // GameWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.btnnewgame);
            this.Controls.Add(this.btncontinuegame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "GameWin";
            this.Text = "WindowsForms";
            this.Load += new System.EventHandler(this.GameWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btncontinuegame;
        private System.Windows.Forms.Button btnnewgame;
    }
}