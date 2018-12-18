<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DangKi.aspx.cs" Inherits="GUI.DangKi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Đăng kí tài khoản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Đăng kí tài khoản</h2>
    <p>Nếu đã có tài khoản, vui lòng chọn mục Đăng nhập ở menu phía trên cùng.</p>
    <asp:Panel ID="panDangKi" runat="server" DefaultButton="btnDangKi">
        <fieldset>
            <legend>Thông tin tài khoản</legend>
            <div class="form-group">
                <label for="txtTenTaiKhoan">Tên tài khoản:</label>
                <asp:TextBox ID="txtTenTaiKhoan" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTenTaiKhoan" runat="server" ControlToValidate="txtTenTaiKhoan" ErrorMessage="Vui lòng nhập tên tài khoản" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTenTaiKhoan" runat="server" ValidationExpression="^[\s\S]{7,20}$" ErrorMessage="Tên tài khoản phải từ 7-20 kí tự" ControlToValidate="txtTenTaiKhoan" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="txtMatKhau">Mật khẩu:</label>
                <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control" MaxLength="20" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMatKhau" runat="server" ControlToValidate="txtMatKhau" ErrorMessage="Vui lòng nhập mật khẩu" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revMatKhau" runat="server" ControlToValidate="txtMatKhau" ValidationExpression="^[\s\S]{7,20}$" ErrorMessage="Mật khẩu phải từ 7-20 kí tự" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="txtNhapLaiMatKhau">Nhập lại mật khẩu:</label>
                <asp:TextBox ID="txtNhapLaiMatKhau" runat="server" CssClass="form-control" MaxLength="20" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNhapLaiMatKhau" runat="server" ControlToValidate="txtNhapLaiMatKhau" ErrorMessage="Vui lòng nhập lại mật khẩu" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cpvNhapLaiMatKhau" runat="server" ControlToValidate="txtNhapLaiMatKhau" ControlToCompare="txtMatKhau" ErrorMessage="Mật khẩu không trùng khớp" Display="Dynamic" CssClass="text-danger"></asp:CompareValidator>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Vui lòng nhập email" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
        </fieldset>
        <fieldset>
            <legend>Thông tin liên hệ</legend>
            <div class="form-group">
                <label for="txtSDT">SĐT:</label>
                <asp:TextBox ID="txtSDT" runat="server" TextMode="Phone" MaxLength="11" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revSDT" runat="server" ControlToValidate="txtSDT" ValidationExpression="0+[19]\d{8,9}" ErrorMessage="SĐT không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="txtDiaChi">Địa chỉ:</label>
                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtHoTen">Họ tên:</label>
                <asp:TextBox ID="txtHoTen" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revHoTen" runat="server" ControlToValidate="txtHoTen" ValidationExpression="[\D]{0,100}" ErrorMessage="Họ tên không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="filAnhDaiDien">Ảnh đại diện:</label><br />
                <asp:Image ID="imgAnhDaiDien" runat="server" ImageUrl="~/img/AnhDaiDien/profile.png" Width="150px" Height="150px" />
                <asp:Button ID="btnXoaAnhDaiDien" runat="server" Text="Xoá" CssClass="btn align-bottom" OnClick="btnXoaAnhDaiDien_Click" CausesValidation="False" /><br />
                <br />
                <asp:FileUpload ID="filAnhDaiDien" runat="server" CssClass="form-row" />
                <script type="text/javascript">
                    function readURL(input) {
                        if (input.files && input.files[0]) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('#cphBody_imgAnhDaiDien').attr('src', e.target.result);
                            }
                            reader.readAsDataURL(input.files[0]);
                        }
                    }
                    $("#cphBody_filAnhDaiDien").change(function () {
                        readURL(this);
                    });
                </script>
                <asp:Label ID="lblAnhDaiDienLoiDungLuong" runat="server" Text="Dung lượng file tối đa 1 MB" Visible="false" CssClass="text-danger"></asp:Label>
                <asp:Label ID="lblAnhDaiDienLoiFile" runat="server" Text="Chỉ được tải lên ảnh .jpg hoặc .png" Visible="false" CssClass="text-danger"></asp:Label>
            </div>
        </fieldset>
        <asp:Button ID="btnDangKi" runat="server" CssClass="btn btn-primary" Text="Đăng kí" OnClick="btnDangKi_Click" />
        <asp:Button ID="btnHuy" runat="server" CssClass="btn btn-danger" Text="Hủy bỏ" OnClick="btnHuy_Click" CausesValidation="False" /><br />
        <asp:Label ID="lblDangKiThatBai" runat="server" Text="Tên tài khoản đã tồn tại" ForeColor="Red" Visible="false"></asp:Label>
    </asp:Panel>
</asp:Content>
