namespace AppProduct.Module_5.Lab5.DocumentPrototype
{
    public class Section : IPrototype<Section>
    {
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";
        public Section Clone() => new Section { Title = Title, Text = Text };
    }
}
