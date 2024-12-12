using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaConfig.Utils
{
    public class Responce
    {
        public int code { get; set; }
        public object data { get; set; }
        public string message { get; set; }

        public Responce(int code, object data, string message)
        {
            this.code = code;
            this.data = data;
            this.message = message;
        }
    }
}
