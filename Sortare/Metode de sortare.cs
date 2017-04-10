using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sortare
{
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
        }

        private void executareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BubbleSort f = new BubbleSort();
            f.Show();
        }

        private void descriereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BubbleSortDescriere f = new BubbleSortDescriere();
            f.Show();
        }

        private void executareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectionSort f = new SelectionSort();
            f.Show();
        }

        private void descriereToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectionSortDescriere f = new SelectionSortDescriere();
            f.Show();
        }

        private void executareToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            InsertionSort f = new InsertionSort();
            f.Show();
        }

        private void descriereToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            InsertionSortDescriere f = new InsertionSortDescriere();
            f.Show();
        }

        private void descriereToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MergeSortDescriere f = new MergeSortDescriere();
            f.Show();
        }

        private void executareToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MergeSort f = new MergeSort();
            f.Show();
        }

        private void descriereToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            QuickSortDescriere f = new QuickSortDescriere();
            f.Show();
        }

        private void executareToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            QuickSort f = new QuickSort();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}