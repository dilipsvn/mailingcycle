<%@ Page Language="C#" MasterPageFile="~/Members/AgentMasterPage.master" AutoEventWireup="true" CodeFile="CreateCustomMessage.aspx.cs" Inherits="CreateCustomMessage" Title="Mailing Cycle Add Custom Message" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPageTitleText" Runat="Server">
<asp:label ID="TitleLabel" runat="server" >Add Custom Message</asp:label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script type="text/javascript" src="../Whizzywig/whizzywig.js"></script>
    <script type="text/javascript" src="../Include/Functions.js"></script>

    <script language="javascript">
        function deleteItem(msg)
        {
            confirm(msg);
        }
        function findTextareaID()
	    {
	        
		    var alltextarea =document.getElementsByTagName("textarea");		    
		    if((typeof alltextarea === 'object') && (typeof alltextarea.length === 'number')) return alltextarea[0].id;
		    else return "";
	    }

    </script>
    


<div class="right-content-mainsection">
    <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
		    <td height="30" class="tableheading">               
                <table width="100%">
                <tr>
                <td>
                <asp:Label ID="SubTitleLabel" runat="server">
                Please fill custom message details in the below form</asp:Label></td>
                <td align=right>
                <asp:Label id="AgentLabel" runat="server" Visible="false"></asp:Label></td>
             </tr>
             </table>
            </td>
		</tr>
        <tr>
            <td class="rowborder">
                <img src="../images/transparent.gif" width="1" height="1" /></td>
        </tr>
		<tr>
		    <td>
		        &nbsp;
		    </td>
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
                <asp:Label runat="server" ID="ErrorLiteral" CssClass="errormessage"></asp:Label>
                <asp:ValidationSummary ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:" />
            </td>
        </tr>        
		<tr>
		   <td>
                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                    <tr>
                        <td>
                            <fieldset>
                                <legend class="LegendText">Custom Message Details</legend>
                                <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                    </tr>
                                    <asp:panel id="MessageIdPanel" runat="server" visible="false">
                                    <tr>
                                        <td width="22%" class="t2" nowrap>
                                            Message Id:&nbsp;<span class="MandatoryMark">*</span>
                                        </td>
                                        <td width="78%" class="t3">
                                            <asp:Label ID="MessageIdLabel" Width="50" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    </asp:panel>
                                    <tr>
                                        <td class="t2" nowrap>
                                            Short Description:&nbsp;<span class="MandatoryMark">*</span>
                                        </td>
                                        <td class="t3">
                                            <asp:TextBox ID="ShortDescTextBox" runat="server" MaxLength="50" Width="300"></asp:TextBox>
                                            <asp:CustomValidator Display="none" ControlToValidate="ShortDescTextBox" OnServerValidate="CheckShortDesc" runat="server" ErrorMessage="Short Description Is Required" CssClass="errormessage" ID="CustomValidator2" ValidateEmptyText="true" ></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="t2" nowrap>
                                            Status:
                                        </td>
                                        <td class="t3">
                                            <asp:dropdownlist id="StatusDropDownList" runat="server" >                                            
                                            </asp:dropdownlist>
                                        </td>
                                    </tr>                                                                  
                                    
                                    <asp:Panel ID="HTMEditorPanel" runat="server" Visible="true">
                                        <tr>
                                            <td class="t2" valign="top" nowrap>
                                                Message Text:&nbsp;<span class="MandatoryMark">*</span>
                                                &nbsp;<a href="javascript: openHelp('../Help/ImageForMessages.htm');"><img
                                                    src="../Images/helpIcon.gif" /></a>
                                            </td>
                                            <td class="t3" align="left">
                                                <table border="0" cellspacing="0" cellpadding="0">
                                                    
                                       <tr>
                                        <td>                                           
                                       <div id="ExistingImagesDiv" style="display:none" >
                                            <br /><b>Please select an image from the list below or upload a new image file (max 500kb)</b>
                                            <asp:GridView width="90%" HeaderStyle-BackColor="#e4e4e4" HeaderStyle-Font-Bold="true" HeaderStyle-CssClass="boldtxt" HeaderStyle-Height="15px"  AutoGenerateColumns="false" ID="ExistingImagesGridview" runat="server" OnRowDataBound="ExistingImagesGridview_RowDataBound">
                                            <Columns>
                                            <asp:BoundField HeaderText="File Name" DataField="Name" />
                                            <asp:TemplateField>
                                                <ItemTemplate   >
                                                    <a id="ImageLink" runat="server">Select</a> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                            </asp:GridView>                                                                                    
                                        </div>                                        
                                        </td>
                                        </tr>
                                        <tr><td>&nbsp;</td></tr>
                                        <tr>
                                        <td class="t3" align="left">
                                        <div id="FileUploadDiv" style="display:none">
                                            <asp:FileUpload runat="server" ID="ImageFileName" />  
                                            <input type=file contenteditable=false 
                                            <asp:CustomValidator Display="none" ControlToValidate="ImageFileName" OnServerValidate="CheckShortDesc" Enabled="false" runat="server" ErrorMessage="File Name Is Required" CssClass="errormessage" ID="ImageFileNameRFValidator" ValidateEmptyText="true" ></asp:CustomValidator>
                                           <asp:RegularExpressionValidator Display="none" ID="ImageFileNameRegExpValidator" Enabled="false"  ControlToValidate="ImageFileName" runat="server" ErrorMessage="Image File Format Is Wrong" ValidationExpression="(.*\.jpg)|(.*\.jpeg)|(.*\.png)|(.*\.gif)|(.*\.JPG)|(.*\.JPEG)|(.*\.PNG)|(.*\.GIF)"></asp:RegularExpressionValidator>
                                           <asp:button id="UploadButton" CausesValidation=false runat="server" text="Upload Image" OnClick="SaveImageFile" />
                                        </div>
                                        </td>
                                    </tr>
                                    <tr><td>&nbsp;</td></tr>
                                            
                                    <tr>
                                        <td align="right">
                                            <asp:dropdownlist id="StandardMessagesDropDownList" OnSelectedIndexChanged="StatusDropDownList_SelectedIndexChanged" AutoPostBack="true" runat="server" style="width:220px">
                                            </asp:dropdownlist>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="../images/transparent.gif" width="1" height="2" /></td>
                                    </tr>      
                                    <tr>
                                        <td>
                                            <div style="font-size: 80%; margin: 0; padding: 0px; font-family: Georgia, Verdana,sans-serif;
                                                color: navy; background: white;">
                                                <asp:Panel runat="server" ID="MessageTextPanel" >                                               
                                                <asp:textbox id="HTMLEditTextBox" runat="server" textmode="MultiLine" rows="10" columns="55"
                                                    height="300px" width="500px">
                                                </asp:textbox>                                                                
                                                <script language="JavaScript" type="text/javascript">
                                                    buttonPath = "../Whizzywig/images/";
                                                    cssFile="../Whizzywig/simple.css";
                                                    buttonlist = "fontname fontsize newline bold italic underline | left center right | number bullet indent outdent | undo redo | color hilite rule | image";
                                                    //makeWhizzyWig("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_HTMLEditTextBox", "all");
                                                    makeWhizzyWig(findTextareaID(),buttonlist);
                                                </script>                                                                
                                                </asp:Panel>
                                                <input type="hidden" id="MessageTextHidden" runat="server" />
                                                <asp:Panel runat="server" ID="MessageImagePanel" visible="false" style="border: 1px dotted #336699; width: 500px; padding: 5px 5px 5px 5px">                                               
                                                 <asp:Image runat="server" ID="MessageImage" width= 500px height=400px/>                                                                   
                                                </asp:Panel>
                                            </div>
                                        </td>
                                    </tr>
                                </table> 
                              </td>
                            </tr>    
                            <tr>
                            <td colspan=2 align=center>
                            <asp:CustomValidator Display="none" ControlToValidate="HTMLEditTextBox" OnServerValidate="CheckShortDesc" runat="server" enabled="false" ErrorMessage="Message text Is Required" CssClass="errormessage" ID="MessageTextRFValidator" ValidateEmptyText="true" ></asp:CustomValidator>
                            </td>
                            </tr>                                    
                          </asp:Panel> 
                        <tr>
                            <td colspan="2" style="height: 3px">
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
                <td><img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button Text="Save" style="width: 80px" runat="server"  CssClass="buttonfont" ID="SaveButton" OnClick="SaveButton_Click" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:button runat="server" id="backbutton" CssClass="buttonfont" CausesValidation="false" Text="Cancel" style="width: 80px" OnClick="BackButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
