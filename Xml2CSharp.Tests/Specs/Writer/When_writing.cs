using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;

namespace Xml2CSharp.Tests.Specs.Writer
{
    public class When_writing
    {
        private InMemoryTextWriter stringWriter;

        public When_writing()
        {
            var classInfo = new[]
                {
                    new Class
                    {
                        Name = "MyClass",
                        XmlName = "MyClass",
                        Namespace = "",
                        Fields = new[]
                        {
                            new Field
                            {
                                Name = "Age",
                                Type = "String",
                                XmlType = XmlType.Element,
                                XmlName = "Age2",
                                Namespace = "wibble"
                            },
                            new Field
                            {
                                Name = "Name",
                                Type = "String",
                                XmlName = "Name",
                                XmlType = XmlType.Attribute
                            },
                        }
                    }
                
            };

            var writer = new ClassInfoWriter(classInfo);
            stringWriter = new InMemoryTextWriter();
            writer.Write(stringWriter);
        }

        public void Then_classes_are_marked_with_xml_root()
        {
            stringWriter.Lines[0].Should().Be("[XmlRoot(ElementName=\"MyClass\", Namespace=\"\")]");
        }

        public void Then_classes_are_public()
        {
            stringWriter.Lines[1].Should().Be("public class MyClass {");
        }

        public void Then_fields_are_marked_with_xml_type()
        {
            stringWriter.Lines[2].Should().Be("\t[XmlElement(ElementName=\"Age2\", Namespace=\"wibble\")]");
        }

        public void Then_fields_are_public()
        {
            stringWriter.Lines[3].Should().Be("\tpublic String Age;");
        }

        public void Then_writer_is_flushed()
        {
            stringWriter.IsDisposed.Should().BeTrue();
        }
    }

    public class InMemoryTextWriter : TextWriter
    {
        public readonly List<string> Lines = new List<string>();

        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }

        public bool IsDisposed { get; set; }

        public override void WriteLine(string format, params object[] arg)
        {
            Lines.Add(string.Format(format, arg));
        }

        public override void WriteLine(string value)
        {
            Lines.Add(value);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            IsDisposed = true;
        }
    }
}