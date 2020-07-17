using System;
using System.Collections.Generic;

namespace Videos
{
    class video
    {
        private int idUsuari;
        private string url, titol;
        private List<string> tags;

        public video(int idUsuari, string url, string titol, List<string> tags)
        {
            this.idUsuari = idUsuari;
            this.url = url;
            this.titol = titol;
            this.tags = tags;
        }

        public int IdUsuari { get => idUsuari; set => idUsuari = value; }

        public override string ToString()
        {
            return string.Format("Titol: {0}, URL {1}.", titol, url);
        }
    }
}
