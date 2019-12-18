<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:DataGrid ID="no2" runat="server"></asp:DataGrid>
        <asp:DataGrid ID="DataGarid1" runat="server"></asp:DataGrid>
        </form>
    <form method="get" name="a">
          	<div class="row">
	          	<div class="col-md-4">
	           		Product Name :
	           	</div>
	           	<div class="col-md-8">
	           	 	<input type="text" class="col-md-8" name="tname">
	           	</div>
	        </div>
	        <div class="row">
	          	<div class="col-md-4">
	           		Product Category
	           	</div>
	           	<div class="col-md-8" runat="server" id="Div1">      
	           	</div>
	        </div>
	        <div class="row">
	          	<div class="col-md-4">
	           		Price :
	           	</div>
	           	<div class="col-md-8">
	           	 	<input type="text" class="col-md-8" name="pname">
	           	</div>
	        </div>
	        <div class="row">
	           	<div class="col-md-12">
	           	 	<input type="submit" class="col-md-12 btn btn-success" name="subbtn" />
	           	</div>
	        </div>
    </div>
    </form>
    <form method="get" name="a">
            <div class="row">
	          	<div class="col-md-4">
	           		Category Name:
	           	</div>
	           	<div class="col-md-8">
	           	 	<input type="text" class="col-md-8" name="cname">
	           	</div>
	        </div>
	        <div class="row">
	           	<div class="col-md-12">
	           	 	<input type="submit" class="col-md-12 btn btn-success" name="ssubbtn" />
	           	</div>
	        </div>
</asp:Content>
