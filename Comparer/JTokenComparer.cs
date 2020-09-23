using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


/** Author - Tanveer Khan; email - tanveer.khan@outlook.com **/


namespace JsonCompare.Comparer
{
    public class JTokenComparer : IComparer<JToken>
    {
        public static JTokenComparer Instance { get { return instance; } }

        static JTokenComparer instance;

        static JTokenComparer()
        {
            instance = new JTokenComparer();
        }

        readonly Dictionary<Type, KeyValuePair<int, IComparer<JToken>>> dict;

        JTokenComparer()
        {
            dict = new Dictionary<Type, KeyValuePair<int, IComparer<JToken>>>
            {
                // Order chosen semi-arbitrarily.  Putting values first seems reasonable though.
                {typeof(JValue), new KeyValuePair<int, IComparer<JToken>>(0, new JValueComparer()) },
                {typeof(JProperty), new KeyValuePair<int, IComparer<JToken>>(1, new JPropertyComparer()) },
                {typeof(JArray), new KeyValuePair<int, IComparer<JToken>>(2, new JArrayComparer()) },
                {typeof(JObject), new KeyValuePair<int, IComparer<JToken>>(3, new JObjectComparer()) },
                {typeof(JConstructor), new KeyValuePair<int, IComparer<JToken>>(4, new JConstructorComparer()) },
                };
        }

        #region IComparer<JToken> Members

        public int Compare(JToken sourceJson, JToken targetJson)
        {

            if (sourceJson is JRaw || targetJson is JRaw)
                throw new InvalidOperationException("Tokens of type JRaw cannot be sorted");
            if (object.ReferenceEquals(sourceJson, targetJson))
                return 0;
            else if (sourceJson == null)
                return -1;
            else if (targetJson == null)
                return 1;


            var typeData1 = dict[sourceJson.GetType()];
            var typeData2 = dict[targetJson.GetType()];

            int comp;
            if ((comp = typeData1.Key.CompareTo(typeData2.Key)) != 0)
                return comp;
            if (typeData1.Value != typeData2.Value)
                throw new InvalidOperationException("inconsistent dictionary values"); // Internal error
            return typeData2.Value.Compare(sourceJson, targetJson);
        }

        #endregion
    }

}
