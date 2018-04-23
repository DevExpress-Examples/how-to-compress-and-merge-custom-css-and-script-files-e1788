<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to compress custom CSS- and JavaScript-files</title>
    
    <link rel="stylesheet" type="text/css" href="CssJsHandler.aspx?cssfolder=~/css/" />
    <script type="text/javascript" src="CssJsHandler.aspx?jsfile=scripts/scripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <h1>How to compress custom CSS- and JavaScript-files sample</h1>
            <p id="textId">Some text</p>
            <p><a href="javascript:MyFunc();">Some Link</a></p>
        </div>
    </form>
</body>
</html>
