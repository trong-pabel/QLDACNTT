using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class CBBItemNXB
    {
        //public static object cbbmaNXB { get; set; }
        //public static object cbbtenNXB { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
