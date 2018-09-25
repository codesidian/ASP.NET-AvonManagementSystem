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
			<button   type="button" class="btn btn-success btn-lg"  onclick="sendOrder();">Create Order</button>
            <span style="display:none">onclick="javascript:__doPostBack('processOrder','JSON.stringify(orderObj))'"</span>
        </div>
    </div>



		</div>
    <br />
    
        <Table id="table" class="table">
       <thead class="thead">
        <tr>
        <th></th>
        <th>Product Number</th>
        <th>Product Name</th>
        <th>Quantity</th>
        <th>Price</th>
        <th></th>
        </tr>

       </thead>

<tr>
        <td>
            <button class="btn btn-primary" onclick="AddRow();"><i class="fa fa-plus"></i></button>
        </td>
        <td>            
            <div class="form-group">
            <input type="text" class="form-control" placeholder="Product Number">
            </div>
        </td>
        <td>
            <div class="form-group">
            <input type="text" class="form-control" placeholder="Product Name">
            </div>
        </td>
        <td>
            <div class="form-group">
            <input type="text" class="form-control" placeholder="0">
            </div>
            
        </td>

        <td>
            <div class="form-group input-icon">
            <input type="text" class="form-control" placeholder="0.00">
            <i>£</i>
        </div>
        </td>
        <td></td>
</tr>
        </Table>

    <h4><div id="testarea"></div></h4>
    <div class="container">

		<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	</div>


	


</asp:Content>

