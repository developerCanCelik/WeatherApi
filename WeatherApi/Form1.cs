using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WeatherApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string api = "afbacc67a05b6756487b2ba103ef34bf";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=uşak&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument weather = XDocument.Load(connection);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var speed = weather.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var nem = weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;

            var weatherstate = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            lbl_temp.Text = temp;
            lbl_rzg.Text = speed + " m/s";
            lbl_nem.Text = nem + " %";
            lbl_ygs.Text = "0 %";
            lbl_state.Text = weatherstate.ToUpper();
        }
    }
}
