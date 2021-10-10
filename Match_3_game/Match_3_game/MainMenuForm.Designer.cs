
namespace Match_3_game
{
    partial class MainMenuForm
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
            this.playButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playButton.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playButton.ForeColor = System.Drawing.Color.Black;
            this.playButton.Location = new System.Drawing.Point(87, 59);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(99, 41);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Match_3_game.Properties.Resources.main_menu_form_background;
            this.ClientSize = new System.Drawing.Size(274, 167);
            this.Controls.Add(this.playButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match-Three";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playButton;
    }
}

