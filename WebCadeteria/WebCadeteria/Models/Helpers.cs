using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace WebCadeteria.Helpers
{
    class HelperModules
    {
        public static string ReadFile(string _Path)
        {
            try
            {
                string read;
                using (FileStream stream = new FileStream(_Path, FileMode.OpenOrCreate))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        read = reader.ReadToEnd();
                        return read;
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static void WriteFile(string _Content, string _Path)
        {
            try
            {
                if (!File.Exists(_Path))
                {
                    File.Create(_Path).Close();
                }
                StreamWriter writer = new StreamWriter(_Path, false);
                writer.WriteLine(_Content);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }

        }
        public static string ReadWebResponse(string _Http, string _Method)
        {
            var request = (HttpWebRequest)WebRequest.Create(_Http);
            request.Method = _Method;
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    string recieved = "";
                    if (stream != null)
                    {
                        StreamReader reader = new StreamReader(stream);
                        recieved = reader.ReadToEnd();
                    }
                    return recieved;
                }
            }
        }
    }
}
