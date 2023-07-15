using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace unitechRFID_CSharp_Sample.Model
{
    public class Product 
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("eid")]
        public string Eid { get; set; }

        [JsonProperty("edited_time")]
        public DateTime EditedTime { get; set; }
        
    }
}