using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BullsandCows
{
    public partial class Form1 : Form
    {
        BullsandCowsDelegate mBullsandCows;
        delegateMethod mdelegateMethod;

        public Form1()
        {
            InitializeComponent();

            mdelegateMethod = new delegateMethod();
            mBullsandCows = new BullsandCowsDelegate();
            mBullsandCows.setFunction_checkAns(mdelegateMethod.checkAns_repeat);
            mBullsandCows.setFunction_RandomAns(mdelegateMethod.randomAns_repeat);
            mBullsandCows.generateAns();


            // set richtextbox read only
            this.richTextBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;

            // set the focus at textbox1
            this.textBox1.Select();

        }

        private void enterNumber_Click(object sender, EventArgs e)
        {
            // check entered number
            List<int> digits = TearNumbersToList(Convert.ToInt32(this.textBox1.Text));
            if (digits.Count == mdelegateMethod.get_digits())
            {
                // compute BullsandCows
                mBullsandCows.checkAnswer(Convert.ToInt32(this.textBox1.Text));

                // print history
                Button thisButton = (Button)sender;
                List<string> loglist = mBullsandCows.get_Log();
                string history = "";
                for (int i = 0; i < loglist.Count; i++)
                {
                    history = history  + loglist[i] + "\n";
                }
                this.richTextBox1.Text = history;
                this.richTextBox1.SelectionStart = richTextBox1.Text.Length;
                this.richTextBox1.ScrollToCaret();
                this.textBox1.Clear();
            }
            else {
                string history = "";
                history = this.richTextBox1.Text + "You must enter the right digits." + "\n";
                this.richTextBox1.Text = history;
                this.richTextBox1.SelectionStart = richTextBox1.Text.Length;
                this.richTextBox1.ScrollToCaret();
                this.textBox1.Clear();
            }
        }

        private void new_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            this.textBox1.Clear();
            mBullsandCows.reset();
            mBullsandCows.generateAns();
            this.textBox1.Select();
        }

        private void hotKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.PerformClick();
            } else if (e.KeyCode == Keys.F1) {
                this.button2.PerformClick();
            }
        }

        List<int> TearNumbersToList(int Numbers)
        {
            int digits = Numbers.ToString().Length;
            List<int> retunList = new List<int>();
            int tempNumbers = Numbers;
            for (int i = 0; i < digits; i++)
            {
                int pow = (int)Math.Pow(10, digits - 1 - i);
                int tempNum = tempNumbers / pow;
                tempNumbers = tempNumbers - pow * tempNum;
                retunList.Add(tempNum);
            }
            return retunList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mBullsandCows != null) {
                this.textBox2.Text = mBullsandCows.get_correctAns().ToString();
            }
        }
    }
}
