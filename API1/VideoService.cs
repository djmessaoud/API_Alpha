using System;
using System.Diagnostics;

namespace API1
{
    public class VideoService
    {
        public string GenerateVideo(string guid)
        {
            try
            {
                string pythonCommand = $"magic.py -u {guid}";

                var process = new Process
                {
                    StartInfo =
                {
                FileName = "python3", // Use the bash shell to run the command
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"{pythonCommand}"
                }
                };
                process.Start();
                process.WaitForExit();

                // Handle the generated video file path and return it
                 string videoFilePath = $"/home/alpha_ftp/ftp/files/{guid}/timelapse.mp4";
               // string videoFilePath = process.StandardOutput.ReadToEnd();
                return videoFilePath;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return $"{ex.Message}";
            }
        }
    }
}
