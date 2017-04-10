using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sortare
{
    public partial class QuickSort : Form
    {
        public QuickSort()
        {
            InitializeComponent();
        }
        
        FrmNext fnext = new FrmNext();
        Brush pen = new SolidBrush(Color.Blue);
        Brush pen2 = new SolidBrush(Color.Red);
        Button[] btn = new Button[100];
        int n;

        void qSort(int[] a, int[] b, int st, int dr)
        {
            Graphics g = panel1.CreateGraphics();
            int temp, min, max, mijl, k;
            mijl = a[st + (dr - st) / 2];
            min = st; max = dr;
            do
            {
                while (a[min] < mijl) min++;
                while (a[max] > mijl) max--;
                if (min <= max)
                {
                    g.FillRectangle(pen2, 50 * min, 0, 50, b[min] * 30);
                    g.FillRectangle(pen2, 50 * max, 0, 50, b[max] * 30);
                    g.DrawLine(new Pen(SystemColors.Control), new Point(50 * min, 0), new Point(50 * min, 500));
                    g.DrawLine(new Pen(SystemColors.Control), new Point(50 * max, 0), new Point(50 * max, 500));
                    fnext.lblMove.Text = "In intervalul [" + st + "," + dr + "] schimbam " + a[min] + " cu  " + a[max];
                    fnext.ShowDialog();
                    temp = a[min];
                    a[min++] = a[max];
                    a[max--] = temp;
                    temp = b[min - 1];
                    b[min - 1] = b[max + 1];
                    b[max + 1] = temp;
                    g.Clear(SystemColors.Control);
                    for (k = 0; k <= n; k++)
                        g.FillRectangle(pen, 50 * k, 0, 50, b[k] * 30);
                    for (k = 0; k <= n; k++)
                        g.DrawLine(new Pen(SystemColors.Control), new Point(50 * k, 0), new Point(50 * k, 500));
                    for (k = 0; k <= n; k++)
                        btn[k].Text = Convert.ToString(a[k]);
                }
            } while (min <= max);
            if (st < max) qSort(a, b, st, max);
            if (dr > min) qSort(a, b, min, dr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j, aux1, c = 0, ok = 0, k, m;
            int[] a = new int[100];
            int[] b = new int[100];
            int[] v = new int[100];
            string s;
            s = richTextBox1.Text;
            n = 0;
            for (i = 0; i < 100; i++)
                v[i] = 0;
            for (i = 0, j = s.Length; i < j; i++)
                if (s[i] != ' ')
                {
                    if (s[i] == '-') ok = 1;
                    else
                    {
                        switch (s[i])
                        {
                            case '0': c = 0; break;
                            case '1': c = 1; break;
                            case '2': c = 2; break;
                            case '3': c = 3; break;
                            case '4': c = 4; break;
                            case '5': c = 5; break;
                            case '6': c = 6; break;
                            case '7': c = 7; break;
                            case '8': c = 8; break;
                            case '9': c = 9; break;
                            default: break;
                        }
                        v[n] = v[n] * 10 + c;
                    }
                }
                else
                {
                    if (ok == 1)
                    { v[n] = v[n] * (-1); ok = 0; }
                    n++;
                }
            if (ok == 1)
            { v[n] = v[n] * (-1); ok = 0; }
            for (i = 0; i <= n; i++)
                a[i] = v[i];
            for (i = 0; i < n; i++)
                for (j = i + 1; j <= n; j++)
                    if (v[i] > v[j])
                    {
                        aux1 = v[i];
                        v[i] = v[j];
                        v[j] = aux1;
                    }
            for (i = 0; i <= n; i++)
                for (j = 0; j <= n; j++)
                    if (a[i] == v[j])
                    { b[i] = j + 1; break; }
            m = n;
            for (i = 1; i <= m + 1; i++)
            {
                ok = 0;
                for (j = 0; j <= n; j++)
                    if (b[j] == i)
                        ok = 1;
                if (ok == 0)
                {
                    for (j = 0; j <= n; j++)
                        if (b[j] > i)
                            b[j]--;
                    m--; i--;
                }
            }
            Graphics g = panel1.CreateGraphics();
            g.Clear(SystemColors.Control);
            label2.Text = null;
            richTextBox2.Text = null;
            for (k = 0; k <= n; k++)
                g.FillRectangle(pen, 50 * k, 0, 50, b[k] * 30);
            for (k = 0; k <= n; k++)
                g.DrawLine(new Pen(SystemColors.Control), new Point(50 * k, 0), new Point(50 * k, 500));
            for (k = 0; k <= n; k++)
            {
                btn[k] = new Button();
                btn[k].Location = new Point(54 + 50 * k, 33);
                btn[k].Visible = true;
                btn[k].Text = Convert.ToString(a[k]);
                btn[k].Size = new Size(50, 30);
                this.Controls.Add(btn[k]);
                btn[k].BringToFront();
            }
            qSort(a, b, 0, n);
            for (k = 0; k <= n; k++)
                btn[k].Visible = false;
            label2.Text = "Sirul a fost sortat!";
            for (k = 0; k <= n; k++)
                richTextBox2.Text = richTextBox2.Text + Convert.ToString(a[k]) + "  ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}