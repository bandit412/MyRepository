using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additonal Namespaces
using System.ComponentModel; //ODS
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class PlaylistTrackController
    {
        // this method returns the tracks for the desired playlist
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<TracksForPlaylist> PlaylistTracks_Get(string playlistName)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.PlaylistTracks
                              where x.Playlist.Name.Equals(playlistName)
                              orderby x.TrackNumber
                              select new TracksForPlaylist
                              {
                                  TrackId = x.TrackId,
                                  TrackNumber = x.TrackNumber,
                                  Name = x.Track.Name,
                                  Title = x.Track.Album.Title,
                                  Milliseconds = x.Track.Milliseconds,
                                  UnitPrice = x.Track.UnitPrice,
                                  Purchased = true
                              };
                return results.ToList();
            }
        } //eom

        public void AddTrackToPlaylist(string playlistName, int trackId)
        {
            using (var context = new ChinookContext())
            {
                int trackNumber = 0;
                Playlist existing = (from x in context.Playlists
                                     where x.Name.Equals(playlistName)
                                     select x).FirstOrDefault();
                PlaylistTrack newTrack = null;

                if (existing == null)
                {
                    existing = new Playlist();
                    existing.Name = playlistName;
                    existing = context.Playlists.Add(existing);

                    trackNumber = 1;
                }
                else
                {
                    trackNumber = existing.PlaylistTracks.Count() + 1;
                    newTrack = existing.PlaylistTracks.SingleOrDefault(x => x.TrackId == trackId);
                }

                // If the track being added to the playlist already exists in the playlist
                //   throw an exception.
                if (newTrack != null)
                {
                    throw new Exception("Playlist already has the requested track.");
                }

                newTrack = new PlaylistTrack();
                newTrack.TrackId = trackId;
                newTrack.TrackNumber = trackNumber;
                existing.PlaylistTracks.Add(newTrack);
                context.SaveChanges();
            }
        }//eom

        public void RemovePlaylistTrack(string playlistName, int trackId, int trackNumber)
        {
            using (var context = new ChinookContext())
            {
                Playlist existing = (from x in context.Playlists
                                     where x.Name.Equals(playlistName)
                                     select x).FirstOrDefault();
                var trackToRemove = context.PlaylistTracks.Find(existing.PlaylistId, trackId);
                List<PlaylistTrack> tracksKept = (from x in existing.PlaylistTracks
                                                  where x.TrackNumber > trackNumber
                                                  orderby x.TrackNumber
                                                  select x).ToList();
                context.PlaylistTracks.Remove(trackToRemove);
                foreach (var track in tracksKept)
                {
                    track.TrackNumber -= 1;
                    context.Entry(track).Property("TrackNumber").IsModified = true;
                }
                context.SaveChanges();
            }
        }//eom

    }//eoc
}//eon
