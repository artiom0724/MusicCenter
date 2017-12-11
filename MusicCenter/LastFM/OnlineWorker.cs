using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Objects;
using MusicCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace LastFM
{
    public class OnlineWorker
    {
        private string reqestUrl;
        private string api_key;
        private string shared_secret;
        private LastfmClient lastfmClient;

        public List<LastArtist> artists;
        public List<LastAlbum> albums;
        public List<LastTrack> tracks;

        public void LastFmStart()
        {
            reqestUrl = "http://ws.audioscrobbler.com/2.0";
            api_key = "4d071ebc3076c381b896936c00648fc7";
            shared_secret = "183381d2084b31ebc7bfc9945ac0011c";
        }

        public OnlineWorker()
        {
            LastFmStart();
            artists = new List<LastArtist>();
            albums = new List<LastAlbum>();
            tracks = new List<LastTrack>();
            lastfmClient = new LastfmClient(api_key, shared_secret, new HttpClient());
            //var response = lastfmClient.Auth.GetSessionTokenAsync("artiom0724", "xtkjdtr1998.Q");
        }

        public async Task<List<LastArtist>> TopArtistsForViewAsync(int numPage)
        {
            artists.Clear();
            var request = await lastfmClient.Chart.GetTopArtistsAsync(numPage,8);
            artists.AddRange(request.Content);
            return artists;
        }

        public async Task<List<LastAlbum>> TopAlbumsForViewAsync(int numPage)
        {
            albums.Clear();
            var request = await lastfmClient.Artist.GetTopAlbumsAsync(artists.First().Name, false, numPage, 8);
            albums.AddRange(request.Content);
            return albums;
        }

        public async Task<List<LastTrack>> TopTracksForViewAsync(int numPage)
        {
            tracks.Clear();
            var request = await lastfmClient.Chart.GetTopTracksAsync(numPage, 28);
            tracks.AddRange(request.Content);
            return tracks;
        }

        public string EncodingFromUTF8toWin1251(string encodeElement)
        {
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            byte[] utf8Bytes = win1251.GetBytes(encodeElement);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            return win1251.GetString(win1251Bytes);
        }

        public string EncodingFromWin1251ToUTF8(string encodeElement)
        {
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            byte[] win1251Bytes = utf8.GetBytes(encodeElement);
            byte[] utf8Bytes = Encoding.Convert(win1251, utf8, win1251Bytes);
            return utf8.GetString(utf8Bytes);
        }
    }
}