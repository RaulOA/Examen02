<%@ Page Title="CrearPersona" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearPersona.aspx.cs" Inherits="Examen02.CrearPersona" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">

<h2>Crear persona</h2>
        
        <div class="form-group">
            <label for="ddlProvincia">Provincia</label>
            <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem Text="Seleccione una provincia" Value="" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia"
                InitialValue="" ErrorMessage="La provincia es requerida" CssClass="text-danger" />
        </div>
        
        <div class="form-group">
            <label for="txtNombreCompleto">Nombre completo</label>
            <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombreCompleto" runat="server" ControlToValidate="txtNombreCompleto"
                ErrorMessage="El nombre completo es requerido" CssClass="text-danger" />
        </div>
        
        <div class="form-group">
            <label for="txtTelefono">Teléfono (0000-0000)</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="9"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono"
                ErrorMessage="El teléfono es requerido" CssClass="text-danger" />
            <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono"
                ValidationExpression="^\d{4}-\d{4}$" ErrorMessage="El teléfono debe cumplir con el formato ####-####"
                CssClass="text-danger" />
        </div>
        
        <div class="form-group">
            <label for="txtFechaNacimiento">Fecha nacimiento</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
                ErrorMessage="La fecha de nacimiento es requerida" CssClass="text-danger" />
            <asp:CompareValidator ID="cvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
                Operator="LessThanEqual" ValueToCompare="2003-12-31" Type="Date"
                ErrorMessage="Solo se aceptan fechas cuyo año sea menor o igual al 2003" CssClass="text-danger" />
        </div>
        
        <div class="form-group">
            <label for="txtSalario">Salario</label>
            <asp:TextBox ID="txtSalario" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSalario" runat="server" ControlToValidate="txtSalario"
                ErrorMessage="El salario es requerido" CssClass="text-danger" />
            <asp:RangeValidator ID="rvSalario" runat="server" ControlToValidate="txtSalario"
                MinimumValue="1" MaximumValue="99999999.99" Type="Double"
                ErrorMessage="El salario debe estar entre 1 y 99.999.999,99" CssClass="text-danger" />
        </div>

        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
        <a href="ListaPersonas.aspx" class="btn btn-default">Cancelar</a>

    </main>
</asp:Content>