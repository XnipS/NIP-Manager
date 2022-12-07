namespace NIP_Manager
{
	partial class Master
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
			if(disposing && (components != null))
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master));
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.strike_title = new System.Windows.Forms.Label();
			this.strike_status = new System.Windows.Forms.Label();
			this.strike_install = new System.Windows.Forms.Button();
			this.strike_repair = new System.Windows.Forms.Button();
			this.strike_progress = new System.Windows.Forms.ProgressBar();
			this.strike_play = new System.Windows.Forms.Button();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.oxide_status = new System.Windows.Forms.Label();
			this.oxide_install = new System.Windows.Forms.Button();
			this.oxide_repair = new System.Windows.Forms.Button();
			this.oxide_progress = new System.Windows.Forms.ProgressBar();
			this.oxide_play = new System.Windows.Forms.Button();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.strike_title);
			this.flowLayoutPanel1.Controls.Add(this.strike_status);
			this.flowLayoutPanel1.Controls.Add(this.strike_install);
			this.flowLayoutPanel1.Controls.Add(this.strike_repair);
			this.flowLayoutPanel1.Controls.Add(this.strike_progress);
			this.flowLayoutPanel1.Controls.Add(this.strike_play);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(206, 190);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// strike_title
			// 
			this.strike_title.AutoSize = true;
			this.strike_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.strike_title.Location = new System.Drawing.Point(3, 0);
			this.strike_title.Name = "strike_title";
			this.strike_title.Size = new System.Drawing.Size(150, 30);
			this.strike_title.TabIndex = 0;
			this.strike_title.Text = "Strike Warfare";
			// 
			// strike_status
			// 
			this.strike_status.AutoSize = true;
			this.strike_status.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.strike_status.Location = new System.Drawing.Point(3, 30);
			this.strike_status.Name = "strike_status";
			this.strike_status.Size = new System.Drawing.Size(126, 21);
			this.strike_status.TabIndex = 1;
			this.strike_status.Text = "Status: Unknown";
			// 
			// strike_install
			// 
			this.strike_install.Enabled = false;
			this.strike_install.Location = new System.Drawing.Point(3, 54);
			this.strike_install.Name = "strike_install";
			this.strike_install.Size = new System.Drawing.Size(200, 23);
			this.strike_install.TabIndex = 2;
			this.strike_install.Text = "Install";
			this.strike_install.UseVisualStyleBackColor = true;
			this.strike_install.Click += new System.EventHandler(this.strike_install_Click);
			// 
			// strike_repair
			// 
			this.strike_repair.Enabled = false;
			this.strike_repair.Location = new System.Drawing.Point(3, 83);
			this.strike_repair.Name = "strike_repair";
			this.strike_repair.Size = new System.Drawing.Size(200, 23);
			this.strike_repair.TabIndex = 3;
			this.strike_repair.Text = "Repair";
			this.strike_repair.UseVisualStyleBackColor = true;
			this.strike_repair.Click += new System.EventHandler(this.strike_repair_Click);
			// 
			// strike_progress
			// 
			this.strike_progress.Location = new System.Drawing.Point(3, 112);
			this.strike_progress.Name = "strike_progress";
			this.strike_progress.Size = new System.Drawing.Size(200, 23);
			this.strike_progress.TabIndex = 4;
			// 
			// strike_play
			// 
			this.strike_play.Enabled = false;
			this.strike_play.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.strike_play.Location = new System.Drawing.Point(3, 141);
			this.strike_play.Name = "strike_play";
			this.strike_play.Size = new System.Drawing.Size(200, 46);
			this.strike_play.TabIndex = 5;
			this.strike_play.Text = "Play";
			this.strike_play.UseVisualStyleBackColor = true;
			this.strike_play.Click += new System.EventHandler(this.strike_play_Click);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel2.Controls.Add(this.label2);
			this.flowLayoutPanel2.Controls.Add(this.oxide_status);
			this.flowLayoutPanel2.Controls.Add(this.oxide_install);
			this.flowLayoutPanel2.Controls.Add(this.oxide_repair);
			this.flowLayoutPanel2.Controls.Add(this.oxide_progress);
			this.flowLayoutPanel2.Controls.Add(this.oxide_play);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(215, 3);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(206, 190);
			this.flowLayoutPanel2.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 30);
			this.label2.TabIndex = 0;
			this.label2.Text = "Oxide";
			// 
			// oxide_status
			// 
			this.oxide_status.AutoSize = true;
			this.oxide_status.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.oxide_status.Location = new System.Drawing.Point(3, 30);
			this.oxide_status.Name = "oxide_status";
			this.oxide_status.Size = new System.Drawing.Size(126, 21);
			this.oxide_status.TabIndex = 1;
			this.oxide_status.Text = "Status: Unknown";
			// 
			// oxide_install
			// 
			this.oxide_install.Enabled = false;
			this.oxide_install.Location = new System.Drawing.Point(3, 54);
			this.oxide_install.Name = "oxide_install";
			this.oxide_install.Size = new System.Drawing.Size(200, 23);
			this.oxide_install.TabIndex = 2;
			this.oxide_install.Text = "Install";
			this.oxide_install.UseVisualStyleBackColor = true;
			// 
			// oxide_repair
			// 
			this.oxide_repair.Enabled = false;
			this.oxide_repair.Location = new System.Drawing.Point(3, 83);
			this.oxide_repair.Name = "oxide_repair";
			this.oxide_repair.Size = new System.Drawing.Size(200, 23);
			this.oxide_repair.TabIndex = 3;
			this.oxide_repair.Text = "Repair";
			this.oxide_repair.UseVisualStyleBackColor = true;
			// 
			// oxide_progress
			// 
			this.oxide_progress.Location = new System.Drawing.Point(3, 112);
			this.oxide_progress.Name = "oxide_progress";
			this.oxide_progress.Size = new System.Drawing.Size(200, 23);
			this.oxide_progress.TabIndex = 4;
			// 
			// oxide_play
			// 
			this.oxide_play.Enabled = false;
			this.oxide_play.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.oxide_play.Location = new System.Drawing.Point(3, 141);
			this.oxide_play.Name = "oxide_play";
			this.oxide_play.Size = new System.Drawing.Size(200, 46);
			this.oxide_play.TabIndex = 5;
			this.oxide_play.Text = "Play";
			this.oxide_play.UseVisualStyleBackColor = true;
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel1);
			this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel2);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(12, 12);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(424, 196);
			this.flowLayoutPanel3.TabIndex = 2;
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.Description = "Select Location";
			this.folderBrowserDialog1.UseDescriptionForTitle = true;
			// 
			// Master
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.flowLayoutPanel3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Master";
			this.Text = "NIP-Manager";
			this.Load += new System.EventHandler(this.Master_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private FlowLayoutPanel flowLayoutPanel1;
		private Label strike_title;
		private Label strike_status;
		private Button strike_install;
		private Button strike_repair;
		private ProgressBar strike_progress;
		private Button strike_play;
		private FlowLayoutPanel flowLayoutPanel2;
		private Label label2;
		private Label oxide_status;
		private Button oxide_install;
		private Button oxide_repair;
		private ProgressBar oxide_progress;
		private Button oxide_play;
		private FlowLayoutPanel flowLayoutPanel3;
		private FolderBrowserDialog folderBrowserDialog1;
	}
}