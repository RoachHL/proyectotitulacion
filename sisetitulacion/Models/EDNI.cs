using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisetitulacion.Models
{
    public class EDNI
    {
        public string _token { get; set; }
        public string dni { get; set; }

        public EDNI()
        {

        }

        public EDNI(string token, string dni)
        {
            _token = token;
            this.dni = dni;
        }
    }
}