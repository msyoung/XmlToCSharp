using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Xml2CSharp
{
    public class ClassInfoWriter
    {
        private readonly IEnumerable<Class> _classInfo;

        public ClassInfoWriter(IEnumerable<Class> classInfo)
        {
            _classInfo = classInfo;
        }

        public void Write(TextWriter textWriter)
        {
            using (textWriter)
                foreach (var @class in _classInfo)
                {
                    textWriter.WriteLine("[XmlRoot(ElementName=\"{0}\", Namespace=\"{1}\")]", @class.XmlName, @class.Namespace);
                    textWriter.WriteLine("public class {0} {{", @class.Name);
                    foreach (var field in @class.Fields)
                    {
                        textWriter.WriteLine("\t[Xml{0}({0}Name=\"{1}\", Namespace=\"{2}\")]", field.XmlType, field.XmlName, field.Namespace);
                        textWriter.WriteLine("\tpublic {0} {1};", field.Type, field.Name);
                    }
                    textWriter.WriteLine("}");
                    textWriter.WriteLine("");
                }
        }
    }
}