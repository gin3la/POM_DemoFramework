using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFramework.utilities
{
    public class JsonReader
    {
        public JsonReader() 
        {
        } 
        public string extractData(string tokenName)
        {
            string myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
        public string GetDropdownPageSize()
        {
            return extractData("dropdown_page_size");
        }
        public string GetSneakerSizeToSelect() 
        {
            return extractData("sneaker_size_to_select");
        }
        public string GetPurchaseOrderNumber()
        {
            return extractData("purchase_order_number");
        }
        public string GetValidUsername()
        {
            return extractData("username_valid");
        }

    }
}
