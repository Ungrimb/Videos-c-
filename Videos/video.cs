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
        
    }
}
