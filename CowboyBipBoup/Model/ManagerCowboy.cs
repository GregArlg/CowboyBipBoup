namespace CowboyBipBoup.Model
{
    public class ManagerCowboy : IDisposable
    {
        public string? SourcePath { get; set; } = null;
        public string? OutputUCSPath { get; set; } = null;
        public string? OutputMemoryPath { get; set; } = null;
        public Dictionary<string, List<string>> UCSDict { get; set; }
        public List<FolderCowboy> FolderCowboys { get; set; } = new List<FolderCowboy>();

        private Log.Log? _log = null;

        public ManagerCowboy(Log.Log? log = null)
        {
            UCSDict = new Dictionary<string, List<string>>
            {
                { "Cat", new List<string>() },
                { "SubCat", new List<string>() },
                { "CatID", new List<string>() }
            };

            _log = log;
        }

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

                    int maxNumberOfChar = 256;

                    if (file.Output.Length > maxNumberOfChar)
                    {
                        _log?.Error($"[ManagerCowboy][SetFileOutputName]\n" +
                            $"File name is too long ({folder.Name}):\n{file.Output}\n" +
                            $"Max number of character: {maxNumberOfChar}" +
                            $"\n");
                    }
                });
            });
        }

        /// <summary>
        /// Get each file in the SourcePath folder and rename it with the Output file name created in SetFileOutputName
        /// and move it in the OutputPath if parameter true
        /// </summary>
        /// <param name="doRenameOnly"></param>
        public void RenameAndMove(bool doRenameOnly = false)
        {
            if (!string.IsNullOrEmpty(SourcePath))
            {
                if (!string.IsNullOrEmpty(OutputUCSPath))
                {
                    if (!string.IsNullOrEmpty(OutputMemoryPath))
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
                                //build ucs and memory folders output

                                //get matching categories to organize folders
                                int ucsIdx = UCSDict["CatID"].FindIndex(cat => cat == file.Category);
                                if (ucsIdx >= 0)
                                {
                                    //get data from serialized dictionary
                                    string cat = UCSDict["Cat"][ucsIdx];
                                    string subcat = UCSDict["SubCat"][ucsIdx];

                                    //concatenate ucs folder path
                                    string ucsFolderPath = Path.Combine(OutputUCSPath, cat + "-" + subcat);
                                    //concatenate memory folder path
                                    string memoryFolderPath = Path.Combine(OutputMemoryPath, "Memories");

                                    //concatenate full file path

                                    //original source file
                                    string oldPath = Path.Combine(folderFullPath, file.OriginalName + ".wav");

                                    //rename only
                                    string renamePath = Path.Combine(folderFullPath, file.Output + ".wav");
                                    //rename and move to ucs
                                    string moveUcsPath = Path.Combine(ucsFolderPath, file.Output + ".wav");
                                    //rename and move to memory
                                    string moveMemoryPath = Path.Combine(memoryFolderPath, file.Output + ".wav");

                                    int maxNumberOfChar = 256;

                                    //do action only if name is valid
                                    if (file.Output.Length < maxNumberOfChar)
                                    {
                                        if (File.Exists(oldPath))
                                        {
                                            if (doRenameOnly)
                                            {
                                                File.Move(oldPath, renamePath);
                                            }
                                            else
                                            {
                                                //if ucs and memory true => move file in both memory and ucs
                                                //if ucs only true => move file in ucs
                                                //if memory only true => move file in memory folder

                                                //UCS
                                                if (file.IsUCS)
                                                {
                                                    if (!File.Exists(moveUcsPath))
                                                    {
                                                        //create directory if it doesn't exist
                                                        //(CreateDirectory method tests existence itself)
                                                        Directory.CreateDirectory(ucsFolderPath);

                                                        File.Copy(oldPath, moveUcsPath);
                                                    }
                                                    else
                                                    {
                                                        _log?.Error($"[ManagerCowboy][Move]\n" +
                                                            $"File already exists:\n{moveUcsPath}" +
                                                            $"From {folder.Name}\n" +
                                                            $"From File: {file.OriginalName}" +
                                                            $"\n");
                                                    }
                                                }

                                                //MEMORY
                                                if (file.IsMemory)
                                                {
                                                    if (!File.Exists(moveMemoryPath))
                                                    {
                                                        //create directory if it doesn't exist
                                                        //(CreateDirectory method tests existence itself)
                                                        Directory.CreateDirectory(memoryFolderPath);

                                                        File.Copy(oldPath, moveMemoryPath);
                                                    }
                                                    else
                                                    {
                                                        _log?.Error($"[ManagerCowboy][Move]\n" +
                                                            $"File already exists:\n{moveMemoryPath}" +
                                                            $"From {folder.Name}\n" +
                                                            $"From File: {file.OriginalName}" +
                                                            $"\n");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            _log?.Error($"[ManagerCowboy][Move]\n" +
                                                $"File doesn't exist:\n{oldPath}" +
                                                $"\n");
                                        }
                                    }
                                }
                                else
                                {
                                    _log?.Error($"[ManagerCowboy][Move]\n" +
                                        $"CatID doesn't exist: {file.Category}\n" +
                                        $"From {folder.Name}\n" +
                                        $"From File: {file.OriginalName}" +
                                        $"\n");
                                }
                            });
                        }); 
                    }
                    else
                    {
                        _log?.Error($"[ManagerCowboy][Move]\n" +
                            $"Memory Output path is not set." +
                            $"\n");
                    }
                }
                else
                {
                    _log?.Error($"[ManagerCowboy][Move]\n" +
                        $"UCS Output path is not set." +
                        $"\n");
                }
            }
            else
            {
                _log?.Error($"[ManagerCowboy][Move]\n" +
                    $"Source path is not set." +
                    $"\n");
            }
        }

        public void Dispose()
        {
            FolderCowboys.ForEach(f => f.Dispose());
        }
    }
}