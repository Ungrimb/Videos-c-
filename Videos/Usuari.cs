using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Videos
{
    class Usuari
    {
        public Usuari(int idUsuari,string nom, string cognom, string password, string data)
        {
            this.idUsuari = idUsuari;
            this.nom = nom;
            this.cognom = cognom;
            this.password = password;
            this.data = data;
        }

        public int idUsuari { get; set; }
        public string nom { get; set; }
        public string cognom { get; set; }
        public string password { get; set; }
        public string data { get; set; }
    }
}
