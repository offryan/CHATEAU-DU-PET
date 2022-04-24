<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChateauDuPet.SITE.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    
        <main>
            <div class="Centro container-xxl flex-start    " style=" align-self: flex-start; margin: auto;">
                <img src="Imagens/-1-Recuperado.png" style="max-width:250px ;max-height:250px; float:right ;" class="  d-none d-md-block" />


                <div class="row    " style="max-width:1300px ;max-height:810px;margin-right:10px;margin-left:10px">
                    <div class="col-md-6 mb-md-0  " style="padding:0;  max-width:200px ;max-height:810px;">
                        <img src="Imagens/Medica.png" style=" float:left; width:200px ;height:350px; " class=" d-none d-md-block " />
                    </div>
                    <div class="col-md-6 TxtMedica " style="align-self: flex-end;   max-width: 1400px; max-height: 400px; ">
                        <h3>"MAIS, QUE UM PET-SHOP"</h3>
                        <hr />
                        <p>
                            A Chateua du pet está com novos objetivos,
                            um dos quais é ajudar proficionais a estabelecerem contato com empresas do mercado Pet
                        </p>

                        <label class="menu">
                            <a href="/sobre.html">Nossa Missão</a>
                        </label> <br /><br />
                    </div>

                </div>
            </div>



            <!-- Faixa azul -->



            <div class="Faixa-Azul w3-container">
                <div class="Centro1 container-xxl " style=" margin:auto;max-height:100% ">
                    <div class="col-md-6  TextFaixaAzul" style="min-height:100%;  ">
                        <a class="menu">Profissional</a>
                        <br>
                        <p>
                            Estudantes ou profissionais que utilizam nossa plataforma podem visualizar empresas que buscam profissionais
                            em determinadas áreas, como<a>Médico Veterinário</a>,
                            <a> </a>
                            o que você está esperando ? Você pode ter uma empresa próxima que precise de pessoas como você,
                            <a>Faça parte do nosso time.</a>
                        </p>

                       

                    </div>

                    <div class=" d-none d-md-block " style="min-height: 300px; float: right;">
                        <img src="Imagens/undraw_emails_6uqr.svg" style="float:right;margin:20px 20px 20px 20px; max-width:270px; max-height:350px; " />
                    </div>

                </div>
            </div>

            <div class="container-xxl" style=" max-height:100%; margin:auto;">

                <div style="max-width:1300px;max-height:100%;">
                    <div id="Empresa" class="tabcontent">
                        <img src="Imagens/undraw_Walking_outside_re_56xo.svg" width="300" height="300" />
                        <h1>Profissionais</h1>
                        <p>
                            Milhares de profissionais do mercado p

                            et em um so lugar
                        </p>
                    </div>
                    <div id="Profissional" class="tabcontent">
                        <h1>Empresa</h1>
                        <p>Empresa is the capital of France.</p>
                    </div>
                    <button class="tablink" onclick="openCity('Empresa', this, ' ')" id="defaultOpen">Empresa</button>
                    <button class="tablink" onclick="openCity('Profissional', this, ' ')">Profissional</button>
                </div>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
