using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using FluentAssertions;
using Xml2CSharp.ExampleOutputs;

namespace Xml2CSharp.Tests.Specs.Reading
{
    public class When_reading_from_example_file_cd_catalog
    {
        private CATALOG root;

        public When_reading_from_example_file_cd_catalog()
        {
            var readAllText = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\ExamplesFiles\\cd_catalog.xml"));

            var xmlSerializer = new XmlSerializer(typeof(CATALOG));
            root = (CATALOG)xmlSerializer.Deserialize(readAllText);
        }

        public void Then_cd_is_populated()
        {
            root.CD.First().TITLE.Should().Be("Empire Burlesque");
            root.CD.First().ARTIST.Should().Be("Bob Dylan");
            root.CD.First().COUNTRY.Should().Be("USA");
            root.CD.First().COMPANY.Should().Be("Columbia");
            root.CD.First().PRICE.Should().Be("10.90");
            root.CD.First().YEAR.Should().Be("1985");

        }

    }
}