using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelAIWindowsTools
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        string keyword => File.ReadAllLines("config.ini")[1];
        int seed
        {
            get
            {
                var value = int.Parse(File.ReadAllLines("config.ini")[3]);
                if (value == 0)
                {
                    value = random.Next(65535);
                }
                return value;
            }
        }
        string model => int.Parse(File.ReadAllLines("config.ini")[5]) == 0 ? "safe-diffusion" : "nai-diffusion";

        int generateCount => int.Parse(File.ReadAllLines("config.ini")[7]);
        int width
        {
            get
            {
                var value = int.Parse(File.ReadAllLines("config.ini")[9]);
                return (value / 64 + (value % 64 > 32 ? 1 : 0)) * 64;
            }
        }
        int height
        {
            get
            {
                var value = int.Parse(File.ReadAllLines("config.ini")[11]);
                return (value / 64 + (value % 64 > 32 ? 1 : 0)) * 64;
            }
        }
        RestClient client;
        RestRequest request;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => true;

        public void Init()
        {
            Directory.CreateDirectory("text2img");
            text_Tag.Text = keyword;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            client = new RestClient("https://api.novelai.net/ai/generate-image");
            client.Timeout = -1;

        }
        public void TextToImage(int num)
        {
            request = new RestRequest(Method.POST);
            request.AddHeader("authority", "api.novelai.net");
            request.AddHeader("accept", "*/*");
            request.AddHeader("accept-language", "zh-CN,zh;q=0.9");
            request.AddHeader("authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjdJVTY1N3l4YzhVX3ZFVWU3dkwxSiIsIm5jIjoiY2NkSHoyc3BDc1luU29mWkloUUpzIiwiaWF0IjoxNjY2ODM5MjMwLCJleHAiOjE2Njk0MzEyMzB9.81py6Lr_qxgrAo8FTQXY_SBFPoRinLfdxK4X9xuispE");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("origin", "https://novelai.net");
            request.AddHeader("referer", "https://novelai.net/");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"106\", \"Google Chrome\";v=\"106\", \"Not;A=Brand\";v=\"99\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");
            client.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36";
            var body = $@"{{""input"":""masterpiece, best quality,{keyword}"",""model"":""{model}"",""parameters"":{{""width"":{width},""height"":{height},""scale"":11,""sampler"":""k_euler_ancestral"",""steps"":28,""seed"":{seed + num},""n_samples"":1,""ucPreset"":0,""qualityToggle"":true,""uc"":""lowres, bad anatomy, bad hands, text, error, missing fingers, extra digit, fewer digits, cropped, worst quality, low quality, normal quality, jpeg artifacts, signature, watermark, username, blurry""}}}}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine("返回数据包长度" + response.Content.Length);
            try
            {
                var data = response.Content.Replace("event: newImage\nid: 1\ndata:", "");
                byte[] bytes = Convert.FromBase64String(data);
                string fileName = $"text2img/[masterpiece, best quality,{keyword}]_{seed + num}.jpg";
                File.WriteAllBytes(fileName, bytes);

                pictureBox.Invoke(new EventHandler(delegate
                {
                    using (Image image = Image.FromFile(fileName))
                    {
                        Bitmap temp = new Bitmap(image);
                        pictureBox.Image = temp;
                    }
                }));
            }
            catch (Exception)
            {
                Console.WriteLine("图片解析出错");
            }
        }

        private void btn_Text2Img_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                TextToImage(seed);
                Console.WriteLine(DateTime.Now + "生成完毕");
            });
        }

        private void btn_Text2Imgs_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                for (int i = 0; i < generateCount; i++)
                {
                    TextToImage(seed + i);
                    Console.WriteLine(DateTime.Now + "生成完毕");
                    await Task.Delay(5000);
                }
            });
        }

        private void btn_Config_Click(object sender, EventArgs e) => Process.Start("config.ini");

        private void btn_images_Click(object sender, EventArgs e) => Process.Start("text2img");

        private void text_Tag_TextChanged(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("config.ini");
            lines[1] = text_Tag.Text;
            File.WriteAllLines("config.ini", lines);
        }
    }
}
