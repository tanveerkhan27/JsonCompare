using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JsonCompare.Comparer
{
    abstract class JContainerOrderedComparerBase<TJToken> : JTokenComparerBase<TJToken> where TJToken : JContainer
    {
        protected int CompareItemsInOrder(TJToken sourceJson, TJToken targetJson)
        {
            int comp;
            // Dictionary order: sort on items before number of items.
            for (int i = 0, n = Math.Min(sourceJson.Count, targetJson.Count); i < n; i++)
                if ((comp = JTokenComparer.Instance.Compare(sourceJson[i], targetJson[i])) != 0)
                    return comp;
            if ((comp = sourceJson.Count.CompareTo(targetJson.Count)) != 0)
                return comp;
            return 0;
        }
    }
}
