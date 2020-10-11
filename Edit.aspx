<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebInserteEdit.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <div>
        <asp:GridView ID="gvUserRegistration" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="EditDb"
             showHeaderWhenEmpty="true"
            OnRowCommand="gvUserRegistration_RowCommand" OnRowEditing="gvUserRegistration_RowEditing" OnRowCancelingEdit="gvUserRegistration_RowCancelingEdit"
             OnRowUpdating="gvUserRegistration_RowUpdating" OnRowDeleting="gvUserRegistration_RowDeleting"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">

            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        
 
      <Columns>
                <asp:TemplateField HeaderText="firstname" >
                    <ItemTemplate>
                        <asp:TextBox  Text='<%#Eval("firstname")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="txtfirstname" Text='<%#Eval("firstname")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                              <asp:TextBox ID="txtfirstnamefooter"  runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="lastname">
                    <ItemTemplate>
                        <asp:TextBox  Text='<%#Eval("lastname")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="txtlastname" Text='<%#Eval("lastname")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                              <asp:TextBox ID="txtlastnamefooter"  runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="contact">
                    <ItemTemplate>
                        <asp:TextBox  Text='<%#Eval("contact")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="txtcontact" Text='<%#Eval("contact")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                              <asp:TextBox ID="txtcontactfooter"  runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:TextBox  Text='<%#Eval("Email")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="txtEmail" Text='<%#Eval("Email")%>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                              <asp:TextBox ID="txtEmailfooter"  runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>

                    <ItemTemplate>

                   <asp:ImageButton imageurl="images/icons8-edit-image-64.png" runat="server" commandName="edit" ToolTip="Edit" width="20px" Height="20px" />
                   <asp:ImageButton imageurl="images/delete.png" runat="server" commandName="delete" ToolTip="delete" width="20px" Height="20px" />


                    </ItemTemplate>
                    <EditItemTemplate>

                        
                   <asp:ImageButton imageurl="images/save-file-option%20(1).png" runat="server" commandName="update" ToolTip="update" width="20px" Height="20px" />
                   <asp:ImageButton imageurl="images/cancel%20(1).png" runat="server" commandName="cancel" ToolTip="cancel" width="20px" Height="20px" />
                    </EditItemTemplate>
                     <FooterTemplate>
                         
                          
                           <asp:ImageButton imageurl="images/add-button%20(1).png" runat="server" commandName="add" ToolTip="add" width="20px" Height="20px" />
                     </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
                <br />
               
        <asp:Label ID ="iblsuccessMessage" Text="" runat="server" ForeColor="Green" />
        <br />
        <asp:Label ID="iblErrorMessage" Text="" runat="server" ForeColor="Red" />
             
    </div>
    </form>
</body>
</html>
