using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace covid19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int SelectedCountry;
        

        public void Form1_Load(object sender, EventArgs e)
        {
            string countries = "https://api.covid19api.com/countries";
            WebRequest req = HttpWebRequest.Create(countries);
            WebResponse res;
            res = req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            string GetInfo = sr.ReadToEnd();
            List<Countries> countriesList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Countries>>(GetInfo);

            IList<Countries> CountriesSorted = (IList<Countries>)countriesList.OrderBy(x => x.Country);
            CountriesSorted.Select(x => x.Country.Replace("-", "").ToUpper());
            //foreach (var i in CountriesSorted)
            //{
            //    listBox1.Items.Add(i.Country);

            //}
            listBox1.DataSource = CountriesSorted;

            //string sslug = countriesList[SelectedCountry].Slug;
            //MessageBox.Show(sslug)
            //ListBox l = (ListBox)sender;
            //Countries d = (Countries)l.SelectedItem;


        }
        
        class Countries
        {
            public string Country { get; set; }
            public string Slug { get; set; }
        }
        string slgg;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBox l = (ListBox)sender;
            Countries d = (Countries)l.SelectedItem;
            slgg = d.Slug;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Find_Slug();

            MessageBox.Show(slgg);
        }

        private void Find_Slug()
        {
            string country = listBox1.Items[listBox1.SelectedIndex].ToString();
            
        }
    }
}
