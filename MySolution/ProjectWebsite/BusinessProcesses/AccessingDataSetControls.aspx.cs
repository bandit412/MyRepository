using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BusinessProcesses_AccessingDataSetControls : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TracksListGV_SelectedIndexChanged(object sender, EventArgs e)
    {
        string msg = null;
        GridViewRow gvRow = TracksListGV.Rows[TracksListGV.SelectedIndex];
        string albumName = gvRow.Cells[0].Text; //first column BoundField
        int milliseconds = int.Parse(gvRow.Cells[1].Text); //second column BoundField
        int size = int.Parse((gvRow.FindControl("Bytes") as Label).Text); //third column Template Label
        decimal price = decimal.Parse((gvRow.FindControl("UnitPrice") as TextBox).Text); //third column Template TextBox
        msg = "GridView Name is: " + albumName + " M/S is: " + milliseconds.ToString() +
            " Size is: " + size.ToString() + " Price is: " + price.ToString();
        MessageUserControl.ShowInfo(msg);
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }

    protected void TracksListLV_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string msg = null;
        ListViewDataItem lvRow = e.Item as ListViewDataItem;
        string albumName = (lvRow.FindControl("Name") as Label).Text; //first column BoundField
        int milliseconds = int.Parse((lvRow.FindControl("Milliseconds") as Label).Text); //second column BoundField
        int size = int.Parse((lvRow.FindControl("Bytes") as Label).Text); //third column Template Label
        decimal price = decimal.Parse((lvRow.FindControl("UnitPrice") as TextBox).Text); //third column Template TextBox
        msg = "ListView Name is: " + albumName + " M/S is: " + milliseconds.ToString() +
            " Size is: " + size.ToString() + " Price is: " + price.ToString();
        MessageUserControl.ShowInfo(msg);
    }

    protected void WalkThroughGV_Click(object sender, EventArgs e)
    {
        int trackCount = 0;
        int albumPlayTime = 0;
        int albumSize = 0;
        decimal albumPrice = 0m;
        string msg = null;
        foreach (GridViewRow item in TracksListGV.Rows)
        {
            trackCount += 1;
            albumPlayTime += int.Parse(item.Cells[1].Text);
            albumSize += int.Parse((item.FindControl("Bytes") as Label).Text);
            albumPrice += decimal.Parse((item.FindControl("UnitPrice") as TextBox).Text);
        }
        msg = "GridView Totals: # of tracks is: " + trackCount.ToString() + " M/S is: " + albumPlayTime.ToString() +
          " Size is: " + albumSize.ToString() + " Price is: " + albumPrice.ToString();
        MessageUserControl.ShowInfo(msg);
    }

    protected void WalkThroughLV_Click(object sender, EventArgs e)
    {
        int trackCount = 0;
        int albumPlayTime = 0;
        int albumSize = 0;
        decimal albumPrice = 0m;
        string msg = null;
        foreach (ListViewDataItem item in TracksListLV.Items)
        {
            trackCount += 1;
            albumPlayTime += int.Parse((item.FindControl("Milliseconds") as Label).Text);
            albumSize += int.Parse((item.FindControl("Bytes") as Label).Text);
            albumPrice += decimal.Parse((item.FindControl("UnitPrice") as TextBox).Text);
        }
        msg = "ListView Totals: # of tracks is: " + trackCount.ToString() + " M/S is: " + albumPlayTime.ToString() +
          " Size is: " + albumSize.ToString() + " Price is: " + albumPrice.ToString();
        MessageUserControl.ShowInfo(msg);
    }
}