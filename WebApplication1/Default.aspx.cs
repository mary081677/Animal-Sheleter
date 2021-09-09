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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
            string sql = "Select * From PET_SIAZE WHERE IS_ADOPT = 0 ";
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
                    string sDate = dt.Rows[i]["CREATE_DATE"].ToString();
                    //string sID = dt.Rows[i]["ID"].ToString();

                    string sHtml = "<div style='text-align:center'>"; //置中
                    sHtml += "<marquee style='width:500px'>公告事項：" + "[" + i + "]" + sDate + "</marquee>";
                    //跑馬燈

                    sHtml += "</div>";

                    Response.Write(sHtml);
                }
            }

            string sHtm2 = "";
            sHtm2 += "<div class='container' style='background-color:#f8f0cc; height:100vh;'>";
            sHtm2 += " <div style = 'width:1125px; height:100vh; margin:auto auto;' >";
            sHtm2 += " <div style='width:373px; height:650px; float:left;'>";
            sHtm2 += " <div style = 'margin:50% 8%; float:left;' >";
            sHtm2 += " <a href='Pet.aspx'><img src = 'Image/05.jpg' /></a >";
            sHtm2 += "  </div >";
            sHtm2 += " </div >";
            sHtm2 += "<div style = 'width:373px; height:650px; float:left;' >";
            sHtm2 += "<div style = 'margin:50% 8%; float:left;' >";
            sHtm2 += "<a href = 'Adopt.aspx' ><img src = 'Image/06.jpg' /></a >";
            sHtm2 += "</div >";
            sHtm2 += "</div >";
            sHtm2 += "<div style = 'width:373px; height:650px; float:left;'>";
            sHtm2 += "<div style = 'margin:50% 8%; float:left;' >";
            sHtm2 += "<a href = 'User.aspx' ><img src = 'Image/07.jpg' /></a >";
            sHtm2 += "</div >";
            sHtm2 += "</div >";
            sHtm2 += "</div >";
            sHtm2 += "</div >";
            Response.Write(sHtm2);


            string strCon2 =
                ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
            sql = "Select * From ADOPTERS";
            dt = new DataTable();
            sqlconn = new SqlConnection();
            sqlCmd = new SqlCommand(sql, sqlconn);

            sqlconn.ConnectionString = strCon;
            sqlconn.Open();

            Sqldr = sqlCmd.ExecuteReader();
            dt.Load(Sqldr);
            Sqldr.Close();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sMail = dt.Rows[i]["ADOPTERS_MAIL"].ToString();
                    string sTime = dt.Rows[i]["CREATE_DATE"].ToString();
                    DateTime Datenow = DateTime.Now.AddDays(-180);
                    //算時間有沒有符合條件
                    if (true)//true 改成你的變數
                    {//send Mail function

                        /*MailMessage mail = new MailMessage();
                        //前面是發信email後面是顯示的名稱
                        mail.From = new MailAddress("xxx@gmail.com", "信件名稱");

                        //收信者email
                        mail.To.Add("xxx@gmail.com");

                        //設定優先權
                        mail.Priority = MailPriority.Normal;

                        //標題
                        mail.Subject = "AutoEmail";

                        //內容
                        mail.Body = "<h1>HIHI,Wellcome</h1>";

                        //內容使用html
                        mail.IsBodyHtml = true;

                        //設定gmail的smtp (這是google的)
                        SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

                        //您在gmail的帳號密碼
                        MySmtp.Credentials = new System.Net.NetworkCredential("account", "pw");

                        //開啟ssl
                        MySmtp.EnableSsl = true;

                        //發送郵件
                        MySmtp.Send(mail);

                        //放掉宣告出來的MySmtp
                        MySmtp = null;

                        //放掉宣告出來的mail
                        mail.Dispose();*/
                    }

                }
            }
        }

    }



}