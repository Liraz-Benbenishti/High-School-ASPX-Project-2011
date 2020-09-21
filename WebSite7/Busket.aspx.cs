using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Busket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            localhost.Service srv = new localhost.Service();
            string user = (string) Session["User"];
            string content = "<table width=100% align=center><tr><td>מספר הזמנה</td><td>המוצר</td><td>כמות</td><td>מחיר כולל</td></tr>";
            DataTable dt = srv.TakeActi("Select * From Orders Where CustomerID='" + user + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataTable dtD = srv.TakeActi("Select * From products Where OrderID='" + dt.Rows[i][0].ToString() + "'");
                for (int h = 0; h < dtD.Rows.Count; h++)
                {
                    string Proid = dtD.Rows[h][1].ToString();

                    DataTable dt1 = srv.TakeActi("Select * From capiteria Where ProductID='" + Proid + "'");
                    int TPrice = int.Parse(dt.Rows[i][2].ToString());
                    content += "<tr><td>" + dtD.Rows[h][0].ToString() + "</td><td><img height=100 width=100 src='" + dt1.Rows[0][2].ToString() + "'></img><br>" + dt1.Rows[0][1].ToString() + "</td><td>" + dtD.Rows[h][3].ToString() + "</td><td>" + TPrice + "</td></tr>";
                }
            }
            content += "</table>";
            busket.InnerHtml = content;
        }
        else
        {
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;

            Session["Loged"] = sRet;
            Response.Redirect("Login.aspx");
        }
    }
}
