using System;
using System.Collections.Generic;

namespace Videos
{
    class video
    {
        private int idUsuari;
        private string url, titol;
        private List<string> tagsVideo;
        private int status;

        public video(int idUsuari, string url, string titol, List<string> tags,int status)
        {
            this.idUsuari = idUsuari;
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException();
            else this.url = url;
            if (string.IsNullOrEmpty(titol))
                throw new ArgumentException();
            else this.titol = titol;
            this.tagsVideo = tags;
            this.status = status;
        }

        public int IdUsuari { get => idUsuari; set => idUsuari = value; }
        public string Url { get => url; set => url = value; }
        public string Titol { get => titol; set => titol = value; }
        public List<string> Tags { get => tagsVideo; set => tagsVideo = value; }
        public int Status { get => status; set => status = value; }

        public override string ToString()
        {
            var result = string.Join(",", tagsVideo);
            return string.Format("Titol: {0}, URL {1}. Tags: {2}", titol, url, result);
        }
    }
}
