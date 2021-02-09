<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftNavMenuWebUserControl.ascx.cs" Inherits="WebUserControls_LeftNavMenuWebUserControl" %>
			    <script type="text/javascript">
			        <!--
			        function openPopupWindow(URL,Height,Width)
			        {
			            day = new Date();
                        id = day.getTime();
                        eval("page" + id + " = window.open(URL, '" + id + "', 'toolbar=0,scrollbars=0,location=0,statusbar=1,menubar=0,resizable=1,width=" + Width + ",height=" + Height + ",left = 102,top = 44');");
			        }
			        //-->
			    </script>
			    <asp:Panel ID="MenuePanelWhenLogin" runat="server" Visible="true">
			    <div id="left-nav">
                    <div class="vertical-menu">
	                    <div class="menu-item"><a id="a_Welcome" runat="server" href="~/Members/Welcome.aspx" >Dashboard</a></div>
	                    <div class="menu-item"><a id="a_FarmManagement" runat="server" href="~/Members/FarmManagement.aspx" >Farm Management </a></div>
	                    <div class="menu-item"><a id="a_UserManagement" runat="server" href="~/Members/SearchUsers.aspx" >User Management </a></div>
	                    <div class="menu-item"><a id="a_DesignManagement" runat="server" href="~/Members/DesignManagement.aspx" >Design Management </a></div>
                        <div class="menu-item"><a id="a_MessageManagement" runat="server" href="~/Members/MessageManagement.aspx" >Message Management </a></div>
                        <div class="menu-item"><a id="a_ScheduleManagement" runat="server" href="~/Members/ScheduleManagement.aspx" >Schedule Management </a></div>
                        <div class="menu-item"><a id="a_ProductCatalog" runat="server" href="~/Members/ProductCatalog.aspx">Product Catalog </a></div>
                        <div class="menu-item"><a id="a_ProductManagement" runat="server" href="~/Members/ProductCatalog.aspx" >Product Management</a></div>
                        <div class="menu-item"><a id="a_OrderManagement" runat="server" href="~/Members/SearchOrders.aspx" >Order Management</a></div>
                        <div class="menu-item"><a id="a_ChangeRegistrationFee" runat="server" href="~/Members/ChangeRegistrationFee.aspx" >Change Registration Fee</a></div>
                        <div class="menu-item"><a id="a_ShoppingCart" runat="server" href="~/Members/ShoppingCart.aspx" >Shopping Cart </a></div>
                        <div class="menu-item"><a id="a_SearchFarmData" runat="server" href="~/Members/SearchFarmData.aspx" >Search Farm Data </a></div>
                        <div class="menu-item"><a id="a_BillingHistory" runat="server" href="~/Members/BillingHistory.aspx" >Billing History </a></div>
                        <div class="menu-item"><a id="a_SearchOrders" runat="server" href="~/Members/SearchOrders.aspx" >Search Orders</a></div>
                        <div class="menu-item"><a id="a_Inventory" runat="server" href="~/Members/Inventory.aspx" >Inventory</a></div>
                        <div class="menu-item"><a id="a_AuditTrail" runat="server" href="javascript: alert('Under development.'); //remove upto here~/Members/AuditTrail.aspx" >Audit Trail</a></div>
                        <div class="menu-item" onmouseover="showMenu('menu_AgentReports')" onmouseout="hideMenu('menu_AgentReports')"><a id="a_AgentReports" href="JavaScript: void(0);" runat="server">Agent Reports &gt;&gt; </a>
                            <div id="menu_AgentReports" class="submenularge">
                                <div class="menu-item"><a id="a_rep_BillingHistory" runat="server" href="~/Members/BillingHistoryReportCriteria.aspx">Billing History</a></div>
		                        <div class="menu-item"><a id="a_rep_ScheduleManagement" runat="server" href="~/Members/ScheduleMgmtReportCriteria.aspx">Schedule Management</a></div>
		                        <div class="menu-item"><a id="a_rep_Inventory" runat="server" href="~/Members/InventoryReportCriteria.aspx">Inventory</a></div>
		                        <div class="menu-item"><a id="a_rep_FarmPlot" runat="server" href="javascript:openPopupWindow('FarmPlotContactReport.aspx','640','820');">Farm Plot</a></div>
		                        <div class="menu-item"><a id="a_ContactList" runat="server" href="javascript:openPopupWindow('ContactListReport.aspx','640','820');">Contact List</a></div>
                            </div>
                        </div>
                        <div class="menu-item" onmouseover="showMenu('menu_PrinterReports')" onmouseout="hideMenu('menu_PrinterReports')"><a id="a_PrinterReports" href="javascript: void(0)" runat="server">Reports &gt;&gt; </a>
                            <div id="menu_PrinterReports" class="submenularge">
                                <div class="menu-item"><a id="a_rep_AgentFirmupStatus" runat="server" href="~/Members/FirmUpStatus.aspx">Agent Firmup Status</a></div>
		                        <div class="menu-item"><a id="a_rep_DesignStatus" runat="server" href="~/Members/DesignStatusReportCriteria.aspx">Design Status</a></div>
		                        <div class="menu-item"><a id="a_rep_FarmData" runat="server" href="~/Members/FarmDataReportCriteria.aspx">Farm Data</a></div>
		                        <div class="menu-item"><a id="a_rep_Message" runat="server" href="~/Members/MessagesReportCriteria.aspx">Message</a></div>
		                        <div class="menu-item"><a id="a_rep_ScheduleEvents" runat="server" href="~/Members/ScheduleEventsReportCriteria.aspx">Schedule & Events</a></div>
                            </div>
                        </div>
                        <div class="menu-item" onmouseover="showMenu('menu_MyAccount')" onmouseout="hideMenu('menu_MyAccount')"><a href="javascript: void(0);" id="a_MyAccount" runat="server">My Account &gt;&gt; </a>
                            <div id="menu_MyAccount" class="submenu">
                                <div class="menu-item"><a id="a_ChangeUserPassword" runat="server" href="~/Members/ChangeUserPassword.aspx">Change Password</a></div>
                                <div class="menu-item"><a id="a_ChangeProfile" runat="server" href="~/Members/ChangeProfile.aspx">Update Profile</a></div>
                                <div class="menu-item"><a id="a_ChangeCreditCard" runat="server" href="~/Members/ChangeCreditCard.aspx">Update Credit Card</a></div>
                                <div class="menu-item"><a id="a_ChangeSecurityQuestion" runat="server" href="~/Members/ChangeSecurityQuestion.aspx">Change Secret Question</a></div>
                            </div>  
                        </div>
	                </div>
	                <p>&nbsp;</p>
	                <p>&nbsp;</p>
	                <p>&nbsp;</p>
	                <script type="text/javascript">
	                <!--
	                    function findAncorTagElement(tagId)
	                    {
	                        var ancorElement;
	                        var indexId = "";
	                        var allAncorTags = document.getElementsByTagName("a");
	                        //document.getElementById(i).style.cssText.color
	                        for(i = 0; i < allAncorTags.length; i++)
	                        {
	                            indexId = allAncorTags[i].id;
	                            if(indexId.indexOf(tagId) > 0)
	                                ancorElement = allAncorTags[i];
	                        }
	                        return ancorElement;
	                    }
	                    
	                    function setLinkColor(tagId)
	                    {
	                        //findAncorTagElement(tagId).style.cssText = "left-nav .vertical-menu .menu-item a:hover";
	                        //findAncorTagElement(tagId).style.backgroundColor = mcMenuHighlightColor;
	                        findAncorTagElement(tagId).style.fontWeight = "bold";
	                        findAncorTagElement(tagId).style.color = "red";
	                    }
	                    
			    var mcMenuHighlightColor = "#CC3300";
	                    var mcDocLoc = document.location.toString();
	                    
	                    if(mcDocLoc.indexOf("Welcome.aspx") > 0)
	                        setLinkColor('a_Welcome');
	                    else if(mcDocLoc.indexOf("ViewContact.aspx") > 0)
	                    {
	                        if(document.URL.indexOf("parentPage=SearchFarmData.aspx") > 0)
	                            setLinkColor("a_SearchFarmData");
	                        else
	                            setLinkColor("a_FarmManagement");
	                    }
	                    else if(mcDocLoc.indexOf("FarmManagement.aspx") > 0 || mcDocLoc.indexOf("ViewFarm.aspx") > 0 || mcDocLoc.indexOf("ViewPlot.aspx") > 0
	                    || mcDocLoc.indexOf("CreateFarm.aspx") > 0 || mcDocLoc.indexOf("CreatePlot.aspx") > 0
	                    || mcDocLoc.indexOf("ModifyFarm.aspx") > 0 || mcDocLoc.indexOf("CreateContact.aspx") > 0 || mcDocLoc.indexOf("ArchivedContactList.aspx") > 0
	                    || mcDocLoc.indexOf("ArchivedFarmList.aspx") > 0 || mcDocLoc.indexOf("ArchivedPlotList.aspx") > 0 || mcDocLoc.indexOf("ContactManagement.aspx") > 0
	                    || mcDocLoc.indexOf("ModifyContact.aspx") > 0 || mcDocLoc.indexOf("ModifyPlot.aspx") > 0 || mcDocLoc.indexOf("ModifyUser.aspx") > 0
	                    || mcDocLoc.indexOf("MoveContacts.aspx") > 0 || mcDocLoc.indexOf("PlotManagement.aspx") > 0 || mcDocLoc.indexOf("FirmUp.aspx") > 0 )
	                        setLinkColor("a_FarmManagement");
	                    else if(mcDocLoc.indexOf("DesignManagement.aspx") > 0 || mcDocLoc.indexOf("EditBrochure.aspx") > 0 || mcDocLoc.indexOf("DesignExtractor.aspx") > 0
	                    || mcDocLoc.indexOf("DesignPageExtractor.aspx") > 0 || mcDocLoc.indexOf("EditDesign.aspx") > 0 )
	                        setLinkColor("a_DesignManagement");
	                    else if(mcDocLoc.indexOf("MessageManagement.aspx") > 0 || mcDocLoc.indexOf("CreateCustomMessage.aspx") > 0
	                    || mcDocLoc.indexOf("CreateStandardMessage.aspx") > 0 || mcDocLoc.indexOf("CustomMessages.aspx") > 0
	                    || mcDocLoc.indexOf("CustomMessages.aspx") > 0 || mcDocLoc.indexOf("ViewStandardMessage.aspx") > 0 || mcDocLoc.indexOf("ViewCustomMessage.aspx") > 0)
	                        setLinkColor("a_MessageManagement");   
	                    else if(mcDocLoc.indexOf("ScheduleManagement.aspx") > 0 || mcDocLoc.indexOf("AssignMessage.aspx") > 0
	                    || mcDocLoc.indexOf("PreviewMessage.aspx") > 0 || mcDocLoc.indexOf("ViewEvents.aspx") > 0 || mcDocLoc.indexOf("ViewEvent.aspx") > 0)
	                        setLinkColor("a_ScheduleManagement");   
	                    else if(mcDocLoc.indexOf("ProductCatalog.aspx") > 0 || mcDocLoc.indexOf("CreateProduct.aspx") > 0 
	                    || mcDocLoc.indexOf("ProductList.aspx") > 0 || mcDocLoc.indexOf("ViewProduct.aspx") > 0)
	                    {
	                        if(findAncorTagElement("a_ProductCatalog") != null)
	                            setLinkColor("a_ProductCatalog");   
	                        else
	                            setLinkColor("a_ProductManagement");   
	                    }
	                    else if(mcDocLoc.indexOf("SearchOrders.aspx") > 0 )
	                    {
	                        if(findAncorTagElement("a_OrderManagement") != null)
	                            setLinkColor("a_OrderManagement");   
	                        else
	                            setLinkColor("a_SearchOrders");   
	                    }
	                    else if(mcDocLoc.indexOf("ChangeRegistrationFee.aspx") > 0 )
	                        setLinkColor("a_ChangeRegistrationFee");   
	                    else if(mcDocLoc.indexOf("ShoppingCart.aspx") > 0 || mcDocLoc.indexOf("Checkout.aspx") > 0
	                    || mcDocLoc.indexOf("CheckoutConf.aspx") > 0)
	                        setLinkColor("a_ShoppingCart");   
	                    else if(mcDocLoc.indexOf("SearchFarmData.aspx") > 0 || mcDocLoc.indexOf("SearchFarmDataResults.aspx") > 0)
	                        setLinkColor("a_SearchFarmData");   
	                    else if(mcDocLoc.indexOf("BillingHistory.aspx") > 0 || mcDocLoc.indexOf("OrderDetails.aspx") > 0 )
	                    {
	                        if(document.URL.indexOf("isFromSearch") > 0)
	                        {
	                            if(findAncorTagElement("a_SearchOrders") != null)
	                                setLinkColor("a_SearchOrders");   
	                            else
	                                setLinkColor("a_OrderManagement");   
	                        }
	                        else
	                            setLinkColor("a_BillingHistory");   
	                    }
	                    else if(mcDocLoc.indexOf("Inventory.aspx") > 0 || mcDocLoc.indexOf("InventoryDetails.aspx") > 0 
	                    )
	                        setLinkColor("a_Inventory");   
                        else if(mcDocLoc.indexOf("FirmUpStatus.aspx") > 0 || mcDocLoc.indexOf("BillingHistoryReportCriteria.aspx") > 0
                        || mcDocLoc.indexOf("ContactListReport.aspx") > 0 || mcDocLoc.indexOf("DesignStatusReport.aspx") > 0 
                        || mcDocLoc.indexOf("DesignStatusReportCriteria.aspx") > 0 || mcDocLoc.indexOf("EventMailingLabelsReport.aspx") > 0 
                        || mcDocLoc.indexOf("FarmDataReport.aspx") > 0 || mcDocLoc.indexOf("FarmDataReportCriteria.aspx") > 0
                        || mcDocLoc.indexOf("FarmPlotContactReport.aspx") > 0 ||mcDocLoc.indexOf("FirmUpStatusReport.aspx") > 0
                        || mcDocLoc.indexOf("InventoryReportCriteria.aspx") > 0 ||mcDocLoc.indexOf("MailingLabelsReport.aspx") > 0
                        || mcDocLoc.indexOf("MailingLabelsReportCriteria.aspx") > 0 || mcDocLoc.indexOf("ScheduleEventsReport.aspx") > 0
                        || mcDocLoc.indexOf("ScheduleEventsReportCriteria.aspx") > 0 || mcDocLoc.indexOf("ScheduleMgmtReport.aspx") > 0
                        || mcDocLoc.indexOf("ScheduleMgmtReportCriteria.aspx") > 0)
                        {
                            if(findAncorTagElement("a_AgentReports") != null)
	                            setLinkColor("a_AgentReports");   	                   
	                        if(findAncorTagElement("a_PrinterReports") != null)
	                            setLinkColor("a_PrinterReports");   	                   
	                    }
	                    else if(mcDocLoc.indexOf("ChangeCreditCard.aspx") > 0 || mcDocLoc.indexOf("ChangeProfile.aspx") > 0
	                    || mcDocLoc.indexOf("ChangeSecurityQuestion.aspx") > 0 || mcDocLoc.indexOf("ChangeUserPassword.aspx") > 0)
	                        setLinkColor("a_MyAccount");   	                   
	                    else if(mcDocLoc.indexOf("SearchUsers.aspx") > 0 )
	                        setLinkColor("a_UserManagement");   	                   
	                //-->
	                </script>
	            </div>
	        </asp:Panel>
	        <asp:Panel ID="MenuePanelTextWhenNotLogin" runat="server" Visible="false">
	            <div id="left-nav-text">
                    <p align="justify" style="background-color:#CCCCCC">
                        <strong>Customer Speaks... </strong>
                    </p>
			        <p align="justify" style="background-color:#CCCCCC">
			            &quot;Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed dui felis, accumdsan eget, cursus a, euismod id, tortor. Aenean commodo magna sed mauris lacinia blandit. Cras posuere enim id nisi. Quisque lacus diam, mollis ac, vestibulum eget, laoreet eget, quam. Mauris dapibus urna cursus mi. Vivamus et quam.&quot;-
			        </p>
			        <p align="right" style="background-color:#CCCCCC">
			            <strong>John Smith, VP <br />Irmac Inc. </strong>
			        </p>
			        <script type="text/javascript">
			        <!--
			            function popUp(URL) 
			            {
                            day = new Date();
                            id = day.getTime();
                            eval("page" + id + " = window.open(URL, '" + id + "', 'toolbar=0,scrollbars=0,location=0,statusbar=1,menubar=0,resizable=1,width=500,height=450,left = 262,top = 159');");
                        }
			        //-->
			        </script>
			        <p style="background-color: #CCCCCC; text-align: center; font-weight: bold;">
			            <!--<a href="javascript:popUp('../how-it-works.htm')" title="Click here to view the application demo">-->
			            <a href="javascript:popUp('../mc.html')" title="Click here to view the application demo">
			                How it Works? <br />
			                <span style="color:BlueViolet; font-size: 0.8em;">Click here to view the application demo</span>
			            </a>
			        </p>
                </div>
	        </asp:Panel>
