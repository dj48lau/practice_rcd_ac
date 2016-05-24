using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileManager.BL;
using FileManager.Model;
using FileManager.DAL;

namespace FileManager.WFA
{
    public partial class Form1 : Form
    {
        List<Model.FileViewModel> files = new List<FileViewModel>();
       // Boolean isDateSelected =false;
        public Form1()
        {
            InitializeComponent();

            FileService _fileservice = new FileService();
            files = _fileservice.GetViewModelList();
            dataGridView1.DataSource = files;

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           // isDateSelected = true;
            Search();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search() 
        {
            String text = textBox1.Text;
            DateTime date = dateTimePicker1.Value;
            String format = textBox2.Text;
            List<Model.FileViewModel> searchList = new List<FileViewModel>();
            MetadataService ms = new MetadataService();
            //string searchResult =
        
            foreach (Model.FileViewModel fv in files) 
            {
               
              /* if (fv.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    searchList.Add(fv);
                }

               if (fv.CreationDate.Date == dateTimePicker1.Value.Date)
                 {
                        searchList.Add(fv);

                 }*/
                if ((fv.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) > 0) && (fv.CreationDate.Date == dateTimePicker1.Value.Date) && (fv.Name.IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) > 0)) 
               {

                   searchList.Add(fv);

               }

                if ((fv.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) > 0) && (fv.CreationDate.Date != dateTimePicker1.Value.Date) && (fv.FormatName.IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) == 0))
               {

                   searchList.Add(fv);

               }

                if ((fv.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) == 0) && (fv.CreationDate.Date == dateTimePicker1.Value.Date) && (fv.FormatName.IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) == 0))
               {

                   searchList.Add(fv);

               }

                if ((fv.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) == 0) && (fv.CreationDate.Date != dateTimePicker1.Value.Date) && (fv.FormatName.IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) > 0))
                {

                    searchList.Add(fv);

                }

                if ((fv.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) > 0) && (fv.CreationDate.Date == dateTimePicker1.Value.Date) && (fv.FormatName.IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) == 0))
               {

                   searchList.Add(fv);

               }

                if ((fv.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) > 0) && (fv.CreationDate.Date != dateTimePicker1.Value.Date) && (fv.FormatName.IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) > 0))
               {

                   searchList.Add(fv);

               }

                if ((fv.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) == 0) && (fv.CreationDate.Date == dateTimePicker1.Value.Date) && (fv.FormatName.IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) > 0))
               {

                   searchList.Add(fv);

               }
              
                
            }
          
            dataGridView1.DataSource = searchList;
        
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
