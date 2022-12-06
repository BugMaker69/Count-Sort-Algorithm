// Copyright © 2022 Omar ElSaadany | All rights reserved
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountSortAlgo
{
    public partial class CountAlg : Form
    {
        public CountAlg()
        {
            InitializeComponent();
        }

        void ClearOutPut()
        {
            OutPut.Items.Clear();
        }

        void CountSort(int[] arr,int size)
        {
            int[] output = new int[size+1];
            int max = arr[0];

            for(int i=1;i<size;i++)
            {
                if (arr[i] > max) 
                {
                    max = arr[i]; 
                }
            }

            int[] count = new int[max+1];

            for (int i = 0; i < max; ++i)
            {
                count[i] = 0;
            }

            for (int i = 0; i < size; i++)
            {
                count[arr[i]]++;
            }

            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = size - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i];
                count[arr[i]]--;
            }

            for (int i = 0; i < size; ++i)
            {
                arr[i] = output[i];
                OutPut.Items.Add(arr[i]);
            }
        }

        private void AddData_Click(object sender, EventArgs e)
        {
            EnteredData.Select();
            int value;
            if (int.TryParse(EnteredData.Text, out value))
            { 
                ListData.Items.Add(value); ClearOutPut();
            }
            else
            { 
                MessageBox.Show("Enter No. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            EnteredData.Clear();
        }

        private void SortData_Click_1(object sender, EventArgs e)
        {
            ClearOutPut();
            int n = ListData.Items.Count;
            int[] values = new int[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = Convert.ToInt32(ListData.Items[i]);
            }
            CountSort(values, n);
        }

        private void DeleteData_Click_1(object sender, EventArgs e)
        {
            if (ListData.SelectedItem != null)
            {
                ListData.Items.Remove(ListData.SelectedItem);
                ClearOutPut();
            }
            else
            {
                MessageBox.Show("Select Element First", "UNSELECTED ELEMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearData_Click_1(object sender, EventArgs e)
        {
            ListData.Items.Clear();
            ClearOutPut();
        }
    }
}
// Copyright © 2022 Omar ElSaadany | All rights reserved
