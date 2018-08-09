using System;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Security;

namespace PMBase.Basic
{
    public class WavConvertToAmr
    {

        ///// <summary>
        ///// 将Wav音频转成Amr手机音频
        ///// </summary>
        ///// <param name="applicationPath">ffmeg.exe文件路径</param>
        ///// <param name="fileName">WAV文件的路径(带文件名)</param>
        ///// <param name="targetFilName">生成目前amr文件路径（带文件名）</param>
        public string ConvertToMp3(string paths, string pathBefore, string pathLater)
        {
            paths = "C:\\ffmpeg.exe";
            //string c = Server.MapPath("/ffmpeg/") + @"ffmpeg.exe -i " + pathBefore + " " + pathLater;
            //  string c = paths+ " -y -i " + pathBefore + " -ar 8000 -ab 12.2k -ac 1 " + pathLater;
            string c = paths + @" -y -i " + pathBefore + " " + pathLater;
            string str = RunCmd(c);
            return str;
        }

        /// <summary>
        /// 执行Cmd命令
        /// </summary>
        private string RunCmd(string c)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
                process.StandardInput.WriteLine(c);
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine("exit");
                //StreamReader reader = process.StandardOutput;//截取输出流    
                //process.WaitForExit();
                return "1";
            }
            catch (Exception ex)
            {
                return "error" + ex.Message;
            }
        }
    }
}
