<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="ChangeRegistrationFee.aspx.cs" Inherits="Members_ChangeRegistrationFee" Title="Change Registration Fee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
Change Registration Fee
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Change your Registration Fee
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td colspan="4">
                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                        </tr>

                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Registration Fee Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                Registration Fee(USD): <span class="MandatoryMark">*</span>
                                            </td>
                                            <td width="78%" class="t3" nowrap>$
                                                <asp:Label id="RegistrationFeeLabel" runat="server" visible="false"></asp:Label>
                                                <asp:Textbox id="RegistrationFeeTextBox" runat="server" visible="false"></asp:Textbox>
                                                    <asp:RegularExpressionValidator
                                                    ID="FeeRegularExpressionValidator" display="none" SetFocusOnError="true" runat="server" ControlToValidate="RegistrationFeeTextBox"
                                                    ErrorMessage="Fee  must be a Number" ValidationExpression="^[0-9]*$" Width="192px"></asp:RegularExpressionValidator>                                                
                                                <asp:RequiredFieldValidator  display="none" ID="RegistrationFeeTextBoxRFValidator" SetFocusOnError="true" runat="server" ErrorMessage="Fee is required" InitialValue="" ControlToValidate="RegistrationFeeTextBox" Width="1px"></asp:RequiredFieldValidator>
                                                <asp:LinkButton id="AddRegistrationFeeButton" runat="server" onClick="AddRegistrationFee_Click" visible="false" text="Add Registration Fee Details..."></asp:LinkButton>
                                                
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
                    <asp:Button ID="SaveFeeButton" cssClass="buttonfont" runat="server" Text="Save" visible="false" OnClick="SaveFeeButton_Click" Width="72px" />
                    <asp:Button ID="EditFeeButton" cssClass="buttonfont" runat="server" Text="Edit" visible="false" OnClick="EditFeeButton_Click" Width="72px" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <input class="buttonfont" type="button" value="Cancel" visible ="false" style="width: 80px" onclick="javascript:location.href='ChangeRegistrationFee.aspx'" id="CancelButton" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table> 
    </div> 
</asp:Content>

