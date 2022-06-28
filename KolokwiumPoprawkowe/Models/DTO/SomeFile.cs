namespace KolokwiumPoprawkowe.Models.DTO
{
    public class SomeFile
    {
        public int FileID { get; set; }

        public int TeamID { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public int FileSize { get; set; }

        public virtual SomeTeam SomeTeam { get; set; }
    }
}
