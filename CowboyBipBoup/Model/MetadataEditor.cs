using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowboyBipBoup.Model
{
    public static class MetadataEditor
    {
        public static void Wav(string fullPath, Log.Log? log = null)
        {
            //if file exists
            if (File.Exists(fullPath))
            {
                //if file has the right extension
                if(Path.GetExtension(fullPath) == ".wav")
                {
                    //edit its metadata

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
