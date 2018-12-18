<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="GUI.DoiMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Đổi mật khẩu</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Đổi mật khẩu</h2>
    <p>Nhập mật khẩu hiện tại, sau đó nhập mật khẩu mới 2 lần và nhấn nút Đổi mật khẩu</p>
    <asp:Panel ID="panDoiMatKhau" runat="server" DefaultButton="btnDoiMatKhau">
        <div class="form-group">
            <label for="txtMatKhauCu">Mật khẩu cũ:</label>
            <asp:TextBox ID="txtMatKhauCu" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMatKhauCu" runat="server" ControlToValidate="txtMatKhauCu" ErrorMessage="Vui lòng nhập mật khẩu cũ" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="txtMatKhauMoi">Mật khẩu mới:</label>
            <asp:TextBox ID="txtMatKhauMoi" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMatKhauMoi" runat="server" ControlToValidate="txtMatKhauMoi" ErrorMessage="Vui lòng nhập mật khẩu mới" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revMatKhauMoi" runat="server" ControlToValidate="txtMatKhauMoi" ValidationExpression="^[\s\S]{7,20}$" ErrorMessage="Mật khẩu phải từ 7-20 kí tự" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="txtNhapLaiMatKhauMoi">Nhập lại mật khẩu mới:</label>
            <asp:TextBox ID="txtNhapLaiMatKhauMoi" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNhapLaiMatKhauMoi" runat="server" ControlToValidate="txtNhapLaiMatKhauMoi" ErrorMessage="Vui lòng nhập lại mật khẩu mới" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cpvNhapLaiMatKhauMoi" runat="server" ControlToValidate="txtNhapLaiMatKhauMoi" ControlToCompare="txtMatKhauMoi" ErrorMessage="Mật khẩu không trùng khớp" Display="Dynamic" CssClass="text-danger"></asp:CompareValidator>
        </div>
        <asp:Button ID="btnDoiMatKhau" runat="server" CssClass="btn btn-primary" Text="Đổi mật khẩu" OnClick="btnDoiMatKhau_Click" />
        <asp:Button ID="btnHuy" runat="server" CssClass="btn btn-danger" Text="Hủy bỏ" OnClick="btnHuy_Click" CausesValidation="False" /><br />
        <asp:Label ID="lblDoiMKThanhCong" runat="server" Text="Đổi mật khẩu thành công" CssClass="text-danger" Visible="false"></asp:Label>
        <asp:Label ID="lblDoiMKThatBai" runat="server" Text="Đổi mật khẩu thất bại" CssClass="text-danger" Visible="false"></asp:Label>
        <asp:Label ID="lblMKCuSai" runat="server" Text="Mật khẩu cũ không đúng" CssClass="text-danger" Visible="false"></asp:Label>
    </asp:Panel>
</asp:Content>
