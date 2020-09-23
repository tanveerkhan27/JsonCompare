using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

/** Author - Tanveer Khan; email - tanveer.khan@outlook.com **/

namespace JsonCompare.Comparer
{
    class JObjectComparer : JTokenComparerBase<JObject>
    {
        protected override int CompareDerived(JObject sourceObject, JObject targetObject)
        {
            int comp;
            // Dictionary order: sort on items before number of items.
            // Order both property sequences to preserve reflexivity.
            foreach (var propertyComp in sourceObject.Properties().OrderBy(p => p.Name).Zip(targetObject.Properties().OrderBy(p => p.Name), (sourceObjectp, targetObjectp) => JTokenComparer.Instance.Compare(sourceObjectp, targetObjectp)))
                if (propertyComp != 0)
                    return propertyComp;
            if ((comp = sourceObject.Count.CompareTo(targetObject.Count)) != 0)
                return comp;
            return 0;
        }
    }
}
