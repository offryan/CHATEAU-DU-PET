<%@ Page Title="" Language="C#" MasterPageFile="~/DefultADM.Master" AutoEventWireup="true" CodeBehind="ListProfissional.aspx.cs" Inherits="ChateauDuPet.UI.ListProfissional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:GridView runat="server" ID="gv2" AutoGenerateColumns="false" ShowFooter="true"  DataKeyNames="IdProfissional"  OnRowCommand="gv2_RowCommand" OnRowEditing="gv2_RowEditing"
        OnRowCancelingEdit="gv2_RowCancel ingEdit" OnRowUpdating="gv2_RowUpdating" 
         OnRowDeleting="gv2_RowDeleting"  AllowSorting="true" AllowPaging="true"  PageSize="5" OnPageIndexChanging="gv2_PageIndexChanging"
         CssClass=" table table-striped table-sm table-responsive"> 
 
        <Columns>
            <asp:TemplateField HeaderText="ID Profissional" HeaderStyle-CssClass="form-text">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIDProfissional" Text='<%#Eval("IdProfissional") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtIDProfissional" CssClass="form-text" runat="server" MaxLength="50" Text='<%#Eval("IdProfissional") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtIDProfissionalFooter" CssClass="form-text" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <asp:Label runat="server"  ID="lblNomeProfissional" Text='<%#Eval("Nome") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNomeProfissional" runat="server" MaxLength="100" Text='<%#Eval("Nome") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNomeProfissonalFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblEmailProfissional" Text='<%#Eval("Email") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmailProfissional" runat="server" MaxLength="100" Text='<%#Eval("Email") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtEmailProfissionalFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <%--Imagem--%>
            <asp:TemplateField HeaderText="Imagem">
                <ItemTemplate>
                    <asp:Image ImageUrl='<%#Eval("UrlImage")%>' Width="100" Height="100" runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fUp1" runat="server" Text="Selecione a Imagem" CssClass="btn btn-danger" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload ID="fUp1" runat="server" Text="Selecione a Imagem"  />
                </FooterTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>


            <%--Usuario--%>
            <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("User") %>' />
                </ItemTemplate>
                <EditItemTemplate>
<asp:TextBox runat="server" ID="txtUser" CssClass="form-text"  Text='<%#Eval("User") %>' ></asp:TextBox>               
                    </EditItemTemplate>
                <FooterTemplate>
<asp:TextBox runat="server" ID="txtUserFooter" CssClass="form-text" ></asp:TextBox>               

                </FooterTemplate>
            </asp:TemplateField>

            <%--Botoes--%>
            <asp:TemplateField HeaderText="Opções">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Imagens/icones/cursor.svg" CommandName="Perfil" ToolTip="Perfil" ID="ImagePerfil" Width="30" Height="30" runat="server" />

                    <%--Editar--%>
                    <asp:ImageButton ImageUrl="~/Images/edit.png" CommandName="Edit" ToolTip="Editar" ID="btnEditar" Width="30" Height="30" runat="server" />
                    <%--Excluir--%>
                    <asp:ImageButton ImageUrl="~/Images/delete.png" CommandName="Delete" ToolTip="Excluir" ID="btnExcluir" Width="30" Height="30" runat="server" OnClientClick="if ( !confirm('Deseja realmente eliminar este registro ?? ')) return false" />
                </ItemTemplate>
                <EditItemTemplate>
                    <%--Salvar--%>
                    <asp:ImageButton ImageUrl="~/Images/save.png" CommandName="Update" ToolTip="Salvar" ID="btnSalvar" Width="30" Height="30" runat="server" />
                    <%--Cancelar--%>
                    <asp:ImageButton ImageUrl="~/Images/cancel.png" CommandName="Cancel" ToolTip="Cancelar" ID="btnCancelar" Width="30" Height="30" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <%--Cadastrar--%>
                    <asp:ImageButton ImageUrl="~/Images/add.png" CommandName="Adicionar" ID="btnAdicionar" Width="30" Height="30" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="table-responsive">
        <table class="table table-striped table-sm">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Header</th>
                    <th scope="col">Header</th>
                    <th scope="col">Header</th>
                    <th scope="col">Header</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptListPro" runat="server">
                    <ItemTemplate>
                        <tr>
                            
                            <td>
                                <asp:Label runat="server"><%# DataBinder.Eval(Container.DataItem, "idprofissional") %></asp:Label>
                            </td>
                            <td>
                                <asp:Label  runat="server"><%# DataBinder.Eval(Container.DataItem, "Nome") %> </asp:Label>

                            </td>
                            <td>
                                <asp:Label runat="server" ><%# DataBinder.Eval(Container.DataItem, "Email") %></asp:Label>

                            </td>
                            <td>
                                <asp:Label runat="server" ><%# DataBinder.Eval(Container.DataItem, "User") %></asp:Label>
                            </td>
                            <td>
                               <asp:ImageButton ImageUrl="~/Imagens/icones/geo-alt.svg" runat="server"  />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </div>

    <br />
    <asp:Label ID="lblMessage" runat="server" Text="Label" />
</asp:Content>
