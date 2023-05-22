namespace Book_Sharing.Models
{
    public class Dimensions
    {
        public string height { get; set; }
    }

    public class BookImageLinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
    }

    public class Layer
    {
        public string layerId { get; set; }
        public string volumeAnnotationsVersion { get; set; }
    }

    public class LayerInfo
    {
        public List<Layer> layers { get; set; }
    }

    public class BookRoot
    {
        public string kind { get; set; }
        public string id { get; set; }
        public string etag { get; set; }
        public string selfLink { get; set; }
        public BookVolumeInfo volumeInfo { get; set; }
        public LayerInfo layerInfo { get; set; }
        public SaleInfo saleInfo { get; set; }
        public AccessInfo accessInfo { get; set; }
    }

    public class BookVolumeInfo
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public List<string> authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public List<IndustryIdentifier> industryIdentifiers { get; set; }
        public ReadingModes readingModes { get; set; }
        public int pageCount { get; set; }
        public int printedPageCount { get; set; }
        public Dimensions dimensions { get; set; }
        public string printType { get; set; }
        public List<string> categories { get; set; }
        public double averageRating { get; set; }
        public int ratingsCount { get; set; }
        public string maturityRating { get; set; }
        public bool allowAnonLogging { get; set; }
        public string contentVersion { get; set; }
        public PanelizationSummary panelizationSummary { get; set; }
        public BookImageLinks imageLinks { get; set; }
        public string language { get; set; }
        public string previewLink { get; set; }
        public string infoLink { get; set; }
        public string canonicalVolumeLink { get; set; }
    }

}
