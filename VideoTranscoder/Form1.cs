using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoTranscoderCore;

namespace VideoTranscoder
{
	public partial class Form1 : Form
	{
		private int _codecType = 0;
		private TranscodeCore.ProResProfile _proResProfile = TranscodeCore.ProResProfile.YUV422HQ;
		private TranscodeCore.TransFrameSize _frameSize = TranscodeCore.TransFrameSize.P1080;
		private TranscodeCore.TransFrameRate _frameRate = TranscodeCore.TransFrameRate.Frames24;
		private TranscodeCore.ColorBits _colorBits = TranscodeCore.ColorBits.Bit8;
		private TranscodeCore.ChromaSubSampling _chromaSubSampling = TranscodeCore.ChromaSubSampling.Med422;

		private string _sourceFilename = "";
		private string _batchSourceFolder = "";
		ParallelOptions _batchParallelOptions;
		TranscodeCore.TransCodec _batchCodec = TranscodeCore.TransCodec.ProRes;
		private bool _isSingle = false;
		List<Transcoder> _processes = new List<Transcoder>();

		public Form1()
		{
			InitializeComponent();
			try
			{
				ddlCodec.SelectedIndex = 0;

				//Watcher watch = new Watcher();
				//watch.WatchFolder("p:\\Video");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ddlCodec_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlCodec.SelectedIndex == 0)
			{
				//ProRes
				grpDNxOptions.Visible = false;
				grpProResOptions.Visible = true;

				//ddlProResSetting.Items.Add("Proxy");
				//ddlProResSetting.Items.Add("LT");
				//ddlProResSetting.Items.Add("Standard");
				//ddlProResSetting.Items.Add("422HQ");
				//ddlProResSetting.Items.Add("4444");
				//ddlProResSetting.Items.Add("4444XQ");
			}
			else
			{
				//DNxHD
				grpDNxOptions.Visible = true;
				grpProResOptions.Visible = false;
			}
		}

		private void ddlResolution_SelectedIndexChanged(object sender, EventArgs e)
		{
			TranscodeCore.TransFrameSize frameSize = (TranscodeCore.TransFrameSize)(int)ddlResolution.SelectedIndex;

			if (frameSize == TranscodeCore.TransFrameSize.P4k)
			{
				ddlFrameRate.Enabled = false;

			}
			else
			{
				ddlFrameRate.Enabled = true;
			}
		}

		#region Single

		private void btnBrowseSource_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "*.mp4 |*.mp4;*.avi";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_sourceFilename = dialog.FileName;
				txtSourceFilename.Text = _sourceFilename;
				rtbStatus.Text = "Ready to process " + Path.GetFileName(_sourceFilename);
			}
		}

		private void btnTranscode_Click(object sender, EventArgs e)
		{
			if (!_encodeBackgroundWorker.IsBusy)
			{
				_isSingle = true;
				rtbStatus.Clear();
				LockControls();

				if (ddlCodec.SelectedIndex > -1)
				{
					_codecType = ddlCodec.SelectedIndex;
				}
				if (ddlProResSetting.SelectedIndex > -1)
				{
					_proResProfile = (TranscodeCore.ProResProfile)ddlProResSetting.SelectedIndex;
				}
				if (ddlResolution.SelectedIndex > -1)
				{
					_frameSize = (TranscodeCore.TransFrameSize)(int)ddlResolution.SelectedIndex;
				}
				if (ddlFrameRate.SelectedIndex > -1)
				{
					_frameRate = (TranscodeCore.TransFrameRate)(int)ddlFrameRate.SelectedIndex;
				}
				if (ddlColorDepth.SelectedIndex > -1)
				{
					_colorBits = (TranscodeCore.ColorBits)(int)ddlColorDepth.SelectedIndex;
				}
				if (ddlChromaSampling.SelectedIndex > -1)
				{
					_chromaSubSampling = (TranscodeCore.ChromaSubSampling)(int)ddlChromaSampling.SelectedIndex;
				}

				_batchParallelOptions = new ParallelOptions();
				_batchParallelOptions.MaxDegreeOfParallelism = 1;
				_batchCodec = (TranscodeCore.TransCodec)ddlCodec.SelectedIndex;
				_encodeBackgroundWorker.RunWorkerAsync();
			}
		}

		private void btnSingleCancel_Click(object sender, EventArgs e)
		{
			rtbStatus.Text += "\n--Stopping transcode - this may take a while--";
			_encodeBackgroundWorker.CancelAsync();

			foreach (Transcoder transcoder in _processes)
			{
				transcoder.Kill();
			}
		}
		#endregion

		#region Batch

		private void btnBrowseFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_batchSourceFolder = dialog.SelectedPath;
				txtSourceFolder.Text = _batchSourceFolder;
				rtbStatus.Text = "Selected " + dialog.SelectedPath + " for batch processing.";
			}
		}

		private void btnBatch_Click(object sender, EventArgs e)
		{
			if (!_encodeBackgroundWorker.IsBusy)
			{
				_isSingle = false;
				rtbStatus.Clear();
				LockControls();

				if (ddlCodec.SelectedIndex > -1)
				{
					_codecType = ddlCodec.SelectedIndex;
				}
				if (ddlProResSetting.SelectedIndex > -1)
				{
					_proResProfile = (TranscodeCore.ProResProfile)ddlProResSetting.SelectedIndex;
				}
				if (ddlResolution.SelectedIndex > -1)
				{
					_frameSize = (TranscodeCore.TransFrameSize)(int)ddlResolution.SelectedIndex;
				}
				if (ddlFrameRate.SelectedIndex > -1)
				{
					_frameRate = (TranscodeCore.TransFrameRate)(int)ddlFrameRate.SelectedIndex;
				}
				if (ddlColorDepth.SelectedIndex > -1)
				{
					_colorBits = (TranscodeCore.ColorBits)(int)ddlColorDepth.SelectedIndex;
				}
				if (ddlChromaSampling.SelectedIndex > -1)
				{
					_chromaSubSampling = (TranscodeCore.ChromaSubSampling)(int)ddlChromaSampling.SelectedIndex;
				}

				_batchParallelOptions = new ParallelOptions();
				if (ddlThreads.SelectedIndex > -1)
				{
					_batchParallelOptions.MaxDegreeOfParallelism = ddlThreads.SelectedIndex;
				}
				else {
					_batchParallelOptions.MaxDegreeOfParallelism = 1;
				}
				_batchCodec = (TranscodeCore.TransCodec)ddlCodec.SelectedIndex;
				_encodeBackgroundWorker.RunWorkerAsync();
			}
		}

		private void btnBatchCancel_Click(object sender, EventArgs e)
		{
			rtbStatus.Text += "\n--Stopping transcode - this may take a while--";
			_encodeBackgroundWorker.CancelAsync();

			foreach (Transcoder transcoder in _processes)
			{
				transcoder.Kill();
			}
		}

		private void _encodeBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			_processes = new List<Transcoder>();

			string[] sourceFiles;
			if (_isSingle)
			{
				sourceFiles = new string[1];
				sourceFiles[0] = _sourceFilename;
			}
			else {
				sourceFiles = Directory.EnumerateFiles(_batchSourceFolder, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.ToLower().EndsWith(".mp4") || s.ToLower().EndsWith(".avi")).ToArray();
			}

			Parallel.ForEach(sourceFiles, _batchParallelOptions, (sourceFile, state) =>
			{
				if (worker.CancellationPending)
				{
					state.Break();
					e.Cancel = true;
				}
				else
				{
					string targetFilename = TranscodeCore.GetTargetFilename(sourceFile, _batchCodec);
					string command = "";
					if (_codecType == 0)
					{
						command = TranscodeCore.GetProResCommandString(_proResProfile, sourceFile);
					}
					else
					{
						command = TranscodeCore.GetDNxHDCommandString(sourceFile, _frameSize, _frameRate, _colorBits, _chromaSubSampling);
					}

					worker.ReportProgress(0, "Starting transcode of " + Path.GetFileName(sourceFile) + "...");
					Transcoder newTranscoder = new Transcoder();
					_processes.Add(newTranscoder);
					if (newTranscoder.TranscodeVideo(command, targetFilename) && !worker.CancellationPending)
					{
						worker.ReportProgress(0, "Success: " + Path.GetFileName(sourceFile));
					}
					else if (worker.CancellationPending)
					{
						worker.ReportProgress(0, "Cancelled: " + Path.GetFileName(sourceFile));
					}
					else
					{
						worker.ReportProgress(0, "Failed: " + Path.GetFileName(sourceFile));
					}
				}
			});
						
		}

		private void _encodeBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			rtbStatus.Text += "\n" + e.UserState.ToString();
			ScrollToEnd();
		}

		private void _encodeBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				rtbStatus.Text += "\nTranscode cancelled";
			}
			else {
				rtbStatus.Text += "\nTranscode complete";
			}
			ScrollToEnd();
			UnlockControls();
		}

		#endregion

		private void LockControls()
		{
			btnTranscode.Enabled = false;
			btnSingleCancel.Enabled = true;
			btnBatch.Enabled = false;
			btnBatchCancel.Enabled = true;
		}

		private void UnlockControls()
		{
			btnTranscode.Enabled = true; 
			btnSingleCancel.Enabled = false;
			btnBatch.Enabled = true;
			btnBatchCancel.Enabled = false;
		}

		private void ScrollToEnd()
		{
			rtbStatus.SelectionStart = rtbStatus.Text.Length;
			// scroll it automatically
			rtbStatus.ScrollToCaret();
		}
	}
}