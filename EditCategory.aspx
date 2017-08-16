<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="TestGridBinding.EditCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1> Edit </h1>
        <table> 
            <tr>
                <td>
                    CategoryName :
                </td>
                <td>
                    <asp:TextBox ID="txt_Category" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"></asp:Button>
                </td>                  
            </tr>
        </table>
    

    </div>
    </form>
</body>
</html>
