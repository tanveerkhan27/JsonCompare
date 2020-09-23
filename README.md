# JsonCompare
dotnet core json compare library, useful for API test validations
this library does deep comparision of json and support all the types i.e JArray/JConstructor/JObject/jProperty/JValue

usage :

        public void TestMethod1()
        {
          string actualjson = "{'test':'testing'}";
          string expectedjson = "{'test':'testing'}";
          Assert.Equal(4, 4);
          JsonCompare.JsonCompare.Compare(actualjson,expectedjson);
        }
