﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola.....</h1>
    <h2>Este es el inicio de la web de discos....</h2>

    <div class="row row-cols-1 row-cols-md-3 g-4">


        <% foreach (Dominio.Disco disco in ListaDisco)
            {

                %>
        <div class="col">
            <div class="card">
                <img src="<%: disco.UrlImagenTapa %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: disco.Titulo %></h5>
                    <p class="card-text"><%: disco.Estilo %></p>
                    <a href="FormDetalleDisco.aspx?id=<%: disco.Id %>">Ver detalle</a>
                </div>
            </div>
        </div>
        
         <% }%>
        
    </div>

</asp:Content>