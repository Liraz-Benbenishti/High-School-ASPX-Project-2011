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

public partial class Admin : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    private OleDbConnection conn;
    private DataTable dt;
    public void BindTheDataGrid()
    {
        localhost.Service srv = new localhost.Service();
        
        DataTable dt = srv.TakeUsers();
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    public void BindTheDataGrid2()
    {
        localhost.Service srv = new localhost.Service();
        string ff = (string) Session["Follow"];
        DataTable dt = srv.TakeTickets(ff);
        GridView2.DataSource = dt;
        GridView2.DataBind();

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.IsPostBack == false)
        {
            orders.Visible = false;
            GridView1.AllowPaging = true;
            GridView1.PageSize = 10;
            GridView1.PagerSettings.Mode = PagerButtons.Numeric;
            localhost.Service srv = new localhost.Service();

            DataTable dt = srv.TakeUsers();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Selected = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
        localhost.Service srv = new localhost.Service();
        DataTable dt3 = srv.TakeTickets(Selected);
        Session["Follow"] = Selected; 
        GridView2.Visible = true;
        GridView2.DataSource = dt3;
        GridView2.DataBind();
        orders.Visible = true;
        GridView1.Visible = false;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindTheDataGrid();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView1.EditIndex = e.NewEditIndex;
        BindTheDataGrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int row = e.RowIndex;
        int pubid = int.Parse(GridView1.Rows[row].Cells[0].Text);
        TextBox st1 = (TextBox)GridView1.Rows[row].Cells[3].Controls[0];
        TextBox st2 = (TextBox)GridView1.Rows[row].Cells[4].Controls[0];
        string sql = "Update Users Set `address`='" + st1.Text + "', `mail`='" + st2.Text + "' Where CustomerID='" + pubid + "'";
        localhost.Service srv = new localhost.Service();

        srv.UpdateGRD(sql);

        GridView1.EditIndex = -1;
        BindTheDataGrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int row = e.RowIndex;
        int k = int.Parse(GridView1.Rows[row].Cells[0].Text);
        string sql2 = "Delete from tickets Where costumerID='" + k + "'";
        string sql = "Delete from Users Where CustomerID='" + k + "'";
        localhost.Service srv = new localhost.Service();
        srv.TakeAcon(sql2);
        srv.DeleteGRD(sql);
        GridView1.EditIndex = -1;
        BindTheDataGrid();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Search1 = TextBox1.Text;
        string Search2 = TextBox2.Text;
        localhost.Service srv = new localhost.Service();
        GridView1.Visible = true;
        GridView2.Visible = false;
        GridView3.Visible = false;
        DataTable dt = srv.SearchGRD(Search1, Search2);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView2.EditIndex = e.NewEditIndex;
        BindTheDataGrid2();
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int row = e.RowIndex;
        int pubid = int.Parse(GridView2.Rows[row].Cells[0].Text);
        TextBox st1 = (TextBox)GridView2.Rows[row].Cells[3].Controls[0];
        TextBox st2 = (TextBox)GridView2.Rows[row].Cells[4].Controls[0];
        TextBox st3 = (TextBox)GridView2.Rows[row].Cells[5].Controls[0];
        string sql = "Update `tickets` Set `seat`='" + st1.Text + "', `Row`='" + st2.Text + "', `status`='" + st3.Text + "' Where ticketID=" + pubid;
        localhost.Service srv = new localhost.Service();

        srv.TakeAcon(sql);

        GridView2.EditIndex = -1;
        string ff = (string)Session["Follow"];
        DataTable dt = srv.TakeTickets(ff);
        GridView2.DataSource = dt;
        GridView2.DataBind();

    }

    protected void  GridView2_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        int row = e.RowIndex;
        int k = int.Parse(GridView2.Rows[row].Cells[0].Text);
        string sql = "Delete from tickets Where ticketID=" + k ;
        localhost.Service srv = new localhost.Service();

        srv.TakeAcon(sql);
        GridView2.EditIndex = -1;
        BindTheDataGrid2();
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Selected = int.Parse(GridView2.Rows[GridView2.SelectedIndex].Cells[2].Text);
        localhost.Service srv = new localhost.Service();
        GridView3.Visible = true;
        DataTable dt3 = srv.TakeActi("SELECT * From movies Where `movieID`='" + Selected + "'");
        GridView3.DataSource = dt3;
        Session["Movie"] = Selected;
        GridView3.DataBind();
        GridView2.Visible = false;
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        BindTheDataGrid2();
    }
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        localhost.Service srv = new localhost.Service();
        int Selected = (int) Session["Movie"];
        DataTable dt = srv.TakeActi("SELECT * From movies Where `movieID`='" + Selected + "'");
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }
    protected void GridView3_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       
    }
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.EditIndex = -1;
        localhost.Service srv = new localhost.Service();
        int Selected = (int)Session["Movie"];
        DataTable dt = srv.TakeActi("SELECT * From movies Where `movieID`='" + Selected + "'");
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindTheDataGrid();
    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        BindTheDataGrid2();
    }
    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int row = e.RowIndex;
        int pubid = int.Parse(GridView3.Rows[row].Cells[0].Text);
        TextBox st1 = (TextBox)GridView3.Rows[row].Cells[4].Controls[0];
        TextBox st2 = (TextBox)GridView3.Rows[row].Cells[5].Controls[0];
        TextBox st3 = (TextBox)GridView3.Rows[row].Cells[6].Controls[0];
        string sql = "Update movies Set `Length`='" + st1.Text + "', `cinemaID`='" + st2.Text + "', `Price`='" + int.Parse(st3.Text) + "' Where movieID='" + pubid + "'";
        localhost.Service srv = new localhost.Service();

        srv.TakeAcon(sql);

        GridView3.EditIndex = -1;
        int Selected = (int)Session["Movie"];
        DataTable dt = srv.TakeActi("SELECT * From movies Where `movieID`='" + Selected + "'");
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }
}
