<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormAgregarDisco.aspx.cs" Inherits="Presentacion_Web.FormAgregarDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="TextBoxId" class="form-label">ID</label>
                <asp:TextBox runat="server" ID="TextBoxId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="TextBoxTitulo" class="form-label">Titulo</label>
                <asp:TextBox runat="server" ID="TextBoxTitulo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="TextBoxCantidadCanciones" class="form-label">Cantidad de canciones</label>
                <asp:TextBox runat="server" ID="TextBoxCantidadCanciones" CssClass="form-control" />
            </div>
            <hr />
            <asp:UpdatePanel ID="UpdatePanelImagen" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="TextBoxUrlImagenTapa" class="form-label">Url de imagen</label>
                        <asp:TextBox runat="server"  AutoPostBack="true" OnTextChanged="TextBoxUrlImagenTapa_TextChanged" ID="TextBoxUrlImagenTapa" CssClass="form-control" />
                    </div>
                    <div class="col">
                        <asp:Button ID="BtnCargarImagen" OnClick="BtnCargarImagen_Click" runat="server" CssClass="btn btn-primary" Text="Cargar" />
                    </div>
                    <div class=" mb-3 row ">
                        <div class="col">
                            <img src="<% = UrlImagenTapa %>" alt="Alternate Text"  width="50%"/>
                        </div>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3">
                <label for="DropDownListEstilo" class="form-label">Estilo</label>
                <asp:DropDownList ID="DropDownListEstilo" CssClass=" btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="DropDownListEdicion" class="form-label">Edición</label>
                <asp:DropDownList ID="DropDownListEdicion" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
            <hr />
            <div class="mb-3">
                <asp:Button ID="ButtonAgregarDisco" CssClass="btn btn-primary" runat="server" Text="Aceptar" />
                <asp:Button ID="ButtonModificarDisco" CssClass="btn btn-primary" runat="server" Text="Modificar" />
                <a href="Default.aspx">Cancelar</a>
            </div>

            <%-- <div class="mb-3">
                <asp:Button ID="ButtonAgregarDireccion" CssClass="btn btn-primary" runat="server" OnClick="ButtonAgregarDireccion_Click" Text="Aceptar" />
                <asp:Button ID="ButtonModificarDireccion" CssClass="btn btn-primary" runat="server"  OnClick="ButtonModificarAuto_Click" Text="Modificar" />
                <a href="Default.aspx">Cancelar</a>
            </div>--%>
            <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
