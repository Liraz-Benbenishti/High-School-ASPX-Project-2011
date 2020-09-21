using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class AddToProductBusket : System.Web.UI.Page
{
    static string img;
    static string price;
    static string name;
    static string proid;
    static string type;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["User"] != null)
        {

            Label1.Text = "Hello, " + Session["Name"];
            localhost.Service srv = new localhost.Service();
            type = Request.QueryString["Item"];
            string user = (string) Session["User"];
            proid = Request.QueryString["IdProduct"];
            if (type == "Movie")
            {
                if (Request.QueryString["r"] != null && Request.QueryString["s"] != null)
                {
                    
                    string R1 = Request.QueryString["r"];
                    string S1 = Request.QueryString["s"];
                    OleDbCommand cmmd = new OleDbCommand();
                   
                    cmmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
                    DataTable dt1 = srv.TakeActi("Select * From movies Where movieID='" + proid + "'");
                    Random rnd = new Random();
                    cmmd.CommandText = "Insert Into tickets values(" + dt1.Rows[0][5].ToString() + ",'" + proid + "','" + S1 + "','" + R1 + "','" + user + "','Y'," + rnd.Next(1000000, 9999999) + ")";

                    string sql = cmmd.CommandText;
                                    srv.TakeAcon(sql);
                }
                TextBox1.Visible = false;


                DataTable dt = srv.TakeActi("Select * From movies Where movieID='" + proid + "'");
                string cinemaID = dt.Rows[0][3].ToString();
                img = dt.Rows[0][5].ToString();
                price = dt.Rows[0][4].ToString();
                name = dt.Rows[0][1].ToString();
                content.InnerHtml = "<img height=100 width=100 src='" + img + "'></img><br>" + name + "<br>מחיר: " + price + "<BR>";
                DataTable dt5 = srv.TakeActi("Select * From cinema Where cinemaID=" + cinemaID);
                int Rows = int.Parse(dt5.Rows[0][2].ToString());
                int SPR = int.Parse(dt5.Rows[0][3].ToString());
                content.InnerHtml += "<table>";
                for (int i = Rows; i >= 1; i--)
                {
                    for (int h = 1; h <= SPR; h++)
                    {
                        if (h == 1)
                        {
                            content.InnerHtml += "</tr><tr>";
                        }
                        string ImgSeat = "seatE.png";
                        string Link = "?r=" + i + "&s=" + h + "&IdProduct=" + proid + "&Item=Movie";
                                    string user2 = (string) Session["User"];
                                    DataTable dt2 = srv.TakeActi("Select * From tickets Where `movieID`='" + proid + "' and `seat`='" + h + "' and `Row`='" + i + "' and `costumerID`='" + user2 + "' and `status`='Y'");
                        int d = dt2.Rows.Count;
                        if (d == 1)
                        {
                            ImgSeat = "seatY.png";
                        }
                        DataTable dt3 = srv.TakeActi("Select * From tickets Where `movieID`='" + proid + "' and `seat`='" + h + "' and `Row`='" + i + "' and `costumerID`<>'" + user2 + "'  and `status`='Y'");
                        int d1 = dt3.Rows.Count;
                        if (d1 >= 1)
                        {
                            ImgSeat = "seatR.png";
                            Link = "";
                        }
                        DataTable dt4 = srv.TakeActi("Select * From tickets Where `movieID`='" + proid + "' and `seat`='" + h + "' and `Row`='" + i + "' and `costumerID`='" + user2 + "' and `status`='G'");
                        int d4 = dt4.Rows.Count;
                        if (d4 >= 1)
                        {
                            ImgSeat = "seatG.png";
                            Link = "";
                        }
                        DataTable dt6 = srv.TakeActi("Select * From tickets Where `movieID`='" + proid + "' and `seat`='" + h + "' and `Row`='" + i + "' and `costumerID`<>'" + user2 + "'  and `status`='G'");
                        int d6 = dt6.Rows.Count;
                        if (d6 == 1)
                        {
                            ImgSeat = "seatR.png";
                            Link = "";
                        }
                        content.InnerHtml += "<td><a href='" + Link + "'><img src='images/" + ImgSeat + "' onmousemove='CreateDiv(" + i + ", " + h + ");'></img></a></td>";
                    }
                }
                content.InnerHtml += "</tr></table>";
            }
            if (type == "Kapitery")
            {
                Button2.Visible = false;
                DataTable dt = srv.TakeActi("Select * From capiteria Where productID='" + proid + "'");
                img = dt.Rows[0][2].ToString();
                price = dt.Rows[0][3].ToString();
                name = dt.Rows[0][1].ToString();
                content.InnerHtml = "<img height=100 width=100 src='" + img + "'></img><br>" + name + "<br>מחיר: " + price + "<BR> כמות: ";
            }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        OleDbCommand cmmd = new OleDbCommand();
        OleDbCommand cmmd2 = new OleDbCommand();

        localhost.Service srv = new localhost.Service();
            Random rnd = new Random();
            if (type == "Kapitery")
            {
                DataTable dt = srv.TakeActi("Select * From capiteria Where productID='" + proid + "'");
                int amountallowed = int.Parse(dt.Rows[0][4].ToString());
                if (int.Parse(TextBox1.Text) <= amountallowed)
                {
                                        string idCus = Session["User"].ToString();
                    int r = rnd.Next(1000000, 9999999);
                    string rnd_prder = "" +  r;
                    int P = int.Parse(price);
                    string date = DateTime.Today.ToShortDateString();
                    int Totalprice = P * int.Parse(TextBox1.Text);
                    cmmd2.CommandText = "Insert Into Orders values('" + rnd_prder + "','" + date + "'," + Totalprice + " ,'" + idCus + "')";
                    srv.TakeAcon("Insert Into ActionsLog (CustomerID, ActionInfo) VALUES('" + Session["User"].ToString() + "', 'המשתמש הזמין מוצר בקפיטריה')");
                    string sql2 = cmmd2.CommandText;

                    srv.TakeAcon(sql2);

                    cmmd.CommandText = "Insert Into products values(@p1,@p2,@p3,@p4)";
                    cmmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
                    cmmd.Parameters["@p1"].Value = rnd_prder;

                    cmmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
                    cmmd.Parameters["@p2"].Value = proid;
                    cmmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
                    cmmd.Parameters["@p3"].Value = price;
                    cmmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
                    cmmd.Parameters["@p4"].Value = TextBox1.Text;
                    string sql = cmmd.CommandText;
                    srv.TakeAcon(sql);
                    amountallowed -= int.Parse(TextBox1.Text);
                    OleDbCommand cmmd4 = new OleDbCommand();
                    cmmd4.CommandText = "Update capiteria Set `amount`='" + amountallowed + "' Where productID='" + proid + "'";
                    srv.TakeAcon(cmmd4.CommandText);

                    Response.Redirect("UserControl.aspx");
                }
                else
                {
                    Label1.Text += "<br>";
                    Label1.Text += "אין מספיק פריטים במלאי על מנת לבצע את הרכישה, אתה יכול לקנות עד " + amountallowed + " מוצרים";
                    Button1.Enabled = true;
                }
            }
            if (type == "Movie")
            {
                    OleDbCommand cmmd3 = new OleDbCommand();
                    string user3 = (string) Session["User"];
                    cmmd3.CommandText = "Update tickets Set `status`='G' Where costumerID='" + user3 + "' and movieID='" + proid + "'";
                    srv.TakeAcon(cmmd3.CommandText);
                    srv.TakeAcon("Insert Into ActionsLog (CustomerID, ActionInfo) VALUES('" + Session["User"].ToString() + "', 'המשתמש רכש כרטיס לסרט')");
                    Response.Redirect("UserControl.aspx");
                
            }
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (type == "Movie")
        {
            localhost.Service srv = new localhost.Service();
            OleDbCommand cmmd3 = new OleDbCommand();
            string user3 = (string)Session["User"];
            cmmd3.CommandText = "Delete from tickets Where `status`='Y' and costumerID='" + user3 + "' and movieID='" + proid + "'";
            srv.TakeAcon(cmmd3.CommandText);
            
            Response.Redirect("UserControl.aspx");

        }
    }
}
