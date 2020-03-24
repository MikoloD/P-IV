using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Asyncs2
{
    public class Team
    {
        public int id { get; set; }
        public string school { get; set; }
        public string mascot { get; set; }
        public virtual CoachTB CoachNavigation { get; set; }
    }
}
