        String myjsonstring = File.ReadAllText("utilities/testData.json");
        var jsonObject = JToken.Parse(myjsonstring);
        Console.WriteLine(jsonObject.SelectToken("username").Value<string;

