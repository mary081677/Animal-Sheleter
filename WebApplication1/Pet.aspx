<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pet.aspx.cs" Inherits="WebApplication1.Pet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="height: 100vh; background-color: #f8f0cc;">
        <div>
            <asp:Button ID="btnfinish" runat="server" Text="已領養" OnClick="btnfinish_Click" />
            &emsp;                   
               <a href="Pet_Detail.aspx?Type=A">新增</a>
            &emsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &emsp;
                <asp:Button ID="btnCheck" runat="server" Text="查詢" OnClick="btnCheck_Click" />
            <br />
        </div>
        <div style="margin: auto auto; width: 1125px;">
            <div class="row" style="width: 800px;">
            </div>

            <asp:Repeater ID="replist" runat="server" OnItemDataBound="replist_ItemDataBound">
                <ItemTemplate>
                    <div style='width: 280px; border: solid 1px black; float: left; margin: 20px 0px 0px 60px;'>
                        <div style='width: 160px; margin: auto auto;'>
                            <a href='<%# "Pet_Detail.aspx?ID=" + Eval("ID") + "&Type=E" %>'>
                                <img src='Image/02.jpg' />
                            </a>
                        </div>
                        <div>
                            <div>
                                <asp:Literal runat="server" ID="ltPetType">類別:</asp:Literal>
                                <lable>類別：

                                    <%#
                                        (((int)Eval("PET_TYPE") == 0) 
                                            ? "貓" 
                                            : "狗")
                                    %>
                                </lable></div>
                            <div>
                                <asp:Literal ID="ltPet_Variety" runat="server"></asp:Literal>
                                <lable>品種： 
                                    <%# 
                                        ((string)Eval("PET_VARIETY ")) 
                                    %> 
                                </lable></div>
                            <div>
                                <lable>性別：
                                    <%#
                                        (((int)Eval("PET_SEX") == 0) 
                                            ? "公" 
                                            : "母")
                                    %>
                                </lable></div>
                            <div>
                                <lable>領養狀態：
                                    <%#
                                        (((int)Eval("IS_Adopt") == 0) 
                                            ? "已領養" 
                                            : "未領養")
                                    %>
                                </lable></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <uc1:ucPager runat="server" ID="ucPager" />
</asp:Content>

