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
                StreamReader reader = new StreamReader(_Path);
                read = reader.ReadToEnd();

                return read;
            }
            catch (FileNotFoundException)
            {
                return "file not found";

            }
            catch (FileLoadException)
            {
                return "file could not load";
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
            }
            catch (Exception e)
            {

                Console.WriteLine($"no se pudo escribir el archivo {e.Message}");
            }

        }
        public static string ReadWebResponse(string _Http, string _Method){
            var request = (HttpWebRequest)WebRequest.Create(_Http);
            request.Method = _Method;
            request.ContentType = "application/json";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();
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
