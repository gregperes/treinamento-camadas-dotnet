<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="GregTreinamentoCamadas.Web.Categorias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Gerenciamento de Categorias</h2>
        <asp:GridView ID="CategoriasGridView" runat="server" 
            onrowcommand="CategoriasGridView_RowCommand">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                            CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' Text="Editar"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" 
                            CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' Text="Excluir"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <hr />
        <fieldset>
            <legend>Categoria</legend>
            Id: <asp:TextBox ID="IdTextBox" runat="server" ReadOnly="true" 
                Width="109px"></asp:TextBox>
            <br />
            Nome: 
            <asp:TextBox ID="NomeTextBox" runat="server" Width="332px"></asp:TextBox>
            <br /><br />
            <asp:Button ID="SalvarButton" runat="server" Text="Salvar" 
                onclick="SalvarButton_Click" />
            <asp:Label ID="MensagemLabel" runat="server"></asp:Label>
        </fieldset>
    </div>
    </form>
</body>
</html>