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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB1();
            SetCBB2();
            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public void SetCBB1()
        {
            comboBox1.Items.Add(new CBBItemTG
            {
                Text1 = "0",
                Text = "ALL"
            });
            foreach (TG i in CSDL_OOP.Instance.GetAllTG())
            {
                comboBox1.Items.Add(new CBBItemTG
                {
                    Text1 = i.maTG,
                    Text = i.tenTG
                });
            }
        }

        public void SetCBB2()
        {
            comboBox3.Items.Add(new CBBItemNXB
            {
                Value = 0,
                Text = "ALL"
            });
            foreach (NXB i in CSDL_OOP.Instance.GetAllNXB())
            {
                comboBox3.Items.Add(new CBBItemNXB
                {
                    Value = i.maNXB,
                    Text = i.tenNXB
                });
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Show(string TG,int NXB, string Name)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.GetListSach(TG,NXB, Name);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Show(((CBBItemTG)comboBox1.SelectedItem).Text1, ((CBBItemNXB)comboBox3.SelectedItem).Value, textBox1.Text);
            /*
            string SearchText = textBox1.Text;
            List<Sach> s;
            s = CSDL_OOP.Instance.GetAllSach();
            dataGridView1.DataSource = s;
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string SearchText = textBox1.Text;
            List<Sach> s;
            s = CSDL_OOP.Instance.GetAllSach();
            dataGridView1.DataSource = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.d = Add;
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            try
            {
                f.EditS(dataGridView1.SelectedCells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Vui long chon Sach de edit");
                return;
            }
            f.d = Edit;
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Add(DataRow s)
        {
            DataRow d = CSDL.Instance.DTS.NewRow();
            d["maSach"] = s["maSach"];
            d["tenSach"] = s["tenSach"];
            d["soLuong"] = s["soLuong"];
            d["maTG"] = s["maTG"];
            d["maNXB"] = s["maNXB"];
            CSDL.Instance.DTS.Rows.Add(d);
        }
        public void Edit(DataRow s)
        {
            foreach (DataRow d in CSDL.Instance.DTS.Rows)
            {
                if (d["maSach"].ToString() == s["maSach"].ToString())
                {
                    d["maSach"] = s["maSach"];
                    d["tenSach"] = s["tenSach"];
                    d["soLuong"] = s["soLuong"];
                    d["maTG"] = s["maTG"];
                    d["maNXB"] = s["maNXB"];
                }

            }


        }
    }
}
