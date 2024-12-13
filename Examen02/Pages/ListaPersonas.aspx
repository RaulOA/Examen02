<%@ Page Title="ListaPersonas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPersonas.aspx.cs" Inherits="Examen02.ListaPersonas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <asp:GridView ID="GridViewPersonas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowDataBound="GridViewPersonas_RowDataBound">
            <Columns>
                <%--<!-- Columna ID -->--%>
                <asp:BoundField DataField="idPersona" HeaderText="ID" SortExpression="idPersona" ItemStyle-HorizontalAlign="Center" />

                <%--<!-- Columna Provincia -->--%>
                <asp:BoundField DataField="nombreProvincia" HeaderText="Provincia" SortExpression="nombreProvincia" ItemStyle-HorizontalAlign="Left" />

                <%--<!-- Columna Nombre Completo -->--%>
                <asp:BoundField DataField="nombreCompleto" HeaderText="Nombre completo" SortExpression="nombreCompleto" ItemStyle-HorizontalAlign="Left" />

                <%--<!-- Columna Teléfono -->--%>
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" SortExpression="telefono" ItemStyle-HorizontalAlign="Center" />

                <%--<!-- Columna Fecha Nacimiento -->--%>
                <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha nacimiento" SortExpression="fechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />

                <%--<!-- Columna Salario -->--%>
                <asp:BoundField DataField="salario" HeaderText="Salario" SortExpression="salario" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />

                <%--<!-- Columna Edad -->--%>
                <asp:TemplateField HeaderText="Edad">
                    <ItemTemplate>
                        <asp:Label ID="lblEdad" runat="server" Text='<%# CalculateAge(Eval("fechaNacimiento")) %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <%--<!-- Columna Generación -->--%>
                <asp:TemplateField HeaderText="Generación">
                    <ItemTemplate>
                        <asp:Label ID="lblGeneracion" runat="server" Text='<%# DetermineGeneration(Eval("fechaNacimiento")) %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <%--<!-- Columna Editar -->--%>
                <asp:TemplateField HeaderText="Acción">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEditar" runat="server" Text="Editar" NavigateUrl='<%# "EditarPersona.aspx?idPersona=" + Eval("idPersona") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </main>
</asp:Content>
