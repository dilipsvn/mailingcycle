<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="EditDesign.aspx.cs" Inherits="Members_EditDesign" Title="Mailing Cycle Add PowerKard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    <asp:Label ID="PageTitleLabel" runat="server">Add PowerKard</asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    <!--
    var prefix = "ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_";
    
    function ChangePanel(panel1, panel2, validator)
    {
        var obj = document.getElementById(prefix + panel2);
        
        obj.style.position = "static";
        obj.style.visibility = "visible";
        
        obj = document.getElementById(prefix + panel1);
        
        obj.style.position = "absolute";
        obj.style.visibility = "hidden";
        
        if (validator != "") {
            document.getElementById(prefix + validator).enabled = "True";
        } else {
            document.getElementById(prefix + "RemoveAdditionalFileHiddenField").value = "YES";
        }
    }
    
    function ConfirmApproval(msg, bypass)
    {
        var bValid = true;
        
        if (bypass == "no") {
            WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions('ctl00$ctl00$ContentPlaceHolder1$ContentPlaceHolder1$SubmitButton', '', true, '', '', false, false));
            
            bValid = ValidatorCommonOnSubmit();
        }
        
        if (bValid) {
            return confirm(msg);
        } else {
            return false;
        }
    }
    
    function DeleteDesign()
    {
        var ctrl = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_UsedHiddenField");
        
        if (ctrl.value == "FoundActive") {
            alert("You cannot delete the design as the design is part of an active plan.");
            return false;
        } else {
            return confirm("Are you sure you want to delete the design?");
        }
    }
    
    function SetControls(source, ctrlLength, ctrlWidth)
    {
        if (source.value == -1) {
            ctrlLength.value = "";
            ctrlWidth.value = "";
            
            ctrlLength.disabled = true;
            ctrlWidth.disabled = true;
        } else {
            var args = source.value.split("|");
            
            if (args[0] == "S") {
                ctrlLength.value = args[1];
                ctrlWidth.value = args[2];
                
                ctrlLength.disabled = true;
                ctrlWidth.disabled = true;
            } else {
                ctrlLength.value = "";
                ctrlWidth.value = "";
                
                ctrlLength.disabled = false;
                ctrlWidth.disabled = false;
            }
        }
    }
    
    function ChangeType(source)
    {
        var ctrlLength = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_LengthTextBox");
        var ctrlWidth = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_WidthTextBox");
        
        SetControls(source, ctrlLength, ctrlWidth);
    }
    
    function MessageLocationValidate(source, arguments)
    {
        var ctrlX = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_MessageXTextBox");
        var ctrlY = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_MessageYTextBox");
        
        if ((ctrlX.value != "") || (ctrlY.value != "")) {
            var x = isNaN(ctrlX.value) ? 0 : parseFloat(ctrlX.value);
            var y = isNaN(ctrlY.value) ? 0 : parseFloat(ctrlY.value);
            
            if ((x <= 0) || (x >= 100) || (y <= 0) || (y >= 100)) {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        } else {
            arguments.IsValid = true;
        }
    }
    
    function MessageSizeValidate(source, arguments)
    {
        var ctrlLength = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_MessageLengthTextBox");
        var ctrlWidth = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_MessageWidthTextBox");
        
        if ((ctrlLength.value != "") || (ctrlWidth.value != "")) {
            var length = isNaN(ctrlLength.value) ? 0 : parseFloat(ctrlLength.value);
            var width = isNaN(ctrlWidth.value) ? 0 : parseFloat(ctrlWidth.value);
            
            if ((length <= 0) || (length >= 100) || (width <= 0) || (width >= 100)) {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        } else {
            arguments.IsValid = true;
        }
    }
    
    function TypeValidate(source, arguments)
    {
        source.errormessage = "Type is Required.";
        
        if (arguments.Value == -1) {
            arguments.IsValid = false;
        } else {
            var args = arguments.Value.split("|");
            var ctrlLength = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_LengthTextBox");
            var ctrlWidth = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_WidthTextBox");
            
            if (args[0] == "S") {
                arguments.IsValid = true;
            } else {
                if ((ctrlLength.value == "") || (ctrlLength.value == null) || (ctrlWidth.value == "") || (ctrlWidth.value == null)) {
                    source.errormessage = "Size is Required.";
                    arguments.IsValid = false;
                } else {
                    var length = isNaN(ctrlLength.value) ? 0 : parseFloat(ctrlLength.value);
                    var width = isNaN(ctrlWidth.value) ? 0 : parseFloat(ctrlWidth.value);
                    
                    if ((length <= 0) || (length >= 100) || (width <= 0) || (width >= 100)) {
                        source.errormessage = "Enter a valid Size.";
                        arguments.IsValid = false;
                    } else {
                        arguments.IsValid = true;
                    }
                }
            }
        }
    }
    
    function openHelp(path)
    {
        var iWidth = 300;
        var iHeight = screen.height - 100;
        var iLeft = (screen.width - iWidth) - 12;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
        window.open(path, "Help", sFeatures + sSize);
    }
    // -->
    </script>

    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <asp:Panel ID="AddPageDescriptionPanel" runat="server">
                                    Please fill design details in the below form
                                </asp:Panel>
                                <asp:Panel ID="EditPageDescriptionPanel" runat="server" Visible="false">
                                    Please modify design details in the below form
                                </asp:Panel>
                                <asp:Panel ID="ReviewPageDescriptionPanel" runat="server" Visible="false">
                                    Please review and modify design details in the below form
                                </asp:Panel>
                                <asp:Panel ID="ViewPageDescriptionPanel" runat="server" Visible="false">
                                    View design details in the below form
                                </asp:Panel>
                            </td>
                            <td align="right">
                                <asp:Label ID="AgentNameLabel" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../../images/transparent.gif" width="1" height="1" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="Notes" style="padding-left: 20px">
                    Fields marked with <span class="MandatoryMark">*</span> are mandatory</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ErrorMessageLabel" runat="server" Visible="false" CssClass="errormessage"></asp:Label>
                    <asp:ValidationSummary ID="ErrorValidationSummary" runat="server" EnableClientScript="true"
                        HeaderText="&nbsp;Please correct the below errors:" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Design Details </legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="t2" nowrap>
                                                Category:</td>
                                            <td width="25%" class="t3">
                                                <table border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td>PowerKard&nbsp;</td>
                                                        <td><a href="javascript: openHelp('../Help/PowerKard.htm');"><img src="../Images/helpIcon.gif" /></a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="25%" class="t2" nowrap>
                                                Status:</td>
                                            <td width="25%" class="t3">
                                                <i>
                                                    <asp:Label ID="StatusLabel" runat="server" Text="Not Uploaded"></asp:Label></i></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Type:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <asp:DropDownList ID="TypeDropDownList" runat="server" onchange="javascript: ChangeType(this);">
                                                    <asp:ListItem Value="-1">&lt;Select a Type&gt;</asp:ListItem>
                                                    <asp:ListItem Value="S|8.5|5.5">Standard 8.5 x 5.5</asp:ListItem>
                                                    <asp:ListItem Value="S|9|6">Standard 9 x 6</asp:ListItem>
                                                    <asp:ListItem Value="C|0|0">Custom Powerkard</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="TypeCustomValidator" runat="server" ControlToValidate="TypeDropDownList"
                                                    ClientValidationFunction="TypeValidate" ErrorMessage="Type is Required." Display="None"
                                                    SetFocusOnError="true"></asp:CustomValidator>
                                            </td>
                                            <td class="t2" nowrap>
                                                Size:</td>
                                            <td class="t3">
                                                <asp:TextBox ID="LengthTextBox" runat="server" CssClass="textbox" Width="40" MaxLength="5"></asp:TextBox>
                                                x
                                                <asp:TextBox ID="WidthTextBox" runat="server" CssClass="textbox" Width="40" MaxLength="5"></asp:TextBox>
                                                inch.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Attributes </legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="t2" nowrap>
                                                Gender:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td width="25%" class="t3">
                                                <asp:DropDownList ID="GenderDropDownList" runat="server">
                                                    <asp:ListItem Value="-1">&lt;Select a Gender&gt;</asp:ListItem>
                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                    <asp:ListItem Value="Group">Group</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="GenderRequiredFieldValidator" ControlToValidate="GenderDropDownList"
                                                    Display="None" ErrorMessage="Gender is Required." InitialValue="-1" runat="server" />
                                                <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a>
                                            </td>
                                            <td width="25%" class="t2" nowrap>
                                                Agent Name:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td width="25%" class="t3">
                                                <asp:TextBox ID="AgentNameTextBox" runat="server" CssClass="textbox" Width="125"
                                                    MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="AgentNameRequiredFieldValidator" ControlToValidate="AgentNameTextBox"
                                                    Display="None" ErrorMessage="Agent Name is Required." runat="server" />
                                                <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Justification:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <asp:DropDownList ID="JustificationDropDownList" runat="server" Width="148">
                                                    <asp:ListItem Value="-1">&lt;Select a Justification&gt;</asp:ListItem>
                                                    <asp:ListItem Value="1">Left</asp:ListItem>
                                                    <asp:ListItem Value="2">Right</asp:ListItem>
                                                    <asp:ListItem Value="3">Center</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="JustificationRequiredFieldValidator" ControlToValidate="JustificationDropDownList"
                                                    Display="None" ErrorMessage="Justification is Required." InitialValue="-1" runat="server" />
                                                <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a>
                                            </td>
                                            <td class="t2" nowrap>
                                                Gutter:</td>
                                            <td class="t3">
                                                <asp:DropDownList ID="GutterDropDownList" runat="server">
                                                    <asp:ListItem Value="">&lt;Select a Gutter&gt;</asp:ListItem>
                                                    <asp:ListItem Value="1/2 x 1/2">1/2 x 1/2</asp:ListItem>
                                                    <asp:ListItem Value="3/4 x 3/4">3/4 x 3/4</asp:ListItem>
                                                </asp:DropDownList>
                                                <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Message Location:&nbsp;<asp:Label runat="server" ID="MessageLocnManLabel" Visible="false"
                                                    CssClass="MandatoryMark">*</asp:Label>
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="MessageXTextBox" runat="server" CssClass="textbox" Width="40" MaxLength="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="MessageXTextBoxRequiredFieldValidator" ControlToValidate="MessageXTextBox"
                                                    Display="None" Enabled="false" ErrorMessage="Message X Location Required." runat="server" />
                                                x
                                                <asp:TextBox ID="MessageYTextBox" runat="server" CssClass="textbox" Width="40" MaxLength="5"></asp:TextBox>
                                                inch.
                                                <asp:RequiredFieldValidator ID="MessageYTextBoxRequiredFieldValidator" ControlToValidate="MessageYTextBox"
                                                    Display="None" Enabled="false" ErrorMessage="Message Y Location Required." runat="server" />
                                                <asp:CustomValidator ID="MessageXCustomValidator" runat="server" ControlToValidate="MessageXTextBox"
                                                    ClientValidationFunction="MessageLocationValidate" ErrorMessage="Enter a valid Message Location."
                                                    Display="None" SetFocusOnError="true"></asp:CustomValidator>
                                                <asp:CustomValidator ID="MessageYCustomValidator" runat="server" ControlToValidate="MessageYTextBox"
                                                    ClientValidationFunction="MessageLocationValidate" ErrorMessage="" Display="None"
                                                    SetFocusOnError="true"></asp:CustomValidator>
                                                <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a>
                                            </td>
                                            <td class="t2" nowrap>
                                                Message Size:&nbsp;<asp:Label runat="server" ID="MessageSizeManLabel" Visible="false"
                                                    CssClass="MandatoryMark">*</asp:Label></td>
                                            <td class="t3">
                                                <asp:TextBox ID="MessageLengthTextBox" runat="server" CssClass="textbox" Width="40"
                                                    MaxLength="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="MessageLengthTextBoxRequiredFieldValidator" ControlToValidate="MessageLengthTextBox"
                                                    Display="None" Enabled="false" ErrorMessage="Message size length Required." runat="server" />
                                                x
                                                <asp:TextBox ID="MessageWidthTextBox" runat="server" CssClass="textbox" Width="40"
                                                    MaxLength="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="MessageWidthTextBoxRequiredFieldValidator" ControlToValidate="MessageWidthTextBox"
                                                    Display="None" Enabled="false" ErrorMessage="Message size width Required." runat="server" />
                                                inch.
                                                <asp:CustomValidator ID="MessageLengthCustomValidator" runat="server" ControlToValidate="MessageLengthTextBox"
                                                    ClientValidationFunction="MessageSizeValidate" ErrorMessage="Enter a valid Message Size."
                                                    Display="None" SetFocusOnError="true"></asp:CustomValidator>
                                                <asp:CustomValidator ID="MessageWidthCustomValidator" runat="server" ControlToValidate="MessageWidthTextBox"
                                                    ClientValidationFunction="MessageSizeValidate" ErrorMessage="" Display="None"
                                                    SetFocusOnError="true"></asp:CustomValidator>
                                                <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Upload Files </legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="t2" nowrap>
                                                1. Low-Resolution File:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td width="75%" class="t3">
                                                <span id="LowResolutionFileNotExistsPanel" runat="server" style="position: relative;
                                                    visibility: visible;">
                                                    <asp:FileUpload ID="LowResolutionFileUpload" runat="server" Width="450px" />
                                                    <asp:RequiredFieldValidator ID="LowResolutionFileRequiredFieldValidator" ControlToValidate="LowResolutionFileUpload"
                                                        Display="None" ErrorMessage="Low-Resolution File is Required." runat="server" />
                                                </span><span id="LowResolutionFileExistsPanel" runat="server" style="position: absolute;
                                                    visibility: hidden;">
                                                    <asp:HyperLink ID="LowResolutionFileHyperLink" runat="server"></asp:HyperLink>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="LowResolutionFileSizeLabel" runat="server" Text=""></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="LowResolutionFileRemoveHyperLink" runat="server"
                                                        href="javascript: ChangePanel('LowResolutionFileExistsPanel', 'LowResolutionFileNotExistsPanel', 'LowResolutionFileRequiredFieldValidator')">
                                                        [Remove]</a> </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="34" height="1" /><img src="../Images/icon_orange_arrow.gif" />
                                                This file will be used for display on the website. Maximum size limit 2 MB. <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                2. High-Resolution File:&nbsp;<span class="MandatoryMark">*</span></td>
                                            <td class="t3">
                                                <span id="HighResolutionFileNotExistsPanel" runat="server" style="position: relative;
                                                    visibility: visible;">
                                                    <asp:FileUpload ID="HighResolutionFileUpload" runat="server" Width="450px" />
                                                    <asp:RequiredFieldValidator ID="HighResolutionFileRequiredFieldValidator" ControlToValidate="HighResolutionFileUpload"
                                                        Display="None" ErrorMessage="High-Resolution File is Required." runat="server" />
                                                </span><span id="HighResolutionFileExistsPanel" runat="server" style="position: absolute;
                                                    visibility: hidden;">
                                                    <asp:HyperLink ID="HighResolutionFileHyperLink" runat="server"></asp:HyperLink>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="HighResolutionFileSizeLabel" runat="server" Text=""></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="HighResolutionFileRemoveHyperLink" runat="server"
                                                        href="javascript: ChangePanel('HighResolutionFileExistsPanel', 'HighResolutionFileNotExistsPanel', 'HighResolutionFileRequiredFieldValidator')">
                                                        [Remove]</a> </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="34" height="1" /><img src="../Images/icon_orange_arrow.gif" />
                                                This file will be used for printing and mailing purposes. Maximum size limit 20
                                                MB. <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                3. Additional File:</td>
                                            <td class="t3">
                                                <span id="AdditionalFileNotExistsPanel" runat="server" style="position: relative;
                                                    visibility: visible;">
                                                    <asp:FileUpload ID="AdditionalFileUpload" runat="server" Width="450px" />
                                                </span><span id="AdditionalFileExistsPanel" runat="server" style="position: absolute;
                                                    visibility: hidden;">
                                                    <asp:HyperLink ID="AdditionalFileHyperLink" runat="server"></asp:HyperLink>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="AdditionalFileSizeLabel" runat="server" Text=""></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="AdditionalFileRemoveHyperLink" runat="server"
                                                        href="javascript: ChangePanel('AdditionalFileExistsPanel', 'AdditionalFileNotExistsPanel', '')">
                                                        [Remove]</a> </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="34" height="1" /><img src="../Images/icon_orange_arrow.gif" />
                                                This is optional. You could upload house flyer etc. Maximum size limit 3 MB. <a href="javascript: openHelp('../Help/DesignGuidelines.htm');">
                                                    <img src="../Images/helpIcon.gif" /></a></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Notes & History </legend>
                                    <table cellpadding="2" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr id="NotesRow" runat="server">
                                            <td width="25%" class="t2" valign="top">
                                                Notes:
                                            </td>
                                            <td width="75%" class="t3">
                                                <asp:TextBox ID="NotesTextBox" runat="server" TextMode="Multiline" Wrap="true" Rows="6"
                                                    Columns="58"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="t2" valign="top">
                                                History:
                                            </td>
                                            <td width="75%" class="t3">
                                                <asp:TextBox ID="HistoryTextBox" runat="server" TextMode="Multiline" Wrap="true"
                                                    Rows="6" Columns="58" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel ID="AgentButtonsPanel" runat="server">
                        <asp:Button ID="SaveButton" Text="Save" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="SaveButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="SubmitButton" Text="Submit for Approval" CssClass="buttonfont" runat="server"
                            OnClientClick="javascript: return ConfirmApproval('Are you sure you want to submit the design for approval?', 'no');"
                            OnClick="SubmitButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="CancelButton" Text="Cancel" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
                    <asp:Panel ID="ReadOnlyButtonsPanel" runat="server" Visible="false">
                        <asp:Button ID="BackButton" Text="Back" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
                    <asp:Panel ID="ReviewButtonsPanel" runat="server" Visible="false">
                        <asp:Button ID="SaveButton1" Text="Save" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="SaveButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="ApproveButton" Text="Approve" CssClass="buttonfont" Width="80px"
                            runat="server" OnClientClick="javascript: return ConfirmApproval('Are you sure you want to approve the design?', 'no');"
                            OnClick="ApproveButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="RejectButton" Text="Reject" CssClass="buttonfont" Width="80px" runat="server"
                            OnClientClick="javascript: return ConfirmApproval('Are you sure you want to reject the design?', 'yes');"
                            OnClick="RejectButton_Click" CausesValidation="false" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="CancelButton1" Text="Cancel" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
                    <asp:Panel ID="ReadWriteButtonsPanel" runat="server" Visible="false">
                        <asp:Button ID="SaveButton2" Text="Save" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="SaveButton_Click" CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="CancelButton2" Text="Cancel" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
                    <asp:Panel ID="DeleteButtonsPanel" runat="server" Visible="false">
                        <asp:Button ID="ExtractPagesButton" Text="Extract Pages" CssClass="buttonfont" Width="100px"
                            runat="server" OnClick="ExtractPagesButton_Click" CausesValidation="false" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="DeleteButton" Text="Delete" CssClass="buttonfont" Width="80px" runat="server"
                            OnClientClick="javascript: return DeleteDesign();" OnClick="DeleteButton_Click"
                            CausesValidation="true" />
                        <img src="../Images/spacer.gif" width="10px" height="1" />
                        <asp:Button ID="CancelButton3" Text="Cancel" CssClass="buttonfont" Width="80px" runat="server"
                            OnClick="CancelButton_Click" CausesValidation="false" />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td height="50">
                </td>
            </tr>
            <tr>
                <td style="background-color: #c9cacd">
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="AgentButtonsHelpPanel" runat="server">
                        <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    If you want to save the design details and want to submit the design later, then
                                    click on <i>'Save'</i> button.
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    If you are satisfied with your design details and ready for submitting the design
                                    for approval, then click on <i>'Submit for Approval'</i> button.
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="ReadOnlyButtonsHelpPanel" runat="server" Visible="false">
                        <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    If you want to navigate back to Design Management screen, then click on <i>'Back'</i>
                                    button.
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="ReviewButtonsHelpPanel" runat="server" Visible="false">
                        <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    If you want to save the design details and want to review the design later, then
                                    click on <i>'Save'</i> button.
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    If you are satisfied with the design details, then click on <i>'Approve'</i> button.
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    If you are not satisfied with the design details, then click on <i>'Reject'</i>
                                    button.
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="ReadWriteButtonsHelpPanel" runat="server" Visible="false">
                        <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    If you are satisfied with the design details, then click on <i>'Save'</i> button.
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="DeleteButtonsHelpPanel" runat="server" Visible="false">
                        <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                            <tr>
                                <td valign="top">
                                    <img width="12" height="8" src="../Images/arrow_orange.gif"></td>
                                <td class="Notes">
                                    If you wish to delete the design and allow the user to add another design, then
                                    click on <i>'Delete'</i> button.
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="IdHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="ModeHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="AgentIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="AgentNameHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="LowResolutionFileHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="HighResolutionFileHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="AdditionalFileHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="RemoveAdditionalFileHiddenField" runat="server" Value="NO" />
                    <asp:HiddenField ID="UsedHiddenField" runat="server" Value="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>