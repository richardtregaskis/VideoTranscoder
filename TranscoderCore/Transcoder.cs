using System;
using System.CodeDom;
using System.IO;

namespace VideoTranscoderCore
{
	public class TranscodeCore
	{
		public enum TransCodec
		{
			ProRes = 0,
			DNxHD = 1,
		}

		public enum TransFrameRate
		{
			Frames2397 = 0,
			Frames24 = 1,
			Frames25 = 2,
			Frames2997 = 3,
			Frames50 = 4,
			Frames5994 = 5,
			Frames60 = 6,
		}

		public enum TransFrameSize
		{
			P720 = 0,
			P1080 = 1,
			P4k = 2,
		}

		public enum ColorBits
		{
			Bit8 = 0,
			Bit10 = 1,
		}

		public enum ChromaSubSampling
		{
			Min420 = 0,
			Med422 = 1,
			Full444 = 2,
		}

		public enum ProResProfile
		{
			PROXY = 0,
			YUV422LT = 1,
			YUV422STANDARD = 2,
			YUV422HQ = 3,
			YUV4444 = 4,
			YUV4444XQ = 5
		}

		public static string GetProResCommandString(ProResProfile profile, string sourceFile)
		{
			//Reference: https://ottverse.com/ffmpeg-convert-to-apple-prores-422-4444-hq/
			string targetFile = GetTargetFilename(sourceFile, TransCodec.ProRes);
			switch (profile)
			{
				case ProResProfile.PROXY:
					return "";
				case ProResProfile.YUV422LT:
					return "-hwaccel auto -i \"" + sourceFile + "\" -c:v prores -profile:v " + (int)profile + " -pix_fmt yuv422p10 -map v:0 -c:a  pcm_s16l3 -ar 48000 -map a? -sws_flags bicubic -metadata:s \"encoder=Apple ProRes LT\" -vendor ap10 -movflags write_colr+write_gama -flags -bitexact -y \"" + targetFile + "\"";
				case ProResProfile.YUV422STANDARD:
					return "-hwaccel none -i \"" + sourceFile + "\" -c:v prores -profile:v " + (int)profile + " -pix_fmt yuv422p10 -map v:0 -c:a  pcm_s16l3 -ar 48000 -map a? -sws_flags bicubic -metadata:s \"encoder=Apple ProRes 422\" -vendor ap10 -movflags write_colr+write_gama -flags -bitexact -y \"" + targetFile + "\"";
				case ProResProfile.YUV422HQ:
					return "-hwaccel none -i \"" + sourceFile + "\" -c:v prores -profile:v " + (int)profile + " -pix_fmt yuv422p10 -map v:0 -c:a  pcm_s16l3 -ar 48000 -map a? -sws_flags bicubic -metadata:s \"encoder=Apple ProRes 422HQ\" -vendor ap10 -movflags write_colr+write_gama -flags -bitexact -y \"" + targetFile + "\"";
				case ProResProfile.YUV4444:
					return "-hwaccel none -i \"" + sourceFile + "\" -c:v prores -profile:v " + (int)profile + " -pix_fmt yuv444p10 -map v:0 -c:a  pcm_s16l3 -ar 48000 -map a? -sws_flags bicubic -metadata:s \"encoder=Apple ProRes 444\" -vendor ap10 -movflags write_colr+write_gama -flags -bitexact -y \"" + targetFile + "\"";
				case ProResProfile.YUV4444XQ:
					return "-hwaccel none -i \"" + sourceFile + "\" -c:v prores_ks -profile:v " + (int)profile + " -pix_fmt yuv444p10 -alpha_bits 16 -map v:0 -c:a  pcm_s16l3 -ar 48000 -map a? -sws_flags bicubic -metadata:s \"encoder=Apple ProRes 444xq\" -vendor ap10 -movflags write_colr+write_gama -flags -bitexact -y \"" + targetFile + "\"";				
				default:
					return "";
			}
		}		

		public static string GetDNxHDCommandString(string sourceFilename, TransFrameSize frameSize, TransFrameRate frameRate, ColorBits colorBits, ChromaSubSampling chroma)
		{
			//Reference: https://en.wikipedia.org/wiki/List_of_Avid_DNxHD_resolutions
			//Reference: http://macilatthefront.blogspot.com/2018/12/tutorial-using-ffmpeg-for-dnxhddnxhr.html

			string targetFilename = GetTargetFilename(sourceFilename, TransCodec.DNxHD);

			string arguments = "";
			if (frameSize == TransFrameSize.P4k)
			{
				//No options for changing framerate or interchanging Chroma (pix_fmt) across quality levels
				#region 4k
				if (chroma == ChromaSubSampling.Full444)
				{
					arguments = " -i \"" + sourceFilename + "\" -c:v dnxhd -profile:v dnxhr_444 -pix_fmt rgb24 -c:a pcm_s16le \"" + targetFilename + "\"";
				}
				else
				{
					if (colorBits == ColorBits.Bit10)
					{
						arguments = " -i \"" + sourceFilename + "\" -c:v dnxhd -profile:v dnxhr_hqx -pix_fmt yuv422p10le -c:a pcm_s16le \"" + targetFilename + "\"";
					}
					else
					{
						arguments = " -i \"" + sourceFilename + "\" -c:v dnxhd -profile:v dnxhr_hq -pix_fmt yuv422p -c:a pcm_s16le \"" + targetFilename + "\"";
					}
				}
				#endregion
			}
			else
			{				
				string frameStr = GetFrameRateStr(frameRate);
				string scaleStr = "";
				string chromaStr = "";
				string bitRateStr = "";

				switch (frameSize)
				{
					case TransFrameSize.P1080:
						#region 1080P
						scaleStr = "1920:1080";
						switch (frameRate)
						{
							case TransFrameRate.Frames60:
							case TransFrameRate.Frames5994:
								if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "440M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "291M";
									chromaStr = "yuv422p";
								}
								break;
							case TransFrameRate.Frames50:
								if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "367M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "242M";
									chromaStr = "yuv422p";
								}
								break;
							case TransFrameRate.Frames2997:
								if (chroma == ChromaSubSampling.Full444)
								{
									bitRateStr = "440M";
									chromaStr = "yuv444p10";
								}
								else if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "220M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "100M";
									chromaStr = "yuv422p";
								}
								break;
							case TransFrameRate.Frames25:
								if (chroma == ChromaSubSampling.Full444)
								{
									bitRateStr = "367M";
									chromaStr = "yuv444p10";
								}
								else if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "184M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "84M";
									chromaStr = "yuv422p";
								}
								break;
							case TransFrameRate.Frames24:
								if (chroma == ChromaSubSampling.Full444)
								{
									bitRateStr = "352M";
									chromaStr = "yuv444p10";
								}
								else if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "176M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "80M";
									chromaStr = "yuv422p";
								}
								break;
						}
						#endregion
						break;
					case TransFrameSize.P720:
						#region 720P
						scaleStr = "1280:720";
						switch (frameRate)
						{
							case TransFrameRate.Frames60:
							case TransFrameRate.Frames5994:
								if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "220M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "145M";
									chromaStr = "yuv422p";
								}
								break;
							case TransFrameRate.Frames50:
								if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "175M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "115M";
									chromaStr = "yuv422p";
								}
								break;
							case TransFrameRate.Frames2997:
								if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "110M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "72M";
									chromaStr = "yuv422p";
								}
								break;
							case TransFrameRate.Frames25:
							case TransFrameRate.Frames2397:
								if (colorBits == ColorBits.Bit10)
								{
									bitRateStr = "92M";
									chromaStr = "yuv422p10";

								}
								else
								{
									bitRateStr = "60M";
									chromaStr = "yuv422p";
								}
								break;
						}
						#endregion
						break;
				}

				arguments = " - i \"" + sourceFilename + "\" - c:v dnxhd -vf \"scale=" + scaleStr + ",fps=" + GetFrameRateStr(frameRate) +
					",format=" + chromaStr + "\" - b:v " + bitRateStr + " - c:a pcm_s16le \"" + targetFilename + "\"";
			}

			return arguments;
		}

		private static string GetFrameRateStr(TransFrameRate frameRate)
		{
			switch (frameRate)
			{
				case TransFrameRate.Frames60:
					return "60";
				case TransFrameRate.Frames5994:
					return "60000/1001";
				case TransFrameRate.Frames50:
					return "50";
				case TransFrameRate.Frames2997:
					return "30000/1001";
				case TransFrameRate.Frames25:
					return "25";
				case TransFrameRate.Frames24:
					return "24";
				case TransFrameRate.Frames2397:
					return "24000/1001";
				default:
					return "30000/1001";
			}
		}

		public static string GetTargetFilename(string sourceFilename, TransCodec codec)
		{
			if (!sourceFilename.ToLower().EndsWith("mov"))
			{
				switch (codec)
				{
					case TransCodec.ProRes:
						return System.IO.Path.ChangeExtension(sourceFilename, "mov");
					case TransCodec.DNxHD:
						return System.IO.Path.ChangeExtension(sourceFilename, "mxf");
					default:
						return System.IO.Path.ChangeExtension(sourceFilename, "mov");
				}				
			}
			else
				return sourceFilename;
		}
	}

	public class Transcoder
	{
		//Bits per macro block range 200 to 8000
		//Bits for alpha component range 0, 8, 16; use 

		System.Diagnostics.Process _ffMPEGProc;
		public Transcoder()
		{ }

		public const int mbs_per_slice = 8;

		public bool TranscodeVideo(string commandString, string targetName)
		{
			return RunProcess(commandString, targetName);
		}

		private bool RunProcess(string arguments, string outFilename)
		{			
			string cmd = "\"" + Path.Combine(VarCore.ApplicationBinDirectory, "ffmpeg.exe") + "\"";		

			_ffMPEGProc = new System.Diagnostics.Process();

			_ffMPEGProc.StartInfo.FileName = cmd;

			_ffMPEGProc.StartInfo.Arguments = arguments;

			_ffMPEGProc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			_ffMPEGProc.StartInfo.UseShellExecute = false;

			try
			{
				_ffMPEGProc.Start();

				_ffMPEGProc.WaitForExit();

				if (File.Exists(outFilename))
				{
					_ffMPEGProc.Dispose();
					return true;
				}

			}
			catch (Exception r) { }

			_ffMPEGProc.Dispose();
			return false;
		}

		public void Kill()
		{
			try { 
				_ffMPEGProc.Kill();
				_ffMPEGProc.Dispose();
			}catch { }
		}
	}
}