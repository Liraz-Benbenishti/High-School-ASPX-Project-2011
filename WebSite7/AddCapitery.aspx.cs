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

public partial class AddCapitery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            localhost.Service srv = new localhost.Service();
            string use = (string) Session["User"];
            DataTable dt = srv.TakeActi("Select * From Users Where `PositionsID`='3' And `CustomerID`='" + use + "'");

         
            if (dt.Rows.Count != 1)
            {
                srv.TakeAcon("Insert Into ActionsLog (CustomerID, ActionInfo) VALUES('" + use + "', '������ ���� ����� ����� AddCapitery �� ���� ����� ��� �����')");
                Response.Redirect("UserControl.aspx");
            }
            srv.TakeAcon("Insert Into ActionsLog (CustomerID, ActionInfo) VALUES('" + use + "', '������ ���� ����� AddCapitery')");
        }
        else
        {
            Response.Redirect("UserControl.aspx");
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string sql = "Insert Into `cinema` (Name, Rows, SPR) VALUES('" + TextBox5.Text + "', " + int.Parse(TextBox6.Text) + ", " + int.Parse(TextBox7.Text) + ")";
        localhost.Service srv = new localhost.Service();

        srv.TakeAcon(sql);
        srv.TakeAcon("Insert Into ActionsLog (CustomerID, ActionInfo) VALUES('" + Session["User"].ToString() + "', '������ ����� ���� ������')");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sql = "Insert Into Catgory (CatgoryName) VALUES('" + TextBox4.Text + "')";
        localhost.Service srv = new localhost.Service();

        srv.TakeAcon(sql);
        srv.TakeAcon("Insert Into ActionsLog (CustomerID, ActionInfo) VALUES('" + Session["User"].ToString() + "', '������ ����� ������� ��������')");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "Insert Into `cinema` (Name, Rows, SPR) VALUES('" + TextBox5.Text + "', " + int.Parse(TextBox6.Text) + ", " + int.Parse(TextBox7.Text) + ")";
        localhost.Service srv = new localhost.Service();

        srv.TakeAcon(sql);
    }
}
