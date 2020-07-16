using System;
using System.Collections.Generic;

namespace Videos
{
    class video
    {

        public video(string url, string titol, List<string> tags)
        {
            this.url = url;
            this.titol = titol;
            this.tags = tags;
        }

        public string url { get; set; }
        public string titol { get; set; }
        public List<string> tags { get; set; }
    }
}
