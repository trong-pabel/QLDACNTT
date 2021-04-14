using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        /*
        public delegate void MyDel(int maSach, string tenSach);
        public MyDel d { get; set; }
        public int maSach { get; set; }
        public Form2(int m)
        {
            InitializeComponent();
            maSach = m;
            SetGUI();
        }
        public void SetGUI()
        {
            if (CSDL_OOP.Instance.GetSachBymaSach(maSach) != null)
            {
                textBox1.Text = CSDL_OOP.Instance.GetSachBymaSach(maSach).maSach.ToString();
                textBox2.Text = CSDL_OOP.Instance.GetSachBymaSach(maSach).tenSach;
                textBox3.Text = CSDL_OOP.Instance.GetSachBymaSach(maSach).soLuong.ToString();
                comboBox2.SelectedIndex = CSDL_OOP.Instance.GetSachBymaSach(maSach).maNXB - 1;
                comboBox3.SelectedIndex = Convert.ToInt32(CSDL_OOP.Instance.GetSachBymaSach(maSach).maTG) - 1;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sach s = new Sach();
            CSDL_OOP.Instance.ExecuteDB(s);
            d(0, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        */
        public Form2()
        {
            InitializeComponent();
            Setcbb1();
            Setcbb2();
        }

        public void Setcbb1()
        {

            foreach (TG i in CSDL_OOP.Instance.GetAllTG())
            {
                comboBox2.Items.Add(new CBBItemTG
                {
                    Text1 = i.maTG,
                    Text = i.tenTG
                });
            }


        }

        public void Setcbb2()
        {

            foreach (NXB i in CSDL_OOP.Instance.GetAllNXB())
            {
                comboBox1.Items.Add(new CBBItemNXB
                {
                    Value = i.maNXB,
                    Text = i.tenNXB
                });
            }
        }

        public delegate void MyDel(DataRow sv);
        public MyDel d;
        
        public void EditS(string maSach)
        {
            textBox1.Text = maSach;
            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow s = CSDL.Instance.DTS.NewRow();
            s["maSach"] = textBox1.Text.ToString();
            s["tenSach"] = textBox2.Text.ToString();
            s["soLuong"] = textBox3.Text.ToString();
            s["maTG"] = ((CBBItemTG)comboBox2.SelectedItem).Text1;
            s["maNXB"] = ((CBBItemNXB)comboBox1.SelectedItem).Value;
            d(s);
            this.Close();
        }
    }

}
