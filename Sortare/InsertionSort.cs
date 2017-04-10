using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sortare
{
    public partial class InsertionSort : Form
    {
        public InsertionSort()
        {
            InitializeComponent();
        }

        FrmNext fnext = new FrmNext();

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j, aux1, aux2, c = 0, ok = 0, k, m;
            int[] a = new int[100];
            int[] b = new int[100];
            int[] v = new int[100];
            int n;
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
            Brush pen = new SolidBrush(Color.Blue);
            Brush pen2 = new SolidBrush(Color.Red);
            g.Clear(SystemColors.Control);
            label2.Text = null;
            richTextBox2.Text = null;
            for (k = 0; k <= n; k++)
                g.FillRectangle(pen, 50 * k, 0, 50, b[k] * 30);
            for (k = 0; k <= n; k++)
                g.DrawLine(new Pen(SystemColors.Control), new Point(50 * k, 0), new Point(50 * k, 500));
            Button[] btn = new Button[100];
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
            for(i = 1; i <= n; i++)
                {j = i;
                while (j > 0 && a[j - 1] > a[j])
                {
                    g.FillRectangle(pen2, 50 * (j - 1), 0, 50, b[j - 1] * 30);
                    g.FillRectangle(pen2, 50 * j, 0, 50, b[j] * 30);
                    g.DrawLine(new Pen(SystemColors.Control), new Point(50 * (j - 1), 0), new Point(50 * (j - 1), 500));
                    g.DrawLine(new Pen(SystemColors.Control), new Point(50 * j, 0), new Point(50 * j, 500));
                    fnext.lblMove.Text = "Schimba " + a[j-1] + " cu  " + a[j];
                    fnext.ShowDialog();
                    aux1 = a[j];
                    aux2 = b[j];
                    a[j] = a[j-1];
                    b[j] = b[j-1];
                    j--;
                    a[j] = aux1;
                    b[j] = aux2;
                    g.Clear(SystemColors.Control);
                    for (k = 0; k <= n; k++)
                        g.FillRectangle(pen, 50 * k, 0, 50, b[k] * 30);
                    for (k = 0; k <= n; k++)
                        g.DrawLine(new Pen(SystemColors.Control), new Point(50 * k, 0), new Point(50 * k, 500));
                    for (k = 0; k <= n; k++)
                        btn[k].Text = Convert.ToString(a[k]);
                }
                }
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