using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class CSDL
    {
        public DataTable DTS { get; set; }
        public DataTable DTTG { get; set; }
        public DataTable DTNXB { get; set; }
        
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CSDL();
                return _Instance;
            }
            private set { }
        }
        private static CSDL _Instance;
        private CSDL()
        {
            DTS = new DataTable();
            DTS.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("maSach", typeof(int)),
                new DataColumn("tenSach", typeof(string)),
                new DataColumn("soLuong", typeof(int)),
                new DataColumn("maNXB", typeof(int)),
                new DataColumn("maTG", typeof(string))
            });
            DataRow dr1 = DTS.NewRow();
            dr1["maSach"] = 1001;
            dr1["tenSach"] = "Số đỏ";
            dr1["soLuong"] = 3;
            dr1["maNXB"] = 1101;
            dr1["maTG"] = "1111";
            DTS.Rows.Add(dr1);

            DataRow dr2 = DTS.NewRow();
            dr2["maSach"] = 2002 ;
            dr2["tenSach"] = "Truyện Kiều";
            dr2["soLuong"] = 1;
            dr2["maNXB"] = 2202;
            dr2["maTG"] = "2222";
            DTS.Rows.Add(dr2);

            DataRow dr3 = DTS.NewRow();
            dr3["maSach"] = 3003;
            dr3["tenSach"] = "Mắt biếc";
            dr3["soLuong"] = 2;
            dr3["maNXB"] = 3303;
            dr3["maTG"] = "3333";
            DTS.Rows.Add(dr3);

            DataRow dr4 = DTS.NewRow();
            dr4["maSach"] = 4004;
            dr4["tenSach"] = "Chí phèo";
            dr4["soLuong"] = 3;
            dr4["maNXB"] = 4404;
            dr4["maTG"] = "4444";
            DTS.Rows.Add(dr4);

            DataRow dr5 = DTS.NewRow();
            dr5["maSach"] = 5005;
            dr5["tenSach"] = "Tắt đèn";
            dr5["soLuong"] = 6;
            dr5["maNXB"] = 5505;
            dr5["maTG"] = "5555";
            DTS.Rows.Add(dr5);

            DTTG = new DataTable();
            DTTG.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("maTG" , typeof(string)),
                new DataColumn("tenTG" , typeof(string))
            });

            DataRow tg1 = DTTG.NewRow();
            tg1["maTG"] = "1111";
            tg1["tenTG"] = "Vũ Trọng Phụng";
            DTTG.Rows.Add(tg1);

            DataRow tg2 = DTTG.NewRow();
            tg2["maTG"] = "2222";
            tg2["tenTG"] = "Nguyễn Du";
            DTTG.Rows.Add(tg2);

            DataRow tg3 = DTTG.NewRow();
            tg3["maTG"] = "3333";
            tg3["tenTG"] = "Nguyễn Nhật Ánh";
            DTTG.Rows.Add(tg3);

            DataRow tg4 = DTTG.NewRow();
            tg4["maTG"] = "4444";
            tg4["tenTG"] = "Nam Cao";
            DTTG.Rows.Add(tg4);

            DataRow tg5 = DTTG.NewRow();
            tg5["maTG"] = "5555";
            tg5["tenTG"] = "Ngô Tất Tố";
            DTTG.Rows.Add(tg5);

            DTNXB = new DataTable();
            DTNXB.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("maNXB", typeof(int)),
                new DataColumn("tenNXB" , typeof(string))
            });
            DataRow nxb1 = DTNXB.NewRow();
            nxb1["maNXB"] = 1101;
            nxb1["tenNXB"] = "Vũ Trọng Phụng";
            DTNXB.Rows.Add(nxb1);

            DataRow nxb2 = DTNXB.NewRow();
            nxb2["maNXB"] = 2202;
            nxb2["tenNXB"] = "Nguyễn Du";
            DTNXB.Rows.Add(nxb2);

            DataRow nxb3 = DTNXB.NewRow();
            nxb3["maNXB"] = 3303;
            nxb3["tenNXB"] = "Nguyễn Nhật Ánh";
            DTNXB.Rows.Add(nxb3);

            DataRow nxb4 = DTNXB.NewRow();
            nxb4["maNXB"] = 4404;
            nxb4["tenNXB"] = "Nam Cao";
            DTNXB.Rows.Add(nxb4);

            DataRow nxb5 = DTNXB.NewRow();
            nxb5["maNXB"] = 5505;
            nxb5["tenNXB"] = "Ngô Tất Tố";
            DTNXB.Rows.Add(nxb5);
        }
        public void AddDataRowSach(Sach s)
        {
            DataRow dr = DTS.NewRow();
            dr["maSach"] = s.maSach;
            dr["tenSach"] = s.tenSach;
            dr["soLuong"] = s.soLuong;
            dr["maTG"] = s.maTG;
            dr["maNXB"] = s.maNXB;
            DTS.Rows.Add(dr);
        }
        public void EditDataRowSach(Sach s)
        {
            foreach(DataRow i in DTS.Rows)
            {
                if(Convert.ToInt32(i["maSach"].ToString()) == s.maSach)
                {
                    CSDL.Instance.DTS.Rows.Remove(i);
                    DataRow dr = DTS.NewRow();
                    dr["tenSach"] = s.tenSach;
                    dr["soLuong"] = s.soLuong;
                    dr["maTG"] = s.maTG;
                    dr["maNXB"] = s.maNXB;
                    DTS.Rows.Add(dr);
                    return;
                }
            }
        }
        public void DeleteDataRow(int maSach)
        {
            foreach(DataRow item in CSDL.Instance.DTS.Select())
            {

                if ((int)item["maSach"] == maSach)
                {
                    item.Delete();
                }
            }
        }
}
}
