<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormListaDiscos.aspx.cs" Inherits="Presentacion_Web.FormListaDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Puedes incluir estilos personalizados aquí si lo deseas -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <!-- Título principal -->
        <h2 class="text-center mb-4">Lista de Discos</h2>
        <p class="text-center text-muted">Consulta y administra los discos disponibles en la base de datos.</p>
     </div>

        <div class="row">
            <div class="col-md-6 offset-md-3">
                <!-- ID -->
                <div id="DivTextBoxId" runat="server" class="mb-3">
                    <label>Filtrar</label>
                    <asp:TextBox ID="FiltroTextbox" AutoPostBack="true" CssClass=" form-control" OnTextChanged="FiltroTextbox_TextChanged" runat="server" />
                </div>
            </div>

            <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                <div class="mb-3">
                    <asp:CheckBox Text="Filtro Avanzado"
                        AutoPostBack="true"
                        OnCheckedChanged="CheckBoxFiltroAvanzado_CheckedChanged"
                        ID="CheckBoxFiltroAvanzado" runat="server" />
                </div>
            </div>

            <%if (FiltroAvanzado)
                {%>
            <div class="row">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="LabelddlCampo" runat="server" />
                    <asp:DropDownList runat="server"  ID="DDLCAMPOasp" AutoPostBack="true"  OnSelectedIndexChanged="DDLCAMPOasp_SelectedIndexChanged" CssClass="form-control">
                        <asp:ListItem Text="Estilo" />
                        <asp:ListItem Text="Titulo" />

                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtBoxFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>

            <div class="row">
                <div class="mb-3">
                    <asp:Label Text="Estado" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button ID="ButtonBuscar" runat="server" CssClass="btn btn-primary" OnClick="ButtonBuscar_Click" Text="Buscar" />
                    </div>
                </div>
            </div>

            <%} %>

            <!-- Tabla estilizada -->
            <div class="table-responsive">
                <asp:GridView
                    ID="DGVListaDiscos"
                    OnSelectedIndexChanged="DGVListaDiscos_SelectedIndexChanged"
                    DataKeyNames="Id"
                    AutoGenerateColumns="false"
                    CssClass="table table-striped table-hover text-center"
                    runat="server">

                    <Columns>

                        <asp:BoundField HeaderText="Nombre" DataField="Titulo" HeaderStyle-CssClass="fw-bold" />


                        <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" HeaderStyle-CssClass="fw-bold" />

                        <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />

                        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
                    </Columns>
                </asp:GridView>
            </div>


            <div class="text-end mt-3">
                <a href="FormAgregarDisco.aspx" class="btn btn-primary">Agregar Disco</a>
            </div>
        </div>
</asp:Content>



