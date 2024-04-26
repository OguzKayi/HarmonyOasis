<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Kategoriicerik.aspx.cs" Inherits="HarmonyOasis.Kategoriicerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_container">
        <div class="formtitle">
            <h2>
                <asp:Literal ID="ltrl_isim" runat="server"></asp:Literal>
            </h2>
        </div>
        <div>
            <asp:Repeater ID="rp_parca" runat="server">
                <ItemTemplate>
                    <div class="parca">
                        <div class="isim">
                            <a href="Parcaicerik.aspx?parcaID=<%# Eval("ID") %>">
                                <h4><%# Eval("Isim") %></h4>
                            </a>
                        </div>
                        <div class="tarih">
                            <label><%# Eval("TarihStr") %></label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
