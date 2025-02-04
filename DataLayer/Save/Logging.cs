using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataLayer
{
    public static class Logging
    {
        public static void Log(string mensagem)
        {
            string caminho = "./Logs.txt";
            StreamWriter file = new StreamWriter(caminho, true, Encoding.Default);
            file.WriteLine(DateTime.Now + " > " + mensagem);
            file.Dispose();
        }
    }
}
