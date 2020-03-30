using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Asyncs2
{
    public class Season
    {
        [JsonIgnore]
        public int id { get; set; }
        public string school { get; set; }
        
    }
    public class Coach
    {
        [JsonIgnore]
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public List<Season> seasons { get; set; }
        [JsonIgnore]
        public virtual Team TeamNavigation { get; set; }
    }
}