<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoveContacts.aspx.cs" Inherits="MoveContacts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mailing Cycle Move to Plot</title>
    <style>
    .t2
    {
	    padding-left: 20px;
	    padding-right: 20px;
    }
    .t3
    {
	    font-weight: normal;
    }
    select 
    {
	    font-family: Verdana, Arial, Helvetica, sans-serif;
	    font-size: 11px;
	    color: #000000;
    }
    .MandatoryMark 
    {
	    color: red;
    }
    .LegendText
    {
        color:black;
        font-weight:bold;
    }
    .Notes
    {
        color:#336699;
        font-size:1em;
        font-weight:500;
    }
    .buttonfont
    {
	    background-color:Orange;
	    border-style:outset;
	    border-color:orange;
	    border-width:thin;
	    font-family: Verdana, Arial, Helvetica, sans-serif;
	    font-size: 11px;
	    color: #000000;
    }
    .errormessage
{
	color: #FF0000;
	font-size: 0.9em;
}
    </style>
    <script language="javascript">
    function newPlot(list)
    {
        if (list.options[list.selectedIndex].value == -2)
        {
            var vTextData = window.prompt("Please enter a new plot name:", "");
            if (!vTextData)
            {
                list.selectedIndex = 0;
                return;
            }           
            if (vTextData != null)
            {
                if (vTextData != "")
                {
                    eleList = document.getElementsByTagName("input");
                    for(i=0;i<eleList.length-1;i++)
                        if(eleList[i].type=="hidden")
                            if(eleList[i].id.indexOf("NewPlotHiddenField")>=0)
                                eleList[i].value = vTextData;
                    list.options[list.length-1].innerText = vTextData;
                    list.selectedIndex = list.length-1;
                }
            }
        }
    }
    </script>
</head>
<body style="font-family:Verdana;font-size:8pt">
    <form id="MoveContactsForm" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
        <tr>
            <td class="Notes" style="padding-left: 0px">
                Fields marked with <span class="MandatoryMark">*</span> are mandatory</td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="ErrorLiteral" CssClass="errormessage"></asp:Label></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend style="color:Black;font-weight:bold">Move Contacts</legend>
                    <asp:Panel ID="MoveContactPanel" runat="server" Height="100px" Width="250px">
                        <table border="0" cellspacing="2" cellpadding="3" width="100%">
                            <tr>
                                <td colspan="2">
                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                            </tr>
                            <tr>
                                <td width="30%" class="t2" nowrap>
                                    Farm:
                                </td>
                                <td width="70%" class="t3" nowrap>
                                    <asp:Label ID="FarmNameLabel" runat="server"></asp:Label>
                                    <asp:HiddenField ID="FarmIdHiddenField" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="t2" nowrap>
                                    Plot From:
                                </td>
                                <td class="t3" nowrap>
                                    <asp:Label ID="PlotNameLabel" runat="server"></asp:Label>
                                    <asp:HiddenField ID="PlotIdHiddenField" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="t2" nowrap valign="top">
                                    Plot To:&nbsp;<span class="MandatoryMark">*</span>
                                </td>
                                <td class="t3" nowrap>
                                    <asp:DropDownList ID="PlotListDropDownList" runat="server">
                                    </asp:DropDownList><asp:RequiredFieldValidator ID="PlotListRequiredFieldValidator" ControlToValidate="PlotListDropDownList"
                                        ErrorMessage="<br />Plot To is Required." InitialValue="-1" Display="Dynamic" runat="server" /><asp:HiddenField ID="ContactIdsHiddenField" runat="server" /><asp:HiddenField ID="NewPlotHiddenField" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <img src="../Images/spacer.gif" width="1" height="8" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="SaveButton" runat="server" Text="Save" width="80px" CssClass="buttonfont" OnClick="SaveButton_Click" />
                <img src="../Images/spacer.gif" width="10px" height="1" />
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" width="80px" CssClass="buttonfont" OnClientClick="javascript: window.close();" />
            </td>
        </tr>
        <tr>
            <td>
                <img src="../Images/spacer.gif" width="1" height="8" /></td>
        </tr>
    </table>
    </form>
</body>
</html>
