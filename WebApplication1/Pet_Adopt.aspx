﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pet_Adopt.aspx.cs" Inherits="WebApplication1.Pet_Adopt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="height: 100vh; background-color: #f8f0cc;">
        <div>
             
               <a href="Pet_Detail.aspx?Type=A">新增</a>
            &emsp;
                <asp:Button ID="btnBack" runat="server" Text="返回未領養" OnClick="btnBack_Click"/>

        </div>
        <div style="margin: auto auto; width: 1125px;">
            <div class="row" style="width: 800px;">
        </div>
            

            <%
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
                %>

                 <%
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

                             if (sIS_Adopt == "0")
                             {
                                 sIS_Adopt = "已領養";
                             }
                             else
                             {
                                 //break;
                                 //return
                                 continue;
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
                %>  
        </div>      
    </div>
    <uc1:ucPager runat="server" id="ucPager" />
</asp:Content>