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
using Newtonsoft.Json;


public class Product
{
    [JsonProperty("productID")]
    public string ProductId { get; set; }

    [JsonProperty("productName")]
    public string ProductName { get; set; }

    [JsonProperty("quantity")]
    public string Quantity { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }
}

public class Order
{
    [JsonProperty("products")]
    public List<Product> Products { get; set; }
}

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{


      
        ClientScript.GetPostBackEventReference(this, e.ToString());
        if (Request.Form["__EVENTTARGET"] == "processOrder")
        {

            System.Diagnostics.Debug.WriteLine("Requeste Received");

            processOrder(Request.Form["__EVENTARGUMENT"]);
        }



        //createProductRow(sender, e);
        if (!this.IsPostBack)
            {
          //  createProductRow(sender, e);
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



    protected void processOrder(String json)
    {
        System.Diagnostics.Debug.WriteLine(json);
        int campaignID = 0, campaignNumber = 0,customerID=0;
        try
        {
            customerID = Convert.ToInt32(ddlSelectCustomers.SelectedItem.Value);
            campaignID = Convert.ToInt32(ddlSelectCampaign_Orders.SelectedItem.Value);
            campaignNumber = Convert.ToInt32(ddlSelectCampaign_Orders.SelectedItem.Text);
        }
        catch
        {
        }

        // String objstring = JsonConvert.SerializeObject(json);
        Order obj = JsonConvert.DeserializeObject<Order>(json);

        //System.Diagnostics.Debug.WriteLine(objstring);

      //  System.Diagnostics.Debug.WriteLine(json);

        //List<Order> ord = obj.orders;
       // String test = JsonConvert.SerializeObject(obj);

       // System.Diagnostics.Debug.WriteLine(test);

        //System.Diagnostics.Debug.WriteLine(ord);

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

    protected void Button1_Click1(object sender, EventArgs e)
    {
        
    }
}