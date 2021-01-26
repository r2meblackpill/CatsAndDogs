using System;
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
using Newtonsoft.Json;

namespace CatsAndDogs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getADog_Click(object sender, EventArgs e)
        {
            dogPicture.Load(CallDogAPI());
            dogPicture.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        public static string CallDogAPI()
        {
            string apiCall = "https://dog.ceo/api/breeds/image/random";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiCall);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            string APIResponse;

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Dog dog = JsonConvert.DeserializeObject<Dog>(response);

                APIResponse = dog.message;
            }

            return APIResponse;
        }
        
        public static string CallCatAPI()
        {
            string apiCall = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiCall);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            string APIResponse;

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Cat cat = JsonConvert.DeserializeObject<Cat>(response);

                APIResponse = cat.message;
            }

            return APIResponse;
        }
    }
}
