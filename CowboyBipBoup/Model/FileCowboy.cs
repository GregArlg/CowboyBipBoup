using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace CowboyBipBoup.Model
{
    public class FileCowboy : IDisposable
    {
        public string OriginalName { get; set; } = "NOORIGINALNAME";
        public string Category { get; set; } = "NOCAT";
        public string Desc { get; set; } = "NODESC";

        public bool IsUCS { get; set; } = false;
        public bool IsMemory { get; set; } = false;

        public string Output { get; set; } = string.Empty;

        public void Dispose()
        {
            
        }
    }
}
