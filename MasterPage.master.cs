using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string path = HttpContext.Current.Request.Url.AbsolutePath;
		StringBuilder html = new StringBuilder();
		html.Append("<br><b>"+path+"</b></br> ");
		PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

		if (path.Contains("Campaign"))
			{
			menuCampaign.Attributes["class"] = "nav-link active";
		}
		else if (path.Contains("Orders"))
		{
			menuOrder.Attributes["class"] = "nav-link active";
		}
		else if (path.Contains("CreateOrder"))
		{
			menuCreateOrder.Attributes["class"] = "dropdown-item active";
		}
		else if (path.Contains("CreateCampaign"))
		{
			menuCreateCampaign.Attributes["class"] = "dropdown-item active";
		}
		else if (path.Contains("CreateCustomer"))
		{
			menuCreateCustomer.Attributes["class"] = "dropdown-item active";
		}

	}
}
