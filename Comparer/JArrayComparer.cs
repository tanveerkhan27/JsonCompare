using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

/** Author - Tanveer Khan; email - tanveer.khan@outlook.com **/

namespace JsonCompare.Comparer
{

    class JArrayComparer : JContainerOrderedComparerBase<JArray>
    {
        protected override int CompareDerived(JArray sourceArray, JArray targetArray)
        {
            int comp;
            if ((comp = CompareItemsInOrder(sourceArray, targetArray)) != 0)
                return comp;
            return 0;
        }
    }
}
