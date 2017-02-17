using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel;    //ODS
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TracksForPlaylistSelection> TracksForPlaylistSelection_Get(int id, string fetchBy)
        {
            List<TracksForPlaylistSelection> results = null;
            using (var context = new ChinookContext())
            {
                switch (fetchBy)
                {
                    case "Artist":
                        {
                            results = (from x in context.Tracks
                                       where x.Album.ArtistId == id
                                       select new TracksForPlaylistSelection
                                       {
                                           TrackId = x.TrackId,
                                           Name = x.Name,
                                           Title = x.Album.Title,
                                           MediaName = x.MediaType.Name,
                                           GenreName = x.Genre.Name,
                                           Composer = x.Composer,
                                           Milliseconds = x.Milliseconds,
                                           Bytes = x.Bytes,
                                           UnitPrice = x.UnitPrice
                                       }).ToList();
                            break;
                        }

                    case "Media":
                        {
                            results = (from x in context.Tracks
                                       where x.MediaType.MediaTypeId == id
                                       select new TracksForPlaylistSelection
                                       {
                                           TrackId = x.TrackId,
                                           Name = x.Name,
                                           Title = x.Album.Title,
                                           MediaName = x.MediaType.Name,
                                           GenreName = x.Genre.Name,
                                           Composer = x.Composer,
                                           Milliseconds = x.Milliseconds,
                                           Bytes = x.Bytes,
                                           UnitPrice = x.UnitPrice
                                       }).ToList();
                            break;
                        }
                    case "Genre":
                        {
                            results = (from x in context.Tracks
                                       where x.Genre.GenreId == id
                                       select new TracksForPlaylistSelection
                                       {
                                           TrackId = x.TrackId,
                                           Name = x.Name,
                                           Title = x.Album.Title,
                                           MediaName = x.MediaType.Name,
                                           GenreName = x.Genre.Name,
                                           Composer = x.Composer,
                                           Milliseconds = x.Milliseconds,
                                           Bytes = x.Bytes,
                                           UnitPrice = x.UnitPrice
                                       }).ToList();
                            break;
                        }
                    default:
                        {
                            results = (from x in context.Tracks
                                       where x.Album.AlbumId == id
                                       select new TracksForPlaylistSelection
                                       {
                                           TrackId = x.TrackId,
                                           Name = x.Name,
                                           Title = x.Album.Title,
                                           MediaName = x.MediaType.Name,
                                           GenreName = x.Genre.Name,
                                           Composer = x.Composer,
                                           Milliseconds = x.Milliseconds,
                                           Bytes = x.Bytes,
                                           UnitPrice = x.UnitPrice
                                       }).ToList();
                            break;
                        }
                }
            }
            return results;
        }
    }
}
