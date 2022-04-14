namespace API_MySIRH.DTOs
{
    public class MemoDTO : DtoBase
    {
        public string Titre { get; set; } = string.Empty;
        public string HtmlContent { get; set; } = string.Empty;
        //public DateTime CreationDate { get; set; }
        //public DateTime ModificationDate { get; set; }
    }
}
