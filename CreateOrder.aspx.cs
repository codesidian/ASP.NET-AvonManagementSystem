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
        //createProductRow(sender, e);
        if (!this.IsPostBack)
            {
            createProductRow(sender, e);
            }
        

    }


    

    protected void sqlSourceOrder_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }



    private int getActiveCampaignNumber()
    {
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
                                    campaignNumber =
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

   

   


    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateOrder.aspx");
    }


    protected void createProductRow(object sender, EventArgs e)
    {

        StringBuilder html = new StringBuilder();
        
        //Table start.
        html.Append("<tr>");

        html.Append("<td>  </td>");
        html.Append("<td>  </td>");
        html.Append("<td>  </td>");
        html.Append("<td>  </td>");

        html.Append("</tr>");

        //Building the Header row.


        //Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

    }

    protected void ddlSelectCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}