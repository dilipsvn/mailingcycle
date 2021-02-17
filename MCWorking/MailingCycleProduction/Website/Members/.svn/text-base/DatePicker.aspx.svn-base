<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatePicker.aspx.cs" Inherits="Members_DatePicker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Date Picker</title>
    <style type="text/css">
	BODY { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 4px; PADDING-TOP: 0px }
    </style>

    <script language="javascript">
    function SelectDate(date)
    {
        var fields = document.getElementById("TargetHiddenField").value;
        var fieldArray = fields.split(",");
        
        window.opener.document.getElementById(fieldArray[0]).value = date;
        if (fieldArray.length == 2)
        {
            window.opener.document.getElementById(fieldArray[1]).value = date;
        }
        
        window.close();
    }
    </script>

</head>
<body onblur="javascript: this.window.focus();">
    <form id="form1" runat="server">
        <div align="center">
            <asp:Calendar ID="Calendar1" runat="server" ShowGridLines="True" BorderColor="Gray"
                Font-Names="Verdana" Font-Size="8pt" OnDayRender="Calendar1_DayRender" Width="100%"
                Height="100%">
                <TitleStyle Font-Bold="True" BackColor="#C02F1C" ForeColor="#FFFFFF" />
                <NextPrevStyle Font-Bold="True" ForeColor="#FFFFFF" />
                <DayHeaderStyle BackColor="#FFCC00" />
                <TodayDayStyle BackColor="#2A7FFF" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="Gray" />
            </asp:Calendar>
            <asp:HiddenField ID="TargetHiddenField" runat="server" Value="" />
            <asp:HiddenField ID="ModeHiddenField" runat="server" Value="" />
        </div>
    </form>
</body>
</html>
