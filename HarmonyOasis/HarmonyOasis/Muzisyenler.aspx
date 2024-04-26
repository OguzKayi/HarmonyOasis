<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Muzisyenler.aspx.cs" Inherits="HarmonyOasis.Muzisyenler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_container">
        <div class="formtitle">
            <h2>Müzisyenler</h2>
        </div>
        <div class="formListContent">
            <asp:Repeater ID="rp_Muzisyenler" runat="server">
                <ItemTemplate>
                    <div class="muzisyenliste">
                        <div>
                            <img src='Resimler/MuzisyenResimleri/<%# Eval("Resim") %>'/>
                        </div>
                        <div class="isim">
                            <a href="Muzisyenicerik.aspx?muzisyenID=<%# Eval("ID") %>">
                                <h3><%# Eval("Isim") %></h3>
                            </a>
                        </div>
                        <div>
                            <label><%# Eval("Ozet") %></label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
