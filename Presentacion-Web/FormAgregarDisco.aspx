<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormAgregarDisco.aspx.cs" Inherits="Presentacion_Web.FormAgregarDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

<div class="container mt-5">
    <!-- Título del formulario -->
    <h2 class="mb-4 text-center">Gestión de Disco</h2>

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <!-- ID -->
            <div class="mb-3">
                <label for="TextBoxId" class="form-label">ID</label>
                <asp:TextBox runat="server" ID="TextBoxId" CssClass="form-control" />
            </div>

            <!-- Título -->
            <div class="mb-3">
                <label for="TextBoxTitulo" class="form-label">Título</label>
                <asp:TextBox runat="server" ID="TextBoxTitulo" CssClass="form-control" />
            </div>

            <!-- Cantidad de canciones -->
            <div class="mb-3">
                <label for="TextBoxCantidadCanciones" class="form-label">Cantidad de Canciones</label>
                <asp:TextBox runat="server" ID="TextBoxCantidadCanciones" CssClass="form-control" />
            </div>

            <!-- URL de imagen y vista previa -->
            <hr />
            <asp:UpdatePanel ID="UpdatePanelImagen" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="TextBoxUrlImagenTapa" class="form-label">URL de Imagen</label>
                        <asp:TextBox 
                            runat="server" 
                            AutoPostBack="true" 
                            OnTextChanged="TextBoxUrlImagenTapa_TextChanged" 
                            ID="TextBoxUrlImagenTapa" 
                            CssClass="form-control" 
                        />
                    </div>

                    <div class="text-center mb-3">
                        <asp:Button ID="BtnCargarImagen" OnClick="BtnCargarImagen_Click" runat="server" CssClass="btn btn-primary" Text="Cargar Imagen" />
                    </div>

                    <div class="mb-3 text-center">
                        <img src="<% = UrlImagenTapa %>" alt="" class="img-fluid border" style="max-width: 70%;" />
                    </div>
                  
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- Dropdown para Estilo -->
            <div class="mb-3">
                <label for="DropDownListEstilo" class="form-label">Estilo</label>
                <asp:DropDownList 
                    ID="DropDownListEstilo" 
                    CssClass="form-select" 
                    runat="server">
                </asp:DropDownList>
            </div>

            <!-- Dropdown para Edición -->
            <div class="mb-3">
                <label for="DropDownListEdicion" class="form-label">Edición</label>
                <asp:DropDownList 
                    ID="DropDownListEdicion" 
                    CssClass="form-select" 
                    runat="server">
                </asp:DropDownList>
            </div>

            <!-- Botones de acción -->
            <hr />
            <div class="d-flex justify-content-between">
                <asp:Button ID="ButtonAgregarDisco" OnClick="ButtonAgregarDisco_Click" CssClass="btn btn-success me-2" runat="server" Text="Aceptar" />
                <%--<asp:Button ID="ButtonModificarDisco" OnClick="ButtonModificarDisco_Click" CssClass="btn btn-success me-2" runat="server" Text="Modificar" />--%>
                <a href="Default.aspx" class="btn btn-warning">Cancelar</a>
            </div>
        </div>
    </div>
</div>


            <%-- <div class="mb-3">
                <asp:Button ID="ButtonAgregarDireccion" CssClass="btn btn-primary" runat="server" OnClick="ButtonAgregarDireccion_Click" Text="Aceptar" />
                <asp:Button ID="ButtonModificarDireccion" CssClass="btn btn-primary" runat="server"  OnClick="ButtonModificarAuto_Click" Text="Modificar" />
                <a href="Default.aspx">Cancelar</a>
            </div>--%>
            <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
   

</asp:Content>
