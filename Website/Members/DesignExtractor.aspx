<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DesignExtractor.aspx.cs"
    Inherits="Members_DesignExtractor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mailing Cycle Design Extractor</title>

    <script language="javascript">
    function onObjectLoad()
    {
        var oMCDE = document.getElementById("ctlMCDE");
        
        if (oMCDE != null)
        {
            oMCDE.PDFFile = "http://www.irmdemo.com/mailingcycle/Members/UserData/100016/200801171041277345$1_SMITS,%20Amy%20PK.pdf";
            oMCDE.FileUploader = "http://localhost:1218/Website/Members/FileUploader.aspx";
            oMCDE.ServerName = "localhost";
            oMCDE.ServerPort = 1218;
            
            oMCDE.ExtractDesign();
            
            alert("Hi!");
        }
    }
    </script>

</head>
<body onload="javascript: onObjectLoad();">
    <form id="form1" runat="server">
        <div>
            <object id="ctlMCDE" classid="CLSID:7874D465-C824-4B04-BC07-8885DB41911F" codebase="McDesignExtractor.CAB#version=1,0,0,0">
                <span style="color: red">ActiveX control failed to load! -- Please check browser security
                    settings.</span>
            </object>
        </div>
    </form>
</body>
</html>
