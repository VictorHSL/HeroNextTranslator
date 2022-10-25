using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HeroNextTranslator
{
    [XmlRoot(ElementName = "text")]
    public class Text
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlText]
        public string Content { get; set; }
    }

    [XmlRoot(ElementName = "texts")]
    public class Texts
    {
        [XmlElement(ElementName = "text")]
        public List<Text> Text { get; set; }
    }

    [XmlRoot(ElementName = "localizationDictionary")]
    public class LocalizationDictionary
    {
        [XmlElement(ElementName = "texts")]
        public Texts Texts { get; set; }
        [XmlAttribute(AttributeName = "culture")]
        public string Culture { get; set; }
    }
}
