using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistanceHammingLevenshtein
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int Levenshtein(String a,String b)
        {
            int n = a.Length;
            int m = b.Length;
            int[,] D = new int[n + 1, m + 1];
            D[0, 0] = 0;
            for (int i = 1; i <= n; i++)
            {
                D[i, 0] = D[i - 1, 0] + 1;
            }
            for (int j = 1; j <= m; j++)
            {
                D[0, j] = D[0, j - 1] + 1;
            }
            int e1 = 0, e2 = 0, e3 = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {

                    if (!(a[i - 1].Equals(b[j - 1])))
                    {
                        e1 = D[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        e1 = D[i - 1, j - 1];

                    }
                    e2 = D[i - 1, j] + 1;
                    e3 = D[i, j - 1] + 1;
                    D[i, j] = Math.Min(e1, Math.Min(e2, e3));
                }
            }
            return D[n,m];
        }
        private int Hamming(String a,String b)
        {
            int n = a.Length;
            int d = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] != b[i])
                    d++;
            }
            return d;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String x = textBox1.Text.ToLower().Trim();
            String y = textBox2.Text.ToLower().Trim();
            int n = x.Length;
            int m = y.Length;
            if (n!=m)
            {
               
                textBox3.Text =this.Levenshtein(x,y) + "";
            }
            else if (n == m)
            {
                textBox3.Text = this.Hamming(x, y) + "";
            }
        }
        
    }
}
