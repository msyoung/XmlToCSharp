using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Xml2CSharp.ExampleOutputs
{
    [XmlRoot(ElementName = "tr", Namespace = "http://www.w3.org/TR/html4/")]
    public class tr
    {
        [XmlElement(ElementName = "", Namespace = "http://www.w3.org/TR/html4/")]
        public List<String> td;
    }
    [XmlRoot(ElementName = "table", Namespace = "http://www.w3.org/TR/html4/")]
    public class table
    {
        [XmlElement(ElementName = "tr", Namespace = "http://www.w3.org/TR/html4/")]
        public tr tr;
    }
    [XmlRoot(ElementName = "table", Namespace = "http://www.w3schools.com/furniture")]
    public class table2
    {
        [XmlElement(ElementName = "name", Namespace = "http://www.w3schools.com/furniture")]
        public String name;
        [XmlElement(ElementName = "width", Namespace = "http://www.w3schools.com/furniture")]
        public String width;
        [XmlElement(ElementName = "length", Namespace = "http://www.w3schools.com/furniture")]
        public String length;
    }
    [XmlRoot(ElementName = "root", Namespace = "")]
    public class root
    {
        [XmlElement(ElementName = "table", Namespace = "http://www.w3.org/TR/html4/")]
        public table table;
        [XmlElement(ElementName = "table", Namespace = "http://www.w3schools.com/furniture")]
        public table2 table2;
        [XmlAttribute(AttributeName = "h", Namespace = "http://www.w3.org/2000/xmlns/")]
        public String h;
        [XmlAttribute(AttributeName = "f", Namespace = "http://www.w3.org/2000/xmlns/")]
        public String f;
    }




}
