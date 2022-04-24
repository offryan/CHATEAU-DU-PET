<%@ Page Title="" Language="C#" MasterPageFile="~/DefultProfissional.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="ChateauDuPet.UI.EditarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <main class="container-xxl "   data-bs-spy="scroll"   >
        <div class="row g-3" tabindex="-1" style="margin: 0 10px 0 10px">
            <div class="col-md-4">

        
            <asp:ImageButton OnClick="imagePro_Click" runat="server" ID="imagePro"   CssClass="bd-placeholder-img rounded-circle" Width="240" Height="240" />
                <asp:FileUpload runat="server"  CssClass="btn btn-outline-danger"  />

            </div>
        
            <div class="col-md-4">
                <label id="lblNome" class="form-label">Nome</label>
                <asp:TextBox CssClass="form-control" ID="txtNome" runat="server" TabIndex="1" MaxLength="100" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNome" ErrorMessage="Campo Nome é obrigatório" ForeColor="red" />
            </div>
        

            <div class="col-md-4">
                <label class="form-label">CPF</label>
                <asp:label runat="server" CssClass="form-control"  ID="lblCPF" TabIndex="5" />
            </div>
            <div class="col-md-3">

                <label id="lbluser" class="form-label">Usuario</label>
                <div class="input-group has-validation">
                    <span class="input-group-text">@</span>
                    <asp:TextBox runat="server" CssClass="form-control" Width="70%" ID="txtUser" MaxLength="15" TabIndex="2" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUser" ErrorMessage="Campo Usuario é obrigatório" ForeColor="red" />
                </div>
            </div>
            <div class="col-md-2">
                <label class="form-label">Data de Nascimento </label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtData" TextMode="Date" TabIndex="4" />
                <asp:RequiredFieldValidator ID="rfvDataN" runat="server" ControlToValidate="txtData" ErrorMessage="Campo Data é obrigatório" ForeColor="red" />
                
            </div>
             
            <div class="col-md-2">
                <label id="lblTelefone" class="form-label">Telefone </label>
                <asp:TextBox runat="server" CssClass="form-control  " ID="txtTelefone" AutoCompleteType="Office" TextMode="Phone" TabIndex="6" MaxLength="11" />
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo Email é obrigatório" ForeColor="red" />

                <asp:RegularExpressionValidator ID="gevEmailValido" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="O E-mail é inválido!" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            </div>
            <hr class="featurette-divider">
            <h2>Endereço</h2>
            <div class="col-md-3">

                <label id="lblrua" class="form-label">Rua</label>
                <asp:TextBox runat="server" Class="form-control" ID="txtRua" MaxLength="100" TabIndex="9" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRua" ErrorMessage="Campo Rua é obrigatório" ForeColor="red" />

            </div>
            <div class="col-md-2">
                <label id="lblNumero" class="form-label">Número</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNumero" MaxLength="5" TabIndex="10" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNumero" ErrorMessage="Campo Número é obrigatório" ForeColor="red" />

            </div> <div class="col-md-2">
                <label id="lblCEP" class="form-label">CEP</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCEP" MaxLength="10" TabIndex="10" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtCEP" ErrorMessage="Campo CEP é obrigatório" ForeColor="red" />

            </div>
            <div class="col-md-3">

                <label id="lblComplemento" class="form-label">Complemento</label>
                <asp:TextBox runat="server" Class="form-control" ID="txtComplemento" TabIndex="9" MaxLength="50" />

            </div>
            <div class="col-md-3">
                <label id="" class="form-label">Bairro</label>
                <asp:TextBox runat="server" CssClass="form-control"  TabIndex="10" ID="txtBairro" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBairro" ErrorMessage="Campo Bairro é obrigatório" ForeColor="red" />

            </div>
            <div class="col-md-3">

                <label id="lblCidade" class="form-label">Cidade</label>
                <asp:TextBox runat="server" Class="form-control" ID="txtCidade" TabIndex="9" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCidade" ErrorMessage="Campo Cidade é obrigatório" ForeColor="red" />

            </div>
            <div class="col-md-3">
                <label id="lblUF" class="form-label">UF</label>
       
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlEstado">
                    <asp:ListItem Value="RO" Text="RO" />
                    <asp:ListItem Value="AC" Text="AC" />
                    <asp:ListItem Value="AM" Text="AM" />
                    <asp:ListItem Value="RR" Text="RR" />
                    <asp:ListItem Value="PA" Text="PA" />
                    <asp:ListItem Value="AP" Text="AP" />
                    <asp:ListItem Value="TO" Text="TO" />
                    <asp:ListItem Value="MA" Text="MA" />
                    <asp:ListItem Value="PI" Text="PI" />
                    <asp:ListItem Value="CE" Text="CE" />
                    <asp:ListItem Value="RN" Text="RN" />
                    <asp:ListItem Value="PB" Text="PB" />
                    <asp:ListItem Value="PE" Text="PE" />
                    <asp:ListItem Value="AL" Text="AL" />
                    <asp:ListItem Value="SE" Text="SE" />
                    <asp:ListItem Value="BA" Text="BA" />
                    <asp:ListItem Value="MG" Text="MG" />
                    <asp:ListItem Value="ES" Text="ES" />
                    <asp:ListItem Value="RJ" Text="RJ" />
                    <asp:ListItem Value="SP" Text="SP" />
                    <asp:ListItem Value="PR" Text="PR" />
                    <asp:ListItem Value="SC" Text="SC" />
                    <asp:ListItem Value="RS" Text="RS" />
                    <asp:ListItem Value="MS" Text="MS" />
                    <asp:ListItem Value="MT" Text="MT" />
                    <asp:ListItem Value="GO" Text="GO" />
                    <asp:ListItem Value="DF" Text="DF" />
                </asp:DropDownList>

            </div>
            <div class="col-md-4 ms-auto">
            </div>

        <div class="col-md-4 ms-auto">

            <asp:Label runat="server" ID="Label1" class="alert alert-danger col-md-5" role="alert" Text="olá" Visible="True" />
            <asp:Label runat="server" ID="Label2" class="alert alert-success col-md-5" Text="olá" role="alert" Visible="True" />
        </div>
        <div class="col-12">

            <div class="col-md-4 ms-auto">
                <asp:Button runat="server" ID="btnCancelar" CssClass="btn  btn-outline-info" OnClick="BtnCancelar_Click" />
                <asp:Button runat="server" ID="BtnSalvar" CssClass="btn  btn-outline-secondary" OnClick="BtnSalvar_Click" />
                <br />
            </div>

        </div>
        <hr class="featurette-divider">

        <h2>Experiências</h2>
        <div class="row g-3" tabindex="-1" style="margin: 0 10px 0 10px">

            <div class="col-md-3">
                <label id="lblCargo" class="form-label">Cargo</label>
                <asp:TextBox runat="server" Class="form-control" ID="txtCargo" TabIndex="9" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCargo" ErrorMessage="Campo Cargo é obrigatório" ForeColor="red" />
            </div>

            <div class="col-md-3">
                <label id="lblEmpresa" class="form-label">Nome da Empresa</label>
                <asp:TextBox runat="server" CssClass="form-control" TabIndex="10" ID="txtEmpresa" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmpresa" ErrorMessage="Campo Nome da Empresa é obrigatório" ForeColor="red" />

            </div>
            <div class="col-md-3">
                <label id="lblLocalidade" class="form-label">Localidade</label>
                <asp:TextBox runat="server" CssClass="form-control" MaxLength="50" TabIndex="10" ID="txtLocalidade" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtLocalidade" ErrorMessage="Campo Local da Empresa é obrigatório" ForeColor="red" />

            </div>
            <div class=" col-md-2">
                <label class="form-label">Data de Inicial </label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDataInicio" TextMode="Date" TabIndex="4" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDataInicio" ErrorMessage="Campo Data inicial é obrigatório" ForeColor="red" />
                <br />
            </div>
            <div class=" col-md-2">
                <label class="form-label">Data Final</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDataFinal" TextMode="Date" TabIndex="4" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtDataFinal" ErrorMessage="Campo Data Final é obrigatório" ForeColor="red" />
                <br />
            </div>
            <div class="col-md-3">

                <label id="lblTipodeContrato" class="form-label">Tipo de Contratação</label>
                <asp:DropDownList runat="server" Class="form-select-sm" ID="ddlTipoCa" TabIndex="9">
                    <asp:ListItem Enabled="false" Selected="False" Text="Selecione uma opção"></asp:ListItem>
                    <asp:ListItem Text="CLT" Value="CLT"></asp:ListItem>
                    <asp:ListItem Text="Freelancer" Value="Freelancer"></asp:ListItem>
                    <asp:ListItem Text="Temporário" Value="Temporário"></asp:ListItem>
                    <asp:ListItem Text="PJ" Value="PJ"></asp:ListItem>

                </asp:DropDownList>

            </div>
            <div class="col-md-3">

                <label id="lblDescrição" class="form-label">Descrição</label>
                <asp:TextBox runat="server" Class="form-control" ID="txtDescricao" TabIndex="9" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescricao" ErrorMessage="Fale um pouco sobre o essa experiência" ForeColor="red" />

            </div>
        </div>
        <hr class="featurette-divider">

        <h2>Formação Profissional</h2>
        <div class="row g-3" tabindex="-1" style="margin: 0 10px 0 10px">

            <div class="col-md-3">
                <label id="lblCurso" class="form-label">Curso</label>
                <asp:TextBox runat="server" Class="form-control" ID="txtCurso" TabIndex="9" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtCurso" ErrorMessage="Campo Curso é obrigatório" ForeColor="red" />
            </div>

            <div class="col-md-3">
                <label id="lblInstituição" class="form-label">Instituição</label>
                <asp:TextBox runat="server" CssClass="form-control" TabIndex="10" ID="txtInstituiçao" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtInstituiçao" ErrorMessage="Campo Instituição Nome da Empresa é obrigatório" ForeColor="red" />

            </div>
            <div class=" col-md-2">
                <label class="form-label">Data de Inicial </label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TextBox5" TextMode="Month" TabIndex="4" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtDataInicio" ErrorMessage="Campo Data inicial é obrigatório" ForeColor="red" />
                <br />
            </div>
            <div class=" col-md-2">
                <label class="form-label">Data Final</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TextBox6" TextMode="Date" TabIndex="4" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtDataFinal" ErrorMessage="Campo Data Final é obrigatório" ForeColor="red" />
                <br />
            </div>
            <div class="col-md-3">

                <label id="lblDescricao" class="form-label">Descrição</label>
                <asp:TextBox runat="server" Class="form-control" ID="txtDescricaoCurso" TabIndex="9" TextMode="MultiLine" />

            </div>

        </div>
            </div>

    </main>
</asp:Content>
