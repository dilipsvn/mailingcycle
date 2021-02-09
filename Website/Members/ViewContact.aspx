<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="ViewContact.aspx.cs" Inherits="ViewContact" Title="Mailing Cycle View Contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText"
    Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" Visible="false"
    runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    View Contact
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
    function deleteConformation()
    {
        var allInputTags = document.getElementsByTagName("input");
        var contactCount = 0;
        var defaultPlotFlag = "";
        
        //Scanning the Hidden Fields
        for(i = 0; i < allInputTags.length; i++)
        {
            if(allInputTags[i].type == "hidden")
            {
                if (allInputTags[i].name.indexOf("ContactCountHiddenField") > 0)
                    contactCount = parseInt(allInputTags[i].value);
                else if(allInputTags[i].name.indexOf("DefaultPlotFlagHiddenField") > 0)
                    defaultPlotFlag = allInputTags[i].value;
            }    
        }
        
        if(contactCount < 2)
        {
            if(defaultPlotFlag == "true")
                return confirm("By deleting this Contact you are going to delete the Parent Plot and its Farm. Are you sure you want to proceed.");
            else
                return confirm("By deleting this Contact you are going to delete the Parent Plot. Are you sure you want to proceed.");
        }
        else
            return confirm("Are you sure you want to delete the Contact.");
    }
    </script>
    
    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="50%">Manage your contacts</td>
                            <td width="40%" align="right">
                                <asp:Literal ID="ForAgentLiteral" runat="server"></asp:Literal>
                                <asp:HiddenField ID="ForAgentUserIdHiddenField" runat="server" />
                            </td>
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
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Plot Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2">
                                                Farm / Plot Name:
                                            </td>
                                            <td width="80%" class="t3">
                                                <asp:Label ID="FarmNameLabel" runat="server"></asp:Label>
                                                <strong>/</strong>
                                                <asp:Label ID="PlotNameLabel" runat="server"></asp:Label>&nbsp;<asp:HiddenField ID="PlotIdHiddenField"
                                                    runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Contact Count:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="ContactCountLabel" runat="server"></asp:Label>
                                                <asp:HiddenField ID="ContactCountHiddenField" runat="server" />
                                                <asp:HiddenField ID="DefaultPlotFlagHiddenField" runat="server" />
                                                <asp:HiddenField ID="ContactIdHiddenField" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2">
                                                Created On:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="CreatedOnLabel" runat="server"></asp:Label>
                                                <asp:HiddenField ID="FarmIdHiddenField" runat="server" />
                                                <asp:HiddenField ID="UserIdHiddenField" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Last Modified On:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="ModifiedOnLable" runat="server"></asp:Label>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 7px">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                    </table>
                                    <asp:Literal ID="ErrorLiteral" runat="server"></asp:Literal></fieldset>
                            </td>
                        </tr>
                    </table>
                    <img src="../Images/spacer.gif" width="1" height="8" /><br />
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Contact Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" class="t2" nowrap>
                                                Contact ID:</td>
                                            <td width="30%" class="t3">
                                                <asp:Label ID="ContactIdLabel" runat="server"></asp:Label></td>
                                            <td width="20%" class="t2" nowrap>
                                                Schedule #:
                                            </td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="ScheduleNumberLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Owner Full Name:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="OwnerFullNameLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Lot:
                                            </td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="LotNumberLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Block:</td>
                                            <td class="t3">
                                                <asp:Label ID="BlockLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Subdivision Name:
                                            </td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="SubdivisionLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Filing #:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="FilingLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Site Address:
                                            </td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="SiteAddressLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Bedrooms:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="BedroomsLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                # Full Baths:
                                            </td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="FullBathLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                # 3/4 Baths:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="ThreeQuarterBathLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                # 1/2 Baths:
                                            </td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="HalfBathLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Acres:</td>
                                            <td class="t3">
                                                <asp:Label ID="AcresLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Act Mkt Comb:
                                            </td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="ActMktComboLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Owner First Name:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="OwnerFirstNameLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Owner Last Name:
                                            </td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="OwnerLastNameLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Owner Address 1:</td>
                                            <td class="t3">
                                                <asp:Label ID="OwnerAddress1Label" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Owner Address 2:</td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="OwnerArrdess2Label" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Owner City:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="OwnerCityLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Owner State:</td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="OwnerStateLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Owner Zip:
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="OwnerZipLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Owner Country:</td>
                                            <td class="t3" style="width: 213px">
                                                <asp:Label ID="OwnerCountryLabel" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="t2" nowrap>
                                                Sale Date:
                                                <asp:hiddenfield ID="ParentPageHiddenField" runat="server"></asp:hiddenfield>
                                            </td>
                                            <td class="t3">
                                                <asp:Label ID="SaleDateLabel" runat="server"></asp:Label></td>
                                            <td class="t2" nowrap>
                                                Transfer Amount:</td>
                                            <td class="t3" style="width: 213px">
                                                <span class="Notes">
                                                <asp:Label ID="TransAmountLabel" runat="server"></asp:Label></span></td>
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
                <td align="center">
                    <asp:Button ID="EditContactButton" runat="server" Text="Edit Contact" CssClass="buttonfont" Width="100px" OnClick="EditContactButton_Click" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="DeleteContactButton" runat="server" Text="Delete Contact" CssClass="buttonfont" Width="100px" OnClick="DeleteContactButton_Click" OnClientClick="javascript: return deleteConformation();" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button ID="BackButton" runat="server" Text="Back" CssClass="buttonfont" Width="80px" OnClick="BackButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
