using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace CowboyBipBoup.Model
{
    public class ManagerCowboy : IDisposable
    {
        public string? SourcePath { get; set; } = null;
        public List<FolderCowboy> FolderCowboys { get; set; } = new List<FolderCowboy>();

        /// <summary>
        /// Concatenate serialized infos to build each full file name
        /// </summary>
        public void SetFileOutputName()
        {
            //browse folders
            FolderCowboys.ForEach(folder =>
            {
                //concatenate folder infos
                string folderOut = $"{folder.Date} {folder.Place} {folder.MonoSte} {folder.Recorder} {folder.Micro} {folder.Format}_{folder.Library}_{folder.Project}";

                //browse files of current folder
                folder.FileCowboys.ForEach(file =>
                {
                    //concatenate file infos
                    string fileOut = $"{file.Category}_{file.Desc} ";
                    //concatenate full name
                    string fullOutput = fileOut + folderOut;

                    //set property
                    file.Output = fullOutput; 
                });
            });
        }

        /// <summary>
        /// Get each file in the SourcePath folder and rename it with the Output file name created in SetFileOutputName
        /// </summary>
        public void Rename()
        {
            if (!string.IsNullOrEmpty(SourcePath))
            {
                //TODO: MIGHT BE DOABLE IN MULTITHREADING

                //browse folders
                FolderCowboys.ForEach(folder =>
                {
                    //concatenate folder path
                    string folderFullPath = Path.Combine(SourcePath, folder.Name);

                    //browse files of current folder
                    folder.FileCowboys.ForEach(file =>
                    {
                        //concatenate full file path
                        string oldPath = Path.Combine(folderFullPath, file.OriginalName + ".wav");
                        string newPath = Path.Combine(folderFullPath, file.Output + ".wav");

                        if (File.Exists(oldPath))
                        {
                            File.Move(oldPath, newPath);
                        }
                        //else
                        //{
                        //    MessageBox.Show($"[ManagerCowboy][Rename]\nFile doesn't exist:\n{oldPath}",
                        //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    });
                }); 
            }
            else
            {
                MessageBox.Show($"[ManagerCowboy][Rename]\nSource path doesn't exist.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Dispose()
        {
            FolderCowboys.ForEach(f => f.Dispose());
        }
    }
}