using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Asyncs2
{
    public class Team
    {
        [JsonIgnore]
        public int id { get; set; }
        public string school { get; set; }
        public string mascot { get; set; }
        [JsonIgnore]
        public List<Coach> CoachNavigation { get; set; } = new List<Coach>();
    }
}
