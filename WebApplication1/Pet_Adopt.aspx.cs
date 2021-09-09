using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Pet_Adopt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pet.aspx");
        }

        protected void replist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
            string sql = "Select * From PET_SIAZE";
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand(sql, sqlconn);

            sqlconn.ConnectionString = strCon;
            sqlconn.Open();

            SqlDataReader Sqldr = sqlCmd.ExecuteReader();
            dt.Load(Sqldr);
            Sqldr.Close();

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var data = e.Item.DataItem as DataRowView;

                int IS_Adopt = (int)data["IS_Adopt"];

                Literal ltIS_Adopt = e.Item.FindControl("ltIS_Adopt") as Literal;

                // check null
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (IS_Adopt == 0)
                {
                    ltIS_Adopt.Text = "已領養";
                }
                else
                {
                    continue;
                } 
                }
            }
        }
    }
}