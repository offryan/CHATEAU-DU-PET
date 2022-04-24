<%@ Page Title="" Language="C#" MasterPageFile="~/DefultADM.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ChateauDuPet.UI.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <br />

<div class="px-4 pt-5 my-5 text-center border-bottom">
    <h1 class="display-4 fw-bold">Cadastrado Concluído</h1>
    <div class="col-lg-6 mx-auto">
      <div class="d-grid gap-2 d-sm-flex justify-content-sm-center mb-5">
        <a  href="Login.aspx" class="btn  btn-outline-success  btn-lg px-4 me-sm-3">Login</a>
        <a  href="Index.aspx" class="btn btn-outline-secondary btn-lg px-4">Home</a>
      </div>
    </div>
    <div class="overflow-hidden" style="max-height: 30vh;">
      <div class="container px-5">
        <asp:Image runat="server" ImageUrl="~/Imagens/undraw_People_search_re_5rre.svg" class="img-fluid border rounded-3 shadow-lg mb-4" alt="Example image" width="700" height="500" loading="lazy"/>
      </div>
    </div>
  </div>



</asp:Content>
