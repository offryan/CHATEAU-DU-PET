<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="ChateauDuPet.SITE.Sobre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <main>
            <div class="Centro container-xxl " style="   margin: auto;">


            </div>
            <br />
            <div id="carouselExampleIndicators" class="carousel slide " data-bs-ride="carousel">

                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <div class="Roleta">

                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="Roleta">

                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="Roleta">
                        </div>
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>



            <div data-slide="slide" class="slide">
                <div class="slide-items">
                    <div class="Roleta">
                    </div>
                    <img src="./Imagens/undraw_Social_networking_re_i1ex.png" alt="Img 2">
                    <img src="./Imagens/undraw_Social2_networking_re_i1ex.png" alt="Img 3">
                    <img src="./Imagens/undraw_Social1_networking_re_i1ex.png" alt="Img 4">
                </div>
                <nav class="slide-nav">
                    <div class="slide-thumb"></div>
                    <button class="slide-prev">Anterior</button>
                    <button class="slide-next">Próximo</button>
                </nav>
            </div>

            <div class="CentroContato container-xxl" style="  margin:auto;">
                <svg xmlns="http://www.w3.org/2000/svg" width="35" height="35" fill="currentColor" class="bi bi-envelope" viewBox="0 0 16 16">
                    <path d="M0 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V4zm2-1a1 1 0 0 0-1 1v.217l7 4.2 7-4.2V4a1 1 0 0 0-1-1H2zm13 2.383-4.758 2.855L15 11.114v-5.73zm-.034 6.878L9.271 8.82 8 9.583 6.728 8.82l-5.694 3.44A1 1 0 0 0 2 13h12a1 1 0 0 0 .966-.739zM1 11.114l4.758-2.876L1 5.383v5.73z"></path>
                </svg>
                <label class="menu">
                    <a style="color:black;" id="#Contato">E-mail</a>

                </label>
                <hr />
                <div class="input-group mb-3">
                    <label>Name</label>
                    <input class="w3-input" type="text" name="Nome" required>
                </div>

                <div class="input-group mb-3">
                    <label>Email:</label>
                    <input class="w3-input" type="text" name="Email" required>

                </div>

                <div class="input-group mb-3">
                    <label>Telefone:</label>
                    <input class="w3-input" type="number" name="Name" required>
                </div>
                <div class="input-group mb-3">
                    <label>Asunto</label>
                    <input class="w3-input" type="text" name="Messagem" required>
                </div>
                <div class="input-group mb-3">
                    <label>Messagem</label>
                    <input class="w3-input" type="text" name="Messagem" style="height:150px;" required>
                </div>

                <button type="submit" class="btn btn-dark" id="Mensagem">Enviar</button>


            </div>







            <div class="custom-shape-divider-bottom-1618516495">
                <svg data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1200 120" preserveAspectRatio="none">
                    <path d="M0,0V46.29c47.79,22.2,103.59,32.17,158,28,70.36-5.37,136.33-33.31,206.8-37.5C438.64,32.43,512.34,53.67,583,72.05c69.27,18,138.3,24.88,209.4,13.08,36.15-6,69.85-17.84,104.45-29.34C989.49,25,1113-14.29,1200,52.47V0Z" opacity=".25" class="shape-fill"></path>
                    <path d="M0,0V15.81C13,36.92,27.64,56.86,47.69,72.05,99.41,111.27,165,111,224.58,91.58c31.15-10.15,60.09-26.07,89.67-39.8,40.92-19,84.73-46,130.83-49.67,36.26-2.85,70.9,9.42,98.6,31.56,31.77,25.39,62.32,62,103.63,73,40.44,10.79,81.35-6.69,119.13-24.28s75.16-39,116.92-43.05c59.73-5.85,113.28,22.88,168.9,38.84,30.2,8.66,59,6.17,87.09-7.5,22.43-10.89,48-26.93,60.65-49.24V0Z" opacity=".5" class="shape-fill"></path>
                    <path d="M0,0V5.63C149.93,59,314.09,71.32,475.83,42.57c43-7.64,84.23-20.12,127.61-26.46,59-8.63,112.48,12.24,165.56,35.4C827.93,77.22,886,95.24,951.2,90c86.53-7,172.46-45.71,248.8-84.81V0Z" class="shape-fill"></path>
                </svg>
            </div>
        </main>
</asp:Content>
