<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="TestGridBinding.Category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        List Of Categories:<br />
        <br />
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
            <headerTemplate>
                <table width="100%">
                    <tr>
                        <td align="left" width="5%">Sno</td>                       
                        <td align="left"  width="10%">CategoryName</td>    
                        <td align="left"  width="10%"></td>
                        <td align="left" width="10%"></td>                    
                    </tr>
                </table>
            </headerTemplate>
            <ItemTemplate>
                <table width="100%">
                    <tr>
                        <td width="5%%" align="left"> <%# DataBinder.Eval( Container.DataItem , "Sno" )%></td>
             
                        <td width="10%" align="left"><%# DataBinder.Eval( Container.DataItem , "CategoryName" )%></td>   
                        <td width="10%" align="left">
                        <td width="10%" align="left"><asp:HyperLink ID="hlEdit" ForeColor="blue" runat="server" Text="Edit" ToolTip="Click here to edit service"> </asp:HyperLink></td>   
                        <td width="10%" align="left"><asp:Linkbutton ID="lnkdelete" CommandName="Delete" ForeColor="blue" runat="server" Text="Delete"  ToolTip="Click here to delete service"> </asp:Linkbutton></td>                     
                       
                        <td style="display: none">
                            <asp:Label ID="lblCategoryID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryId")%>'></asp:Label>
                        </td>
                  </tr>
                </table>

            </ItemTemplate>
            <FooterTemplate></FooterTemplate>

        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
