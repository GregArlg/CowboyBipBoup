using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowboyBipBoup.Model
{
    public class FolderCowboy
    {
        public string Date { get; set; } = "NODATE";
        public string Place { get; set; } = "NOPLACE";
        public string MonoSte { get; set; } = "NOMONOSTE";
        public string Recorder { get; set; } = "NORECORDER";
        public string Micro { get; set; } = "NOMICRO";
        public string Format { get; set; } = "NOFORMAT";
        public string Library { get; set; } = "NOLIB";
        public string Project { get; set; } = "NOPROJ";
        public string? Note { get; set; } = null;

        public List<FileCowboy> FileCowboys { get; set; } = new List<FileCowboy>();
    }
}
