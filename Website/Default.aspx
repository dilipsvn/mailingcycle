<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" Title="Welcome to Mailing Cycle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPageTitle" Runat="Server" Visible="false">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelMenu" Visible="false" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="homepagelefttext">
	    <span class="head2">
		    Customer Speaks... 
        </span>
        <p>
            &quot;Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed dui felis, accumdsan eget, cursus a, euismod id, tortor. Aenean commodo magna sed mauris lacinia blandit. Cras posuere enim id nisi. Quisque lacus diam, mollis ac, vestibulum eget, laoreet eget, quam. Mauris dapibus urna cursus mi. Vivamus et quam.&quot;-
        </p>
        <p align="right">
            <strong>John Smith, VP <br />Irmac Inc. </strong>
        </p>
        <script type="text/javascript">
        <!--
            function popUp(URL) 
            {
                day = new Date();
                id = day.getTime();
                eval("page" + id + " = window.open(URL, '" + id + "', 'toolbar=0,scrollbars=0,location=0,statusbar=1,menubar=0,resizable=1,width=660,height=570,left = 262,top = 159');");
            }
        //-->
        </script>
        
        <span class="head2">
            How it Works?
        </span>
        <p style="text-align: left; font-weight: bold;">
		    <!--<a href="javascript:popUp('./how-it-works.htm')" title="Click here to view the application demo">-->
		    <a href="javascript:popUp('./mc.html')" title="Click here to view the application demo">
        <span style="font-size: 1em;">
            Click here to view the application demo</span>
            </a>
    
                </div>

	<div class="homepagelefttext">
	    <span class="head2">
	<center>Welcome to Mailing Cycle</center><br />
		    
	    </span>
	    <p>
	        The real-estate industry has been waiting for a solution that is cost-effective and dependable to reach its customer base frequently to inform them of available opportunities in their neighborhood. 
	    </p>
	    <p>
            It takes a number of resources to define mailing strategy, print the material and deliver it to target customers on schedule. 
        </p>
	    <p>
            If all of this were to happen at bare minimal cost, it would be all too difficult to handle. With MailingCycle's award winning solution, we simplify the entire process, it takes a few clicks to set up your mailing plan and start the mailingcycle rolling for your company. 	    
	    </p>
	    <p>
            It is like set it up and forget it! Click on the demo to understand how the process works and how we can help you reduce the overhead involved in reaching to your customers as frequently as you like.	    
	    </p>
    </div>
	<div class="homepagerighttext"> 
	
	    <span class="head2">
		    <center>News & Updates</center>
	    </span>
        <table border="0" cellspacing="2" cellpadding="1" width="100%">
            <tr>
                <td>
                    <p><u>08/20/07:</u> <a href="#">MailingCycle to host Realtors conference in Minneapolis, MN</a></p>
                </td>
            </tr> 
            <tr>
                <td>
                    <p><u>08/13/07:</u> <a href="#">MailingCycle goes to Las Vegas, NV</a> </p>
                </td>
            </tr> 
            <tr>
                <td>
                    <p><u>07/28/07:</u> <a href="#">Kevin Smits named the CEO of MailingCycle.com</a></p>
                </td>
            </tr> 
            <tr>
                <td>
                    <p><u>07/10/07:</u> <a href="#">MailingCycle goes live and adds 165 realtors in the 1st week</a></p>
                </td>
            </tr> 
        </table> 
	    
	
	</div>
	<div></div>
	<br />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Visible="false" Runat="Server">
</asp:Content>