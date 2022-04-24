<%@ Page Title="" Language="C#" MasterPageFile="~/DefultEmpresa.Master" AutoEventWireup="true" CodeBehind="Criar-Vagas.aspx.cs" Inherits="ChateauDuPet.UI.Criar_Vagas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="row g-3" tabindex="-1" style=" margin:0 10px 0 10px">
            <span class="mb-3">
                         <svg xmlns="http://www.w3.org/2000/svg" width="25" height="25" fill="currentColor" class="bi bi-columns-gap" viewBox="0 0 16 16">
  <path d="M6 1v3H1V1h5zM1 0a1 1 0 0 0-1 1v3a1 1 0 0 0 1 1h5a1 1 0 0 0 1-1V1a1 1 0 0 0-1-1H1zm14 12v3h-5v-3h5zm-5-1a1 1 0 0 0-1 1v3a1 1 0 0 0 1 1h5a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-5zM6 8v7H1V8h5zM1 7a1 1 0 0 0-1 1v7a1 1 0 0 0 1 1h5a1 1 0 0 0 1-1V8a1 1 0 0 0-1-1H1zm14-6v7h-5V1h5zm-5-1a1 1 0 0 0-1 1v7a1 1 0 0 0 1 1h5a1 1 0 0 0 1-1V1a1 1 0 0 0-1-1h-5z"/>
</svg>
                            Vagas</span>
                        <br />
              <div class="col-md-4">
                        <label id="lblTitulo" class="form-label">Título</label>
                        <asp:TextBox CssClass="form-control" ID="txtTitulo" runat="server" TabIndex="1" MaxLength="100" />
                        <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Campo Título é obrigatório" ForeColor="red" />
                  </div>
              
                  
            <div class="col-md-3">


                        <label for="username" class="form-label">Nível de Experiência</label>
                        <div class="input-group has-validation">
                            <asp:DropDownList ID="DLLExperiencia"  Width="70%"   runat="server" CssClass="form-select" TabIndex="2">
                                <asp:ListItem Value="Até 1 ano" Text="Até 1 Ano"/>
                                <asp:ListItem Value="De 1 a 2 Anos" Text="De 1 a 2 Anos"/>
                                <asp:ListItem Value="De 3 a 4 Anos" Text="De 3 a 4 Anos" />
                                <asp:ListItem Value="Mais de 5 Anos" Text="Mais de 5 Anos" />
                            </asp:DropDownList>

                        </div>
            </div>

  <div class=" col-md-2">
                        <label class="form-label">Tipo de Registro</label>   <div class="input-group has-validation "  >
                            <asp:DropDownList ID="ddl"  Width="70%"   runat="server" CssClass="form-select" TabIndex="3">
                                <asp:ListItem Value="CLT" Text="CLT"/>
                                <asp:ListItem Value="Freelancer" Text="Freelancer" />
                                <asp:ListItem Value="Temporário" Text="Temporário" />
                                <asp:ListItem Value="PJ" Text="PJ" />
                            </asp:DropDownList>
                        <br />
            </div>
            </div>
  <div class=" col-md-2">
                        <label class="form-label">Sexo</label>   <div class="input-group has-validation "  >
                            <asp:DropDownList ID="DllSexo"  Width="70%"   runat="server" CssClass="form-select" TabIndex="4">
                                <asp:ListItem Value="Indiferente" Text="Indiferente" />
                                <asp:ListItem Value="Masculino" Text="Masculino"/>
                                <asp:ListItem Value="Feminino" Text="Feminino" />
                            </asp:DropDownList>
                        <br />
            </div>
            </div>
  <div class=" col-md-2">
                        <asp:label runat="server" ID="lblValidade" class="form-label">Tempo disponivel</asp:label> 
      <div class="input-group has-validation "  >
                            <asp:DropDownList ID="DllValidade"  Width="70%"   runat="server"  CssClass="form-select" TabIndex="5">
                                <asp:ListItem Value="7 Dias" Text="7 Dias"/>
                                <asp:ListItem Value="15 Dias" Text="15 Dias" />
                                <asp:ListItem Value="30 Dias" Text="30 Dias" />
                            </asp:DropDownList>
                        <br />
            </div>
            </div>
            
  <div class="col-md-2">
                        <label class="form-label">Descrição</label>
                        <asp:TextBox runat="server" CssClass=" form-control"   ID="txtDescricao" MaxLength="11" TabIndex="6"  />
                        <asp:RequiredFieldValidator ID="rfvDescrição" runat="server" ControlToValidate="txtDescricao"  ErrorMessage="Fale mais um pouco sobre a vaga." ForeColor="red" />
                                       </div>

  
                  
  <div class="col-12">
      
      <div class="col-md-4 ms-auto">
                            <asp:Label runat="server" ID="lblMensagem" ForeColor="Red" />
                            <br />
                            <br />
                            <asp:Button runat="server" ID="BtnCancelar" CssClass="btn" Width="100px" OnClick="BtnCancelar_Click"  TabIndex="8"  Text="Cancelar" />
                            <asp:Button runat="server" ID="BtnCadastrar" Width="100px" CssClass="btn  btn-primary"  TabIndex="7"  OnClick="BtnCadastrar_Click"  Text="Cadastrar" />
            </div>

  </div>
            </div>
</asp:Content>
