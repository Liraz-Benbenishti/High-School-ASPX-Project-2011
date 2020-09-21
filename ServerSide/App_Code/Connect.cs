using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Connect
{
    private string path;
    private OleDbConnection my_conn;

    public Connect(string my_path)
    {
        this.path = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + my_path;

        this.my_conn = new OleDbConnection(this.path);

    }

    //----------------------------------------------------------------------------

    public DataSet DownLoadData(string sql, string TableName)
    {
        DataSet ds = new DataSet();

        OleDbCommand cmmd = new OleDbCommand(sql, this.my_conn);

        OleDbDataAdapter da = new OleDbDataAdapter(cmmd);

        da.Fill(ds, TableName);

        return (ds);
    }
    //------------------------------------------------------------
    public void TakeAction(OleDbCommand cmmd)
    {
        cmmd.Connection = this.my_conn;

        this.my_conn.Open();

        cmmd.ExecuteNonQuery();

        this.my_conn.Close();
    }

}
