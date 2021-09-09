using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
    public partial class Pet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnfinish_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pet_Adopt.aspx");
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string sID_num = this.TextBox1.Text;
            string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
            string sql = "Select * From PET_SIAZE WHERE ID = " + sID_num;
            //string sql = "Select * From PET_SIAZE";
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand(sql, sqlconn);

            sqlconn.ConnectionString = strCon;
            sqlconn.Open();

            SqlDataReader Sqldr = sqlCmd.ExecuteReader();
            dt.Load(Sqldr);
            Sqldr.Close();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sType = dt.Rows[i]["PET_TYPE"].ToString();
                    string sPET_VARIETY = dt.Rows[i]["PET_VARIETY"].ToString();
                    string sSEX = dt.Rows[i]["PET_SEX"].ToString();
                    string sID = dt.Rows[i]["ID"].ToString();
                    string sIS_Adopt = dt.Rows[i]["IS_ADOPT"].ToString();
                    if (sType == "0")
                    {
                        sType = "貓";
                    }
                    else
                    {
                        sType = "狗";
                    }

                    if (sSEX == "0")
                    {
                        sSEX = "公";
                    }
                    else
                    {
                        sSEX = "母";
                    }
                    if (sIS_Adopt == "1")
                    {
                        sIS_Adopt = "未領養";
                    }
                    else
                    {
                        sIS_Adopt = "已領養";
                    }

                    string s = "Pet_Detail.aspx?ID=" + sID + "&Type=E";

                    string sHtml = "<div style='width:280px;border:solid 1px black; float:left; margin:20px 0px 0px 60px;'>";
                    sHtml += "<div style='width:160px; margin:auto auto;'>";
                    sHtml += "<a href='" + s + "'>";
                    sHtml += "<img src='Image/02.jpg' />";
                    sHtml += "</a>";
                    sHtml += "</div>";
                    sHtml += "<div>";
                    sHtml += "<div><lable>類別：" + sType + "</lable></div>";
                    sHtml += "<div><lable>品種：" + sPET_VARIETY + "</lable></div>";
                    sHtml += "<div><lable>性別：" + sSEX + "</lable></div>";
                    sHtml += "<div><lable>領養狀態：" + sIS_Adopt + "</lable></div>";
                    sHtml += "</div>";
                    sHtml += "</div>";

                    Response.Write(sHtml);
                }
            }
        }

        protected void replist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var data = e.Item.DataItem as DataRowView;

                int petType = (int)data["PET_TYPE"];

                Literal ltPetType = e.Item.FindControl("ltPetType") as Literal;

                // check null
                if (petType == 0)
                {
                    ltPetType.Text = "貓";
                }
                else
                {
                    ltPetType.Text = "狗";
                }
            }

            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    var data = e.Item.DataItem as DataRowView;

            //    int Pet_Variety = (int)data["PET_VARIETY"];

            //    Literal ltPet_Variety = e.Item.FindControl("ltPet_Variety") as Literal;

            //}
        }
    }
}
