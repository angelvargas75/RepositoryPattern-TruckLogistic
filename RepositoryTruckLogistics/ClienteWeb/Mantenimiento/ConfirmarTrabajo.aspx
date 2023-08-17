<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmarTrabajo.aspx.cs" Inherits="ClienteWeb.Mantenimiento.ConfirmarTrabajo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align-last:center">Confirmar los datos</h2>
    <br />
    <h4>Conductor</h4>
    <div>
        <table class="table table-success table-striped">
            <tr>
                <td>Nombre:</td>
                <td>
                    <asp:Label ID="lblConductorNombre" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Origen:</td>
                <td>
                    <asp:Label ID="lblConductorPais" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>
    <br />
    <br />

    <h4>Detalles del trabajo</h4>
    <div>
        <table class="table table-success table-striped">
            <tr>
                <td>Carga:</td>
                <td>
                    <asp:Label ID="lblCarga" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Ingresos del trabajo:</td>
                <td>
                    <asp:Label ID="lblIngresosTrabajo" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Destino:</td>
                <td>
                    <asp:Label ID="lblDestino" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Distancia:</td>
                <td>
                    <asp:Label ID="lblDistancia" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Peso:</td>
                <td>
                    <asp:Label ID="lblPeso" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Tiempo:</td>
                <td>
                    <asp:Label ID="lblTiempo" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>

    <br />


    <!-- Ventana modal del boton Confirmar -->
    <style>
        .modal {
            display: none;
            position: fixed;
            z-index: 1000;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            overflow: hidden;
            background-color: rgba(0, 0, 0, 0.6);
        }

        .modal-content {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: #fff;
            padding: 20px;
            border-radius: 4px;
        }

        .close {
            position: absolute;
            top: 10px;
            right: 10px;
            cursor: pointer;
        }

        /* Centra verticalmente la ventana modal */
        .modal.vertical-align .modal-dialog {
            display: flex;
            align-items: center;
            min-height: 100vh;
        }

            /* Centra horizontalmente la ventana modal */
            .modal.vertical-align .modal-dialog .modal-content {
                margin: auto;
            }

        /* Mueve el botón hacia abajo */
        .modal.custom-footer .modal-footer {
            margin-top: 20px;
        }
    </style>


    <button type="button" id="btnAbrirModal" class="btn btn-outline-success">Confirmar</button>

    <div class="modal vertical-align" id="miVentanaModal">
        <div class="modal-dialog modal-md">
            <div class="modal-content" id="miVentanaModalContent">
                <span class="close" onclick="modal.style.display = 'none'">&times;</span>
                <h4 style="padding-bottom: 15px;">¡Confirmación existosa!</h4>
                <p>Los datos del trabajo se guardaron correctamente.</p>
                <div class="modal-footer customer-footer">
                    <hr style="margin-top: 10px; border-top: 1px solid #d1d1d1;">
                    <a href="Conductor.aspx" class="btn btn-secondary">Cerrar</a>
                </div>
            </div>
        </div>
    </div>


    <script>
        // Obtiene referencias a los elementos del DOM
        const btnAbrirModal = document.getElementById('btnAbrirModal');
        const modal = document.getElementById('miVentanaModal');
        const modalContent = document.getElementById('miVentanaModalContent');

        // Asigna un evento al botón para abrir el modal
        btnAbrirModal.addEventListener('click', () => {
            modal.style.display = 'block';
        });

        // Asigna un evento al botón para cerrar el modal
        modal.addEventListener('click', (event) => {
            if (event.target === modal) {
                modal.style.display = 'none';
            }
        });
    </script>


    <div class="form-group" style="padding-top: 20px;">
        <asp:HyperLink runat="server" NavigateUrl="~/Mantenimiento/Conductor.aspx">Cancelar</asp:HyperLink>
    </div>
</asp:Content>
