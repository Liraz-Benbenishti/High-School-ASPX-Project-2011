using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;




public class Clients
{
    static string CreditNumber;
    static string CustomerID;
    static string TypeID;
    static string Password;
    static string fname;
    static string lname;
    static string address;
    static string CityID;
    static string mail;
    static string Phone;
    static string Picture;
    static int PositionID;

	public Clients()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int PositionID1
    {
        get
        {
            return PositionID;
        }
        set
        {
            PositionID = value;
        }
    }
    public string Picture1
    {
        get
        {
            return Picture;
        }
        set
        {
            Picture = value;
        }
    }
    public string Phone1
    {
        get
        {
            return Phone;
        }
        set
        {
            Phone = value;
        }
    }
    public string mail1
    {
        get
        {
            return mail;
        }
        set
        {
            mail = value;
        }
    }
    public string CityID1
    {
        get
        {
            return CityID;
        }
        set
        {
            CityID = value;
        }
    }
    public string address1
    {
        get
        {
            return address;
        }
        set
        {
            address = value;
        }
    }
    public string lname1
    {
        get
        {
            return lname;
        }
        set
        {
            lname = value;
        }
    }
    public string fname1
    {
        get
        {
            return fname;
        }
        set
        {
            fname = value;
        }
    }
    public string Password1
    {
        get
        {
            return Password;
        }
        set
        {
            Password = value;
        }
    }
    public string TypeID1
    {
        get
        {
            return TypeID;
        }
        set
        {
            TypeID = value;
        }
    }
    public string CustomerID1
    {
        get
        {
            return CustomerID;
        }
        set
        {
            CustomerID = value;
        }
    }
    public string CreditNumber1
    {
        get
        {
            return CreditNumber;
        }
        set
        {
            CreditNumber = value;
        }
    }
}
