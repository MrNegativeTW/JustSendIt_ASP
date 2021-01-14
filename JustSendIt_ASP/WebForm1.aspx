<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="JustSendIt_ASP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Just Send it!</title>
    <!--CSS-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.12.0-2/css/all.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.0/animate.min.css">
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header-nightsky">

        <nav class="navbar navbar-light" style="background: transparent;">
            <a class="navbar-brand" href="#" style="color: #ffffff">
                <img src="./image/navIcon.png" width="30" height="30" alt="">
                Just Send It !
            </a>
            <a target="_blank" href="https://bit.ly/gh_justsendit" class="btn btn-outline-light form-inline" >
                <i class="fab fa-github"> GitHub</i>
            </a>
        </nav>

        <div class="hero">

            <div class="container">
                <div class="row">

                    <div class="col-sm formBorder formPadding">
                        <span class="title3 textLeft">Send</span>

                        <form id="uploadForm" runat="server" method="POST" action="" enctype="multipart/form-data">
                            <asp:FileUpload ID="FileUpload" runat="server" style="padding-top: 8px; padding-bottom: 8px;" />
                            <asp:Button ID="Button1" runat="server" Text="Upload" class="btn btn-get whiteText" style="width: 100%;" OnClick="Upload_File_Click"/>
                        
                        <div style="padding-top: 4px;">
                            <asp:Label ID="FileUploadSuccessMessage" runat="server" Text="Success! Your file ID is " Visible="False"></asp:Label>
                            <asp:Label ID="FileUploadSuccessFileCode" runat="server" class="title3 textLeft" Visible="False"></asp:Label>
                        </div>

                        <hr/>

                        <span class="title3 textLeft">Receive</span>

                            <div class="form-group input-group">
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button ID="Button2" runat="server" Text="Get file" class="btn btn-get whiteText" OnClick="Receive_File_Click" />
                                </div>
                              </div>
                        </form>
                

                    </div> <!-- ./col-sm -->

                </div> <!-- ./row -->
            </div> <!-- ./container -->
        </div><!-- ./hero -->
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
</body>
</html>
