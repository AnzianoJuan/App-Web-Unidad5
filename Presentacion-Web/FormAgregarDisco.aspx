<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormAgregarDisco.aspx.cs" Inherits="Presentacion_Web.FormAgregarDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <div class="container mt-5">
        <!-- Título principal -->
        <h2 class="mb-4 text-center text-primary"><i class="fa-solid fa-record-vinyl"></i> Gestión de Disco</h2>

        <div class="row justify-content-center">
            <div class="col-md-6">
                <!-- ID -->
                <div id="DivTextBoxId" runat="server" class="mb-3">
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
                                CssClass="form-control" />
                        </div>

                        <div class="text-center">
                            <asp:Button ID="BtnCargarImagen" OnClick="BtnCargarImagen_Click" runat="server" CssClass="btn btn-primary" Text="Cargar Imagen" />
                        </div>

                        <div class="text-center mt-3">
                            <img src="<% = UrlImagenTapa %>" alt="Imagen del Disco" class="img-thumbnail shadow-lg" style="max-width: 80%;" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <!-- Dropdowns para Estilo y Edición -->
                <div class="mb-3">
                    <label for="DropDownListEstilo" class="form-label">Estilo</label>
                    <asp:DropDownList ID="DropDownListEstilo" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="DropDownListEdicion" class="form-label">Edición</label>
                    <asp:DropDownList ID="DropDownListEdicion" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>

                <!-- Botones de acción -->
                <hr />
                <div class="d-flex justify-content-between">
                    <asp:Button ID="ButtonAgregarDisco" OnClick="ButtonAgregarDisco_Click" CssClass="btn btn-success" runat="server" Text="Aceptar" />
                    <a href="Default.aspx" class="btn btn-secondary"><i class="fa-solid fa-arrow-left"></i> Cancelar</a>
                    <asp:Button Text="Inactivar" ID="BtnInactivar" runat="server" OnClick="BtnInactivar_Click" CssClass="btn btn-warning" />
                </div>

                <hr />

                <!-- Sección de eliminación con alerta -->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button Text="Eliminar" ID="ButtonEliminar" OnClick="ButtonEliminar_Click" CssClass="btn btn-danger w-100" runat="server" />
                        </div>

                        <!-- Confirmación de eliminación -->
                        <div class="alert alert-danger text-center" runat="server" id="DivConfirmaEliminacion">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="CheckBoxConfiEliminacion" runat="server" />
                            <asp:Button Text="Eliminar Confirmado" OnClick="ButtonConfiEliminar_Click" ID="ButtonConfiEliminar" CssClass="btn btn-outline-danger mt-2" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
