<%@ Page Title="" Language="C#" MasterPageFile="~/Defult.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="ChateauDuPet.UI.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    
    <main class="Centro container-xxl " style="margin: auto;"> 
         

         
                       

        <div class="row g-3" tabindex="-1" style=" margin:0 10px 0 10px">  <span class="mb-3">
                            <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="bi bi-person" viewBox="0 0 16 16">
                                <path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z" />
                            </svg>
                            Cadastro</span>
                        <br />
              <div class="col-md-4">
                        <label id="lblNome" class="form-label">Nome</label>
                        <asp:TextBox CssClass="form-control" ID="txtNome" runat="server" TabIndex="1" MaxLength="100" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNome" ErrorMessage="Campo Nome é obrigatório" ForeColor="red" />
                  </div>
              
              <div class="col-md-3">
                  
                        <label id="lbluser" class="form-label">Usuario</label>
                        <div class="input-group has-validation">
                            <span class="input-group-text">@</span>
                            <asp:TextBox runat="server" CssClass="form-control" Width="70%" ID="txtUser" MaxLength="15" TabIndex="2" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUser" ErrorMessage="Campo Usuario é obrigatório" ForeColor="red" />
                            </div>
            </div>           
            <div class="col-md-3">


                        <label for="username" class="form-label">Tipo de Usuario</label>
                        <div class="input-group has-validation "  >
                            <asp:DropDownList ID="DLLTipoUSer" Width="70%"   runat="server" CssClass="form-select" TabIndex="3">
                                                       <asp:ListItem Text="Selecione uma opção" /> 
                                <asp:ListItem Value="1" Text="Empresa" />
                                <asp:ListItem Value="2" Text="Profissional" />
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DLLTipoUSer" ErrorMessage="Campo Tipo Usuario é obrigatório" ForeColor="red" />
                        </div>
            </div>

  <div class=" col-md-2">
                        <label class="form-label">Data de Nascimento </label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtData" TextMode="Date" TabIndex="4" />
                        <asp:RequiredFieldValidator ID="rfvDataN" runat="server" ControlToValidate="txtData" ErrorMessage="Campo Data é obrigatório" ForeColor="red" />
                        <br />
            </div>
            
  <div class="col-md-2">
                        <label class="form-label">CPF</label>
                        <asp:TextBox runat="server" CssClass=" form-control  cpf" ID="txtCpf" MaxLength="11" TabIndex="5"   />
                        <asp:RequiredFieldValidator ID="rfvCpf" runat="server" ControlToValidate="txtCpf"  ErrorMessage="Campo CPF é obrigatório" ForeColor="red" />
                                       </div>
  <div class="col-md-2">
                        <label id="lblTelefone" class="form-label">Telefone </label>
                        <asp:TextBox runat="server" CssClass="form-control  " ID="txtTelefone" AutoCompleteType="Office"  TabIndex="6" MaxLength="11" />
                        <asp:RequiredFieldValidator ID="rfvTelefone" runat="server" ControlToValidate="txtTelefone" ErrorMessage="Campo Telefone é obrigatório" ForeColor="red" />
                                       </div>
            
 
  <div class="col-md-3">

                        <label for="username" class="form-label">Sexo</label>
                        <div class="input-group has-validation">
                            <asp:DropDownList ID="DDLSexo" runat="server" CssClass="form-select " TabIndex="7">
                                <asp:ListItem Text="Selecione uma opção" />
                                <asp:ListItem Value="Masculino" Text="Masculino" />
                                <asp:ListItem Value="Feminino" Text="Feminino" />
                            </asp:DropDownList>

                        </div>

  </div>     
                          <div class="col-md-4">
                        <label id="lblEmail" class="form-label">Email</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" TabIndex="8" MaxLength="100" TextMode="Email" />
                                               <asp:RequiredFieldValidator    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"  ErrorMessage="Campo Email é obrigatório" ForeColor="red" />

                        <asp:RegularExpressionValidator ID="gevEmailValido" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="O E-mail é inválido!" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            </div>
               <hr class="featurette-divider">
            <div class="col-md-3">

                        <label id="lblSenha" class="form-label">Senha *</label>
                        <asp:TextBox runat="server"  CssClass="form-control senha" ID="senha"       TabIndex="9"  TextMode="Password" />
                                         <span     id="SenhaRetorno"  ></span>    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="senha"  ErrorMessage="Campo Senha é obrigatório" ForeColor="red" />
  
                            </div> 
            <div class="col-md-3">  
                        <label id="lblSenhaa" class="form-label">Confirmar Senha *</label>
                        <asp:TextBox runat="server"   CssClass="form-control senhaC"  ID="senhaC" TabIndex="10" TextMode="Password" />
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="senhaC"  ErrorMessage="Campo Senha é obrigatório" ForeColor="red" />

                    </div>  
             <div class="col-md-4 ms-auto">

   <asp:Label runat="server" ID="lblMensagem"   CssClass="alert alert-danger col-md-4" Visible="False"/> 
       <asp:Label runat="server" ID="lblMensagemCadastrado"  CssClass="alert alert-success col-md-4" Visible="False"/>

       </div></div>
  <div class="col-12">
                        <div class="form-check">
                            <asp:CheckBox runat="server" ID="cbPolitica" TabIndex="11" />
                            <label class="form-check-label" id=""><a  data-bs-target="#modalTermos" class="link" data-bs-toggle="modal">Aceito</a> A política de privacidade.</label>
                            <br />
                            <asp:CheckBox runat="server" ID="cbTermos" TabIndex="12" />
                            <asp:Label runat="server" CssClass="form-check-label" ID="txtTermos"><a class="link" data-bs-target="#modalTermos" data-bs-toggle="modal" > Aceito</a>  os termos de uso. </asp:Label>
                            <br /> 
                        </div>
      
  <div class="col-12">
      
      <div class="col-md-4 ms-auto">
                            <br />
                            <br />
                            <asp:Button runat="server" ID="BtnCancelar" CssClass="btn" Width="100px" OnClick="BtnCancelar_Click"  TabIndex="15"  Text="Cancelar" />
                            <asp:Button runat="server" ID="BtnCadastrar" Width="100px" CssClass="btn  btn-primary"  TabIndex="14"  OnClick="BtnCadastrar_Click"  Text="Cadastrar" />
            </div></div>
            </div>
    </main>
</asp:Content>
