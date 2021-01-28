using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBot.Models
{
    public class AdviceResponse
    {
        public Slip slip { get; set; }
    }
    public class Slip
    {
        public int id { get; set; }
        public string advice { get; set; }
    }

}
