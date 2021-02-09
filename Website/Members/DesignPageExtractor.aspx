<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true"
    CodeFile="DesignPageExtractor.aspx.cs" Inherits="Members_DesignPageExtractor"
    Title="Mailing Cycle Design Page Extractor" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="Server">
    Design Page Extractor
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-content-mainsection">
        <table width="100%" cellspacing="0" class="toptable">
            <tr>
                <td height="30" class="tableheading">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                This page will extract the design pages.
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
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td>
                                                <img src="../Images/spacer.gif" width="1" height="1" alt=""/></td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <object id="ctlMCDE" classid="CLSID:7874D465-C824-4B04-BC07-8885DB41911F" codebase="McDesignExtractor.CAB#version=1,0,0,0">
                                                    <p style="color: red">
                                                        ActiveX control failed to load! -- Please check your browser security settings.</p>
                                                    <p align="left">
                                                        <font color="#336699" style="font-weight: bold; text-decoration: underline">Install
                                                            the ActiveX control</font><br />
                                                        <br />
                                                        If Internet Explorer default settings are on, you'll see the Information Bar at
                                                        the top of the page (just below the address bar). You'll see the alert below.<br />
                                                        <br />
                                                        <img src="../Images/InformationBar.JPG" style="border: solid 1px Gray" width="407"
                                                            height="108" /><br />
                                                        <br />
                                                        To install the ActiveX control:<br />
                                                        <br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;1. Click the Information Bar.<br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;2. Click Install/Run ActiveX Control.</p>
                                                    <p align="left">
                                                        <font color="#336699" style="font-weight: bold; text-decoration: underline">Change Your
                                                            Security Settings</font><br />
                                                        <br />
                                                        In some cases the information bar will display a message telling that your security
                                                        settings do not allow a particular action. You can follow the steps below:<br />
                                                        <br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;1. On the <b>Tools</b> menu, click <b>Internet Options</b>.<br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;2. On the <b>Security</b> tab, click <b>Custom Level</b>.<br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;3. In the <b>Security Settings</b> dialog box, scroll to
                                                        the <b>Download unsigned ActiveX controls</b> setting in the <b>ActiveX controls and
                                                            plug-ins</b> section, and then click <b>Prompt</b>.<br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;4. Click <b>OK</b> in the <b>Security Settings</b> dialog
                                                        box, and then click <b>OK</b> to exit <b>Internet Options</b>.<br />
                                                        <br />
                                                        <img src="../Images/SecuritySettings.JPG" style="border: solid 1px Gray" width="333"
                                                            height="183" /></p>
                                                </object>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
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
                    <asp:Button id="OKButton" text="OK" cssclass="buttonfont" width="80px" runat="server"
                        onclick="OKButton_Click" causesvalidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /><asp:HiddenField ID="AgentIdHiddenField"
                        runat="server" Value="" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
