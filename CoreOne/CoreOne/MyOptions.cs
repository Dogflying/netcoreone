using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreOne
{
    public class MyOptions
    {
        public MyOptions()
        {
            Option1 = "varlue_from_ctor";
        }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
    }
}
