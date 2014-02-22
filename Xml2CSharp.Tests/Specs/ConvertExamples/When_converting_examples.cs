using System;
using System.IO;
using System.Linq;
using FluentAssertions;

namespace Xml2CSharp.Tests.Specs.ConvertExamples
{
    public class When_converting_examples
    {
        public When_converting_examples()
        {
            
        }

        [Input("BeetAnGeSample.xml")]
        [Input("Binchois.xml")]
        public void Then_no_duplicate_classes_are_created(string fileName)
        {
            var classInfo = new Xml2CSharpConverer().Convert(File.ReadAllText(Path.Combine("Specs\\ConvertExamples", fileName)));
            var writer = new ClassInfoWriter(classInfo);
            writer.Write(Console.Out);
            classInfo.Select(c => c.Name).Distinct().Should().HaveCount(classInfo.Count());
        }

    }
}