<%@ Page Title="" Language="C#" MasterPageFile="~/Defult.Master" AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="ChateauDuPet.UI.Sobre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
        <main class="Centro container-xxl " style="   margin: auto;">
                 
            <div class="row mb-2">
    <div class="col-md-6">
      <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
        
          
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
                    <img src="Imagens/1624082007356.jpg" alt="Img 2">
                    <img src="Imagens/1624081878901.jpg" alt="Img 3">
                    <img src="/Imagens/" alt="Img 4">
                </div>
                <nav class="slide-nav">
                    <div class="slide-thumb"></div>
                    <button class="slide-prev">Anterior</button>
                    <button class="slide-next">Próximo</button>
                </nav>
            </div>
      </div>
    </div>



    <div class="col-md-6">
      <div class="row g-0  rounded overflow-hidden flex-md-row mb-4  h-md-250 position-relative">
       
            <div class="CentroContato container-xxl" style="  width:90%; ">
                <svg xmlns="http://www.w3.org/2000/svg" width="35" height="35" fill="currentColor" class="bi bi-envelope" viewBox="0 0 16 16">
                    <path d="M0 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V4zm2-1a1 1 0 0 0-1 1v.217l7 4.2 7-4.2V4a1 1 0 0 0-1-1H2zm13 2.383-4.758 2.855L15 11.114v-5.73zm-.034 6.878L9.271 8.82 8 9.583 6.728 8.82l-5.694 3.44A1 1 0 0 0 2 13h12a1 1 0 0 0 .966-.739zM1 11.114l4.758-2.876L1 5.383v5.73z"></path>
                </svg>
                <span class="menu">
                    <a style="color:black;" id="#Contato">E-mail</a>

                </span>
                <hr />      <br />
                 
        <asp:Label runat="server" Text="Nome" AssociatedControlID="txtNome" CssClass="text-light lead" />
             <asp:TextBox runat="server" ID="txtNome" Width="90%" CssClass="text-light lead" />
                <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome" ErrorMessage="Campo Nome é obrigatório!" ForeColor="Yellow" />

        <br />
        <asp:Label runat="server" Text="E-mail" AssociatedControlId="txtEmail" CssClass="text-light lead" />
        <asp:TextBox ID="txtEmail" Cssclass="form-control" MaxLength="100" runat="server" Width="90%" />
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo E-mail é obrigatório" ForeColor="Yellow" />
        <asp:RegularExpressionValidator ID="gevEmailValido" runat="server" ControlToValidate="txtEmail" 
            ErrorMessage="O E-mail é inválido!" ForeColor="Yellow" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />

        <br />
        <asp:Label runat="server" Text="Telefone" AssociatedControlID="txtTelefone" CssClass="text-light lead" />
        <asp:TextBox ID="txtTelefone" Cssclass="form-control phone_with_ddd" MaxLength="20" runat="server" Width="90%" />
        <asp:RequiredFieldValidator ID="rfvTelefone" runat="server" ControlToValidate="txtTelefone" ErrorMessage="Campo Telefone é obrigatório" ForeColor="Yellow" />

        <br />
        <asp:Label runat="server" Text="Mensagem" AssociatedControlID="txtMensagem" CssClass="text-light lead" />
        <asp:TextBox ID="txtMensagem" CssClass="form-control" runat="server" Width="90%" Height="120px" TextMode="MultiLine" />
        <asp:RequiredFieldValidator ID="rfvMensagem" runat="server" ControlToValidate="txtMensagem" ErrorMessage="Campo Mensagem é obrigatório" ForeColor="Yellow" />

        <br /><br />
        <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" CssClass="Btn btn-secondary" OnClick="BtnEnviar_Click" />

        <br /><br />
        <asp:Label ID="lblMensagem" runat="server" CssClass="text-light lead" />
        <br /><br />
        <br /><br />
            </div>
    </div>
  </div>
  </div>
                 
            </main>

             
</asp:Content>
