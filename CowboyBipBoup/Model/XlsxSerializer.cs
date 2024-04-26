using OfficeOpenXml;

namespace CowboyBipBoup.Model
{
    public static class XlsxSerializer
    {
        public static ManagerCowboy GetData(string xlsxPath)
        {
            //init manager
            ManagerCowboy managerCB = new ManagerCowboy();

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
                    //managerCB.SourcePath = metadataSheet.Cells[sourcePathCell].Value.ToString();
                    managerCB.SourcePath = @"D:\Coding\CowboyBipBoup__Backlog\test"; //DEBUG

                    if (Directory.Exists(managerCB.SourcePath))
                    {
                        //select only folder sheets
                        var folderSheets = excelFile.Worksheets.Where(s => s.Name.Contains("Folder"));

                        //parse folder sheets
                        foreach (ExcelWorksheet folderSheet in folderSheets)
                        {
                            //create new folder object
                            FolderCowboy folderCB = new FolderCowboy();

                            //get Date 
                            folderCB.Date = folderSheet.Cells["C2"].Value?.ToString();
                            //get Place 
                            folderCB.Place = folderSheet.Cells["D2"].Value?.ToString();
                            //get MonoSte 
                            folderCB.MonoSte = folderSheet.Cells["E2"].Value?.ToString();
                            //get Recorder 
                            folderCB.Recorder = folderSheet.Cells["F2"].Value?.ToString();
                            //get Micro 
                            folderCB.Micro = folderSheet.Cells["G2"].Value?.ToString();
                            //get Format 
                            folderCB.Format = folderSheet.Cells["H2"].Value?.ToString();
                            //get Library 
                            folderCB.Library = folderSheet.Cells["A2"].Value?.ToString();
                            //get Project 
                            folderCB.Project = folderSheet.Cells["B2"].Value?.ToString();
                            //get Note 
                            folderCB.Note = folderSheet.Cells["I2"].Value?.ToString();

                            //get all file rows, from cell 4
                            var fileRows = folderSheet.Rows.Skip(3);
                            //parse original files
                            foreach (ExcelRangeRow fileRow in fileRows)
                            {
                                //create file object
                                FileCowboy fileCB = new FileCowboy();

                                //get OriginalName
                                fileCB.OriginalName = fileRow.Range.GetCellValue<string>(0);
                                //get Category
                                fileCB.Category = fileRow.Range.GetCellValue<string>(2) ?? "NOCAT";
                                //get Desc
                                fileCB.Desc = fileRow.Range.GetCellValue<string>(3) ?? "NODESC";
                                //get Report
                                fileCB.Report = fileRow.Range.GetCellValue<string>(1) == "1";
                                
                                //add file object to folder list
                                folderCB.FileCowboys.Add(fileCB);
                            }

                            //add folder object to manager list
                            managerCB.FolderCowboys.Add(folderCB);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Metadata source path doesn't exist.\nSheet: {metadataSheet.Name}\nCell: {sourcePathCell}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            else
            {
                MessageBox.Show($"Xlsx source file doesn't exist.\nGiven Path: {xlsxPath}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return managerCB;
        }
    }
}
