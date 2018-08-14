﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PCObserve
{
    class Config
    {
        private string ans;
        public Config()
        {
            string url = "http://192.168.1.131:2333/admin.php";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(stream, Encoding.UTF8);
            ans = myStreamReader.ReadToEnd();
            //Console.WriteLine(ans.CompareTo("blacklist_mode"));
        }

        public int check()
        {
            return ans.CompareTo("blacklist_mode");
        }
    }
}
