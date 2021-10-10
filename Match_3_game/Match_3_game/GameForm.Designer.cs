
namespace Match_3_game
{
    partial class GameForm
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
            this.gameMapPictureBox = new System.Windows.Forms.PictureBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameMapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameMapPictureBox
            // 
            this.gameMapPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.gameMapPictureBox.Location = new System.Drawing.Point(3, 3);
            this.gameMapPictureBox.Name = "gameMapPictureBox";
            this.gameMapPictureBox.Size = new System.Drawing.Size(500, 500);
            this.gameMapPictureBox.TabIndex = 2;
            this.gameMapPictureBox.TabStop = false;
            this.gameMapPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameMapPictureBox_MouseDown);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerLabel.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timerLabel.ForeColor = System.Drawing.Color.Black;
            this.timerLabel.Location = new System.Drawing.Point(392, 521);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(57, 27);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "0:00";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.ForeColor = System.Drawing.Color.Black;
            this.scoreLabel.Location = new System.Drawing.Point(51, 521);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(98, 27);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Score: 0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Match_3_game.Properties.Resources.game_form_background;
            this.ClientSize = new System.Drawing.Size(506, 568);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.gameMapPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match-Three";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gameMapPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameMapPictureBox;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label scoreLabel;
    }
}