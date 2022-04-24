<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChateauDuPet.UI.Login" %>

<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml">
    
    <head runat="server">
        <meta http-equiv="Content-Type" 
    content="text/html; charset=utf-8"/>
        <!-- Incluidos-->
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <link href="Imagens/pp.png" rel="icon" />
        <link href="Scripts/Login.css" rel="stylesheet" />
         
    <title>Login</title>
        <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style>

    
    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet"/>
</head>

<body class=" text-center">
        <form id="form1" runat="server"  >
        <div class="container-fluid" >    
            
    
             

            
<main id="" class=" container  " tabindex="-1" style="width:500px;"><br />
     <asp:Image runat="server"   Cssclass="mb-4 " ImageUrl="/Imagens/pp.png"  width="200" height="200"/>
  <div class="form-floating">
   
        <asp:Label runat="server" Text="Email"  />
        <asp:TextBox ID="txtEmail" runat="server"  CssClass="form-control " TabIndex="1"  MaxLength="100"  TextMode="Email" />
        <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail"   runat="server" ErrorMessage="Campo Email é obrigatório!" ForeColor="red" TabIndex="1"/>
        <br />
        <asp:Label runat="server" Text="Senha" />
        <asp:TextBox ID="txtSenha" runat="server"   CssClass="form-control " MaxLength="15" TabIndex="2" TextMode="Password"/>
        <asp:RequiredFieldValidator ID="RfvSenha" ControlToValidate="txtSenha"  runat="server" ErrorMessage="Campo Senha é obrigatório!" ForeColor="red"/>
        <br />
        <asp:DropDownList ID="DDLList" runat="server" CssClass="form-select  "  TabIndex="3">
            <asp:ListItem    Value="Administrativo" Text="Selecione uma opção" />
            <asp:ListItem    Value="Empresa" Text="Empresa" />
            <asp:ListItem    Value="Profissional" Text="Profissional" />
        </asp:DropDownList>
        <asp:Label ID="lblMensagem" runat="server"  CssClass="" ForeColor="red" />
        
      <br />
    <asp:RequiredFieldValidator runat="server" id="Validacao" Cssclass="Card" ControlToValidate="DDLList"/>

      <br /><br />
    <asp:Button ID="btnEntrar" runat="server" TabIndex="3" Text="Entrar" CssClass=" btn btn-lg btn-primary " OnClick="BtnEntrar_Click" />
    <p class="mt-5 mb-3 text-muted">&copy; 2020 - 2021 @CHATEAUDUPET</p>    <a  runat="server" href="Cadastro.aspx"  class="mt-5 mb-3 link-danger" > Cadastre-se!</a>
     </div>
         
        </main>
       <footer class="container">
           
       </footer>
 </div>  

        <script src="Scripts/jquery-3.6.0.min.js"></script>
 </form>                                                                                                                                                                                                                                                                                               </body>
</html>  
