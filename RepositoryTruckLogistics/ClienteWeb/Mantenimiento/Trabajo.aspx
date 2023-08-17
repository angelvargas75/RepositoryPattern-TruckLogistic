<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Trabajo.aspx.cs" Inherits="ClienteWeb.Mantenimiento.Trabajo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        html,
        body {
            position: relative;
            height: 100%;
            padding: 0;
            margin: 0;
        }

        body {
            background: #eee;
            font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
            font-size: 14px;
            color: #000;
        }

        .swiper {
            width: calc(100% - 120px); /* Resta 60px de padding a cada lado */
            height: 100%;
            margin: 0 auto; /* Centra horizontalmente */
            padding: 0 60px; /* Agrega 60px de padding a cada lado */
            box-sizing: border-box;
        }

        .swiper-slide {
            text-align: center;
            font-size: 18px;
            background: #fff;
            display: flex;
            flex-direction: column; 
            align-items: center;
        }
        .swiper-pagination {
            position: relative;
            margin-top: -545px; 
            text-align: center;
        }


        .swiper-slide img {
            display: block;
            width: 70%;
            height: 70%;
            object-fit: cover;
            padding-top: 30px;
            max-height: 100%;
        }

        .slide-content {
            margin-top: 20px; /* Ajusta el margen superior de la tabla */
        }

            .slide-content table {
                margin-top: 20px;
            }

        #swiperContainer {
            height: 97vh; /* Ajusta la altura del carrusel */
        }
    </style>

    
    <asp:HiddenField ID="hdnIDConductor" runat="server" />

    
    <h2 style="text-align-last:center; padding-top:80px;">Asignar trabajo</h2>
    <br />

    <div class="input-group mb-3">
        <input id="txtFiltroNombre" type="text" runat="server" class="form-control" placeholder="Nombre del conductor" aria-label="Recipient's username" aria-describedby="button-addon2">
        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-outline-secondary" Text="Buscar" OnClick="btnBuscar_Click" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFiltroNombre"
                        ErrorMessage="Debe asignar un conductor" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div style="padding-top: 10px; padding-bottom:20px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label runat="server" Text="Nombre:" Style="padding-right: 10px; font-weight: bold;"></asp:Label>
                    <asp:Label ID="lblNombre" runat="server"></asp:Label></td>
                </div>
                <div>
                    <asp:Label runat="server" Text="Origen:" Style="padding-right: 21px; font-weight: bold;"></asp:Label>
                    <asp:Label ID="lblOrigen" runat="server"></asp:Label></td>
                </div>
            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>



    <!-- Carousel Swiper -->
    <div id="swiperContainer" class="swiper mySwiper" style="padding-top: 20px; padding-bottom: 20px;">
        <div class="swiper-wrapper">
            <asp:ListView runat="server" ID="carouselListView" OnSelectedIndexChanging="carouselListView_SelectedIndexChanging" OnItemCreated="carouselListView_ItemCreated">
                <ItemTemplate>
                    <div class="swiper-slide">
                        <!-- Contenido de cada diapositiva -->
                        <img src='<%# Eval("Imagen") %>' alt="" width="300" height="150">
                        <div class="slide-content">
                            <table class="table table-secondary" style="text-align: center; font-weight: bold; font-style: italic; margin: 5px">
                                <tbody>
                                    <tr>
                                        <td><%# Eval("Carga") %></td>
                                        <td></td>
                                        <td></td>
                                        <td style="font-size: 20px"><%# "€ " + Eval("IngresosDeTrabajo") %></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center;"><%# Eval("Destino") %></td>
                                    </tr>
                                    <tr>
                                        <td>Peso</td>
                                        <td><%# Eval("Peso") + " t" %></td>
                                        <td>Tiempo</td>
                                        <td><%# Eval("Tiempo") %></td>
                                    </tr>
                                </tbody>
                                <div>
                                    <asp:LinkButton runat="server" ID="btnSeleccionar" Text="Seleccionar"
                                        CommandName="Select" CommandArgument='<%# Eval("Id") %>'
                                        OnClick="btnSeleccionar_Click"></asp:LinkButton>
                                </div>
                            </table>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <div class="swiper-pagination"></div>
        <div id="btnNext" runat="server" class="swiper-button-next"></div>
        <div id="btnPrev" runat="server" class="swiper-button-prev"></div>

    </div>

    <script>
        var swiper = new Swiper(".swiper", {
            slidesPerView: 1,
            spaceBetween: 30,
            loop: true,
            pagination: {
                el: ".swiper-pagination",
                type: "fraction",
            },
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
        });
    </script>

</asp:Content>
