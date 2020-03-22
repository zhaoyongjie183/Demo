using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 双色球
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> resultNum = new List<string>();

        private List<string> DltResultNum = new List<string>();

        private List<string> DltResultBlueNum = new List<string>();

        private bool isGoOn = true;

        /// <summary>
        /// 获取红球
        /// </summary>
        /// <returns></returns>
        private string GetRedNum(int maxNum)
        {
            Random random = new Random();

            return random.Next(1, maxNum).ToString("00");
        }

        /// <summary>
        /// 获取篮球
        /// </summary>
        /// <returns></returns>
        private string GetBlue()
        {
            Random random = new Random();

            return random.Next(1, 17).ToString("00");
        }

        /// <summary>
        /// 判断红球是否存在
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string ExisitNum(string num)
        {

            string number = num;

            while (!string.IsNullOrEmpty(resultNum.FirstOrDefault(x => x.Equals(number))))
            {
                number = GetRedNum(34);
            }

            resultNum.Add(number);

            return number;
        }

        /// <summary>
        /// 获取大乐透红球
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string DaLeTouRedNum(string num)
        {

            string number = num;

            while (!string.IsNullOrEmpty(DltResultNum.FirstOrDefault(x => x.Equals(number))))
            {
                number = GetRedNum(36);
            }

            DltResultNum.Add(number);

            return number;
        }

        /// <summary>
        /// 获取大乐透红球
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string DaLeTouBlueNum(string num)
        {

            string number = num;

            while (!string.IsNullOrEmpty(DltResultBlueNum.FirstOrDefault(x => x.Equals(number))))
            {
                number = GetRedNum(13);
            }

            DltResultBlueNum.Add(number);

            return number;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;

                    if (textBox.Name == "textBox7")
                    {
                        this.Invoke(new Action(() => textBox.Text = GetBlue()));
                    }
                    else
                    {
                        this.Invoke(new Action(() => textBox.Text = ExisitNum(GetRedNum(34))));
                    }
                }
            }

            resultNum = new List<string>();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                while (isGoOn)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.button1.Enabled = false;
                    }));
                    foreach (var item in groupBox2.Controls)
                    {
                        if (item is TextBox)
                        {
                            TextBox textBox = (TextBox)item;

                            if (textBox.Name == "textBox8")
                            {
                                this.Invoke(new Action(() =>
                                {
                                    textBox.Text = GetBlue();
                                }));
                            }
                            else
                            {
                                this.Invoke(new Action(() =>
                                {
                                    textBox.Text = ExisitNum(GetRedNum(34));
                                }));
                            }
                        }
                    }
                    resultNum = new List<string>();
                }
            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;

                    if (textBox.Name.Contains("Blue"))
                    {
                        textBox.Text = DaLeTouBlueNum(GetRedNum(13));
                    }
                    else
                    {
                        textBox.Text = DaLeTouRedNum(GetRedNum(36));
                    }
                }
            }
            DltResultBlueNum = new List<string>();

            DltResultNum = new List<string>();
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            this.isGoOn = false;

            MessageBox.Show(string.Join(",", resultNum));
        }
    }
}
