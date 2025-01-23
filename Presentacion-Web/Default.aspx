<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <!-- Título principal -->
        <h2 class="text-center mb-4">Bienvenido a la Web de Discos</h2>
        <p class="text-center text-muted">Explora nuestra colección de discos y descubre música increíble.</p>

        <!-- Tarjetas de discos -->
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="RepRepetidor" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card shadow-sm h-100">
                            <!-- Imagen del disco -->
                            <img src="<%#Eval("UrlImagenTapa") %>" class="card-img-top img-fluid" alt="Portada del Disco" style="max-height: 250px; object-fit: cover;">

                            <!-- Contenido de la tarjeta -->
                            <div class="card-body d-flex flex-column">
                                <!-- Título del disco -->
                                <h5 class="card-title text-primary"><%#Eval("Titulo") %></h5>

                                <!-- Estilo del disco -->
                                <p class="card-text text-secondary"><%#Eval("Estilo") %></p>

                                <!-- Botones de acción -->
                                <div class="mt-auto">
                                    <a href="FormAgregarDisco.aspx?id=<%#Eval("Id") %>" class="btn btn-outline-info btn-sm me-2">Ver Detalle</a>
                                    <asp:Button
                                        ID="BtnRepeater"
                                        CssClass="btn btn-primary btn-sm"
                                        runat="server"
                                        Text="Acción"
                                        CommandArgument='<%#Eval("Id") %>'
                                        CommandName="discoId"
                                        OnClick="BtnRepeater_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>


</asp:Content>
