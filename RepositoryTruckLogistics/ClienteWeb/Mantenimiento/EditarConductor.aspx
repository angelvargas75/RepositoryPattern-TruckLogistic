<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarConductor.aspx.cs" Inherits="ClienteWeb.Mantenimiento.EditarConductor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hidCodigoConductor" runat="server" />
    <%-- Datos del Conductor --%>
    <br />
    <h2>Datos del Conductor</h2>
    <div>
        <table class="table table-borderless">
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"
                        CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="Debe ingresar el nombre" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Pais</td>
                <td>
                    <asp:TextBox ID="txtPais" runat="server"
                        CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPais"
                        ErrorMessage="Debe ingresar el pais" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Ciudad</td>
                <td>
                    <asp:TextBox ID="txtCiudad" runat="server"
                        CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCiudad"
                        ErrorMessage="Debe ingresar una ciudad" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Telefono</td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server"
                        CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTelefono"
                        ErrorMessage="Debe ingresar un numero telefonico" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono"
                        ErrorMessage="Ingrese un número entero o en el formato '000-1234567'" Display="Dynamic"
                        ValidationExpression="^[\d()]{1,10}-\d{1,15}$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>
    <br />


    <%-- Datos del Camion --%>
    <h2>Datos del Camión</h2>
    <div>
        <table class="table table-borderless">
            <tr>
                <td>Tipo de carga</td>
                <td>
                    <asp:DropDownList ID="ddlTipoCarga" runat="server"
                        CssClass="form-select">
                        <asp:ListItem Text="Normal" Value="Normal" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Pesada" Value="Pesada"></asp:ListItem>
                    </asp:DropDownList>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTipoCarga"
                        ErrorMessage="Seleccione un tipo de carga" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Chasis</td>
                <td>
                    <asp:TextBox ID="txtChasis" runat="server"
                        CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtChasis"
                        ErrorMessage="Ingrese un tipo de chasis" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Recuento de engranajes</td>
                <td>
                    <asp:TextBox ID="txtRecuentoEngranajes" runat="server"
                        CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRecuentoEngranajes"
                        ErrorMessage="Ingrese el numero de engranajes de la caja de cambios" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecuentoEngranajes"
                        ErrorMessage="Debe ser un número entero" ValidationExpression="^\d+$" ForeColor="Orange"></asp:RegularExpressionValidator>
                </td>

            </tr>
            <tr>
                <td>Retardero</td>
                <td>
                    <asp:RadioButton ID="rbRetarderoSi" runat="server" GroupName="grupo1" Text="Si" Checked="true" CssClass="form-check-input" />
                    <asp:RadioButton ID="rbRetarderoNo" runat="server" GroupName="grupo1" Text="No" CssClass="form-check-input" />
                </td>
            </tr>
            <tr>
                <td>Ejes alimentados</td>
                <td>
                    <asp:TextBox ID="txtEjesAlimentados" runat="server"
                        CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEjesAlimentados"
                        ErrorMessage="Ingrese el numero de ejes alimentados" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecuentoEngranajes"
                        ErrorMessage="Debe ser un número entero" ValidationExpression="^\d+$" ForeColor="Orange"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Potencia del motor</td>
                <td>
                    <div style="display: flex; align-items: center;">
                        <asp:TextBox ID="txtPotencia" runat="server"
                            CssClass="form-control"></asp:TextBox>
                        <span style="margin-left: 5px;">Hp</span>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPotencia"
                        ErrorMessage="Ingrese el numero de potencia en HP" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecuentoEngranajes"
                        ErrorMessage="Debe ser un número entero" ValidationExpression="^\d+$" ForeColor="Orange"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Esfuerzo de torsión</td>
                <td>
                    <div style="display: flex; align-items: center;">
                        <asp:TextBox ID="txtTorque" runat="server"
                            CssClass="form-control custom-validation"></asp:TextBox>
                        <span style="margin-left: 5px;">Nm</span>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTorque"
                        ErrorMessage="Ingrese el numero de torque en NM" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtRecuentoEngranajes"
                        ErrorMessage="Debe ser un número entero" ValidationExpression="^\d+$" ForeColor="Orange"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>
    <br />

    <div class="form-group">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
            CssClass="btn btn-outline-primary" OnClick="btnGuardar_Click" />

    </div>
    <div class="form-group">
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl="~/Mantenimiento/Conductor.aspx">Atras</asp:HyperLink>
    </div>

</asp:Content>
