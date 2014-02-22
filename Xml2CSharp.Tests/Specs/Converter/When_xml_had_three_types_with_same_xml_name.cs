using System.Collections.Generic;
using System.Linq;

namespace Xml2CSharp.Tests.Specs.Converter
{
    public class When_xml_had_three_types_with_same_xml_name
    {
                private readonly IEnumerable<Class> _classInfo;

                public When_xml_had_three_types_with_same_xml_name()
        {
            const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE score-partwise PUBLIC ""-//Recordare//DTD MusicXML 3.0 Partwise//EN"" ""http://www.musicxml.org/dtds/partwise.dtd"">
<score version=""3.0"">
  <movement-title>Excerpt from Magnificat secundi toni</movement-title>
  <identification>
    <creator type=""composer"">Gilles Binchois</creator>
    <rights>Copyright © 2010 Recordare LLC</rights>
    <encoding>
      <software>Finale 2011 for Windows</software>
      <software>Dolet 6.0 for Finale</software>
      <encoding-date>2011-08-08</encoding-date>
      <supports attribute=""new-system"" element=""print"" type=""yes"" value=""yes""/>
      <supports attribute=""new-page"" element=""print"" type=""yes"" value=""yes""/>
    </encoding>
  </identification>
<identification>
    <rights>Copyright © 2010 Recordare LLC</rights>
    <encoding>
      <software>Finale 2011 for Windows</software>
      <software>Dolet 6.0 for Finale</software>
      <encoding-date>2011-08-08</encoding-date>
      <supports attribute=""new-system"" element=""print"" type=""yes"" value=""yes""/>
      <supports attribute=""new-page"" element=""print"" type=""yes"" value=""yes""/>
    </encoding>
  </identification>
<identification>
    <creator type=""composer"">Gilles Binchois</creator>
    <encoding>
      <software>Finale 2011 for Windows</software>
      <software>Dolet 6.0 for Finale</software>
      <encoding-date>2011-08-08</encoding-date>
      <supports attribute=""new-system"" element=""print"" type=""yes"" value=""yes""/>
      <supports attribute=""new-page"" element=""print"" type=""yes"" value=""yes""/>
    </encoding>
  </identification>
</score>
";
            _classInfo = new Xml2CSharpConverer().Convert(xml);
        }

        public void Then_each_version_gets_its_own_name()
        {
            _classInfo.Single(x => x.Name == "identification");
            _classInfo.Single(x => x.Name == "identification2");
            _classInfo.Single(x => x.Name == "identification3");
        } 
    }
}