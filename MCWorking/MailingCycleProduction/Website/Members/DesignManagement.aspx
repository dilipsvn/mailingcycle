<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="DesignManagement.aspx.cs" Inherits="Agent_DesignManagement" Title="Mailing Cycle Design Management" %>

<%@ Register Src="../WebUserControls/ListOfAgentsWebUserControl.ascx" TagName="ListOfAgentsWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Design Management
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    <!--
    var designMode = 1;
    
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
    
    function ChangePowerKardType(source)
    {
        var ctrlLength = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_PowerKardLengthTextBox");
        var ctrlWidth = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_PowerKardWidthTextBox");
        
        SetControls(source, ctrlLength, ctrlWidth);
    }
    
    function ChangeBrochureType(source)
    {
        var ctrlLength = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_BrochureLengthTextBox");
        var ctrlWidth = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_BrochureWidthTextBox");
        
        SetControls(source, ctrlLength, ctrlWidth);
    }
    
    function SetMode(mode)
    {
        designMode = mode;
    }
    
    function AgentNameValidate(source, arguments)
    {
        if (designMode == 0) {
            if (arguments.Value == -1) {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        } else {
            arguments.IsValid = true;
        }
    }
    
    function PowerKardValidate(source, arguments)
    {
        source.errormessage = "PowerKard Type is Required.";
        
        if (designMode == 1) {
            if (arguments.Value == -1) {
                arguments.IsValid = false;
            } else {
                var args = arguments.Value.split("|");
                var ctrlLength = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_PowerKardLengthTextBox");
                var ctrlWidth = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_PowerKardWidthTextBox");
                
                if (args[0] == "S") {
                    arguments.IsValid = true;
                } else {
                    if ((ctrlLength.value == "") || (ctrlLength.value == null) || (ctrlWidth.value == "") || (ctrlWidth.value == null)) {
                        source.errormessage = "PowerKard Size is Required.";
                        arguments.IsValid = false;
                    } else {
                        var length = isNaN(ctrlLength.value) ? 0 : parseFloat(ctrlLength.value);
                        var width = isNaN(ctrlWidth.value) ? 0 : parseFloat(ctrlWidth.value);
                        
                        if ((length <= 0) || (length >= 100) || (width <= 0) || (width >= 100)) {
                            source.errormessage = "Enter a valid PowerKard Size.";
                            arguments.IsValid = false;
                        } else {
                            arguments.IsValid = true;
                        }
                    }
                }
            }
        } else {
            arguments.IsValid = true;
        }
    }
    
    function BrochureValidate(source, arguments)
    {
        source.errormessage = "Brochure Type is Required.";
        
        if (designMode == 2) {
            if (arguments.Value == -1) {
                arguments.IsValid = false;
            } else {
                var args = arguments.Value.split("|");
                var ctrlLength = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_BrochureLengthTextBox");
                var ctrlWidth = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_BrochureWidthTextBox");
                
                if (args[0] == "S") {
                    arguments.IsValid = true;
                } else {
                    if ((ctrlLength.value == "") || (ctrlLength.value == null) || (ctrlWidth.value == "") || (ctrlWidth.value == null)) {
                        source.errormessage = "Brochure Size is Required.";
                        arguments.IsValid = false;
                    } else {
                        var length = isNaN(ctrlLength.value) ? 0 : parseFloat(ctrlLength.value);
                        var width = isNaN(ctrlWidth.value) ? 0 : parseFloat(ctrlWidth.value);
                        
                        if ((length <= 0) || (length >= 100) || (width <= 0) || (width >= 100)) {
                            source.errormessage = "Enter a valid Brochure Size.";
                            arguments.IsValid = false;
                        } else {
                            arguments.IsValid = true;
                        }
                    }
                }
            }
        } else {
            arguments.IsValid = true;
        }
    }
    // -->
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Manage your design & brochure.
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ErrorMessageLabel" runat="server" Visible="false" CssClass="errormessage"></asp:Label><asp:ValidationSummary
                        ID="ErrorValidationSummary" runat="server" EnableClientScript="true" HeaderText="&nbsp;Please correct the below errors:" />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <asp:Panel ID="AgentSelectionPanel" runat="server" Visible="false">
                                    <fieldset>
                                        <legend class="LegendText">Agent Selection</legend>
                                        <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="t2" nowrap>
                                                    Agent Name:&nbsp;<span class="MandatoryMark">*</span></td>
                                                <td width="75%" class="t3">
                                                    <asp:DropDownList ID="AgentNameDropDownList" runat="server">
                                                        <asp:ListItem Value="-1">&lt;Select an Agent&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Button ID="GoButton" runat="server" CssClass="buttonfont" Text="Go"
                                                        Width="40px" OnClientClick="SetMode(0)" OnClick="GoButton_Click" />
                                                    <asp:CustomValidator ID="AgentNameCustomValidator" runat="server" ControlToValidate="AgentNameDropDownList"
                                                        ClientValidationFunction="AgentNameValidate" ErrorMessage="Agent Name is Required."
                                                        Display="None" SetFocusOnError="true"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <br />
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td width="49%" valign="top">
                                <fieldset>
                                    <legend class="LegendText">PowerKard</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" colspan="2">
                                                This is the primary design layout, mandatory for starting any mailing plan.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:HyperLink ID="PowerkardHyperLink" runat="server"><img src="../Images/Powerkard.jpg" alt="PowerKard" /></asp:HyperLink>
                                                <br />
                                                <label class="Notes">
                                                    <u>Note</u>: Click to view the design file.</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="25%" height="28" class="t2" nowrap>
                                                Type:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="75%" class="t3">
                                                <asp:DropDownList ID="PowerKardTypeDropDownList" runat="server" onchange="javascript: ChangePowerKardType(this);">
                                                    <asp:ListItem Value="-1">&lt;Select a Type&gt;</asp:ListItem>
                                                    <asp:ListItem Value="S|8.5|5.5">Standard 8.5 x 5.5</asp:ListItem>
                                                    <asp:ListItem Value="S|9|6">Standard 9 x 6</asp:ListItem>
                                                    <asp:ListItem Value="C|0|0">Custom Powerkard</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="PowerKardTypeCustomValidator" runat="server" ControlToValidate="PowerKardTypeDropDownList"
                                                    ClientValidationFunction="PowerKardValidate" ErrorMessage="PowerKard Type is Required."
                                                    Display="None" SetFocusOnError="true"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="28" class="t2" nowrap>
                                                Size:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="PowerKardLengthTextBox" runat="server" CssClass="textbox" Width="40"
                                                    MaxLength="5"></asp:TextBox>
                                                x
                                                <asp:TextBox ID="PowerKardWidthTextBox" runat="server" CssClass="textbox" Width="40"
                                                    MaxLength="5"></asp:TextBox>
                                                inch.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="28" class="t2" nowrap>
                                                Status:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="PowerKardStatusLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="PreviousDesignsRow" runat="server" visible="false">
                                            <td height="28" class="t2" nowrap valign="top">
                                                Previous Designs:
                                            </td>
                                            <td class="t3">
                                                <asp:GridView ID="PreviousDesignsGridView" runat="server" AutoGenerateColumns="false"
                                                    HeaderStyle-Height="20px" GridLines="Both" CellPadding="2" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Design Id" HeaderStyle-Width="50%">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="DesignIdHyperLink" runat="server" Text='<%#Eval("DesignId")%>'
                                                                    NavigateUrl='<%# Eval("Url", "{0}") %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Deleted On" HeaderStyle-Width="50%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LastModifyDate" Text='<%#Eval("DeletedOn")%>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="8" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="PowerKardEditButton" runat="server" CssClass="buttonfont" Text="Add PowerKard"
                                                    Width="120px" OnClientClick="SetMode(1)" OnClick="PowerKardEditButton_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                            <td width="2%" align="center" style="padding-top: 6px">
                                <img src="../Images/blue_dot.jpg" width="1" height="308" />
                            </td>
                            <td width="49%" valign="top">
                                <fieldset>
                                    <legend class="LegendText">Brochure</legend>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" colspan="2">
                                                This is a mandatory file if you plan to use 12-Standard, 12-Direct, or Impact mailing
                                                plans.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:HyperLink ID="BrochureHyperLink" runat="server"><img src="../Images/Brochure.jpg" alt="Brochure" /></asp:HyperLink>
                                                <br />
                                                <label class="Notes">
                                                    <u>Note</u>: Click to view the brochure file.</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="25%" height="28" class="t2" nowrap>
                                                Type:&nbsp;<span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="75%" class="t3">
                                                <asp:DropDownList ID="BrochureTypeDropDownList" runat="server" onchange="javascript: ChangeBrochureType(this);">
                                                    <asp:ListItem Value="-1">&lt;Select a Type&gt;</asp:ListItem>
                                                    <asp:ListItem Value="S|6|18">Standard 6 x 18</asp:ListItem>
                                                    <asp:ListItem Value="S|9|18">Standard 9 x 18</asp:ListItem>
                                                    <asp:ListItem Value="C|0|0">Custom Brochure</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="BrochureTypeCustomValidator" runat="server" ControlToValidate="BrochureTypeDropDownList"
                                                    ClientValidationFunction="BrochureValidate" ErrorMessage="Brochure Type is Required."
                                                    Display="None" SetFocusOnError="true"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="28" class="t2" nowrap>
                                                Size:
                                            </td>
                                            <td class="t3">
                                                <asp:TextBox ID="BrochureLengthTextBox" runat="server" CssClass="textbox" Width="40"
                                                    MaxLength="5"></asp:TextBox>
                                                x
                                                <asp:TextBox ID="BrochureWidthTextBox" runat="server" CssClass="textbox" Width="40"
                                                    MaxLength="5"></asp:TextBox>
                                                inch.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="28" class="t2" nowrap>
                                                Status:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="BrochureStatusLabel" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="PreviousBrochuresRow" runat="server" visible="false">
                                            <td height="28" class="t2" nowrap valign="top">
                                                Previous Brochures:
                                            </td>
                                            <td class="t3">
                                                <asp:GridView ID="PreviousBrochuresGridView" runat="server" AutoGenerateColumns="false"
                                                    HeaderStyle-Height="20px" GridLines="Both" CellPadding="2" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Design Id" HeaderStyle-Width="50%">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="BrochureIdHyperLink" runat="server" Text='<%#Eval("DesignId")%>'
                                                                    NavigateUrl='<%# Eval("Url", "{0}") %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Deleted On" HeaderStyle-Width="50%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="BrochureLastModifyDate" Text='<%#Eval("DeletedOn")%>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="8" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="BrochureEditButton" runat="server" CssClass="buttonfont" Text="Add Brochure"
                                                    Width="120px" OnClientClick="SetMode(2)" OnClick="BrochureEditButton_Click" />
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
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="DesignIdHiddenField"
                        runat="server" Value="" />
                    <asp:HiddenField ID="BrochureIdHiddenField" runat="server" Value="" />
                    <asp:HiddenField ID="AgentIdHiddenField" runat="server" Value="" /><asp:HiddenField ID="AgentNameHiddenField" runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
