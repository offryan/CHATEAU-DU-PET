<%@ Page Title="" Language="C#" MasterPageFile="~/DefultEmpresa.Master" AutoEventWireup="true" CodeBehind="MainEmpresa.aspx.cs" Inherits="ChateauDuPet.UI.MainEmpre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
      
        <div class="row">
            <hr class="featurette-divider">
    <asp:Repeater ID="rptVaga1" runat="server" >
        <ItemTemplate>
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <a runat="server" id="A1" href="Vagas.aspx" class="btn btn-primary"><%# DataBinder.Eval(Container.DataItem, "IdVaga")%>
                            <asp:Label runat="server" ID="txtVaga" CssClass="card-title"><%# DataBinder.Eval(Container.DataItem, "Vaga") %></asp:Label>
                            <asp:Label runat="server" ID="txtSobre" CssClass="card-text"><%# DataBinder.Eval(Container.DataItem, "Descricao") %></asp:Label>
                            <a runat="server" id="idvaga" href="Vagas.aspx" class="btn btn-primary"><%# DataBinder.Eval(Container.DataItem, "IdVaga")%>Ver mais</a></a>
                    </div>
                </div>
            </div>


        </ItemTemplate>
    </asp:Repeater>
     
    <asp:Repeater ID="rptPro" runat="server">
                <ItemTemplate>
      <div class="col-sm-6 col-md-4 col-xl-3 mb-3">
          <img src="<%# DataBinder.Eval(Container.DataItem, "UrlImage").ToString().Replace("~", ".") %>"  class="bd-placeholder-img rounded-circle" Width="140" Height="140" />
          <h3 class="h5 mb-1"><%# DataBinder.Eval(Container.DataItem, "Nome") %></h3>
       
        <p class="text-muted"><%# DataBinder.Eval(Container.DataItem, "Biografia") %></p>
          <a class="btn btn-primary"  href="Perfil-User.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdProfissional") %>">Ver mais</a>
      </div> 
            
                </ItemTemplate>
            </asp:Repeater>
    </div> 

      

</asp:Content>
