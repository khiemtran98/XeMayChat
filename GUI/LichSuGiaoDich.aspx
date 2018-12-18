<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LichSuGiaoDich.aspx.cs" Inherits="GUI.LichSuGiaoDich" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Lịch sử giao dịch</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Lịch sử giao dịch</h2>
    <hr />
    <asp:Label ID="lblThongBao" runat="server" Text="Chưa có đơn hàng nào." CssClass="text-body" Visible="false"></asp:Label>
    <asp:GridView ID="grvHoaDon" runat="server" AutoGenerateColumns="False" CssClass="table-bordered table-hover" CellPadding="5" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grvHoaDon_PageIndexChanging" PageSize="5">
        <Columns>
            <asp:BoundField DataField="MaHD" HeaderText="Mã hoá đơn">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayMua" HeaderText="Ngày mua">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DiaChiGiaoHang" HeaderText="Địa chỉ giao hàng">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="SDTGiaoHang" HeaderText="SĐT giao hàng">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="TongTien" HeaderText="Tổng tiền" DataFormatString="{0:C0}">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" Font-Size="14pt" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="TrangThai" HeaderText="Đã xác nhận">
            <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
        </Columns>
        <PagerStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
