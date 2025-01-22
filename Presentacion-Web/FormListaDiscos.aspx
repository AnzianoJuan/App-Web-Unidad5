<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormListaDiscos.aspx.cs" Inherits="Presentacion_Web.FormListaDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="DGVListaDiscos" OnSelectedIndexChanged="DGVListaDiscos_SelectedIndexChanged" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Titulo" />
            <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />   
        </Columns>
    </asp:GridView>

    <a href="FormAgregarDisco.aspx" >Agregar</a>

</asp:Content>
