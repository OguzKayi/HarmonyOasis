<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HarmonyOasis.AdminPanel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Harmony Oasis</h3>
        </div>
        <div class="formContent">
            <div class="count_row">
                <div class="toplam-tablo">
                    <div class="table_title">
                        <h4>Admin</h4>
                    </div>
                    <div class="table">
                        <div class="columns_title">
                            <div class="leftColumn_title">
                                <label>Aktif</label>
                            </div>
                            <div class="rightColumn_title">
                                <label>Değil</label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <div class="columns">
                            <div class="leftColumn_content">
                                <asp:Label runat="server" ID="lbl_adminDegil"></asp:Label>
                            </div>
                            <div class="rightColumn_content">
                                <asp:Label runat="server" ID="lbl_adminAskida"></asp:Label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                    <div class="toplam">
                        <asp:Label runat="server" ID="lbl_adminToplam"></asp:Label>
                    </div>
                </div>
                <div class="toplam-tablo">
                    <div class="table_title">
                        <h4>Üye</h4>
                    </div>
                    <div class="table">
                        <div class="columns_title">
                            <div class="leftColumn_title">
                                <label>Aktif</label>
                            </div>
                            <div class="rightColumn_title">
                                <label>Değil</label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <div class="columns">
                            <div class="leftColumn_content">
                                <asp:Label runat="server" ID="lbl_uyeDegil"></asp:Label>
                            </div>
                            <div class="rightColumn_content">
                                <asp:Label runat="server" ID="lbl_uyeAskida"></asp:Label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                    <div class="toplam">
                        <asp:Label runat="server" ID="lbl_uyeToplam"></asp:Label>
                    </div>
                </div>
                <div class="toplam-tablo">
                    <div class="table_title">
                        <h4>Yorum</h4>
                    </div>
                    <div class="table">
                        <div class="columns_title">
                            <div class="leftColumn_title">
                                <label>Aktif</label>
                            </div>
                            <div class="rightColumn_title">
                                <label>Değil</label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <div class="columns">
                            <div class="leftColumn_content">
                                <asp:Label runat="server" ID="lbl_yorumDegil"></asp:Label>
                            </div>
                            <div class="rightColumn_content">
                                <asp:Label runat="server" ID="lbl_yorumAskida"></asp:Label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                    <div class="toplam">
                        <asp:Label runat="server" ID="lbl_yorumToplam"></asp:Label>
                    </div>
                </div>
                <div style="clear: both"></div>
            </div>

            <div class="count_row">
                <div class="toplam-tablo">
                    <div class="table_title">
                        <h4>Kategori</h4>
                    </div>
                    <div class="table">
                        <div class="columns_title">
                            <div class="leftColumn_title">
                                <label>Aktif</label>
                            </div>
                            <div class="rightColumn_title">
                                <label>Değil</label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <div class="columns">
                            <div class="leftColumn_content">
                                <asp:Label runat="server" ID="lbl_katDegil"></asp:Label>
                            </div>
                            <div class="rightColumn_content">
                                <asp:Label runat="server" ID="lbl_katAskida"></asp:Label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                    <div class="toplam">
                        <asp:Label runat="server" ID="lbl_katToplam"></asp:Label>
                    </div>
                </div>
                <div class="toplam-tablo">
                    <div class="table_title">
                        <h4>Müzisyen</h4>
                    </div>
                    <div class="table">
                        <div class="columns_title">
                            <div class="leftColumn_title">
                                <label>Aktif</label>
                            </div>
                            <div class="rightColumn_title">
                                <label>Değil</label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <div class="columns">
                            <div class="leftColumn_content">
                                <asp:Label runat="server" ID="lbl_muzDegil"></asp:Label>
                            </div>
                            <div class="rightColumn_content">
                                <asp:Label runat="server" ID="lbl_muzAskida"></asp:Label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                    <div class="toplam">
                        <asp:Label runat="server" ID="lbl_muzToplam"></asp:Label>
                    </div>
                </div>
                <div class="toplam-tablo">
                    <div class="table_title">
                        <h4>Parça</h4>
                    </div>
                    <div class="table">
                        <div class="columns_title">
                            <div class="leftColumn_title">
                                <label>Aktif</label>
                            </div>
                            <div class="rightColumn_title">
                                <label>Değil</label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <div class="columns">
                            <div class="leftColumn_content">
                                <asp:Label runat="server" ID="lbl_parDegil"></asp:Label>
                            </div>
                            <div class="rightColumn_content">
                                <asp:Label runat="server" ID="lbl_parAskida"></asp:Label>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                    <div class="toplam">
                        <asp:Label runat="server" ID="lbl_parToplam"></asp:Label>
                    </div>
                </div>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>
</asp:Content>
