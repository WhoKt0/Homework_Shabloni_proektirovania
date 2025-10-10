using System.Collections.Generic;
using System.Linq;

namespace AppProduct.Module_5.Lab5.DocumentPrototype
{
    public class Document : IPrototype<Document>
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public List<Section> Sections { get; } = new List<Section>();
        public List<Image> Images { get; } = new List<Image>();

        public Document Clone()
        {
            var copy = new Document { Title = Title, Content = Content };
            foreach (var s in Sections.Select(s => s.Clone())) copy.Sections.Add(s);
            foreach (var i in Images.Select(i => i.Clone())) copy.Images.Add(i);
            return copy;
        }
        public override string ToString() => $"{Title} | sections: {Sections.Count} | images: {Images.Count}";
    }
}
