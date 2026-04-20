namespace BookShop.Web.Client.Settings;

public class FileSettings
{
    public int FileSizeLimit { get; set; }
    public List<string> PermittedExtensions { get; set; } = [];
}
