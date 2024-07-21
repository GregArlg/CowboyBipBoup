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
            _log?.Message("Building file names ...");

            //browse folders
            FolderCowboys.ForEach(folder =>
            {
                //concatenate folder infos
                string folderOut = $"{folder.Date} {folder.Place} {folder.MonoSte} {folder.Recorder} {folder.Micro} {folder.Format}_{folder.Library}_{folder.Project}";

                //browse files of current folder
                folder.FileCowboys.ForEach(file =>
                {
                    //concatenate file infos
                    string fileOut = "";
                    if (file.IsUCS)
                    {
                        fileOut = $"{file.Category}_{file.Desc} ";
                    }
                    else if (file.IsMemory)
                    {
                        fileOut = $"{file.Desc} ";
                    }
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

                        file.IsValid = false;
                    }
                });
            });

            _log?.Valid("File names are set!");
        }

        /// <summary>
        /// Get each file in the SourcePath folder and rename it with the Output file name created in SetFileOutputName
        /// and move it in the OutputPath if parameter true
        /// </summary>
        /// <param name="doRenameOnly"></param>
        public void RenameAndMove(bool doRenameOnly = false)
        {
            if (doRenameOnly)
                _log?.Message("Renaming files ...");
            else
                _log?.Message("Renaming and Moving files ...");

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
#pragma warning disable CS8604 // Possible null reference argument.
                            string folderFullPath = Path.Combine(SourcePath, folder.Name);
#pragma warning restore CS8604 // Possible null reference argument.

                            //browse files of current folder
                            folder.FileCowboys.ForEach(file =>
                            {
                                //original source file
                                string oldPath = Path.Combine(folderFullPath, file.OriginalName + ".wav");

                                if (file.IsValid)
                                {
                                    if (File.Exists(oldPath))
                                    {
                                        //will contain the file path to edit metadata
                                        string metadataPath = "";

                                        //first manage rename only case
                                        if (doRenameOnly)
                                        {
                                            //rename only
                                            string renamePath = Path.Combine(folderFullPath, file.Output + ".wav");

                                            File.Move(oldPath, renamePath);

                                            //then set metadata, we edit metadata even if we do rename only
                                            metadataPath = renamePath;
                                        }
                                        else
                                        {
                                            //if ucs and memory true => move file in both memory and ucs
                                            //if ucs only true => move file in ucs
                                            //if memory only true => move file in memory folder


                                            //move file to memory folder if needed
                                            if (file.IsMemory)
                                            {
                                                //concatenate memory folder path
                                                string memoryFolderPath = Path.Combine(OutputMemoryPath, "Memories");

                                                //destination memory full file path
                                                string moveMemoryPath = Path.Combine(memoryFolderPath, file.Output + ".wav");

                                                if (!File.Exists(moveMemoryPath))
                                                {
                                                    //create directory if it doesn't exist
                                                    //(CreateDirectory method tests existence itself)
                                                    Directory.CreateDirectory(memoryFolderPath);

                                                    File.Copy(oldPath, moveMemoryPath);

                                                    //set metadata path
                                                    metadataPath = moveMemoryPath;
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

                                            //move file to ucs folder if needed
                                            if (file.IsUCS)
                                            {
                                                //get matching categories to organize folders
                                                int ucsIdx = UCSDict["CatID"].FindIndex(cat => cat == file.Category);
                                                if (ucsIdx >= 0)
                                                {
                                                    //get data from serialized dictionary
                                                    string cat = UCSDict["Cat"][ucsIdx];
                                                    string subcat = UCSDict["SubCat"][ucsIdx];

                                                    //concatenate ucs folder path
                                                    string ucsFolderPath = Path.Combine(OutputUCSPath, cat + "-" + subcat);

                                                    //destination ucs full file path
                                                    string moveUcsPath = Path.Combine(ucsFolderPath, file.Output + ".wav");

                                                    if (!File.Exists(moveUcsPath))
                                                    {
                                                        //create directory if it doesn't exist
                                                        //(CreateDirectory method tests existence itself)
                                                        Directory.CreateDirectory(ucsFolderPath);

                                                        File.Copy(oldPath, moveUcsPath);

                                                        //set metadata path
                                                        metadataPath = moveUcsPath;
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
                                                else
                                                {
                                                    _log?.Error($"[ManagerCowboy][Move]\n" +
                                                        $"CatID doesn't exist: {file.Category}\n" +
                                                        $"From {folder.Name}\n" +
                                                        $"From File: {file.OriginalName}" +
                                                        $"\n");
                                                }
                                            }
                                        }

                                        //now edit metadata if the file has been renamed or modified

                                        if (!string.IsNullOrWhiteSpace(metadataPath))
                                        {
                                            MetadataEditor.Wav(metadataPath, folder, file, _log);
                                        }
                                    }
                                    else
                                    {
                                        _log?.Error($"[ManagerCowboy][Move]\n" +
                                            $"File doesn't exist:\n{oldPath}" +
                                            $"\n");
                                    }
                                }
                            });
                        });

                        if (doRenameOnly)
                            _log?.Valid("Files name changed!");
                        else
                            _log?.Valid("Files name changed and moved!");
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