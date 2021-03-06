﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using ChinookSystem.BLL;
using ChinookSystem.Data.POCOs;
using Chinook.UI;
#endregion

public partial class BusinessProcesses_ManagePlayList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ArtistFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun((ProcessRequest)FetchTracksForArtist);
    }
     
    public void FetchTracksForArtist()
    {
        int id = int.Parse(ArtistrList.SelectedValue);
        TracksBy.Text = "Artist";
        SearchArgID.Text = id.ToString();
        TrackSearchList.DataBind();
    }

    protected void MediaTypeFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun((ProcessRequest)FetchTracksForMediaType);
    }

    public void FetchTracksForMediaType()
    {
        int id = int.Parse(MediaTypeList.SelectedValue);
        TracksBy.Text = "Media Type";
        SearchArgID.Text = id.ToString();
        TrackSearchList.DataBind();
    }

    protected void GenreFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun((ProcessRequest)FetchTracksForGenre);
    }

    public void FetchTracksForGenre()
    {
        int id = int.Parse(GenreList.SelectedValue);
        TracksBy.Text = "Genre";
        SearchArgID.Text = id.ToString();
        TrackSearchList.DataBind();
    }

    protected void AlbumFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun((ProcessRequest)FetchTracksForAlbum);
    }

    public void FetchTracksForAlbum()
    {
        int id = int.Parse(AlbumList.SelectedValue);
        TracksBy.Text = "Album";
        SearchArgID.Text = id.ToString();
        TrackSearchList.DataBind();
    }

    protected void PlaylistFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            if(string.IsNullOrEmpty(PlaylistName.Text))
            {
                throw new Exception("Enter a playlist name.");
            }
            else
            {
                PlaylistTrackController controller = new PlaylistTrackController();
                List<TracksForPlaylist> results = controller.PlaylistTracks_Get(PlaylistName.Text);
                CurrentPlaylist.DataSource = results;
                CurrentPlaylist.DataBind();
                CurrentPlaylist.SelectedIndex = -1; // sets this to read only mode
            }
        });
    }

    protected void TrackSearchList_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        ListViewDataItem rowContents = e.Item as ListViewDataItem;
        string playlistName = PlaylistName.Text;
        if(string.IsNullOrEmpty(PlaylistName.Text))
        {
            MessageUserControl.ShowInfo("Please enter a playlist name.");
        }
        else
        {
            MessageUserControl.TryRun(() =>
            {
                // The TrackId is attached to each ListView row via the CommandArgument parameter
                // This method does not make the value visible to the user; access to the TrackId
                //   is done through the ListViewCommandEventArgs e, and thus is treated as an
                //   object, thus it needs to be cast to a string for the Parse to work.
                PlaylistTrackController controller = new PlaylistTrackController();
                controller.AddTrackToPlaylist(playlistName, int.Parse(e.CommandArgument.ToString()));
                List<TracksForPlaylist> results = controller.PlaylistTracks_Get(playlistName);
                CurrentPlaylist.DataSource = results;
                CurrentPlaylist.DataBind();
            });
        }
    }

    protected void DeleteTrack_Click(object sender, EventArgs e)
    {
        if(CurrentPlaylist.Rows.Count == 0)
        {
            MessageUserControl.ShowInfo("You must have a playlist with entries before trying to remove a track.");
        }
        else
        {
            int rowIndex = CurrentPlaylist.SelectedIndex;
            if(rowIndex > -1)
            {
                int trackId = int.Parse((CurrentPlaylist.Rows[rowIndex].FindControl("PL_TrackId") as Label).Text);
                int trackNumber = int.Parse((CurrentPlaylist.Rows[rowIndex].FindControl("PL_TrackNumber") as Label).Text);
                MessageUserControl.TryRun(() =>
                {
                    PlaylistTrackController controller = new PlaylistTrackController();
                    controller.RemovePlaylistTrack(PlaylistName.Text, trackId, trackNumber);
                    List<TracksForPlaylist> results = controller.PlaylistTracks_Get(PlaylistName.Text);
                    CurrentPlaylist.DataSource = results;
                    CurrentPlaylist.SelectedIndex = -1;
                    CurrentPlaylist.DataBind();
                });
            }
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        // This code sets up the ability to click anywhere on a row of a 
        //   GridView to select the row for processing
        foreach(GridViewRow r in CurrentPlaylist.Rows)
        {
            if(r.RowType == DataControlRowType.DataRow)
            {
                r.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                r.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                r.ToolTip = "Click to select row";
                r.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.CurrentPlaylist, "Select$" + r.RowIndex, true);
            }
        }
        base.Render(writer);
    }
}