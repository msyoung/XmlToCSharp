using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fixie;
using Fixie.Conventions;

namespace Xml2CSharp.Tests.Specs
{
    public class WhenTestConvention : Convention
    {
        public WhenTestConvention()
        {
            Classes.Where(type => type.Namespace.Contains("Specs") && type.Name.StartsWith("When_"));

            Methods
                .Where(method => method.IsVoid());

            Parameters(FromInputAttributes);

        }

        static IEnumerable<object[]> FromInputAttributes(MethodInfo method)
        {
            return method.GetCustomAttributes<InputAttribute>(true).Select(input => input.Parameters);
        }
    }
}
