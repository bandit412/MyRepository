<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Chinook Music Store</h1>
        <p class="lead">The Chinook music store provides customers to create custom playlists from a wide selection of music titles. Titles can be selected by Artist, Genre, Album, or Media Type.</p>
        <p>Future features will include movies and other video types, and the ability to request media for other user to add to their custom play lists.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                To be able to create your playlist you must register as a customer.
            </p>
            <p>
                <a class="btn btn-default" href="Account/Register.aspx">Register</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Request Music</h2>
            <p>
                This feature will come in the next addition of this web store.
            </p>
            <p>
                <a class="btn btn-default" href="#">Request Media</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>More Info</h2>
            <p>
                You can always send us a message.
            </p>
            <p>
                <a class="btn btn-default" href="Contact.aspx">More</a>
            </p>
        </div>
    </div>
</asp:Content>
