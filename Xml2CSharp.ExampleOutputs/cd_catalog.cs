using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Xml2CSharp.ExampleOutputs
{
    [XmlRoot(ElementName = "CD", Namespace = "")]
    public class CD
    {
        [XmlElement(ElementName = "TITLE", Namespace = "")]
        public String TITLE;
        [XmlElement(ElementName = "ARTIST", Namespace = "")]
        public String ARTIST;
        [XmlElement(ElementName = "COUNTRY", Namespace = "")]
        public String COUNTRY;
        [XmlElement(ElementName = "COMPANY", Namespace = "")]
        public String COMPANY;
        [XmlElement(ElementName = "PRICE", Namespace = "")]
        public String PRICE;
        [XmlElement(ElementName = "YEAR", Namespace = "")]
        public String YEAR;
    }

    [XmlRoot(ElementName = "CATALOG", Namespace = "")]
    public class CATALOG
    {
        [XmlElement(ElementName = "", Namespace = "")]
        public List<CD> CD;
    }

}
