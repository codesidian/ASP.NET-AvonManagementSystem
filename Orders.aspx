<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="container">






	<asp:SqlDataSource ID="sqlCampaignDS" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [CampaignNumber], [IsActive] FROM [Campaign]"></asp:SqlDataSource>

	</div>


	
	<br />
	<div class="container ">

		<div class="row">
        <div class="col-sm-6 " align="center"><h3>Select Campaign</h3></div>
        <div class="col-sm-6 " align="center">
    </div></div>

	    <div class="row spaceTop">
        <div class="col-sm-6 " align="center"><asp:DropDownList class="btn btn-secondary btn-lg dropdown-toggle"   ID="ddlSelectCampaign_Orders" runat="server" DataSourceID="sqlCampaignDS" DataTextField="CampaignNumber" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectCampaign_Orders_SelectedIndexChanged">
	</asp:DropDownList></div>
        <div class="col-sm-6 " align="center">
			<asp:Button ID="Button1" runat="server" Text="Create Order" class="btn btn-lg btn-info" OnClick="Button1_Click" /></div>
    </div>



		</div>



	<div class="container">

		<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	</div>




</asp:Content>

