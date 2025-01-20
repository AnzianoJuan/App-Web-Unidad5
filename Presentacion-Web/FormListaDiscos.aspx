<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormListaDiscos.aspx.cs" Inherits="Presentacion_Web.FormListaDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Aca estaria la lista de discos...</h1>
    <asp:GridView ID="DGVListaDiscos" AutoGenerateColumns="false" CssClass="table" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Titulo" />
            <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />

        </Columns>
    </asp:GridView>

</asp:Content>
