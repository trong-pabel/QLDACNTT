using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class NXB
    {
        public int maNXB { get; set; }
        public string tenNXB { get; set; }
        public NXB()
        {

        }
        public NXB(DataRow Row)
        {
            maNXB = (int)Row["maNXB"];
            tenNXB = Row["tenNXB"].ToString();
        }

        
    }
}
