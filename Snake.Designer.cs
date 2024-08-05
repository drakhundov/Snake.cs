namespace Snake.cs
{
    partial class Snake
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Snake));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.empty = new System.Windows.Forms.PictureBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonGoesThroughWall = new System.Windows.Forms.Button();
            this.buttonDecreasesThroughWall = new System.Windows.Forms.Button();
            this.buttonEatsHimself = new System.Windows.Forms.Button();
            this.buttonKillsHimself = new System.Windows.Forms.Button();
            this.buttonEndSettings = new System.Windows.Forms.Button();
            this.MadeBy = new System.Windows.Forms.Button();
            this.AbdulAkhundzade = new System.Windows.Forms.Button();
            this.SoundTrackButton = new System.Windows.Forms.Button();
            this.musicNameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.empty)).BeginInit();
            this.SuspendLayout();
            // 
            // empty
            // 
            this.empty.BackColor = System.Drawing.Color.Transparent;
            this.empty.Location = new System.Drawing.Point(680, 0);
            this.empty.Name = "empty";
            this.empty.Size = new System.Drawing.Size(125, 729);
            this.empty.TabIndex = 0;
            this.empty.TabStop = false;
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.buttonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSettings.Location = new System.Drawing.Point(248, 30);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(140, 55);
            this.buttonSettings.TabIndex = 8;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            // 
            // buttonGoesThroughWall
            // 
            this.buttonGoesThroughWall.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonGoesThroughWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGoesThroughWall.Location = new System.Drawing.Point(55, 132);
            this.buttonGoesThroughWall.Name = "buttonGoesThroughWall";
            this.buttonGoesThroughWall.Size = new System.Drawing.Size(240, 40);
            this.buttonGoesThroughWall.TabIndex = 9;
            this.buttonGoesThroughWall.Text = "Goes Through Wall";
            this.buttonGoesThroughWall.UseVisualStyleBackColor = false;
            this.buttonGoesThroughWall.Click += new System.EventHandler(this.buttonGoesThroughWall_Click);
            // 
            // buttonDecreasesThroughWall
            // 
            this.buttonDecreasesThroughWall.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonDecreasesThroughWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDecreasesThroughWall.Location = new System.Drawing.Point(332, 132);
            this.buttonDecreasesThroughWall.Name = "buttonDecreasesThroughWall";
            this.buttonDecreasesThroughWall.Size = new System.Drawing.Size(240, 40);
            this.buttonDecreasesThroughWall.TabIndex = 10;
            this.buttonDecreasesThroughWall.Text = "Decreases Through Wall";
            this.buttonDecreasesThroughWall.UseVisualStyleBackColor = false;
            this.buttonDecreasesThroughWall.Click += new System.EventHandler(this.buttonDecreasesThroughWall_Click);
            // 
            // buttonEatsHimself
            // 
            this.buttonEatsHimself.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonEatsHimself.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEatsHimself.Location = new System.Drawing.Point(55, 231);
            this.buttonEatsHimself.Name = "buttonEatsHimself";
            this.buttonEatsHimself.Size = new System.Drawing.Size(240, 40);
            this.buttonEatsHimself.TabIndex = 11;
            this.buttonEatsHimself.Text = "Eats Himself";
            this.buttonEatsHimself.UseVisualStyleBackColor = false;
            this.buttonEatsHimself.Click += new System.EventHandler(this.buttonEatsHimself_Click);
            // 
            // buttonKillsHimself
            // 
            this.buttonKillsHimself.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonKillsHimself.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonKillsHimself.Location = new System.Drawing.Point(332, 231);
            this.buttonKillsHimself.Name = "buttonKillsHimself";
            this.buttonKillsHimself.Size = new System.Drawing.Size(240, 40);
            this.buttonKillsHimself.TabIndex = 12;
            this.buttonKillsHimself.Text = "Kills Himself";
            this.buttonKillsHimself.UseVisualStyleBackColor = false;
            this.buttonKillsHimself.Click += new System.EventHandler(this.buttonKillsHimself_Click);
            // 
            // buttonEndSettings
            // 
            this.buttonEndSettings.BackColor = System.Drawing.Color.Red;
            this.buttonEndSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.buttonEndSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEndSettings.Location = new System.Drawing.Point(584, 290);
            this.buttonEndSettings.Name = "buttonEndSettings";
            this.buttonEndSettings.Size = new System.Drawing.Size(75, 26);
            this.buttonEndSettings.TabIndex = 13;
            this.buttonEndSettings.Text = "Next";
            this.buttonEndSettings.UseVisualStyleBackColor = false;
            this.buttonEndSettings.Click += new System.EventHandler(this.buttonEndSettings_Click);
            // 
            // MadeBy
            // 
            this.MadeBy.BackColor = System.Drawing.Color.Red;
            this.MadeBy.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MadeBy.Location = new System.Drawing.Point(796, 12);
            this.MadeBy.Name = "MadeBy";
            this.MadeBy.Size = new System.Drawing.Size(315, 104);
            this.MadeBy.TabIndex = 14;
            this.MadeBy.Text = "Made By";
            this.MadeBy.UseVisualStyleBackColor = false;
            // 
            // AbdulAkhundzade
            // 
            this.AbdulAkhundzade.BackColor = System.Drawing.Color.Red;
            this.AbdulAkhundzade.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AbdulAkhundzade.Location = new System.Drawing.Point(841, 122);
            this.AbdulAkhundzade.Name = "AbdulAkhundzade";
            this.AbdulAkhundzade.Size = new System.Drawing.Size(238, 71);
            this.AbdulAkhundzade.TabIndex = 15;
            this.AbdulAkhundzade.Text = "Abdul Akhundzade";
            this.AbdulAkhundzade.UseVisualStyleBackColor = false;
            // 
            // SoundTrackButton
            // 
            this.SoundTrackButton.BackColor = System.Drawing.Color.Lime;
            this.SoundTrackButton.Location = new System.Drawing.Point(495, 30);
            this.SoundTrackButton.Name = "SoundTrackButton";
            this.SoundTrackButton.Size = new System.Drawing.Size(76, 23);
            this.SoundTrackButton.TabIndex = 16;
            this.SoundTrackButton.Text = "SoundTrack";
            this.SoundTrackButton.UseVisualStyleBackColor = false;
            this.SoundTrackButton.Click += new System.EventHandler(this.SoundTrackButton_Click);
            // 
            // musicNameButton
            // 
            this.musicNameButton.BackColor = System.Drawing.Color.Gold;
            this.musicNameButton.Location = new System.Drawing.Point(524, 62);
            this.musicNameButton.Name = "musicNameButton";
            this.musicNameButton.Size = new System.Drawing.Size(75, 23);
            this.musicNameButton.TabIndex = 17;
            this.musicNameButton.Text = "Change ";
            this.musicNameButton.UseVisualStyleBackColor = false;
            this.musicNameButton.Click += new System.EventHandler(this.musicNameButton_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(806, 384);
            this.Controls.Add(this.musicNameButton);
            this.Controls.Add(this.SoundTrackButton);
            this.Controls.Add(this.AbdulAkhundzade);
            this.Controls.Add(this.MadeBy);
            this.Controls.Add(this.buttonEndSettings);
            this.Controls.Add(this.buttonKillsHimself);
            this.Controls.Add(this.buttonEatsHimself);
            this.Controls.Add(this.buttonDecreasesThroughWall);
            this.Controls.Add(this.buttonGoesThroughWall);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.empty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox empty;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonGoesThroughWall;
        private System.Windows.Forms.Button buttonDecreasesThroughWall;
        private System.Windows.Forms.Button buttonEatsHimself;
        private System.Windows.Forms.Button buttonKillsHimself;
        private System.Windows.Forms.Button buttonEndSettings;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button MadeBy;
        private System.Windows.Forms.Button AbdulAkhundzade;
        private System.Windows.Forms.Button SoundTrackButton;
        private System.Windows.Forms.Button musicNameButton;
    }
}

