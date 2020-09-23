using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonCompare.Comparer;
using NUnit.Framework;

/** Author - Tanveer Khan; email - tanveer.khan@outlook.com **/

namespace JsonCompare
{
    public class JsonCompare
    {
        private static dynamic sourceJson;
        private static dynamic targetJson;

        public static void Compare(string sourceJsonString, string targetJsonString)
        {

                if (sourceJsonString.Substring(0, 1).ToLower() == "[")
                {
                    sourceJson = JsonConvert.DeserializeObject<JArray>(sourceJsonString);
                    targetJson = JsonConvert.DeserializeObject<JArray>(targetJsonString);
                    int comp = JTokenComparer.Instance.Compare(sourceJson, targetJson);
                    Assert.IsTrue(comp == 0);
                    Console.WriteLine(comp);

                }
                else
                {
                    sourceJson = JsonConvert.DeserializeObject<JObject>(sourceJsonString);
                    targetJson = JsonConvert.DeserializeObject<JObject>(targetJsonString);
                    int comp = JTokenComparer.Instance.Compare(sourceJson, targetJson);
                    Assert.IsTrue(comp == 0);
                    Console.WriteLine(comp);
                }

        }
    }
}
