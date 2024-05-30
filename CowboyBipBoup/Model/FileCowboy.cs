namespace CowboyBipBoup.Model
{
    public class FileCowboy : IDisposable
    {
        public string OriginalName { get; set; } = "NOORIGINALNAME";
        public string Category { get; set; } = "NOCAT";
        public string Desc { get; set; } = "NODESC";

        public bool IsUCS { get; set; } = false;
        public bool IsMemory { get; set; } = false;

        public bool IsValid { get; set; } = true;

        public string Output { get; set; } = string.Empty;

        public void Dispose()
        {

        }
    }
}
