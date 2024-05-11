﻿using OfficeOpenXml;

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
            managerCB = new ManagerCowboy(log);

            if (File.Exists(xlsxPath))
            {
                //set nuget license, mandatory according to doc
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //import excel
                using (ExcelPackage package = new ExcelPackage(xlsxPath))
                {
                    ExcelWorkbook excelFile = package.Workbook;

                    //get metadata
                    var metadataSheet = excelFile.Worksheets[0];
                    string sourcePathCell = "B1";
                    managerCB.SourcePath = metadataSheet.Cells[sourcePathCell].Value.ToString();
                    string outputPathCell = "B2";
                    managerCB.OutputUCSPath = metadataSheet.Cells[outputPathCell].Value.ToString();
                    string outputMemoryPathCell = "B3";
                    managerCB.OutputMemoryPath = metadataSheet.Cells[outputMemoryPathCell].Value.ToString();
#if DEBUG
                    //DEBUG
                    managerCB.SourcePath = @"D:\Coding\CowboyBipBoup__Backlog\test\a trier";
                    managerCB.OutputUCSPath = @"D:\Coding\CowboyBipBoup__Backlog\test\Move_To_UCS";
                    managerCB.OutputMemoryPath = @"D:\Coding\CowboyBipBoup__Backlog\test\Move_To_Memory";
#endif

                    //get UCS columns
                    var ucsSheet = excelFile.Worksheets[1];
                    //TODO: MIGHT DO THESE LOOPS IN MULTITHREADING
                    foreach (var cell in ucsSheet.Cells["A2:A754"])
                    {
                        managerCB.UCSDict["Cat"].Add(cell.Text);
                    }
                    foreach (var cell in ucsSheet.Cells["B2:B754"])
                    {
                        managerCB.UCSDict["SubCat"].Add(cell.Text);
                    }
                    foreach (var cell in ucsSheet.Cells["C2:C754"])
                    {
                        managerCB.UCSDict["CatID"].Add(cell.Text);
                    }

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
                                // Read the report (ucs) and memory cells
                                //if both false, do not get the file
                                bool isFileUCS = fileRow.Range.GetCellValue<string>(1) == "1";
                                bool isFileMemory = fileRow.Range.GetCellValue<string>(2) == "1";

                                if (isFileUCS || isFileMemory)
                                {
                                    //create file object
                                    FileCowboy fileCB = new FileCowboy();

                                    //get OriginalName
                                    fileCB.OriginalName = fileRow.Range.GetCellValue<string>(0) ?? fileCB.OriginalName;
                                    //get Category
                                    fileCB.Category = fileRow.Range.GetCellValue<string>(3) ?? fileCB.Category;
                                    //get Desc
                                    fileCB.Desc = fileRow.Range.GetCellValue<string>(4) ?? fileCB.Desc;

                                    //get is ucs
                                    fileCB.IsUCS = isFileUCS;
                                    //get is memory
                                    fileCB.IsMemory = isFileMemory;

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
