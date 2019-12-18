<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication5.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:GridView ID="dr1" runat="server"></asp:GridView>
        </form>
        <form method="get">
            <input type="text" name="rid" />
            <input type="text" name="rname" />
            <input type="submit" name="sbtn" />
        </form>
        </div>
</asp:Content>