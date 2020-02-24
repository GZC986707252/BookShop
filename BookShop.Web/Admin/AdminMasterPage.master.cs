using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["AdminUserId"]!=null)
        {
            lblAdminName.Text = Session["UserName"].ToString();
            AdminHeadImage.ImageUrl = "~/HeadImage.aspx?id=" + Session["AdminUserId"];
        }
    }

    protected void BtnAdminLogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Login.aspx");
    }
}
