<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Fondo con degradado sutil */
        body {
            background: linear-gradient(135deg, #1f1c2c, #928dab);
            color: white;
        }

        /* Carrusel de discos */
        .carousel-item img {
            height: 300px;
            object-fit: cover;
            border-radius: 15px;
        }

        /* Tarjetas con efecto 3D */
        .card {
            border-radius: 15px;
            transition: transform 0.3s ease-in-out, box-shadow 0.3s ease-in-out;
            background: rgba(255, 255, 255, 0.1);
            backdrop-filter: blur(10px);
        }

        .card:hover {
            transform: scale(1.05);
            box-shadow: 0px 10px 20px rgba(255, 255, 255, 0.2);
        }

        /* Hover con información emergente */
        .card .card-img-top {
            transition: transform 0.3s ease-in-out;
        }

        .card:hover .card-img-top {
            transform: scale(1.1);
        }

        .info-hover {
            opacity: 0;
            position: absolute;
            bottom: 10px;
            left: 50%;
            transform: translateX(-50%);
            background: rgba(0, 0, 0, 0.7);
            color: white;
            padding: 5px 10px;
            border-radius: 5px;
            transition: opacity 0.3s ease-in-out;
        }

        .card:hover .info-hover {
            opacity: 1;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <!-- Carrusel de discos destacados -->
        <div id="carouselDiscos" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <asp:Repeater ID="RepCarrusel" runat="server">
                    <ItemTemplate>
                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                            <img src="<%#Eval("UrlImagenTapa") %>" class="d-block w-100" alt="Disco Destacado">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselDiscos" data-bs-slide="prev">
                <span class="carousel-control-prev-icon"></span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselDiscos" data-bs-slide="next">
                <span class="carousel-control-next-icon"></span>
            </button>
        </div>

        <div class="divider text-center mt-5 mb-4">🎵 Nuestra Colección 🎶</div>

        <!-- Tarjetas de discos con efectos -->
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="RepRepetidor" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100 position-relative">
                            <img src="<%#Eval("UrlImagenTapa") %>" class="card-img-top" alt="Portada del Disco">
                            <div class="info-hover">🎧 <%#Eval("Titulo") %> - <%#Eval("Estilo") %></div>
                            <div class="card-body d-flex flex-column">
                                <h5 class="card-title text-light fw-bold"><%#Eval("Titulo") %></h5>
                                <p class="card-text text-light"><%#Eval("Estilo") %></p>
                                <div class="mt-auto d-flex justify-content-between">
                                    <a href="FormAgregarDisco.aspx?id=<%#Eval("Id") %>" class="btn btn-outline-light btn-sm">🔍 Ver Detalle</a>
                                    <asp:Button
                                        ID="BtnRepeater"
                                        CssClass="btn btn-primary btn-sm"
                                        runat="server"
                                        Text="🎶 Acción"
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



