using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_6
{
    public partial class Form1 : Form
    {
        Arithmetic arithmetic;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int search = Convert.ToInt32(numericUpDown2.Value);
            MessageBox.Show(arithmetic.k_element(search).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arithmetic = new Arithmetic(Convert.ToInt32(numericUpDown4.Value));
            arithmetic.First = Convert.ToInt32(numericUpDown1.Value);
            arithmetic.Step = Convert.ToInt32(numericUpDown3.Value);
            arithmetic.array_value();
            string str = "";
            foreach (int a in arithmetic.return_elements())
                str += a + "     ";
            label5.Text = "Арифметична прогресія : " + str;
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = Convert.ToInt32(numericUpDown4.Value);
            MessageBox.Show(arithmetic.sum(sum).ToString());
        }
    }

    public abstract class Poslidovnist
    {
        protected int[] Arr;
        private int first_element;
        private int step;

    
        protected Poslidovnist(int element)
        {
            Arr = new int[element];
        }

        public int First
        {
            set
            {
                first_element = value;
            }
            get
            {
                return first_element;
            }
        }
        public virtual int Step
        {
            set
            {
                if (value < 2)
                    step = 2;
                else
                    step = value;
            }
            get
            {
                return step;
            }
        }
        public int [] return_elements()
        {
            return Arr;
        }
        public abstract int sum(int k);
        public abstract int k_element(int k);
    }

    public class Arithmetic : Poslidovnist
    {
        public Arithmetic(int element) : base (element)
        {

        }
        public override int sum(int k)
        {
            int sum = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                sum += Arr[i];
            } 
            return sum;

        }
        public override int k_element(int k)
        {
            return Arr[k-1];
        }
        private int next(int prev, int step)
        {
            return prev + step;
        }
        public void array_value()
        {
            Arr[0] = First;
            for (int i = 1; i < Arr.Length; i++)
                Arr[i] = next(Arr[i - 1], Step);
        }
    }
}
