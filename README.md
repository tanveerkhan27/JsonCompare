# JsonCompare
dotnet core json compare library, useful for API test validations
this library does deep comparision of json and support all the types i.e JArray/JConstructor/JObject/jProperty/JValue


usage :

        public void TestMethod1()
        {
          string actualjson = "{'test':'testing'}";
          string expectedjson = "{'test':'testing'}";
          JsonCompare.Compare(actualjson,expectedjson);
        }

        ----- Test Execution Summary -----

        JsonCompareTest.UnitTest1.TestMethod1:
            Outcome: Passed

        Total tests: 1. Passed: 1. Failed: 0. Skipped: 0
        
        ----- Test Execution Summary -----
        
         [xUnit.net 00:00:00.84]     JsonCompareTest.UnitTest1.TestMethod1 [FAIL]                                                                                                                                         
         X JsonCompareTest.UnitTest1.TestMethod1 [129ms]                                                                                                                                                                
         Error Message:
           NUnit.Framework.AssertionException : test:Testing value has not matched
         
         Total tests: 1. Passed: 0. Failed: 1. Skipped: 0

If you want to ignore certain values which are random in nature you can use $jsonignore (keyword)
example - 

output json from your call - 
        {
          'test': 'testing',
          'date': '26/09/2020'
        }
        
expected json for comparison as:

        {
           'test': 'testing',
           'date': '$jsoningore'
        }
