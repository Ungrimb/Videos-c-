﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Videos
{
    class Usuari
    {
        public int idUsuari { get; set; }
        public string nom { get; set; }
        public string cognom { get; set; }
        public string password { get; set; }
        public string data { get; set; }
        public Usuari(int idUsuari,string nom, string cognom, string password, string data)
        {
            this.idUsuari = idUsuari;
            this.nom = nom;
            this.cognom = cognom;
            this.password = password;
            this.data = data;
        }

        public video CreateVideo(string url, string titol, List<string> tags)
        {
            video newVideo = new video(idUsuari, url, titol, tags);
            return newVideo;
        }

        public bool IsUser(string nom)
        {
            bool resultado=false;
            return resultado;
        }

        public override string ToString()
        {
            return string.Format("Usuario: {0} {1} Creado el {2}.", nom, cognom, data);
        }

    }
}
