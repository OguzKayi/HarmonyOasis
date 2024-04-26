<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Kategoriler.aspx.cs" Inherits="HarmonyOasis.Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_container">
        <div class="formtitle">
            <h2>Kategoriler</h2>
        </div>
        <div>
            <asp:Repeater ID="rp_Kategoriler" runat="server">
                <ItemTemplate>
                    <div class="kategoriliste">
                        <div class="isim">
                            <a href='Kategoriicerik.aspx?kategoriID=<%# Eval("ID") %>'>
                                <h3><%# Eval("Isim") %></h3>
                            </a>
                        </div>
                        <div class="aciklama">  
                            <label><%# Eval("Aciklama") %></label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
