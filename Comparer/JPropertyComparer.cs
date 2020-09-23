using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JsonCompare.Comparer
{
    class JPropertyComparer : JTokenComparerBase<JProperty>
    {
        protected override int CompareDerived(JProperty sourceProperty, JProperty targetProperty)
        {
            int comp;
            if ((comp = sourceProperty.Name.CompareTo(targetProperty.Name)) != 0)
                return comp;
            return JTokenComparer.Instance.Compare(sourceProperty.Value, targetProperty.Value);
        }
    }
}
