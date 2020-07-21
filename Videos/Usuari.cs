using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace Videos
{
    class Usuari
    {
        public int idUsuari { get; set; }
        public string nom { get; set; }
        public string cognom { get; set; }
        public string password { get; set; }
        public string data { get; set; }

        private int status = 1;

        private List<video> videos = new List<video>();

        public Usuari(int idUsuari, string nom, string cognom, string password, string data)
        {
            this.idUsuari = idUsuari;
            if (string.IsNullOrEmpty(nom))
                throw new ArgumentException();
            else this.nom = nom;
            if (string.IsNullOrEmpty(cognom))
                throw new ArgumentException();
            else this.cognom = cognom;
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException();
            else this.password = password;
            this.data = data;
        }
        public void CreateVideo(string url, string titol, List<string> tags, int status)
        {
            videos.Add(new video(idUsuari, url, titol, tags,status));
        }
        public void PrintVideos()
        {
            foreach (var v in videos)
            {
                Console.WriteLine(v);
            }
        }
        public bool IsUser(string nom)
        {
            bool resultado=false;
            return resultado;
        }
        public video IsVideo(string name)
        {
            foreach (var v in videos)
            {
                if (v.Titol==name) return v;
            }
            return null;
        }
        public int Status(video video)
        { 
            return video.Status;
        }
        public override string ToString()
        {
            return string.Format("Usuario: {0} {1} Creado el {2}.", nom, cognom, data);
        }

    }
}
