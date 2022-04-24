<%@ Page Title="" Language="C#" MasterPageFile="~/DefultProfissional.Master" AutoEventWireup="true" CodeBehind="VagaProfissional.aspx.cs" Inherits="ChateauDuPet.UI.MainProfissional.VagaProfissional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cone-striped" viewBox="0 0 16 16">
  <path d="m9.97 4.88.953 3.811C10.159 8.878 9.14 9 8 9c-1.14 0-2.158-.122-2.923-.309L6.03 4.88C6.635 4.957 7.3 5 8 5s1.365-.043 1.97-.12zm-.245-.978L8.97.88C8.718-.13 7.282-.13 7.03.88L6.275 3.9C6.8 3.965 7.382 4 8 4c.618 0 1.2-.036 1.725-.098zm4.396 8.613a.5.5 0 0 1 .037.96l-6 2a.5.5 0 0 1-.316 0l-6-2a.5.5 0 0 1 .037-.96l2.391-.598.565-2.257c.862.212 1.964.339 3.165.339s2.303-.127 3.165-.339l.565 2.257 2.391.598z"/>
</svg>


    <div class="card-columns">

            <asp:Repeater ID="rptAlbuns" runat="server">
                <ItemTemplate>

                    <div class="card" style="width: 18rem;">
                        <a href="Vaga.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Id") %>">
                            <img class="card-img-top" src="<%# DataBinder.Eval(Container.DataItem, "UrlImagemAlbum").ToString().Replace("~", ".") %>" alt="Card image cap">
                        </a>
                        <div class="card-body">
                            <a href="Album.aspx?id=<%# DataBinder.Eval(Container.DataItem, "IdAlbum") %>">
                                <h5 class="card-title"><%# DataBinder.Eval(Container.DataItem, "NomeAlbum") %></h5>
                            </a>
                            <p class="card-text">
                                <%# DataBinder.Eval(Container.DataItem, "ArtistaAlbum") %>  
                                -  <%# DataBinder.Eval(Container.DataItem, "SeloAlbum") %>
                            </p>
                            <span class="badge badge-info"><%# DataBinder.Eval(Container.DataItem, "DescricaoGenero") %></span>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>


        </div>

    
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    
    <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
        <div class="col p-4 d-flex flex-column position-static">
          <strong class="d-inline-block mb-2 text-primary"><%# DataBinder.Eval(Container.DataItem, "NmVaga") %></strong>
          <h3 class="mb-0"><%# DataBinder.Eval(Container.DataItem, "Id") %></h3>
          <div class="mb-1 text-muted"><%# DataBinder.Eval(Container.DataItem, "") %> </div>
          <p class="card-text mb-auto"><%# DataBinder.Eval(Container.DataItem, "Descricao") %></p>
          <a href="VagaProfissional.aspx" class="stretched-link">ver mais</a>
        </div>
        <div class="col-auto d-none d-lg-block">
        <%# DataBinder.Eval(Container.DataItem, "Validade") %> </div>
        </div>
      </div>
                </ItemTemplate>
            </asp:Repeater>

</asp:Content>
