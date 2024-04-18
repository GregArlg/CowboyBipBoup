using IronXL;

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
                //import excel
                WorkBook excelFile = WorkBook.Load(xlsxPath);
                excelFile.EvaluateAll();

                //get metadata
                var metadataSheet = excelFile.WorkSheets[0];
                string sourcePathCell = "A2";
                managerCB.SourcePath = metadataSheet[sourcePathCell].StringValue;
                //string test = metadataSheet["H2"].First().FormattedCellValue;

                if (Directory.Exists(managerCB.SourcePath))
                {
                    //select only folder sheets
                    var folderSheets = excelFile.WorkSheets.Where(s => s.Name.Contains("Folder"));

                    //parse folder sheets
                    foreach (WorkSheet folderSheet in folderSheets)
                    {
                        //create new folder object
                        FolderCowboy folderCB = new FolderCowboy();

                        //get Date 
                        folderCB.Date = folderSheet["C2"].StringValue;
                        //get Place 
                        folderCB.Place = folderSheet["D2"].StringValue;
                        //get MonoSte 
                        folderCB.MonoSte = folderSheet["E2"].StringValue;
                        //get Recorder 
                        folderCB.Recorder = folderSheet["F2"].StringValue;
                        //get Micro 
                        folderCB.Micro = folderSheet["G2"].StringValue;
                        //get Format 
                        folderCB.Format = folderSheet["H2"].StringValue;
                        //get Library 
                        folderCB.Library = folderSheet["A2"].StringValue;
                        //get Project 
                        folderCB.Project = folderSheet["B2"].StringValue;
                        //get Note 
                        folderCB.Note = folderSheet["I2"].StringValue;

                        //get all file rows, from cell 4
                        var fileRows = folderSheet.Rows.Skip(3);
                        //parse original files
                        foreach (RangeRow fileRow in fileRows)
                        {
                            //create file object
                            FileCowboy fileCB = new FileCowboy();

                            //get OriginalName
                            fileCB.OriginalName = fileRow.Columns[0].First().FormattedCellValue;
                            //get Category
                            fileCB.Category = fileRow.Columns[2].First().FormattedCellValue;
                            //get Desc
                            fileCB.Desc = fileRow.Columns[3].First().FormattedCellValue;
                            //get Report
                            fileCB.Report = fileRow.Columns[1].First().BoolValue;

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
            else
            {
                MessageBox.Show($"Xlsx source file doesn't exist.\nGiven Path: {xlsxPath}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return managerCB;
        }
    }
}
