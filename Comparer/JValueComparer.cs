using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

/** Author - Tanveer Khan; email - tanveer.khan@outlook.com **/

namespace JsonCompare.Comparer
{

    class JValueComparer : JTokenComparerBase<JValue>
    {
        protected override int CompareDerived(JValue sourceValue, JValue targetValue)
        {
            
            if (!(sourceValue.Type == JTokenType.Null))
            {
                if (targetValue.Value.ToString().ToLower() == "$jsonignore")
                {
                    var xparentProperty = ((JProperty)sourceValue.Parent);
                    var yparentProperty = ((JProperty)targetValue.Parent);    
                    if (xparentProperty.Name == yparentProperty.Name)
                        Console.WriteLine("{0}:{1} value has been ignored", xparentProperty.Name, xparentProperty.Value);
                        return 0;
                }
            }
            
            int comp = Comparer<JToken>.Default.Compare(sourceValue, targetValue);
            
            if(comp!=0)
            {
                var xparentProperty = ((JProperty)sourceValue.Parent);
                var yparentProperty = ((JProperty)targetValue.Parent);
                Assert.Fail("{0}:{1} value has not matched", xparentProperty.Name, xparentProperty.Value);
                return 1;
            }
            else
                return 0;
        }
    }
}
