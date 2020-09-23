using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

/** Author - Tanveer Khan; email - tanveer.khan@outlook.com **/

namespace JsonCompare.Comparer
{
    class JConstructorComparer : JContainerOrderedComparerBase<JConstructor>
    {
        protected override int CompareDerived(JConstructor sourceConstructor, JConstructor targetConstructor)
        {
            int comp;
            if ((comp = sourceConstructor.Name.CompareTo(targetConstructor.Name)) != 0)
                return comp;
            if ((comp = CompareItemsInOrder(sourceConstructor, targetConstructor)) != 0)
                return comp;
            return 0;
        }
    }
}
