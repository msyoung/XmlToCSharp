using System.Linq;
using FluentAssertions;
using System.Collections.Generic;

namespace Xml2CSharp.Tests.Specs.Converter
{
    public class When_simple_xml
    {
        private readonly IEnumerable<Class> _classInfo;

        public When_simple_xml()
        {
            const string xml = @"<xml></xml>";
            _classInfo = new Xml2CSharpConverer().Convert(xml);
        }

        public void Then_class_count_is_one()
        {
            _classInfo.Should().HaveCount(1);
        }
        
        public void Then_class_name_is_xml()
        {
            _classInfo.First().Name.Should().Be("xml");
        }

        public void Then_class_has_no_fields()
        {
            _classInfo.First().Fields.Should().BeEmpty();
        }

    }
}