using System.ComponentModel;
using System.Net;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace NIP_Manager
{
	public partial class Master : Form
	{
		bool strike_installed = false;
		public Master()
		{
			InitializeComponent();
		}

		private void Master_Load(object sender, EventArgs e)
		{
			if(!AccessableViaGithub("https://github.com/XnipS/Oxide"))
			{
				oxide_status.Text = "Status: Unavailable";
			}
			if(!AccessableViaGithub("https://github.com/XnipS/StrikeWarfare"))
			{
				strike_status.Text = "Status: Unavailable";
			}

			strike_installed = Directory.Exists(Main.Default.strike_path + "/StrikeWarfare");
			if(strike_installed)
			{
				strike_status.Text = "Status: Ready";
				strike_install.Enabled = true;
				strike_install.Text = "Uninstall";
				strike_repair.Enabled = true;
				strike_play.Enabled = true;
				strike_progress.Value = 0;
			}
			else
			{
				strike_status.Text = "Status: Not Installed";
				strike_install.Enabled = true;
				strike_install.Text = "Install";
				strike_repair.Enabled = false;
				strike_play.Enabled = false;
				strike_progress.Value = 0;
			}
		}

		private bool AccessableViaGithub(string url)
		{
			try
			{
				HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
				request.Method = "HEAD";
				HttpWebResponse response = request.GetResponse() as HttpWebResponse;
				response.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void strike_install_Click(object sender, EventArgs e)
		{
			strike_install.Enabled = false;
			strike_repair.Enabled = false;
			strike_play.Enabled = false;
			if(!strike_installed)
			{
				install_strike_dialog();
			}
			else
			{
				uninstall_strike();
			}
		}

		private void uninstall_strike()
		{

			if(!Directory.Exists(Main.Default.strike_path + "/StrikeWarfare"))
			{ return; }
			Directory.Delete(Main.Default.strike_path + "/StrikeWarfare", true);
			refresh_master();
		}

		private void install_strike_dialog()
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.InitialDirectory = Main.Default.strike_path;
			if(dialog.ShowDialog() != DialogResult.OK)
			{ return; }

			Main.Default.strike_path = dialog.SelectedPath;
			Main.Default.Save();

			install_strike();
		}

		private void install_strike()
		{
			strike_status.Text = "Status: Downloading";

			using(WebClient webClient = new WebClient())
			{
				webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(strike_progress_completed);
				webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(strike_progress_change);
				webClient.DownloadFileAsync(new Uri("https://github.com/XnipS/StrikeWarfare/releases/download/v0.0.1/StrikeWarfare_27-11-2022_13-17.tar.gz"), Main.Default.strike_path + "/temp.tar.gz");
			}
		}

		private void refresh_master()
		{
			Master next = new Master();
			next.Activate();
			next.Show();
			this.Owner = next;
			this.Hide();
		}

		private void strike_progress_change(object sender, DownloadProgressChangedEventArgs e)
		{
			strike_progress.Value = e.ProgressPercentage;
		}

		private void strike_progress_completed(object sender, AsyncCompletedEventArgs e)
		{
			strike_status.Text = "Status: Extracting";
			strike_progress.Value = 25;
			UNTAR(Main.Default.strike_path + "/temp.tar.gz", Main.Default.strike_path + "/StrikeWarfare");
			strike_progress.Value = 50;
			strike_status.Text = "Status: Cleaning";
			File.Delete(Main.Default.strike_path + "/temp.tar.gz");
			strike_progress.Value = 100;
			strike_status.Text = "Status: Done";

			refresh_master();
		}

		private void strike_repair_Click(object sender, EventArgs e)
		{
			strike_install.Enabled = false;
			strike_repair.Enabled = false;
			strike_play.Enabled = false;
			install_strike();
		}

		private void strike_play_Click(object sender, EventArgs e)
		{
			using(System.Diagnostics.Process newprocess = new System.Diagnostics.Process())
			{
				newprocess.StartInfo.FileName = Main.Default.strike_path + "/StrikeWarfare/StrikeWarfare.exe";
				//newprocess.StartInfo.Arguments = "olaa"; //argument
				newprocess.Start();
			}
			this.Close();
		}

		public static void UNTAR(String input, String output)
		{
			Directory.CreateDirectory(output);
			using(Stream stream = File.OpenRead(input))
			{
				var reader = ReaderFactory.Open(stream);
				while(reader.MoveToNextEntry())
				{
					if(!reader.Entry.IsDirectory)
					{
						ExtractionOptions opt = new ExtractionOptions
						{
							ExtractFullPath = true,
							Overwrite = true
						};
						reader.WriteEntryToDirectory(output, opt);
					}
				}
			}
		}
	}
}