using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using FluentAssertions;
using Xml2CSharp.ExampleOutputs;

namespace Xml2CSharp.Tests.Specs.Reading
{
    public class When_reading_from_example_file_namespaces
    {
        private root root;

        public When_reading_from_example_file_namespaces()
        {
            var readAllText = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\ExamplesFiles\\namespaces.xml"));

            var xmlSerializer = new XmlSerializer(typeof(root));
            root = (root)xmlSerializer.Deserialize(readAllText);
        }

        public void Then_table_is_populated()
        {
            root.table.Should().NotBeNull();
            root.table.tr.Should().NotBeNull();
            root.table.tr.td.Should().HaveCount(2);
            root.table.tr.td.First().Should().Be("Apples");
            root.table.tr.td.Last().Should().Be("Bananas");
        }

        public void Then_table2_is_populated()
        {
            root.table2.Should().NotBeNull();
            root.table2.name.Should().Be("African Coffee Table");
            root.table2.width.Should().Be("80");
            root.table2.length.Should().Be("120");
        }
    }
}