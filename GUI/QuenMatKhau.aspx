<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuenMatKhau.aspx.cs" Inherits="GUI.QuenMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Quên mật khẩu</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Quên mật khẩu</h2>
    <p>Đặt lại mật khẩu bằng cách sử dụng Email và SĐT lúc đăng kí</p>
    <asp:Panel ID="panQuenMatKhau" runat="server" DefaultButton="btnTiepTuc">
        <p>Nhập tên tài khoản, địa chỉ Email và SĐT và nhấn nút Tiếp tục</p>
        <div class="form-group">
            <label for="txtTenTaiKhoan">Tên tài khoản:</label>
            <asp:TextBox ID="txtTenTaiKhoan" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTenTaiKhoan" runat="server" ControlToValidate="txtTenTaiKhoan" ErrorMessage="Vui lòng nhập tên tài khoản" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revTenTaiKhoan" runat="server" ValidationExpression="^[\s\S]{7,20}$" ErrorMessage="Tên tài khoản phải từ 7-20 kí tự" ControlToValidate="txtTenTaiKhoan" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Vui lòng nhập email" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="txtSDT">SĐT:</label>
            <asp:TextBox ID="txtSDT" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSDT" runat="server" ControlToValidate="txtSDT" ErrorMessage="Vui lòng nhập SĐT" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSDT" runat="server" ControlToValidate="txtSDT" ValidationExpression="0+[19]\d{8,9}" ErrorMessage="SĐT không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>
        <asp:Button ID="btnTiepTuc" runat="server" CssClass="btn btn-primary" Text="Tiếp tục" OnClick="btnTiepTuc_Click" /><br />
        <asp:Label ID="lblThongTinSai" runat="server" Text="Email hoặc SĐT không đúng" CssClass="text-danger" Visible="false"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="panDoiMatKhau" runat="server" DefaultButton="btnDoiMatKhau" Visible="false">
        <p>Nhập mật khẩu mới 2 lần và nhấn nút Tiếp tục</p>
        <div class="form-group">
            <label for="txtMatKhauMoi">Mật khẩu mới:</label>
            <asp:TextBox ID="txtMatKhauMoi" runat="server" MaxLength="20" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMatKhauMoi" runat="server" ControlToValidate="txtMatKhauMoi" ErrorMessage="Vui lòng nhập mật khẩu mới" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revMatKhauMoi" runat="server" ControlToValidate="txtMatKhauMoi" ValidationExpression="^[\s\S]{7,20}$" ErrorMessage="Mật khẩu phải từ 7-20 kí tự" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="txtNhapLaiMatKhauMoi">Nhập lại mật khẩu mới:</label>
            <asp:TextBox ID="txtNhapLaiMatKhauMoi" runat="server" MaxLength="20" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNhapLaiMatKhauMoi" runat="server" ControlToValidate="txtNhapLaiMatKhauMoi" ErrorMessage="Vui lòng nhập lại mật khẩu mới" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cpvNhapLaiMatKhauMoi" runat="server" ControlToValidate="txtNhapLaiMatKhauMoi" ControlToCompare="txtMatKhauMoi" ErrorMessage="Mật khẩu không trùng khớp" Display="Dynamic" CssClass="text-danger"></asp:CompareValidator>
        </div>
        <asp:Button ID="btnDoiMatKhau" runat="server" CssClass="btn btn-primary" Text="Cập nhật" OnClick="btnDoiMatKhau_Click" />
        <asp:Button ID="btnHuy" runat="server" CssClass="btn btn-danger" Text="Hủy bỏ" OnClick="btnHuy_Click" CausesValidation="False" /><br />
        <asp:Label ID="lblDoiMKThanhCong" runat="server" Text="Đổi mật khẩu thành công" CssClass="text-danger" Visible="false"></asp:Label>
        <asp:Label ID="lblDoiMKThatBai" runat="server" Text="Đổi mật khẩu thất bại" CssClass="text-danger" Visible="false"></asp:Label>
    </asp:Panel>
</asp:Content>
