<%@ Page Title="" Language="C#" MasterPageFile="~/DefultProfissional.Master" AutoEventWireup="true" CodeBehind="Perfil-Profissional.aspx.cs" Inherits="ChateauDuPet.UI.MainProfissional.Perfil_Profissional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptPerfil"  runat="server">
        <ItemTemplate>
            <div class="row featurette">
                <div class="col-md-4">
                    <asp:Image runat="server"  ID="imagePro" class="  rounded-circle    border col-md-4 ms-4" Width="240" Height="240" />
                </div>
                <div class="col-md-8">
                    <div class="container">
                        <div class="row g-2">
                            <div class="col-md-10">
                                <div class="p-3  ">
                                    <label class="form-label">Nome Completo :</label>
                                    <asp:Label runat="server" CssClass="form-text col-md-10" ID="lblNome"><%# DataBinder.Eval(Container.DataItem, "Nome") %></asp:Label>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="p-3 ">
                                    <label class="form-label">Usuário :</label>
                                    <asp:Label runat="server" CssClass="form-text col-md-10" ID="lbluser"><%# DataBinder.Eval(Container.DataItem, "User") %></asp:Label>

                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="p-3">
                                    <label class="form-label">Formação Acadêmica :</label><br />
                                    <asp:Label ID="lblFormacaoEscolar" CssClass="form-text" runat="server"><%# DataBinder.Eval(Container.DataItem, "FormacaoEscolar") %></asp:Label>

                                </div>
                            </div>
                                <div class="p-3 col-md-6">
                                    <label class="form-label ">Data de Nascimento :</label>
                                    <asp:Label runat="server" ID="DataAniversario" CssClass="form-text" ><%# DataBinder.Eval(Container.DataItem, "Nascimento") %></asp:Label>
                                </div>
                                <div class="p-3 col-6">

                                    <label class="form-label">Sexo :</label>
                                    <asp:Label runat="server" ID="lblSexo" CssClass="form-text"  ><%# DataBinder.Eval(Container.DataItem, "Sexo") %></asp:Label>
                                </div>
                            <div class="col-md-10">
                                <div class="p-3 border">
                                    <label class="form-label">Biografia Acadêmica</label><br />
                                    <asp:Label ID="lblBiografiaPro" runat="server" CssClass=" col-form-label "><%# DataBinder.Eval(Container.DataItem, "Biografia") %></asp:Label>
                                </div>
                            </div> <div class="col-md-2 ms-auto g-2">
                                    <a runat="server"  CssClass="btn btn-outline-danger"   Visible="false" ID="btnEditar"  OnClick="btnEditar_Click"   href="EditarPerfil.aspx?id<%# DataBinder.Eval(Container.DataItem, "idProfissional") %>" Text="Atualizar" />
                            </div>
                                </div>
                        </div>
                    </div>



                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>

    <div class="accordion accordion-flush" id="Dados Para contato.">
         
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingOne">
                        <button class="accordion-button " type="button" data-bs-toggle="collapse" data-bs-target="#containerEndereco" 
                            aria-expanded="true" aria-controls="containerEndereco">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-geo" viewBox="0 0 16 16">
  <path fill-rule="evenodd" d="M8 1a3 3 0 1 0 0 6 3 3 0 0 0 0-6zM4 4a4 4 0 1 1 4.5 3.969V13.5a.5.5 0 0 1-1 0V7.97A4 4 0 0 1 4 3.999zm2.493 8.574a.5.5 0 0 1-.411.575c-.712.118-1.28.295-1.655.493a1.319 1.319 0 0 0-.37.265.301.301 0 0 0-.057.09V14l.002.008a.147.147 0 0 0 .016.033.617.617 0 0 0 .145.15c.165.13.435.27.813.395.751.25 1.82.414 3.024.414s2.273-.163 3.024-.414c.378-.126.648-.265.813-.395a.619.619 0 0 0 .146-.15.148.148 0 0 0 .015-.033L12 14v-.004a.301.301 0 0 0-.057-.09 1.318 1.318 0 0 0-.37-.264c-.376-.198-.943-.375-1.655-.493a.5.5 0 1 1 .164-.986c.77.127 1.452.328 1.957.594C12.5 13 13 13.4 13 14c0 .426-.26.752-.544.977-.29.228-.68.413-1.116.558-.878.293-2.059.465-3.34.465-1.281 0-2.462-.172-3.34-.465-.436-.145-.826-.33-1.116-.558C3.26 14.752 3 14.426 3 14c0-.599.5-1 .961-1.243.505-.266 1.187-.467 1.957-.594a.5.5 0 0 1 .575.411z"/>
</svg>  Endereço </button> </h2>

                    <div id="containerEndereco" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
                        <div class="accordion-body  row g-2">
                    <asp:Repeater ID="rptEndereco" runat="server">
            <ItemTemplate>        <div class="col-md-3">
                                <label class="form-label">Endereço</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblEndereco"><%# DataBinder.Eval(Container.DataItem, "Endereco") %></asp:Label>
                            </div>
                            <div class="col-2">
                                <label class="form-label">Número</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblNumero">
                                    <%# DataBinder.Eval(Container.DataItem, "NroEndereco") %></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <label class="form-label">CEP</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblCep"><%# DataBinder.Eval(Container.DataItem, "CEP") %></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <label class="form-label">Complemento</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblComplemento"><%# DataBinder.Eval(Container.DataItem, "Complemento") %></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <label class="form-label">Bairro</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblBairro"><%# DataBinder.Eval(Container.DataItem, "Bairro") %></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <label class="form-label">Cidade</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblCidade"><%# DataBinder.Eval(Container.DataItem, "Cidade") %></asp:Label>
                            </div>
                            <div class="col-2">
                                <label class="form-label">UF</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblUF"><%# DataBinder.Eval(Container.DataItem, "UF") %></asp:Label>
                            </div>
                
            </ItemTemplate>
        </asp:Repeater>
                        </div>

                    </div>
                </div>
         

        <div class="accordion-item">
            <h2 class="accordion-header" id="btnFormaçao">
                 <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#containerFormacao" 
                     aria-expanded="true" aria-controls="containerFormacao"> <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-bookmark-star" viewBox="0 0 16 16">
  <path d="M7.84 4.1a.178.178 0 0 1 .32 0l.634 1.285a.178.178 0 0 0 .134.098l1.42.206c.145.021.204.2.098.303L9.42 6.993a.178.178 0 0 0-.051.158l.242 1.414a.178.178 0 0 1-.258.187l-1.27-.668a.178.178 0 0 0-.165 0l-1.27.668a.178.178 0 0 1-.257-.187l.242-1.414a.178.178 0 0 0-.05-.158l-1.03-1.001a.178.178 0 0 1 .098-.303l1.42-.206a.178.178 0 0 0 .134-.098L7.84 4.1z"/>
  <path d="M2 2a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v13.5a.5.5 0 0 1-.777.416L8 13.101l-5.223 2.815A.5.5 0 0 1 2 15.5V2zm2-1a1 1 0 0 0-1 1v12.566l4.723-2.482a.5.5 0 0 1 .554 0L13 14.566V2a1 1 0 0 0-1-1H4z"/>
</svg>  Formação Profissional</button>
            </h2>
            <div id="containerFormacao" class="accordion-collapse show collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
                <div class="accordion-body row g-2">

                    <asp:Repeater ID="rptCurso" runat="server">
                        <ItemTemplate>
                            <div class="col-md-3">
                                <label class="form-label">Curso :</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblCurso"><%# DataBinder.Eval(Container.DataItem, "Curso ") %></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <label id="lblInstituição" class="form-label">Instituição :</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblInstituiçao"><%# DataBinder.Eval(Container.DataItem, "Instituicao") %></asp:Label>

                            </div>
                            <div class=" col-md-2">
                                <label class="form-label">Iniciou : </label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblDataInicial" TextMode="Month"><%# DataBinder.Eval(Container.DataItem, "DataInicio") %></asp:Label>
                                <br />
                            </div>
                            <div class=" col-md-2">
                                <label class="form-label">Conclusção : </label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblDataFinal"><%# DataBinder.Eval(Container.DataItem, "DataConclusao") %></asp:Label>
                                <br />
                            </div>
                            <div class=" col-md-12">

                                <label id="lblDescricao" class="form-label">Descrição</label>
                                <asp:Label runat="server" Class="form-text " ID="txtDescricaoCurso" TextMode="MultiLine"><%# DataBinder.Eval(Container.DataItem, "Descricao") %></asp:Label>

                            </div>
                                    <div class="col-md-2 ms-auto g-2">
                                    <a runat="server"  CssClass="btn btn-outline-danger"   Visible="false" ID="btnEditar"  OnClick="btnEditar_Click"   href="AddCertificados.aspx?id<%# DataBinder.Eval(Container.DataItem, "IdCertificado") %>" Text="Atualizar" />
                            </div>
    <hr class="featurette-divider">

                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
        </div>

        <div class="accordion-item">
            <h2 class="accordion-header" id="heading1">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#containerExperiencia" aria-expanded="true" aria-controls="containerExperiencia">
                      <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-bookmark-check-fill" viewBox="0 0 16 16">
  <path fill-rule="evenodd" d="M2 15.5V2a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v13.5a.5.5 0 0 1-.74.439L8 13.069l-5.26 2.87A.5.5 0 0 1 2 15.5zm8.854-9.646a.5.5 0 0 0-.708-.708L7.5 7.793 6.354 6.646a.5.5 0 1 0-.708.708l1.5 1.5a.5.5 0 0 0 .708 0l3-3z"/>
</svg>
                    Experiência Profissional
                </button>
            </h2>
            <div id="containerExperiencia" class="accordion-collapse show collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
                <div class="accordion-body row g-2">
                    <asp:Repeater ID="rptExperiencia" runat="server">
                        <ItemTemplate>
                            <div class="col-md-3">
                                <label class="form-label">Cargo</label>
                                <asp:Label runat="server" Class="form-text" ID="lblCargo"><%# DataBinder.Eval(Container.DataItem, "Cargo ") %></asp:Label>
                            </div>

                            <div class="col-md-3">
                                <label class="form-label">Nome da Empresa</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblEmpresa"><%# DataBinder.Eval(Container.DataItem, "Empresa ") %></asp:Label>

                            </div>
                            <div class="col-md-3">
                                <label class="form-label">Localidade</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblLocalidade"> <%# DataBinder.Eval(Container.DataItem, "Localidade ") %></asp:Label>

                            </div>
                            <div class=" col-md-2">
                                <label class="form-label">Data de Inicial </label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblDataInicio" TextMode="Date"><%# DataBinder.Eval(Container.DataItem, "DataInicio") %></asp:Label>
                                <br />
                            </div>
                            <div class=" col-md-2">
                                <label class="form-label">Data Final</label>
                                <asp:Label runat="server" CssClass=" form-text" ID="lblDataFinal" TextMode="Date"><%# DataBinder.Eval(Container.DataItem, "DataFinal") %></asp:Label>
                                <br />
                            </div>
                            <div class="col-md-3">

                                <label class="form-label">Tipo de Contratação</label>
                                <asp:Label runat="server" CssClass="form-text" ID="lblTipodeContrato"><%# DataBinder.Eval(Container.DataItem, "TipoContrato") %></asp:Label>

                            </div>
                            <div class="col-md-2 ms-auto g-2">
                                    <a runat="server"  CssClass="btn btn-outline-danger"   Visible="false" ID="btnEditar"  OnClick="btnEditar_Click"   href="EditarPerfil.aspx?id<%# DataBinder.Eval(Container.DataItem, "IdExperiencia") %>" Text="Atualizar" />
                            </div>
    <hr class="featurette-divider">

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>
