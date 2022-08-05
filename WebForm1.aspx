<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="API_StudentTable.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css"
        integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N"
        crossorigin="anonymous">
    
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.22/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="//cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>

    <title></title>
     <script type="text/javascript">
        $(document).ready(function () {
            //$('#datatable').dataTable();
            $.ajax(
                {
                    url: 'api/values',
                    method: 'get',
                    dataType: 'json',
                    contentType: 'application/json',
                    async: false,
                    success: function (data) {
                        $('#datatable').dataTable({
                            data: JSON.parse(data),
                            columns: [
                                { 'data': 'ID' },
                                { 'data': 'Name' },
                                { 'data': 'Address' },
                                { 'data': 'Marks' }
                            ]
                        });
                    }
                    
                });
        });
       
    </script>
</head>
<body style="font-family: Arial">
    <form id="form1" runat="server">
        <div style="width: 500px; border: 1px solid black; padding: 5px">
            
            <table  id="datatable" >
                <thead>
                <tr>
                   <th>ID</th>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Address</th>
                    <th>Marks</th>
                </tr>
                </thead>
            </table>
            
        </div>
    </form>
</body>
</html>
