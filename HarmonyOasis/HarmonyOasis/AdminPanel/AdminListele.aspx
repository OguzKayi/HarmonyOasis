<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminListele.aspx.cs" Inherits="HarmonyOasis.AdminPanel.AdminListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Admin Liste</h3>
        </div>
        <div class="addbutton">
            <a href="AdminEkle.aspx">
                <h3>Admin Ekle</h3>
            </a>
        </div>
        <asp:Panel ID="failed_pnl" CssClass="pnl_fail" runat="server" Visible="false">
            <asp:Label ID="lbl_fail" runat="server"></asp:Label>
        </asp:Panel>
        <div class="formContent">
            <asp:Panel ID="pnl_secenekVar" runat="server" Visible="false">
                <asp:ListView ID="lv_AdminlerSecenekli" OnItemCommand="lv_Adminler_ItemCommand" runat="server">
                    <LayoutTemplate>
                        <table cellspacing="0" cellpadding="0" class="tablo">
                            <tr>
                                <th>ID</th>
                                <th>Tür</th>
                                <th>Kullanıcı Adı</th>
                                <th>Tarih</th>
                                <th>Durum</th>
                                <th>Seçenekler</th>
                            </tr>
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("Tur") %></td>
                            <td><%# Eval("KullaniciAdi") %></td>
                            <td><%# Eval("Tarih") %></td>
                            <td><%# Eval("Durum") %></td>
                            <td>
                                <a class="TableButtonDuzenle" href='AdminDuzenle.aspx?adminID=<%# Eval("ID") %>'>Düzenle</a>
                                <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="TableButtonSil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                                <asp:LinkButton ID="lbtn_durum" runat="server" CssClass="TableButtonDurum" CommandArgument='<%# Eval("ID") %>' CommandName="durum">Durum</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </asp:Panel>
            <asp:Panel ID="pnl_secenekYok" runat="server" Visible="false">
                <asp:ListView ID="lv_AdminlerSeceneksiz" runat="server">
                    <LayoutTemplate>
                        <table cellspacing="0" cellpadding="0" class="tablo">
                            <tr>
                                <th>ID</th>
                                <th>Tür</th>
                                <th>Kullanıcı Adı</th>
                                <th>Tarih</th>
                                <th>Durum</th>
                            </tr>
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("Tur") %></td>
                            <td><%# Eval("KullaniciAdi") %></td>
                            <td><%# Eval("Tarih") %></td>
                            <td><%# Eval("Durum") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </asp:Panel>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
