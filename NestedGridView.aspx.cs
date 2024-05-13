using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NestedGridView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindgridview();
        }
    }

    private void bindgridview()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["testdb"].ToString();
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from [country]", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["testdb"].ToString();
            con.Open();

            GridView gv = (GridView)e.Row.FindControl("GridView2");
            int countryid = Convert.ToInt32(e.Row.Cells[1].Text);

            SqlCommand cmd = new SqlCommand("SELECT * FROM [state] WHERE country_Id = @countryid", con);
            cmd.Parameters.AddWithValue("@countryid", countryid);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();

            gv.DataSource = ds;
            gv.DataBind();
        }
    }
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        SqlConnection con = new SqlConnection();
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["testdb"].ToString();
    //        con.Open();
    //        GridView gv = (GridView)e.Row.FindControl("GridView2");
    //        int countryid = Convert.ToInt32(e.Row.Cells[1].Text);
    //        SqlCommand cmd = new SqlCommand("select * from [state] where country_Id" + countryid, con);
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        con.Close();
    //        gv.DataSource = ds;
    //        gv.DataBind();
    //    }
    //}

}