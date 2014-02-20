using Fixie;
using Fixie.Conventions;

namespace Xml2CSharp.Tests
{
    public class WhenTestConvention : Convention
    {
        public WhenTestConvention()
        {
            Classes.Where(type => type.Namespace.Contains("Specs") && type.Name.StartsWith("When_"));

            Methods
                .Where(method => method.IsVoid());

        }
    }
}
