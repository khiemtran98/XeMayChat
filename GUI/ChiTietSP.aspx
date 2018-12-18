<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChiTietSP.aspx.cs" Inherits="GUI.ChiTietSP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title id="TenTrang" runat="server"></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="row">
        <div class="col-md-3">
            <asp:Image ID="imgAnhMinhHoa" runat="server" Width="200px" />
        </div>
        <div class="col-md-9">
            <asp:Label ID="lblTenSP" runat="server" CssClass="h3 font-weight-bold"></asp:Label><br />
            <asp:Label ID="lblThongTin" runat="server"></asp:Label><br />
            <span>Giá tiền: </span><asp:Label ID="lblGiaTien" runat="server"></asp:Label><span> VND</span><br />
            <span>Số lượng tồn kho: </span><asp:Label ID="lblSoLuongTonKho" runat="server"></asp:Label>
            <asp:TextBox ID="txtSoLuongMua" runat="server" CssClass="form-control" Text="1" TextMode="Number"></asp:TextBox>
            <asp:Button ID="btnThemVaoGH" runat="server" CssClass="btn btn-primary" Text="Thêm vào giỏ hàng" OnClick="btnThemVaoGH_Click" />
            <asp:Label ID="lblThongBaoThanhCong" runat="server" CssClass="text-success font-weight-bold" Visible="false"></asp:Label>
            <asp:Label ID="lblThongBaoThatBai" runat="server" CssClass="text-danger font-weight-bold" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>
