<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NestedGridView.aspx.cs" Inherits="NestedGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function expandcollapse(name)
        {
            var div = document.getElementById(name);
            var img = document.getElementById('img' + name);
            if (div.style.display == 'none')
            {
                div.style.display = "inline";
                img.src = "minus.png"
            }
            else
            {
                div.style.display = "none";
                img.src = "plus.png";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
                                              <%--added AutoGenerateColumns equals to false--%>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="JavaScript:expandcollapse('<%# Eval("country_id") %>');">
                                <img src="plus.png" border="0"  id='img<%# Eval("country_Id") %>' />

                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="country_Id" Headertext="Country Id" />
                    <asp:BoundField DataField="country_name" Headertext="Country Name" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">

                                    <div id='<%# Eval("country_Id") %>' style="display:none">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="state_Id" HeaderText="state id" />
                                                <asp:BoundField DataField="state_name" HeaderText="state Name" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
            </asp:GridView>
        </div>
    </form>
</body>
</html>
