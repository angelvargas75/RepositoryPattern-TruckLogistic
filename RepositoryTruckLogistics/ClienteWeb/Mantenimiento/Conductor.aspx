<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Conductor.aspx.cs" Inherits="ClienteWeb.Mantenimiento.Conductor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align-last: center">Listado de conductores</h2>
    <br />
    <br />

    <div style="padding-bottom: 10px;">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Mantenimiento/EditarConductor.aspx?cod={0}">Nuevo</asp:HyperLink>
    </div>

    <asp:GridView ID="dgvConductor" runat="server" AutoGenerateColumns="false" 
        CssClass="table table-success table-hover"
        DataKeyNames="ID" OnRowCommand="dgvConductor_RowCommand"  >
        <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="pais" HeaderText="Pais" />
            <asp:BoundField DataField="ciudad" HeaderText="Ciudad" />
            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
            <asp:HyperLinkField DataNavigateUrlFormatString="~/Mantenimiento/EditarConductor.aspx?Id={0}" DataNavigateUrlFields="Id" Text="Editar" />
            <asp:TemplateField>
                <ItemTemplate>
                    <!-- Agrega el LinkButton que eliminará el registro -->
                    <asp:LinkButton ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="ConfirmarEliminar" CommandArgument='<%# Eval("ID") %>'
                    OnClientClick="return confirmarEliminacion();" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

  

    <script type="text/javascript">
        function confirmarEliminacion() {
            return confirm('¿Estás seguro de que deseas eliminar este registro?');
        }
    </script>
</asp:Content>
