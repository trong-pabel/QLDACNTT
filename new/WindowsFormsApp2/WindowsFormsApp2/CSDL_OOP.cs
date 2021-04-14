using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CSDL_OOP();
                return _Instance;
            }
            private set { }
        }
        private CSDL_OOP() { }
        public Sach GetSach(DataRow i)
        {
            return new Sach
            {
                maSach = Convert.ToInt32(i["maSach"].ToString()),
                tenSach = i["tenSach"].ToString(),
                soLuong = Convert.ToInt32(i["soLuong"].ToString()),
                maNXB = Convert.ToInt32(i["maNXB"].ToString()),
                maTG = i["maTG"].ToString()
            };
        }
        public List<Sach> GetAllSach()
        {
            List<Sach> data = new List<Sach>();
            foreach (DataRow i in CSDL.Instance.DTS.Rows)
            {
                data.Add(GetSach(i));
            }
            return data;
        }

        public List<Sach> GetListSach(string TG,int NXB, string Name)
        {
            List<Sach> data = new List<Sach>();
            foreach (Sach i in GetAllSach())
            {
                if ((i.maTG == TG || TG == "0") && (i.maNXB == NXB || NXB == 0) && i.tenSach.Contains(Name))
                {
                    data.Add(new Sach
                    {
                        maSach = i.maSach,
                        tenSach = i.tenSach,
                        soLuong = i.soLuong,
                        maNXB = i.maNXB,
                        maTG = i.maTG
                    });
                }
            }
            return data;
        }

        

        public TG GetTG(DataRow i)
        {
            return new TG
            {
                maTG = i["maTG"].ToString(),
                tenTG = i["tenTG"].ToString()
            };
        }
        public List<TG> GetAllTG()
        {
            List<TG> data = new List<TG>();
            foreach (DataRow i in CSDL.Instance.DTTG.Rows)
            {
                data.Add(GetTG(i));
            }
            return data;
        }

        public NXB GetNXB(DataRow i)
        {
            return new NXB
            {
                maNXB = Convert.ToInt32(i["maNXB"].ToString()),
                tenNXB = i["tenNXB"].ToString()
            };
        }
        public List<NXB> GetAllNXB()
        {
            List<NXB> data = new List<NXB>();
            foreach (DataRow i in CSDL.Instance.DTNXB.Rows)
            {
                data.Add(GetNXB(i));
            }
            return data;
        }

        /*
        public void ExecuteDB(Sach s)
        {
            bool check = false;
            foreach (Sach i in GetAllSach())
            {
                if (i.maSach == s.maSach)
                    check = true;
            }
            if (check)
                CSDL.Instance.EditDataRowSach(s);
            else CSDL.Instance.AddDataRowSach(s);
        }
        public Sach GetSachBymaSach(int maSach)
        {
            Sach s = new Sach();
            foreach (Sach i in GetAllSach())
            {
                if (i.maSach == maSach)
                    s = i;
            }
            return s;
        }
        public void DeleteSach(int maSach)
        {
            CSDL.Instance.DeleteDataRow(maSach);
        }
        */
    }
}
