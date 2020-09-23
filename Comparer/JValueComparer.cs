using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

/** Author - Tanveer Khan; email - tanveer.khan@outlook.com **/

namespace JsonCompare.Comparer
{

    class JValueComparer : JTokenComparerBase<JValue>
    {
        protected override int CompareDerived(JValue x, JValue y)
        {
            if (!(x.Type == JTokenType.Null))
            {
                if (y.Value.ToString().ToLower() == "$jsonignore")
                {
                    var xparentProperty = ((JProperty)x.Parent);
                    var yparentProperty = ((JProperty)y.Parent);
                    if (xparentProperty.Name == yparentProperty.Name)
                        Console.WriteLine("{0}:{1} value has been ignored", xparentProperty.Name, xparentProperty.Value);
                        return 0;
                }
            }

            return Comparer<JToken>.Default.Compare(x, y); // JValue implements IComparable<JValue>

        }
    }
}
