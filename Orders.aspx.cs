using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			ddlSelectCampaign_Orders_SelectedIndexChanged(sender, e);
		}
	}

	private DataTable getOrdersByCampaign()
	{
		int campaignID = 0;

		try
		{
			campaignID = Convert.ToInt32(ddlSelectCampaign_Orders.SelectedItem.Value);
		}
		catch
		{
			campaignID =3;
		}

		string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(constr))
		{

			using (SqlCommand cmd = new SqlCommand("getNiceOrdersByCampaign", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@campaign", campaignID);

				using (SqlDataAdapter sda = new SqlDataAdapter())
				{
					cmd.Connection = con;
					sda.SelectCommand = cmd;
					using (DataTable dt = new DataTable())
					{
						sda.Fill(dt);
						return dt;
					}
				}
			}
		}
	}

	protected void sqlSourceOrder_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
	{

	}

	protected void ddlSelectCampaign_Orders_SelectedIndexChanged(object sender, EventArgs e)
	{

		//Populating a DataTable from database.
		DataTable dt = this.getOrdersByCampaign();
		//dt.Columns.Remove("Id");
		//Building an HTML string.
		StringBuilder html = new StringBuilder();
		string firstname;
		int campaignID = 0,campaignNumber=0;

		try
		{
			campaignID = Convert.ToInt32(ddlSelectCampaign_Orders.SelectedItem.Value);
			campaignNumber = Convert.ToInt32(ddlSelectCampaign_Orders.SelectedItem.Text);
		}
		catch
		{
			campaignID = 3;
			campaignNumber = getActiveCampaignNumber();
		}


		//Table start.
		html.Append("<table class=\"table sortable \" ");

		//Building the Header row.
		html.Append("<thead class=\"  thead-dark\"> <tr>");
		foreach (DataColumn column in dt.Columns)
		{
			if (column.ColumnName!="ID") {
				html.Append("<th>");

				html.Append(column.ColumnName);

				html.Append("</th>");
			}
		}
		html.Append("  <th>Completed</th> <th></th>  <th></th> </tr></thead>");

		//Building the Data rows.
		int id;
		foreach (DataRow row in dt.Rows)
		{
			html.Append("<tr>");
			foreach (DataColumn column in dt.Columns)
			{
				if (column.ColumnName != "ID")
				{
					html.Append("<td>");
					if (column.ToString() == "Total") { html.Append(string.Format("{0:C}", Convert.ToDecimal(row["Total"].ToString()))); }
					else
						html.Append(row[column.ColumnName]);
					html.Append("</td> ");
				}
			}

			
			id = Convert.ToInt32(row["Id"].ToString());

			firstname = row["Customer Name"].ToString();
			// ############################################################################################




			// #############################################################################################


			if (IsComplete(id)) { html.Append("<td ><h2> <div class=\"centerText badge badge-success\" >  <i class=\"fa fa-check\" ><div style=\"display:none\">Yes</div></i>  </div> </h2> </td>"); }
			else { html.Append("<td ><h2> <div class=\"centerText badge badge-danger\" >		<i class=\"fa fa-times\" ><div style=\"display:none\">No</div></i>		</div> </h2> </td>"); }

			/*
		
			 onclick=\"window.location = 'ViewOrder.aspx?customerID=" + id + "&campaignID=" + campaignID + "';\"
			 
			 */

			html.Append("<td ><button type=\"button\" class=\" centerButton btn btn-primary  \"		data-toggle=\"modal\" data-target=\".bd-example-modal-lg" + id + " \">View</button></td> " +
				"<td><button type=\"button\" class=\"btn btn-warning  centerButton\">Complete</button></td>" +
				"  </tr> "+ "<div class=\"modal fade bd-example-modal-lg" + id + " \" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myLargeModalLabel\" aria-hidden=\"true\"> <div class=\"modal-dialog modal-lg\"><div class=\"modal-content\"><div class=\"modal-header\"><h5 class=\"modal-title\" id=\"exampleModalLabel\">"+ firstname + "'s Order - Campaign No "+ campaignNumber + "</h5><button type = \"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button></div><div class=\"modal-body\">" + getOrderInfo(id, campaignID) + "</div></div></div></div>");
		}

		//Table end.
		html.Append("</table>");

		//Append the HTML string to Placeholder.
		PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

	}

	private int getActiveCampaignNumber() {
		int campaignNumber = 0;

		string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(constr))
		{

			using (SqlCommand cmd = new SqlCommand("getActiveCampaign", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;

				using (SqlDataAdapter sda = new SqlDataAdapter())
				{
					cmd.Connection = con;
					sda.SelectCommand = cmd;
					using (DataTable dt = new DataTable())
					{
						sda.Fill(dt);


						foreach (DataRow row in dt.Rows)
						{

							foreach (DataColumn column in dt.Columns)
							{

								if (column.ToString() == "CampaignNumber")
								{
									campaignNumber= 
										Convert.ToInt32(row["CampaignNumber"].ToString());

								}

							}
						}

					}
				}
			}
		}

		return campaignNumber;

	}

	private string getOrderInfo(int customerID,int campaignID)
	{

		
		StringBuilder html = new StringBuilder();
		string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(constr))
		{

			using (SqlCommand cmd = new SqlCommand("getOrdersByCustomerCampaign", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@campaignID", campaignID);
				cmd.Parameters.AddWithValue("@customerID", customerID);

				using (SqlDataAdapter sda = new SqlDataAdapter())
				{
					cmd.Connection = con;
					sda.SelectCommand = cmd;
					using (DataTable dt = new DataTable())
					{
						sda.Fill(dt);

						//Table start.
						html.Append("<div class=\" container \">");

						dt.Columns.Remove("Completed");
						dt.Columns.Remove("CustomerID");
						dt.Columns.Remove("CampaignID");
						//Building the Data rows.
						int id;
						html.Append("<div class=\"row\">");
						html.Append("<div class=\"col-md-2\">");
						html.Append("Product Number");
						html.Append("</div>");

						html.Append("<div class=\"col-md-2\">");
						html.Append("Quantity");
						html.Append("</div>");

						html.Append("<div class=\"col-md-2\">");
						html.Append("Name");
						html.Append("</div>");

						html.Append("<div class=\"col-md-2\">");
						html.Append("Price");
						html.Append("</div>");

						html.Append("<div class=\"col-md-2\">");
						html.Append("Completed");
						html.Append("</div>");
						html.Append("</div>");



						html.Append("<div class=\"row\">");
						html.Append("<div class=\"col-md-2\">");
						html.Append("---------------");
						html.Append("</div>");

						html.Append("<div class=\"col-md-2\">");
						html.Append("---------------");
						html.Append("</div>");

						html.Append("<div class=\"col-md-2\">");
						html.Append("---------------");
						html.Append("</div>");

						html.Append("<div class=\"col-md-2\">");
						html.Append("---------------");
						html.Append("</div>");

						html.Append("<div class=\"col-md-2\">");
						html.Append("---------------");
						html.Append("</div>");

						html.Append("</div>");

						
						foreach (DataRow row in dt.Rows)
						{
							html.Append("<div class=\"row\">");
							foreach (DataColumn column in dt.Columns)
							{
								if (column.ColumnName != "Id")
								{
									html.Append("<div class=\"col-md-2\">");
									if (column.ToString() == "Price") { html.Append(string.Format("{0:C}", Convert.ToDecimal(row["Price"].ToString()))); }
									else
										html.Append(row[column.ColumnName]);
									
									html.Append("</div>");

								}
								
								
							}
							id = Convert.ToInt32(row["Id"].ToString());
							if (checkOrderStatus(id)) { html.Append("<div class=\"col-md-2\"><h2><div class=\"centerText badge badge-success\"><i class=\"fa fa-check\" ></i></div></h2></div>"); }
							else { html.Append("<div class=\"col-md-2\"><h2><div class=\"centerText badge badge-danger\" ><i class=\"fa fa-times\"></i></div></h2></div>"); }

							html.Append("<div class=\"col-md-2\"><button type=\"button\" class=\"btn btn-warning\"> Complete </button></div>");
							html.Append("</div>");



							html.Append("<div class=\"row\">");
							html.Append("<div class=\"col-md-2\">");
							html.Append("---------------");
							html.Append("</div>");

							html.Append("<div class=\"col-md-2\">");
							html.Append("---------------");
							html.Append("</div>");

							html.Append("<div class=\"col-md-2\">");
							html.Append("---------------");
							html.Append("</div>");

							html.Append("<div class=\"col-md-2\">");
							html.Append("---------------");
							html.Append("</div>");

							html.Append("<div class=\"col-md-2\">");
							html.Append("---------------");
							html.Append("</div>");

							html.Append("</div>");
						}

						//Table end.
						html.Append("</div>");
						return html.ToString();
					}
				}
			}
		}

		

	}

	private bool checkOrderStatus(int orderID)
	{
		
		string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(constr))
		{

			using (SqlCommand cmd = new SqlCommand("isOrderCompleted", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@orderID", orderID);

				using (SqlDataAdapter sda = new SqlDataAdapter())
				{
					cmd.Connection = con;
					sda.SelectCommand = cmd;
					using (DataTable dt = new DataTable())
					{
						sda.Fill(dt);


						foreach (DataRow row in dt.Rows)
						{

							foreach (DataColumn column in dt.Columns)
							{

								if (column.ToString() == "Completed")
								{

									if (
										row["Completed"].ToString() == "False")
									{
										return false;
									}
								}

							}
						}

					}
				}
			}
		}

		return true;

	}


	private bool IsComplete(int id)
	{
		int campaignID = 0;
		
		try
		{
			campaignID = Convert.ToInt32(ddlSelectCampaign_Orders.SelectedItem.Value);
		}
		catch
		{
			campaignID = 3;
		}

		string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(constr))
		{

			using (SqlCommand cmd = new SqlCommand("getIsActive", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@campaign", campaignID);
				cmd.Parameters.AddWithValue("@customerID", id);

				using (SqlDataAdapter sda = new SqlDataAdapter())
				{
					cmd.Connection = con;
					sda.SelectCommand = cmd;
					using (DataTable dt = new DataTable())
					{
						sda.Fill(dt);


						foreach(DataRow row in dt.Rows)
		{
							
							foreach (DataColumn column in dt.Columns)
							{
								
								if (column.ToString() == "Completed") {
									//System.Diagnostics.Debug.WriteLine(row["Completed"].ToString());
									if (
										row["Completed"].ToString() == "False")
									{
										return false;
									}
								}
								
							}
						}

					}
				}
			}
		}

		return true;

	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		Response.Redirect("CreateOrder.aspx");
	}
}