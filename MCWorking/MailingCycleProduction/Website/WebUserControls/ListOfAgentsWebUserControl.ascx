<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListOfAgentsWebUserControl.ascx.cs" Inherits="ListOfAgentsWebUserControl" %>

                            <asp:label ID="SelectLabel" runat="server">Select an Agent: <span class="MandatoryMark">*</span> </asp:label> 
                            <asp:DropDownList ID="AgentIdDropDownList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="AgentIdDropDownList_SelectedIndexChanged"> 
                            <asp:ListItem Text="select an agent"></asp:ListItem>                                                            
                            </asp:DropDownList>&nbsp;                                                    
                       
