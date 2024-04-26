using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace CowboyBipBoup.Model
{
    public class FileCowboy
    {
        public string? OriginalName { get; set; } = null;
        public string Category { get; set; } = "NOCAT";
        public string Desc { get; set; } = "NODESC";
        public bool Report { get; set; } = false;

        public string Output { get; set; } = string.Empty;
    }
}
