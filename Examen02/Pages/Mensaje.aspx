<%@ Page Title="Mensaje" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="Examen02.Mensaje" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">

        <h2>Resultado de la operación</h2>
        
        <div class="alert alert-success" role="alert">
            <asp:Label ID="lblMensaje" runat="server" Text="El mensaje será mostrado aquí"></asp:Label>
        </div>
        
        <a href="ListaPersonas.aspx" class="btn btn-primary">Volver a la lista de personas</a>

    </main>
</asp:Content>