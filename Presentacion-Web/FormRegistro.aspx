<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormRegistro.aspx.cs" Inherits="Presentacion_Web.FormRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2 class="text-center">Registro de Usuario</h2>
        <div class="card p-4 shadow-lg">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
            </div>
            <div class="text-center">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
            </div>
            <div>

            </div>
        </div>
    </div>
</asp:Content>

