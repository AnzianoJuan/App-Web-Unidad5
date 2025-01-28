<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormListaDiscos.aspx.cs" Inherits="Presentacion_Web.FormListaDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Puedes incluir estilos personalizados aquí si lo deseas -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <!-- Título principal -->
        <h2 class="text-center mb-4">Lista de Discos</h2>
        <p class="text-center text-muted">Consulta y administra los discos disponibles en la base de datos.</p>
        
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



