<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" Title="Mailing Cycle Intro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPageTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHomePage" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeftPanelMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderLeftPanelText" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Xml ID="Xml1" runat="server"></asp:Xml>
<div style="margin:0; padding:0; height:100%; width:100%; margin-top:100px;">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#666666">
  <tr>
    <td><div align="center">
      <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#333333">
        <tr>
          <td width="25%">&nbsp;</td>
          <td width="55%"><div align="center">
            <!--<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="500" height="350" title="Mailing Cycle Intro">
              <param name="movie" value="MCIntro.swf" />
              <param name="quality" value="high" />
              <embed src="MCIntro.swf" pluginspage="http://www.macromedia.com/go/getflashplayer" width="500" height="350"></embed>
            </object>-->
         <embed autostart="0" filename="MCIntro.mp4" height="500" runat="server" ID="Video"
                                pluginspage="http://www.microsoft.com/Windows/Downloads/Contents/MediaPlayer/" 
                                showcontrols="1" showdisplay="1" showstatusbar="1" 
                                 type="application/x-mplayer2" width="350"></embed>
 
            
          </div></td>
          <td width="25%">&nbsp;</td>
        </tr>
      </table>
    </div></td>
    </tr>
</table>
</div>
</asp:Content>

