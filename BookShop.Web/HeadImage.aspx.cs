using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using BookShop.BLL;


public partial class HeadImage : System.Web.UI.Page
{
    UserService userService = new UserService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count != 0)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            byte[] Imgdata = userService.GetUserHeadImgById(id);
            if (Imgdata != null)
            {
                Response.Clear();
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(Imgdata);
                Response.End();
            }
            else
            {
                string path = Server.MapPath("~/Images") + "\\DefaultImg.jpg";
                FileStream fs = File.OpenRead(path);
                byte[] data = new byte[fs.Length];
                fs.Position = 0;
                fs.Read(data, 0, (int)fs.Length);
                Response.Clear();
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(data);
                Response.End();
            }
        }
    }

}