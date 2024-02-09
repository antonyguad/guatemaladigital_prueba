<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="venta.aspx.cs" Inherits="Guatemaladigitalp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>VENTAS POR FECHA</title>
    <style>
        body {
            font-family:Arial;
            margin:0;
            padding:0;
            background-color:aliceblue;
        }
        .container{
            max-width: 10000px;
            margin: 20px auto;
            padding: 20px;
            background-color:white;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align:center;
            margin-bottom: 50px;
        }
        table {
            width: 100%;
            border-collapse:collapse;
        }
        th{
            background-color:darkorange;
        }
        td::-webkit-scrollbar {
            display:none;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>VERNTAS POR FECHA</h1>
            <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged">
                <asp:ListItem Text="AÑO" Value="" />
                <asp:ListItem Text="2018" Value="2018" />
                <asp:ListItem Text="2019" Value="2019" />
                <asp:ListItem Text="2020" Value="2020" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddlcat" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged">
                <asp:ListItem Text="CATEGORIAS" Value="" />
            </asp:DropDownList>

            <asp:GridView ID="nohay" runat="server" AutoGenerateColumns="false" EmptyDataText="NO HAY REGISTROS QUE MOSTRAR.">
                <Columns>
                    <asp:BoundField DataField="Categoria" HeaderText="CATEGORIA" />
                    <asp:BoundField DataField="Producto" HeaderText="PRODUCTO" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
