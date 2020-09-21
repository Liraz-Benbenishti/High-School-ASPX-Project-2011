using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Web.Services;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public DataSet DownLoadDataSet(string sql)
    {
        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        return conn.DownLoadData(sql, "table1");
    
    }
    [WebMethod]
    public void TakeAcon(string sql)
    {
        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        OleDbCommand cmmd = new OleDbCommand(sql);
       
        conn.TakeAction(cmmd);
    }
    [WebMethod]
    public DataTable TakeActi(string sql)
    {
        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));

        DataSet ds = conn.DownLoadData(sql, "q1");

        return ds.Tables[0];
    }
    [WebMethod]
    public DataTable SearchGRD(string Search1, string Search2)
    {
        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));

        DataSet ds = conn.DownLoadData("Select * From Users Where (CustomerID='" + Search1 + "' or mail='" + Search2 + "')", "Users");

        return ds.Tables[0];
    }
    [WebMethod]
    public void DeleteGRD(string sql)
    {

        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        OleDbCommand cmmd = new OleDbCommand(sql);
        conn.TakeAction(cmmd);
    }
    [WebMethod]
    public void UpdateGRD(string sql)
    {

        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        OleDbCommand cmmd = new OleDbCommand(sql);
        conn.TakeAction(cmmd);
    }
    [WebMethod]
    public DataTable TakeTickets(string Selected)
    {

        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        DataSet ds = conn.DownLoadData("Select * From tickets Where costumerID='" + Selected + "'", "tickets");

        return ds.Tables[0];
    }
    [WebMethod]
    public DataTable TakeUsers()
    {

        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        DataSet ds = conn.DownLoadData("Select * From Users", "Users");

        return ds.Tables[0];
    }
    [WebMethod]
    public DataTable Login(string user, string pass)
    {

        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        DataSet ds = conn.DownLoadData("Select * From Users Where CustomerID='" + user + "' and pass='" + pass + "'", "Users");

        return ds.Tables[0];
    }
    [WebMethod]
    public DataTable GetMovies()
    {

        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        DataSet ds = conn.DownLoadData("Select * From movies", "movies");
        return ds.Tables[0];
    }
    [WebMethod]
    public DataTable GetUserControl(string user)
    {

        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        DataSet ds = conn.DownLoadData("Select * From Users Where CustomerID='" + user + "'", "Users");
        return ds.Tables[0];
    }
    [WebMethod]
    public DataTable GetCapitery(string value)
    {
        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        DataSet ds1 = conn.DownLoadData("Select * From capiteria Where amount>0 and CatgoryID='" + value + "' and `status`='T'", "capiteria");
        return ds1.Tables[0];
    }
    [WebMethod]
    public DataTable GetCities()
    {
        Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));
        DataSet ds3 = conn.DownLoadData("Select * From City", "City");

        return ds3.Tables[0];
    }

    [WebMethod]
    public bool Register(Clients c)
    {
         OleDbCommand cmmd = new OleDbCommand();
        OleDbCommand cmmd2 = new OleDbCommand();

            cmmd2.CommandText = "Insert Into Viza values(@p1,@p2,@p3)";
            cmmd2.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
            cmmd2.Parameters["@p1"].Value = c.CustomerID1;
            cmmd2.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
            cmmd2.Parameters["@p2"].Value = c.CreditNumber1;
            cmmd2.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
            cmmd2.Parameters["@p3"].Value = c.TypeID1;
            cmmd.CommandText = "Insert Into Users values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";
            cmmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
            cmmd.Parameters["@p1"].Value = c.CustomerID1;
            cmmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
            cmmd.Parameters["@p2"].Value = c.Password1;
            cmmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
            cmmd.Parameters["@p3"].Value = c.fname1;
            cmmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
            cmmd.Parameters["@p4"].Value = c.lname1;
            cmmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
            cmmd.Parameters["@p5"].Value = c.address1;
            cmmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));
            cmmd.Parameters["@p6"].Value = c.CityID1;
            cmmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));
            cmmd.Parameters["@p7"].Value = c.mail1;
            cmmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));
            cmmd.Parameters["@p8"].Value = c.Phone1;
            cmmd.Parameters.Add(new OleDbParameter("@p9", OleDbType.VarChar));
            cmmd.Parameters["@p9"].Value = c.Picture1;
            cmmd.Parameters.Add(new OleDbParameter("@p10", OleDbType.VarChar));
            cmmd.Parameters["@p10"].Value = c.PositionID1;
            string id = c.CustomerID1;
            Connect conn = new Connect(Server.MapPath("App_Data/db1.mdb"));

            DataSet ds = conn.DownLoadData("Select * From Users Where Customerid='" + id + "'", "Users");

            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
            {

               
                Session["User"] = c.CustomerID1;
                Session["Name"] = c.fname1;
                conn.TakeAction(cmmd);
                conn.TakeAction(cmmd2);
                return true;
            }
            return false;

    }
    
    
}
