namespace AppProduct.Module_5.Lab5.DocumentPrototype
{
    public class Image : IPrototype<Image>
    {
        public string Url { get; set; } = "";
        public string Caption { get; set; } = "";
        public Image Clone() => new Image { Url = Url, Caption = Caption };
    }
}
