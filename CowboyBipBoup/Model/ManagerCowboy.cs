using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace CowboyBipBoup.Model
{
    public class ManagerCowboy
    {
        public string? SourcePath { get; set; } = null;
        public List<FolderCowboy> FolderCowboys { get; set; } = new List<FolderCowboy>();

        public void Rename()
        {
            FolderCowboys.ForEach(folder =>
            {
                string folderOut = $"{folder.Date} {folder.Place} {folder.MonoSte} {folder.Recorder} {folder.Micro} {folder.Format}_{folder.Library}_{folder.Project}";

                folder.FileCowboys.ForEach(file =>
                {
                    if (file.Report)
                    {
                        string fileOut = $"{file.Category}_{file.Desc} ";
                        //concatenate
                        string fullOutput = fileOut + folderOut;
                        //add file extension
                        fullOutput = Path.ChangeExtension(fullOutput, ".wav");

                        file.Output = fullOutput; 
                    }
                });
            });
        }
    }
}