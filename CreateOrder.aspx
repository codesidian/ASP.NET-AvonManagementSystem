<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateOrder.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style> 

        td{
            margin:auto;
        }
    </style>
    
<div class="container">






	<asp:SqlDataSource ID="sqlCampaignDS" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [CampaignNumber], [IsActive] FROM [Campaign]"></asp:SqlDataSource>
	<asp:SqlDataSource ID="sqlCustomerDS" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], Concat([FirstName], ' ' , [LastName]) as Name FROM [Customer]"></asp:SqlDataSource>

	</div>


	
	<br />
	<div class="container ">

		<div class="row">
        <div class="col-sm-4 " align="center"><h3>Select Campaign</h3></div>
        <div class="col-sm-4 " align="center"><h3>Select Customer</h3></div>
        <div class="col-sm-4 " align="center">
    </div></div>

	    <div class="row spaceTop">
        <div class="col-sm-4 " align="center"><asp:DropDownList class="btn btn-secondary btn-lg dropdown-toggle"   ID="ddlSelectCampaign_Orders" runat="server" DataSourceID="sqlCampaignDS" DataTextField="CampaignNumber" DataValueField="Id" AutoPostBack="True" ></asp:DropDownList></div>
        <div class="col-sm-4 " align="center"><asp:DropDownList class="btn btn-secondary btn-lg dropdown-toggle"   ID="ddlSelectCustomers" runat="server" DataSourceID="sqlCustomerDS" DataTextField="Name" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectCustomers_SelectedIndexChanged" ></asp:DropDownList></div>
        <div class="col-sm-4 " align="center">
			<asp:Button ID="Button1" runat="server" Text="Create Order" class="btn btn-lg btn-info" /></div>
    </div>



		</div>
    <br />
    
        <table class="table">
       <thead class="thead-dark"><tr>
        <th> </th>
        <th>Product ID</th>
        <th>Product Name</th>
        <th>Quantity</th>
        <th>Price</th>
        </tr></thead>

        <tr>
        <td>

            <asp:Button ID="AddRow" runat="server" Text="+" class="btn btn-success" />

        </td>
        <td>123</td>
        <td>test</td>
        <td>42</td>
        <td>£100000</td>
        </tr>
        </table>

    <div class="container">

		<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	</div>


	


</asp:Content>

