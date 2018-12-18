<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="GUI.ThanhToan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Thanh toán</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Thanh toán</h2>
    <p>Nhập địa chỉ giao hàng và SĐT liên hệ</p>
    <div class="form-group">
        <label for="txtDiaChiGiaoHang">Địa chỉ giao hàng:</label>
        <asp:TextBox ID="txtDiaChiGiaoHang" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="revDiaChi" runat="server" ControlToValidate="txtDiaChiGiaoHang" ErrorMessage="Vui lòng nhập địa chỉ" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtSDTGiaoHang">SĐT liên hệ:</label>
        <asp:TextBox ID="txtSDTGiaoHang" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSDT" runat="server" ControlToValidate="txtSDTGiaoHang" ErrorMessage="Vui lòng nhập SĐT" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revSDT" runat="server" ControlToValidate="txtSDTGiaoHang" ValidationExpression="0+[19]\d{8,9}" ErrorMessage="SĐT không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>
    <asp:Button ID="btnThanhToan" runat="server" CssClass="btn btn-primary" Text="Thanh toán" OnClick="btnThanhToan_Click" /><br />
    <asp:Label ID="lblThanhToanThanhCong" runat="server" Text="Thanh toán thành công" CssClass="font-weight-bold text-success" Visible="false"></asp:Label>
    <asp:Label ID="lblThanhToanThatBai" runat="server" Text="Thanh toán thất bại" CssClass="font-weight-bold text-danger" Visible="false"></asp:Label>
</asp:Content>
