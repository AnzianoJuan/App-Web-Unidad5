<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormListaDiscos.aspx.cs" Inherits="Presentacion_Web.FormListaDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table th {
            background-color: #007bff;
            color: white;
            text-align: center;
        }
        .table tbody tr:hover {
            background-color: #f8f9fa;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <!-- Título principal -->
        <h2 class="text-center mb-3">🎵 Lista de Discos</h2>
        <p class="text-center text-muted">Consulta y administra los discos disponibles.</p>

        <!-- Sección de filtros -->
        <div class="card p-3 shadow-sm mb-4">
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label fw-bold">Filtrar</label>
                    <asp:TextBox ID="FiltroTextbox" AutoPostBack="true" CssClass="form-control" OnTextChanged="FiltroTextbox_TextChanged" runat="server" placeholder="Buscar disco..." />
                </div>
                <div class="col-md-6 d-flex align-items-end">
                    <asp:CheckBox ID="CheckBoxFiltroAvanzado" runat="server" Text="" AutoPostBack="true" CssClass="form-check-input ms-2" OnCheckedChanged="CheckBoxFiltroAvanzado_CheckedChanged" />
                    <label class="form-check-label ms-2" for="CheckBoxFiltroAvanzado">Filtro Avanzado</label>
                </div>
            </div>

            <% if (FiltroAvanzado) { %>
            <div class="row mt-3">
                <div class="col-md-4">
                    <label class="form-label">Campo</label>
                    <asp:DropDownList ID="DDLCAMPOasp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLCAMPOasp_SelectedIndexChanged" CssClass="form-select">
                        <asp:ListItem Text="Estilo" />
                        <asp:ListItem Text="Título" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label class="form-label">Criterio</label>
                    <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label class="form-label">Filtro</label>
                    <asp:TextBox ID="txtBoxFiltroAvanzado" runat="server" CssClass="form-control" placeholder="Ingrese filtro..." />
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-md-4">
                    <label class="form-label">Estado</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 d-flex align-items-end">
                    <asp:Button ID="ButtonBuscar" runat="server" CssClass="btn btn-primary w-100" OnClick="ButtonBuscar_Click" Text="🔍 Buscar" />
                </div>
            </div>
            <% } %>
        </div>

        <!-- Tabla de Discos -->
        <div class="table-responsive">
            <asp:GridView ID="DGVListaDiscos"
                AutoGenerateColumns="false"
                CssClass="table table-hover table-bordered text-center"
                DataKeyNames="Id"
                OnSelectedIndexChanged="DGVListaDiscos_SelectedIndexChanged"
                runat="server">

                <Columns>
                    <asp:BoundField HeaderText="🎶 Nombre" DataField="Titulo" HeaderStyle-CssClass="fw-bold" />
                    <asp:BoundField HeaderText="🎼 Estilo" DataField="Estilo.Descripcion" HeaderStyle-CssClass="fw-bold" />
                    <asp:CheckBoxField HeaderText="✅ Activo" DataField="Activo" />
                    <asp:CommandField ShowSelectButton="true" SelectText="📌 Seleccionar" HeaderText="⚡ Acción" />
                </Columns>
            </asp:GridView>
        </div>

        <!-- Botón para agregar un nuevo disco -->
        <div class="text-end mt-4">
            <a href="FormAgregarDisco.aspx" class="btn btn-success">
                ➕ Agregar Disco
            </a>
        </div>
    </div>
</asp:Content>




