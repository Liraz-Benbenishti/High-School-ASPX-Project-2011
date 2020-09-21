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

public partial class CapiteryTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            GridView1.PageSize = 5;
            GridView1.PagerSettings.Mode = PagerButtons.Numeric;
            localhost.Service srv = new localhost.Service();

            DataTable dt = srv.TakeActi("Select * From capiteria WHERE `status`='T'");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int row = e.RowIndex;
        int k = int.Parse(GridView1.Rows[row].Cells[0].Text);
        string sql2 = "Update capiteria SET `status`='F' Where productID='" + k + "'";
        localhost.Service srv = new localhost.Service();
        srv.TakeAcon(sql2);
        GridView1.EditIndex = -1;
        DataTable dt = srv.TakeActi("Select * From capiteria WHERE `status`='T'");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int row = e.RowIndex;
        int pubid = int.Parse(GridView1.Rows[row].Cells[0].Text);
        TextBox st3 = (TextBox)GridView1.Rows[row].Cells[1].Controls[0];
        TextBox st1 = (TextBox)GridView1.Rows[row].Cells[3].Controls[0];
        TextBox st2 = (TextBox)GridView1.Rows[row].Cells[4].Controls[0];
        string sql = "Update capiteria Set `productID`='" + st3.Text + "', `Price`='" + st1.Text + "', `amount`='" + st2.Text + "' Where productID='" + pubid + "'";
        localhost.Service srv = new localhost.Service();

        srv.UpdateGRD(sql);

        GridView1.EditIndex = -1;
        DataTable dt = srv.TakeActi("Select * From capiteria WHERE `status`='T'");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        localhost.Service srv = new localhost.Service();
        GridView1.EditIndex = e.NewEditIndex;
        DataTable dt = srv.TakeActi("Select * From capiteria WHERE `status`='T'");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        localhost.Service srv = new localhost.Service();
        GridView1.EditIndex = -1;
        DataTable dt = srv.TakeActi("Select * From capiteria WHERE `status`='T'");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}
