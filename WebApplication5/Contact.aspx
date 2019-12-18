<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication5.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid>
</form>
<form method="get" name="b">
          	<div class="row">
	          	<div class="col-md-4">
	           		Select Manufactures product:
	           	</div>
	           	<div class="col-md-8" runat="server" id="Div1">      
	           	</div>
	        </div>
	        <div class="row">
	          	<div class="col-md-4">
	           		Select Retail:
	           	</div>
	           	<div class="col-md-8" runat="server" id="rune">

                       
	           	</div>
	        </div>
	        <div class="row">
	           	<div class="col-md-12">
	           	 	<input type="submit" class="col-md-12 btn btn-success" name="subbtn" />
	           	</div>
	        </div>
        <br /><br /><br /><br /><br /><br />
        	<div class="row">
	           	<div class="col-md-12">
	           	 	ID for modification<input type="text" name="tide" />
	           	</div>
	        </div>
        	<div class="row">
	           	<div class="col-md-12">
	           	 	<input type="submit" class="col-md-12 btn btn-success" name="ssubbtn" value="update" />
                       <input type="submit" class="col-md-12 btn btn-danger" name="sssubbtn" value="delete" />
	           	</div>
	        </div>
    </div>
</asp:Content>