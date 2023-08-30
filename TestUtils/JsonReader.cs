using System;
using Newtonsoft.Json.Linq;

namespace NUnitDataDrivenFramework.TestUtils;

public class JsonReader
{
    public string GetTestData(string tokenKey)
    {
        string JsonFile = File.ReadAllText("TestData/TestData.json");
        var JsonObject = JToken.Parse(JsonFile);
        return JsonObject.SelectToken(tokenKey).Value<string>();
    }

}