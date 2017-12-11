using IF.Lastfm.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCenter.Models
{
    public class SearchResult
    {
        public SearchResult()
        {
            Artists = new List<LastArtist>();
            Albums = new List<LastAlbum>();
            Tracks = new List<LastTrack>();
        }
        public List<LastArtist> Artists { get; set; }
        public List<LastAlbum> Albums { get; set; }
        public List<LastTrack> Tracks { get; set; }
        public string SearchReqest { get; set; }

    }
}