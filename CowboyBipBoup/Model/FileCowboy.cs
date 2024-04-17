using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowboyBipBoup.Model
{
    public class FileCowboy
    {
        public string? OriginalName { get; set; } = null;
        public string Category { get; set; } = "NOCAT";
        public string Desc { get; set; } = "NODESC";
        public bool Report { get; set; } = false;

    }
}
