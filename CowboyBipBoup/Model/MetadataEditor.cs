using GroupDocs.Metadata;
using GroupDocs.Metadata.Tagging;
using System.Globalization;

namespace CowboyBipBoup.Model
{
    public static class MetadataEditor
    {
        public static void Wav(string fullPath, FolderCowboy folder, FileCowboy file, Log.Log? log = null)
        {
            //if file exists
            if (File.Exists(fullPath))
            {
                //if file has the right extension
                if (Path.GetExtension(fullPath) == ".wav")
                {
                    try
                    {
                        //use nuget to edit file metadata
                        using (var metadata = new Metadata(fullPath))
                        {

                            //set description
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.Content.Description),
                                new GroupDocs.Metadata.Common.PropertyValue(file.Desc)
                            );

                            //set category
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.Content.Subject),
                                new GroupDocs.Metadata.Common.PropertyValue(file.Category)
                            );

                            //set date
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.Time.Created),
                                new GroupDocs.Metadata.Common.PropertyValue(DateTime.ParseExact(folder.Date, "yyyyMMdd", CultureInfo.InvariantCulture))
                            );

                            //set place
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.PropertyType.Location),
                                new GroupDocs.Metadata.Common.PropertyValue(folder.Place)
                            );

                            //set mono or stereo
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.Content.Type),
                                new GroupDocs.Metadata.Common.PropertyValue(folder.MonoSte)
                            );

                            //set recorder and micro
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.Tool.Hardware),
                                new GroupDocs.Metadata.Common.PropertyValue($"Rec: {folder.Recorder}, Mic: {folder.Micro}")
                            );

                            //set format
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.PropertyType.Measure),
                                new GroupDocs.Metadata.Common.PropertyValue("Format: " + folder.Format)
                            );

                            //set library
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.Person.Artist),
                                new GroupDocs.Metadata.Common.PropertyValue(folder.Library)
                            );

                            //set project
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.Content.Album),
                                new GroupDocs.Metadata.Common.PropertyValue(folder.Project)
                            );

                            //set note
                            metadata.SetProperties(
                                p => p.Tags.Contains(Tags.Content.Comment),
                                new GroupDocs.Metadata.Common.PropertyValue(folder.Note)
                            );

                            // Save result WAV
                            metadata.Save(fullPath);

                        }
                    }
                    catch (Exception e)
                    {
                        log?.Warning($"[MetadataEditor][Wav]\n" +
                            $"An error occured when editing metadata.\n" +
                            $"Error: {e.Message}\n" +
                            $"From file: {fullPath}\n" +
                            $"\n");
                    }
                }
                else
                {
                    log?.Error($"[MetadataEditor][Wav]\n" +
                                $"File extension must be .wav:\n" +
                                $"{fullPath}\n" +
                                $"\n");
                }
            }
            else
            {
                log?.Error($"[MetadataEditor][Wav]\n" +
                            $"File does not exist:\n" +
                            $"{fullPath}\n" +
                            $"\n");
            }
        }
    }
}
