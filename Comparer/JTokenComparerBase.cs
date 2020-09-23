using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonCompare.Comparer
{
    abstract class JTokenComparerBase<TJToken> : IComparer<JToken> where TJToken : JToken
    {

        protected TJToken CheckType(JToken item)
        {
            if (item != null && item.GetType() != typeof(TJToken))
                throw new ArgumentException(string.Format("Actual type {0} of token \"{1}\" does not match expected type {2}", item.GetType(), item, typeof(TJToken)));
            return (TJToken)item;
        }

        protected bool TryBaseCompare(TJToken sourceJson, TJToken targetJson, out int comparison)
        {
            CheckType(sourceJson);
            CheckType(targetJson);
            if (object.ReferenceEquals(sourceJson, targetJson))
            {
                comparison = 0;
                return true;
            }
            else if (sourceJson == null)
            {
                comparison = -1;
                return true;
            }
            else if (targetJson == null)
            {
                comparison = 1;
                return true;
            }
            comparison = 0;
            return false;
        }

        protected abstract int CompareDerived(TJToken sourceJson, TJToken targetJson);
        

        protected int TokenCompare(JToken sourceJson, JToken targetJson)
        {
            var tsourceJson = CheckType(sourceJson);
            var ttargetJson = CheckType(targetJson);
            int comp;
            if (TryBaseCompare(tsourceJson, ttargetJson, out comp))
                return comp;
            return CompareDerived(tsourceJson, ttargetJson);
        }

        #region IComparer<JToken> Members

        int IComparer<JToken>.Compare(JToken sourceJson, JToken targetJson)
        {
            return TokenCompare(sourceJson, targetJson);
        }

        #endregion

        
    }
}