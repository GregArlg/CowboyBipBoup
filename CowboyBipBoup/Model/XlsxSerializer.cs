using OfficeOpenXml;

namespace CowboyBipBoup.Model
{
    public static class XlsxSerializer
    {

        /// <summary>
        /// Serialize the excel file in input to get all the Cowboy objects infos
        /// </summary>
        /// <param name="xlsxPath">Full path of the excel file to serialize</param>
        /// <param name="isValid">True if the seriali</param>
        /// <returns></returns>
        public static bool GetData(string xlsxPath, out ManagerCowboy managerCB, Log.Log? log = null)
        {
            bool result = false;

            //init manager
            managerCB = new ManagerCowboy();

            if (File.Exists(xlsxPath))
            {
                //set nuget license, mandatory according to doc
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //import excel
                using (ExcelPackage package =  new ExcelPackage(xlsxPath))
                {
                    ExcelWorkbook excelFile = package.Workbook;

                    //get metadata
                    var metadataSheet = excelFile.Worksheets[0];
                    string sourcePathCell = "A2";
                    managerCB.SourcePath = metadataSheet.Cells[sourcePathCell].Value.ToString();
#if DEBUG
                    //DEBUG
                    managerCB.SourcePath = @"D:\Coding\CowboyBipBoup__Backlog\test\a trier"; 
#endif
                    if (Directory.Exists(managerCB.SourcePath))
                    {
                        //select only folder sheets
                        var folderSheets = excelFile.Worksheets.Where(s => s.Name.Contains("Folder"));

                        //parse folder sheets
                        foreach (ExcelWorksheet folderSheet in folderSheets)
                        {
                            //create new folder object
                            FolderCowboy folderCB = new FolderCowboy();

                            //get folder name
                            folderCB.Name = folderSheet.Name;

                            //get Date 
                            folderCB.Date = folderSheet.Cells["C2"].Value.ToString() ?? folderCB.Date;
                            //get Place 
                            folderCB.Place = folderSheet.Cells["D2"].Value.ToString() ?? folderCB.Place;
                            //get MonoSte 
                            folderCB.MonoSte = folderSheet.Cells["E2"].Value.ToString() ?? folderCB.MonoSte;
                            //get Recorder 
                            folderCB.Recorder = folderSheet.Cells["F2"].Value.ToString() ?? folderCB.Recorder;
                            //get Micro 
                            folderCB.Micro = folderSheet.Cells["G2"].Value.ToString() ?? folderCB.Micro;
                            //get Format 
                            folderCB.Format = folderSheet.Cells["H2"].Value.ToString() ?? folderCB.Format;
                            //get Library 
                            folderCB.Library = folderSheet.Cells["A2"].Value.ToString() ?? folderCB.Library;
                            //get Project 
                            folderCB.Project = folderSheet.Cells["B2"].Value.ToString() ?? folderCB.Project;
                            //get Note 
                            folderCB.Note = folderSheet.Cells["I2"].Value.ToString() ?? folderCB.Note;

                            //get all file rows, from cell 4
                            var fileRows = folderSheet.Rows.Skip(3);
                            //parse original files
                            foreach (ExcelRangeRow fileRow in fileRows)
                            {
                                // Read the report cell and get the file infos only if true
                                bool isFileValid = fileRow.Range.GetCellValue<string>(1) == "1";

                                if (isFileValid)
                                {
                                    //create file object
                                    FileCowboy fileCB = new FileCowboy();

                                    //get OriginalName
                                    fileCB.OriginalName = fileRow.Range.GetCellValue<string>(0) ?? fileCB.OriginalName; ;
                                    //get Category
                                    fileCB.Category = fileRow.Range.GetCellValue<string>(2) ?? fileCB.Category;
                                    //get Desc
                                    fileCB.Desc = fileRow.Range.GetCellValue<string>(3) ?? fileCB.Desc;

                                    //add file object to folder list
                                    folderCB.FileCowboys.Add(fileCB); 
                                }
                            }

                            //add folder object to manager list
                            managerCB.FolderCowboys.Add(folderCB);
                        }

                        result = true;
                    }
                    else
                    {
                        log?.Error($"[XlsxSerializer][GetData]\n" +
                            $"Metadata source path doesn't exist.\n" +
                            $"Sheet: {metadataSheet.Name}\nCell: {sourcePathCell}");
                    }
                }
                
            }
            else
            {
                log?.Error($"[XlsxSerializer][GetData]\n" +
                    $"Xlsx source file doesn't exist.\n" +
                    $"Given Path: {xlsxPath}");
            }

            return result;
        }
    }
}
