﻿using System;
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
        }//eom


        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Track> ListTracks()
        {
            using (var context = new ChinookContext())
            {
                // Return all records, all attributes
                return context.Tracks.ToList();
            }
        }//eom

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track GetTrack(int trackid)
        {
            using (var context = new ChinookContext())
            {
                //return a record all attributes
                return context.Tracks.Find(trackid);
            }
        }//eom

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void AddTrack(Track trackinfo)
        {
            using (var context = new ChinookContext())
            {
                //any business rules
                if (trackinfo.UnitPrice > 1.0m)
                    throw new Exception("Invalid Unit Price.");
                //any data refinements
                //review of using iif
                //composer can be a null string
                //we do not wish to store an empty string
                trackinfo.Composer = string.IsNullOrEmpty(trackinfo.Composer) ? null : trackinfo.Composer;

                //add the instance of trackinfo to the database
                context.Tracks.Add(trackinfo);

                //commit of the transaction
                context.SaveChanges();
            }
        }//eom

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void UpdateTrack(Track trackinfo)
        {
            using (var context = new ChinookContext())
            {
                //any business rules

                //any data refinements
                //review of using iif
                //composer can be a null string
                //we do not wish to store an empty string
                trackinfo.Composer = string.IsNullOrEmpty(trackinfo.Composer) ? null : trackinfo.Composer;

                //update the existing instance of trackinfo on the database
                context.Entry(trackinfo).State = System.Data.Entity.EntityState.Modified;

                //commit of the transaction
                context.SaveChanges();
            }
        }//eom

        //the delete is an overload method technique
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteTrack(Track trackinfo)
        {
            DeleteTrack(trackinfo.TrackId);
        }//eom

        public void DeleteTrack(int trackid)
        {
            using (var context = new ChinookContext())
            {
                //any business rules

                //do the delete
                //find the existing record on the database
                var existing = context.Tracks.Find(trackid);
                //delete the record from the database
                context.Tracks.Remove(existing);
                //commit the transaction
                context.SaveChanges();
            }
        }//eom
    }//eoc
}//eon
