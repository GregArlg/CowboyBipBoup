using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowboyBipBoup.Model
{
    public class ManagerCowboy
    {
        public string? SourcePath { get; set; } = null;
        public List<FolderCowboy> FolderCowboys { get; set; } = new List<FolderCowboy>();
    }
}