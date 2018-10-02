<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateCampaign.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="container">


	<br />
	<div class="container ">

		<div class="row">
        <div class="col-sm-4 " align="center"><h3>Is Active?</h3></div>
        <div class="col-sm-4 " align="center"><h3></h3></div>
        <div class="col-sm-4 " align="center">
    </div></div>

	    <div class="row spaceTop">
        <div class="col-sm-4 " align="center">Campaign Number</div>
        <div class="col-sm-4 " align="center">Start Date</div>
        <div class="col-sm-4 " align="center">End Date
			        </div>
    </div>



		</div>
    
    <div class="row">
            <div class="col-sm-4 " align="center">    
                
                <div class="form-group">
                    <input type="text" class="form-control" placeholder="Campaign Number" id="number">
                    </div>
                
                </div>

            <div class="col-sm-4 " align="center">
                    <div class="form-group">
                            <input type="date" max="2222-05-26" class="form-control" placeholder="Start Date" id="name">
                            </div>               
            
            </div>
            <div class="col-sm-4 " align="center">


                    <div class="form-group">
                            <input type="date"  max="2222-05-26" class="form-control" placeholder="End Date" id="quantity">
                            </div>
        </div>
    </div>


    <div class="row">
            <div class="col-sm-12" align="center">    
                

    <button   type="button" class="btn btn-success btn-lg"  onclick="sendOrder();">Create Campaign</button>
    <span style="display:none">onclick="javascript:__doPostBack('processOrder','JSON.stringify(orderObj))'"</span>


                
                </div>


    </div>


    <h4></h4><div id="testarea"></div></h4>


	</div>
</asp:Content>