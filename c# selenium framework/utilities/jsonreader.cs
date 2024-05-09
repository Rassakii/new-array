using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__selenium_framework.utilities
{
    public class jsonreader
    {
        public jsonreader()
        {

           
        }
        public string extractdata(String tokenname)
        {
            String myjsonstring = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myjsonstring);
            return jsonObject.SelectToken("username").Value<string>();



        }


    }
}
