<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AgentRegistrationFee.aspx.cs" Inherits="AgentRegistrationFee" Title="Mailing Cycle Agent Registration" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="WebUserControls/CreditCardWebUserControl.ascx" TagName="CreditCardWebUserControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftPanelMenu"
    runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHomePage" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPageTitleText"
    runat="server">
    Agent Registration <span style="font-size: 0.8em">(Step 2 of 3)</span>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager id="scriptmanager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript">

    function openHelp(path)
    {
        var iWidth = 450;
        var iHeight = screen.height - 100;
        var iLeft = (screen.width - iWidth) - 12;
        var iTop = ((screen.height - iHeight) / 2) - 20;
        
        var sFeatures = "toolbar=0,scrollbars=1,location=0,statusbar=1,menubar=0,resizable=0,";
        var sSize = "width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + ""
        
        window.open(path, "Help", sFeatures + sSize);
    }
    
    function cancelRegistration()
    {
        if (confirm("Your registration has not been completed. If you do not accept now all the registration data will be lost.\n\nAre you sure you want to cancel your registration?") == true)
            return true;
        else
            return false;
    }
    </script>

    <div class="right-content-mainsection">
        <table class="toptable" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td height="30" class="tableheading">
                    Please fill your payment details in the below form, review and accept the Terms of Service
                </td>
            </tr>
            <tr>
                <td class="rowborder">
                    <img src="../images/transparent.gif" width="1" height="1" /></td>
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
                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:ValidationSummary ID="ErrorValidationSummary" EnableClientScript="true" runat="server" HeaderText="Please correct the below errors:"/>
                            </td>
                        </tr>
                    </table> 
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend class="LegendText">Membership Details</legend>
                                    <table border="0" cellspacing="2" cellpadding="3" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" nowrap>
                                                Membership Fee:
                                            </td>
                                            <td width="78%" class="t3" nowrap>
                                                <span class="Notes">US $</span><asp:Literal ID="MembershipFeeLiteral" runat="server"></asp:Literal> 
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
                    <img src="../Images/spacer.gif" width="1" height="8" /><br />
                    
                    
                    
                    <uc1:CreditCardWebUserControl ID="CreditCardDetails1" runat="server" />
                   
                    <img src="../Images/spacer.gif" width="1" height="8" /><br />
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td>
                                <fieldset>
                                    <table border="0" cellspacing="2" cellpadding="1" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../Images/spacer.gif" width="1" height="1" /></td>
                                        </tr>
                                        <tr>
                                            <td width="22%" class="t2" valign="top" nowrap>
                                                Terms of Service:
                                            </td>
                                            <td width="78%" class="t3">
                                                Please check the Payment information above (feel free to change anything you like),
                                                review the Terms of Service below and indicate your acceptance below.<br />
                                                <br />
                                                <asp:TextBox ID="UserAgreementTextBox" runat="server" TextMode="MultiLine" Rows="15" columns="62" ReadOnly="true">Terms Of Service&#13;&#10;&#13;&#10;IMPORTANT-PLEASE READ CAREFULLY: THIS IS A LEGAL AGREEMENT BETWEEN YOU AND SHARPER AGENT, LLC, A COLORADO LIMITED LIABILITY COMPANY, REGARDING THE SHARPERAGENT WEB SITE (THIS &quot;WEB SITE&quot;). AS USED HEREIN, &quot;WE,&quot; &quot;US,&quot; &quot;OUR&quot; AND &quot;SHARPERAGENT&quot; SHALL MEAN SHARPER AGENT, LLC; &quot;YOU&quot; AND &quot;YOUR&quot; SHALL MEAN THE INDIVIDUAL OR LEGAL ENTITY, AS APPLICABLE, THAT REGISTERS FOR OR USES THIS WEB SITE.&#13;&#10;&#13;&#10;BY REGISTERING AS A USER OF SHARPERAGENT, YOU AGREE TO FOLLOW AND BE BOUND BY THESE TERMS AND CONDITIONS. YOU ARE PERMITTED TO USE, REPRODUCE AND DISTRIBUTE MATERIALS ON THE WEB SITE AS SET FORTH BELOW ONLY UPON THE CONDITION THAT YOU ACCEPT ALL OF THE TERMS CONTAINED IN THESE TERMS OF SERVICE (THE &quot;AGREEMENT&quot;).&#13;&#10;&#13;&#10;IF YOU CLICK THE &quot;Agree&quot; BUTTON, YOU INDICATE YOUR AGREEMENT TO THE TERMS SET FORTH BELOW. IF YOU DO NOT AGREE, OR DO NOT HAVE AUTHORITY TO AGREE, TO THESE TERMS, PLEASE CLICK THE &quot;Disagree&quot; BUTTON TO EXIT REGISTRATION AND CEASE USE OF THIS WEB SITE. IF YOU ARE ENTERING INTO THIS AGREEMENT ON BEHALF OF A COMPANY, YOU REPRESENT AND WARRANT THAT YOU HAVE AUTHORITY TO ENTER INTO THIS AGREEMENT ON BEHALF OF THE COMPANY AND TO BIND THE COMPANY TO ALL OF THE TERMS AND CONDITIONS HEREOF. ANY USE, REPRODUCTION OR DISTRIBUTION OF ANY MATERIALS ON THIS WEB SITE BY YOU OR BY A THIRD PARTY ON YOUR BEHALF CONSTITUTES YOUR ACCEPTANCE OF THIS AGREEMENT.&#13;&#10;&#13;&#10;IF YOUR COMPANY HAS ENTERED INTO A CUSTOMER SALES AGREEMENT WITH SHARPERAGENT, YOU WILL BE BOUND BY APPLICABLE ADDITIONAL TERMS CONTAINED IN THAT CUSTOMER SALES AGREEMENT. IF ANY TERMS OF THE CUSTOMER SALES AGREEMENT CONFLICT WITH THE TERMS OF THIS AGREEMENT, THE TERMS OF THE CUSTOMER SALES AGREEMENT SHALL GOVERN.&#13;&#10;&#13;&#10;1. OPENING USER ACCOUNT; LOGIN AND PASSWORD.&#13;&#10;1.1 To open a user account, you must complete the registration process by providing SHARPERAGENT with current, complete and accurate information as prompted by the registration form. In registering for the user account, you agree to submit accurate, current and complete information about you and your company, and promptly update such information. Should SHARPERAGENT suspect that such information is untrue, inaccurate, not current or incomplete, SHARPERAGENT has the right to suspend or terminate your usage of the user account. Your user account cannot be shared or used by more than one individual.&#13;&#10;&#13;&#10;1.2 Upon registration, you will receive a user name and personal password. You will be responsible for keeping your user name and password confidential. You will notify us immediately upon learning of any unauthorized use of your user name or password. SHARPERAGENT cannot and will not protect you from the unauthorized use of your user name and password. You will be responsible for all activities and charges incurred through the use of your user name and password, and any claims, liability, damages, losses and costs (including reasonable attorneys' fees) resulting from the unauthorized use of your password. Notwithstanding the preceding sentence, you will not be responsible for any activities, charges, claims, liabilities, damages, losses or costs (including reasonable attorneys' fees) that arise from the unauthorized use of your password directly resulting from a grossly negligent act or omission or willful misconduct of SHARPERAGENT.&#13;&#10;&#13;&#10;2. GENERAL USE PROVISIONS.&#13;&#10;2.1 All materials provided on this Web Site, including information, documents, products, logos, graphics, sounds, images, Software (as further defined below) and services (hereinafter, &quot;Materials&quot;), are provided either by SHARPERAGENT or by its respective third party manufacturers, authors, developers and vendors (&quot;Third Party Providers&quot;) and are the copyrighted work of SHARPERAGENT and/or its Third Party Providers. As used herein, the term &quot;Materials&quot; shall not include the Data provided by and generated by you as referenced in Section 5, below. Third Party Providers are intended third party beneficiaries of this Agreement and may enforce the terms of this Agreement against you.&#13;&#10;&#13;&#10;2.2 Subject to the terms and conditions herein, SHARPERAGENT hereby grants you a non-exclusive, non-sublicensable, non-transferable license to use, reproduce and distribute the SHARPERAGENT Materials on this Web Site provided that: (1) the intellectual property notices identified in Section 17 below appear in the Materials; and (2) the use, reproduction, and distribution of such Materials is solely for your own business use, including dissemination to your actual or potential clients or customers, and will not otherwise be distributed, transferred, assigned, provided, or displayed to third parties, posted on any networked computer, mirrored on any third party server or broadcast in any media.&#13;&#10;&#13;&#10;2.3 Except as stated herein, none of the Materials may be copied, reproduced, distributed, republished, downloaded, displayed, posted, transferred, assigned or transmitted in any form or by any means, including electronic, mechanical, photocopying, recording, or other means, without the prior express written permission of SHARPERAGENT or the appropriate Third Party Provider. Except where expressly provided otherwise by SHARPERAGENT, nothing on this Web Site shall be construed to confer any license to any of SHARPERAGENT's or any Third Party Provider's intellectual property rights, whether by estoppel, implication, or otherwise.&#13;&#10;&#13;&#10;3. LINKS TO THIRD PARTY SITES; THIRD PARTY INTERACTION.&#13;&#10;3.1 This Web site may contain links to web sites controlled by parties other than SHARPERAGENT. SHARPERAGENT is not responsible for and does not endorse or accept any responsibility for the contents or use of these third party web sites or any transactions completed through such sites. SHARPERAGENT is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement by SHARPERAGENT of the linked web site, notwithstanding the inclusion on such site of the trademarks of SHARPERAGENT or its Third Party Providers. It is your responsibility to take precautions to ensure that whatever materials you select for your use is sufficient for your purposes and is free of viruses or other items of a destructive nature.&#13;&#10;&#13;&#10;3.2 Materials provided by Third Party Providers on this Web Site have not been independently reviewed, tested, certified, or authenticated in whole or in part by SHARPERAGENT. SHARPERAGENT does not provide, sell, license, or lease any of the Materials other than those specifically identified as being provided by SHARPERAGENT. Any correspondence with, purchase of goods or  services from, participation in third party promotions of such Third Party Providers is solely between you and the applicable Third Party Provider.&#13;&#10;&#13;&#10;4. SOFTWARE USE RESTRICTIONS.&#13;&#10;4.1 Any software that may be made available to download from this Web Site (&quot;Software&quot;) is the copyrighted work of SHARPERAGENT and/or Third Party Providers. Use of the Software is governed by this Agreement, including the terms set forth in this Section (&quot;Software Use Restrictions&quot;). For purposes of this Agreement, &quot;Software&quot; also includes the third party computer software and/or materials provided with or incorporated into the Software, and any related materials or documentation thereto.&#13;&#10;&#13;&#10;4.2 You may (a) install and use one copy of the Software for use by you; (b) use the third party computer software provided with or incorporated into the Software, and any related materials or documentation thereto, only in connection with the individual software programs for which they are licensed and solely for purposes of installing or operating the Software in accordance with the standard documentation accompanying the Software; (c) make one copy of the Software in machine-readable form solely for back-up purposes; and (d) make an additional copy of the Software so that the Software may be used on both one desktop computer and one notebook or portable computer, provided that the Software is used only by you on only one computer at any given time. You must reproduce all proprietary notices on all copies you make. If you are provided with any upgrades or new versions of the Software, you  shall promptly replace, cease using and destroy all superseded copies.&#13;&#10;&#13;&#10;4.3 You and anyone acting on your behalf may not (a) modify, adapt, translate, reverse engineer, decompile, disassemble, derive source code, create derivative works based on, or copy the Software (except as stated above) or the accompanying documentation, except and only to the extent that such activity is expressly permitted by applicable law notwithstanding this limitation; (b) rent, sublicense, loan, transfer, provide, display, distribute or grant any rights in the Software in any form; (c) use the Software for any purpose other than to support your own use; (d) use the third party computer software or materials provided with or incorporated in the Software as stand alone applications or other than with the individual software programs for which they are licensed; (e) remove any proprietary notices, labels or marks in or on the Software; (f) use the Software on any unsupported platform; or (g) use, copy, modify or transfer the Software or any copy, in whole or in part, except as expressly provided in this Agreement.&#13;&#10;&#13;&#10;4.4 Title and copyrights in and to the Software, and any copies thereof, are owned by and remain with SHARPERAGENT and/or its third Party Providers.&#13;&#10;&#13;&#10;5. USER DATA.&#13;&#10;5.1 SHARPERAGENT does not own any Data that you post onto your user account, unless we specifically tell you otherwise beforehand. For the purpose of this Agreement, &quot;Data&quot; means information, data, text, software, music, sound, photographs, graphics, video, messages or other materials, whether publicly posed or privately transmitted. SHARPERAGENT will not monitor or disclose any information regarding you or your account, including any of your Data, without your prior permission except in accordance with this Agreement and the SHARPERAGENT Privacy Policy. SHARPERAGENT may access your account to respond to support related issues.&#13;&#10;&#13;&#10;5.2 If a dispute arises regarding the rights to access to a user account, SHARPERAGENT at its sole discretion may give access to an authorized officer of the company listed as the employer of the primary contact upon written request from such officer on company letterhead or, among other options, withhold disclosure of the user account information to any person until it receives an order of the court. If the named company on a user account is not a legal entity, SHARPERAGENT may presume that the primary contact named on the user account is the only person authorized to access the account.&#13;&#10;&#13;&#10;5.3 You, and not SHARPERAGENT, are responsible for all Data that you upload, post, email, or otherwise transmit via the Web Site. SHARPERAGENT does not control the Data posted via the Web Site and, as such, does not guarantee the accuracy, integrity or quality of such Data. Under no circumstances will SHARPERAGENT be liable in any way for any Data, including for any errors or omissions in any Data, or for any loss or damage of any kind incurred as a result of the use of any Data posted, emailed or otherwise transmitted via the Web Site.&#13;&#10;&#13;&#10;5.4 SHARPERAGENT reserves the right to establish or modify general practices and limits concerning use of the Web Site, including the maximum number of days that Data will be retained in any particular section of the Web Site, and the maximum disk space that will be allotted on SHARPERAGENT's servers on your behalf.&#13;&#10;&#13;&#10;6. SUBMISSIONS. You hereby grant to SHARPERAGENT a perpetual, worldwide, irrevocable, unrestricted, non-exclusive, royalty free license to use, copy, license, sublicense, adapt, distribute, display, publicly perform, reproduce, transmit, modify, edit and otherwise exploit any and all comments, feedback, information or materials regarding this Web Site that you or your agents submit to SHARPERAGENT (&quot;Submissions&quot;). You acknowledge that you are responsible for the Submissions that you provide, and that you, not SHARPERAGENT, have full responsibility for the Submissions.&#13;&#10;&#13;&#10;7. USER CONDUCT.&#13;&#10;7.1 You agree not to use this Web Site to: (a) Upload, post, email or otherwise transmit any Data that is unlawful, harmful, threatening, abusive, harassing, tortuous, defamatory, vulgar, obscene, invasive of another's privacy, hateful, or racially, ethnically or otherwise objectionable; (b) Harm minors in any way; (c) Impersonate any person or entity, including a SHARPERAGENT official, or otherwise misrepresent your affiliation with a person or entity; (d) Upload, post, email, or otherwise transmit any Data that you do not have a right to transmit under any law or under contractual or fiduciary relationships (such as inside information, proprietary and confidential information learned or disclosed a part of employment relationships or under nondisclosure agreements); (e) Upload, post, email, or otherwise transmit any Data that infringes any patent, trademark, trade secret, copyright or other proprietary rights (&quot;Rights&quot;) of any party; (f) Upload, post, email or otherwise transmit any material that contains software viruses or any other computer code, files or programs designed to interrupt, destroy or limit the functionality of any computer software or hardware or telecommunications equipment; (g) Upload, post, email or otherwise transmit any unsolicited or unauthorized advertising, promotional materials, &quot;junk mail,&quot; &quot;spam,&quot; &quot;chain letters,&quot; &quot;pyramid schemes,&quot; or any other form of solicitation; (h) Interfere with or disrupt the Web Site or servers or networks connected to the Web Site, or disobey the requirements, procedures, policies or regulations of networks connected to this Web Site; (i) Intentionally or unintentionally violate any applicable local, state, national or international law; (j) Provide inaccurate, incomplete, outdated or misleading registration information; or (k) Attempt to gain unauthorized access to the Materials, other users' accounts or account information, or other computer systems, servers or networks connected to the Materials or any portion thereof.&#13;&#10;&#13;&#10;7.2 In addition to the prohibitions contained in Section 7.1, (a) all email sent through this Website or sent using the Software shall (i) comply with all elements of the federal CAN-SPAM Act of 2003, (ii) only be sent to recipients that have voluntarily registered to receive emails from you, (iii) contain your physical mailing address, and (iv) contain a link or instructions that allow recipients to remove themselves from your distribution list, (b) you shall not use this Web Site or the Software to send (i) unsolicited bulk email, whether for commercial or non-commercial use, (ii) email to recipients whose email addresses were &quot;scraped&quot; or &quot;aggregated&quot; from other websites, public membership lists, print publications or gathered on any other third party mailing list, and (ii) email that contains any false contact information or any false, misleading or deceptive information or content in the header, subject line or body of the email message.  You shall process any recipient's request to unsubscribe or opt-out from receiving your email within ten (10) business days of such request.  &#13;&#10;&#13;&#10;7.3 In addition to the prohibitions contained in Section 7.1 and 7.2, you shall not use the names of SHARPER AGENT or any Third Party Provider to promote your business or services in any manner, including in the sending of unsolicited email.&#13;&#10;&#13;&#10;7.4 You acknowledge that SHARPERAGENT does not pre-screen Data, but that SHARPERAGENT and its designees shall have the right (but not the obligation) in their sole discretion to refuse or remove any Data that is available via the Web Site. Without limiting the foregoing, SHARPERAGENT and its designees shall have the right to remove any Data that violates the Agreement or is otherwise objectionable. You agree that you must evaluate, and bear all risks associated with, the use of any Data, including any reliance on the accuracy, completeness, or usefulness of such Data.&#13;&#10;&#13;&#10;8. TERMINATION.&#13;&#10;8.1 The licenses granted to you under this Agreement shall terminate automatically without notice immediately upon the breach of any of the terms of this Agreement by you or by any person or entity acting on your behalf, including the failure to make any required payments on a timely basis.  In the event that you breach any of the terms of this Agreement, including, without limitation, the terms contained in Section 7 above, SHARPERAGENT may suspend your access to the Web Site, or (b) terminate this Agreement, or (c) both (a) and (b). &#13;&#10;&#13;&#10;8.2 SHARPERAGENT further reserves the right to terminate this Agreement for any or no reason.&#13;&#10;&#13;&#10;8.3 Upon termination under Sections 8.1 and 8.2, above (i) you must immediately cease using the Materials, (ii) all of the rights granted to you hereunder shall immediately cease, and (iii) you must promptly destroy or erase all copies (including back-up copies) of the Materials.&#13;&#10;&#13;&#10;8.4 Provided that you are not in breach of this Agreement, upon termination of this Agreement, SHARPERAGENT will (a) refund any prepaid charges for the remaining whole months left in the term of your subscription, starting within one month of the termination; and (b) make available a file of your Data for thirty (30) days after termination. Except for the foregoing, SHARPERAGENT shall have no obligation to maintain any Data stored in your account or to forward any Data to you or any third party.&#13;&#10;&#13;&#10;8.5 The following sections of this Agreement shall survive the termination of this Agreement for any reason: 1.2, 2, 3, 4, 5, 6, 8, 10, 11, 12, 13, 14, 15, and 16. &#13;&#10;&#13;&#10;9. PRIVACY POLICY. You hereby acknowledge and accept the SHARPERAGENT Privacy Policy as provided at Privacy Policy, which Policy may be revised from time to time.&#13;&#10;&#13;&#10;10. FEES.&#13;&#10;10.1 You will pay all fees or charges to your account in accordance with the fees, charges and billing terms in effect at the time the fee or charge is due and payable. Fees and charges do not include tax and, where applicable, you agree to pay any sales, use, property, value-added, withholding or other taxes that may be assessed in connection with such fees or charges. Notwithstanding any provisions to the contrary, the legal entity on whose behalf an individual has registered onto this Web Site shall be jointly and severally liable for the activities of, including all fees and charges incurred by, said individual on this Web Site.&#13;&#10;&#13;&#10;10.2 SHARPERAGENT will automatically bill your credit card or invoice your account in advance as follows: (a) every month for monthly subscriptions; (b) every quarter for quarterly subscriptions; or (c) approximately thirty (30) days prior to the anniversary date for annual subscriptions. Subject to the terms herein, all subscriptions shall automatically renew monthly, quarterly or annually in accordance with the monthly, quarterly or annual term then in effect immediately prior to expiration. You will have thirty (30) days prior to any expiration to provide written notice to SHARPERAGENT to cancel or not renew your subscription. All invoices shall be due and payable within thirty (30) days after the invoice date.&#13;&#10;&#13;&#10;10.3 If timely payment is not received or cannot be charged to your credit card for any reason, SHARPERAGENT may (a) suspend your access to the Web Site, including your account, or (b) terminate this Agreement or (c) both (a) and (b). If SHARPERAGENT receives a cancellation notice from you, you will be obligated to pay the balance of fees due on your account under the terms of this Agreement. You agree that SHARPERAGENT may charge such unpaid fees to your credit card or otherwise bill you for such unpaid fees.&#13;&#10;&#13;&#10;11. DISCLAIMER. EXCEPT WHERE EXPRESSLY PROVIDED OTHERWISE BY SHARPERAGENT THE MATERIALS ON THE WEB SITE, INCLUDING BUT NOT LIMITED TO SOFTWARE, ARE PROVIDED &quot;AS IS&quot;, AND ARE FOR COMMERCIAL USE ONLY. WITH REGARD TO SUCH MATERIALS, SHARPERAGENT AND THE THIRD PARTY PROVIDERS MAKE NO WARRANTY REGARDING USE OR PERFORMANCE, AND HEREBY DISCLAIM ALL EXPRESS OR IMPLIED REPRESENTATIONS, WARRANTIES, GUARANTIES AND CONDITIONS, INCLUDING, BUT NOT LIMITED TO, ANY IMPLIED REPRESENTATIONS, WARRANTIES, GUARANTIES AND CONDITIONS OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, TITLE AND NON-INFRINGEMENT, EXCEPT TO THE EXTENT THAT SUCH DISCLAIMERS ARE HELD TO BE LEGALLY INVALID. SHARPERAGENT AND THIRD PARTY PROVIDERS DO NOT WARRANT WITH RESPECT TO THE PERFORMANCE OR RESULTS YOU MAY OBTAIN BY USING THE MATERIALS. SHARPERAGENT AND THE THIRD PARTY PROVIDERS SHALL HAVE NO LIABILITY FOR ANY VIRUSES RELATED TO THE MATERIALS. WITHOUT LIMITING THE GENERALITY OF THE FOREGOING, SHARPERAGENT AND THE THIRD PARTY PROVIDERS DO NOT WARRANT THAT (A) THE MATERIALS WILL MEET YOUR REQUIREMENTS; (B) THE MATERIALS WILL OPERATE OR BE USABLE IN COMBINATION WITH OTHER HARDWARE, SOFTWARE, SYSTEMS, OR DATA; (C) THE OPERATION OR USE OF THE MATERIALS WILL BE UNINTERRUPTED OR ERROR-FREE; OR (D) ANY PROGRAM ERRORS WILL BE CORRECTED. YOU ASSUME ALL RESPONSIBILITY FOR DETERMINING WHETHER THE MATERIALS ARE ACCURATE OR SUFFICIENT FOR YOUR PURPOSES. SHARPERAGENT AND THE THIRD PARTY PROVIDERS DO NOT MAKE ANY REPRESENTATIONS, WARRANTIES, GUARANTIES OR CONDITIONS AS TO THE QUALITY, SUITABILITY, TRUTH, ACCURACY, OR COMPLETENESS OF ANY OF THE MATERIALS CONTAINED ON THIS WEB SITE.&#13;&#10;&#13;&#10;12. LIMITATION OF LIABILITY. SHARPERAGENT AND THE THIRD PARTY PROVIDERS SHALL NOT BE LIABLE FOR ANY DAMAGES SUFFERED AS A RESULT OF USING, MODIFYING, CONTRIBUTING, COPYING, DISTRIBUTING OR DOWNLOADING THE MATERIALS. IN NO EVENT SHALL SHARPERAGENT OR THIRD PARTY PROVIDERS BE LIABLE FOR ANY INDIRECT, PUNITIVE, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES (INCLUDING BUT NOT LIMITED TO LOSS OF BUSINESS, REVENUE, PROFITS, USE, DATA OR OTHER ECONOMIC ADVANTAGE), HOWEVER ARISING, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF ANY MATERIALS AVAILABLE FROM THIS WEB SITE, EVEN IF SHARPERAGENT HAS BEEN PREVIOUSLY ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. YOU HAVE SOLE RESPONSIBILITY FOR THE ADEQUATE PROTECTION AND BACKUP OF DATA AND/OR EQUIPMENT USED IN CONNECTION WITH THIS WEB SITE AND YOU WILL NOT MAKE A CLAIM AGAINST SHARPERAGENT FOR LOST DATA, RE-RUN TIME, INACCURATE OUTPUT, WORK DELAYS, LOST PROFITS, OR LOST OPPORTUNITIES RESULTING FROM THE USE OF THE MATERIALS. WITHOUT DIMINISHING THE GENERALITY OF THE FOREGOING, IN NO CASE SHALL SHARPERAGENT'S LIABILITY TO YOU UNDER ANY CAUSE OF ACTION EXCEED THE TOTAL AMOUNT THAT YOU HAVE PAID TO SHARPERAGENT FOR MATERIALS DURING THE THREE MONTHS IMMEDIATELY PRECEDING THE EVENT GIVING RISE TO THE CAUSE OF ACTION.&#13;&#10;&#13;&#10;13. INDEMNITY. You agree to indemnify and hold SHARPERAGENT and the Third Party Providers harmless from, and you covenant not to sue SHARPERAGENT or Third Party Providers for, any claims based on or related to (a) your negligence, error, omission or willful misconduct, (b) your breach of any terms of this Agreement, (c) any claim by a third party that SHARPERAGENT, due to your use of the Materials, is liable for contributory infringement of a copyright, patent, trade secret, or other proprietary right of a third party, provided that this indemnity will not apply to any claim to the extent the Software delivered by SHARPERAGENT infringes on a proprietary right of a third party, (d) any claim by a third party that Shaper Agent, due to your use of or inability to use the Materials, is liable to a third party in tort or under statutory liability, including, without limitation, defamation, invasion of privacy, spamming or similar theories of law, (d) your use of the Web Site or the Materials, except to the extent due to SHARPERAGENT's gross negligence or willful misconduct.&#13;&#10;&#13;&#10;14. MODIFICATIONS. SHARPERAGENT and the Third Party Providers may make improvements and/or changes in the products, services, Software, and prices described in this Web Site at any time without notice. SHARPERAGENT may make changes to the terms and conditions of the Privacy Policy or other policies relating to the usage of the Web Site at any time and shall notify you by posting an updated version of the policies on the Web Site at least 30 days prior to the implementation of such change. You are responsible for regularly reviewing the policies. Your continued use of this Web Site after any such changes constitute your consent to such changes.&#13;&#10;&#13;&#10;15. NOTICE. SHARPERAGENT may give notice by means of a general notice on the Web Site, electronic mail to your e-mail address on record in SHARPERAGENT's account information, or by written communication sent by first class mail to your address on record with SHARPERAGENT's account information. You may give notice to SHARPERAGENT (such notice shall be deemed given when received by SHARPERAGENT) at any time by any of the following: electronic mail to info@SharperAgent.com or letter delivered by nationally recognized overnight delivery service or first class postage prepaid mail to SHARPERAGENT at Sharper Agent, LLC, 7555 East Hampden Suite 104, Denver, CO  80231.&#13;&#10;&#13;&#10;16. GENERAL. This Web Site may include inaccuracies or typographical errors. The section headings are inserted for convenience of reference only and are not intended to be a part of or to affect the meaning or interpretation of this Agreement. As used in this Agreement, the word &quot;including&quot; means &quot;including but not limited to.&quot; No joint venture, partnership, employment or agency relationship exists between you and SHARPERAGENT as result of this Agreement or through the use of this Web Site. No alteration, amendment, or modification of any of the provisions of this Agreement shall be binding unless made in writing with express reference to this Agreement, and signed by a duly authorized representatives of each party. The failure of SHARPERAGENT to enforce any right or provision of this Agreement shall not constitute a waiver of such right or provision unless acknowledged and agreed to by SHARPERAGENT in writing. If any of the provisions of this Agreement is held by a court of competent jurisdiction to be unenforceable, such provision shall be changed and interpreted to accomplish the objectives of such provision to the greatest extent possible under applicable law and remaining provisions will remain in full force and effect. SHARPERAGENT shall not be liable for any failure to fulfill its obligations hereunder due to causes beyond its reasonable control, including acts or omissions of government or military authority, acts of God, shortages of materials, transportation delays, earthquakes, fires, floods, labor disturbances, riots, or war. This Agreement will be governed by Colorado law and controlling U.S. federal law, without regard to the choice or conflicts of law provisions of any jurisdiction. Any and all disputes, actions, claims, or causes or action related to or in connection with this Agreement or the Web Site shall be brought in the federal and state courts located in Denver, Colorado. This Agreement and any Customer Sales Agreement represent the entire understanding relating to the use of the Web Site &#13;&#10;and prevails over any prior or contemporaneous, conflicting or additional communications, including statements on the Web Site. SHARPERAGENT has the right to assign or transfer this Agreement to a third party which acquires substantially all of the assets of SHARPERAGENT connected with the Web Site. You may not assign or otherwise transfer in whole or in part or in any manner any rights, obligations, or any interest in or under this Agreement without SHARPERAGENT's prior written consent and any attempted assignment will be void. A merger or other acquisition by a third party will be treated as an assignment.&#13;&#10;&#13;&#10;17. INTELLECTUAL PROPERTY NOTICES. You hereby acknowledge the following proprietary notices and legends: Elements of the Web Site are protected by copyright, trademark and other intellectual and industrial property laws and may not be copied or imitated in whole or in part except as provided in this Agreement. No logo, graphic, sound or image from the Web Site may be copied or retransmitted unless expressly permitted by SHARPERAGENT.&#13;&#10;&#13;&#10;SHARPERAGENT, the SHARPERAGENT logo, and/or other SHARPERAGENT brand names for products or services referenced herein are trademarks of Sharper Agent, LLC and may be registered in certain jurisdictions.&#13;&#10;&#13;&#10;18. CONTACT INFORMATION. If you have any questions about this Agreement, please contact SHARPERAGENT Customer Service Department at (303) 331-6240 or Sharper Agent, LLC, 7555 East Hampden Suite 104, Denver, CO  80231.&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;&#9;                                                
                                                </asp:TextBox>
                                                <br />
                                                <br />
                                                By clicking on 'I accept' below you are agreeing to the Terms of Service above.
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
                    <asp:Button CssClass="buttonfont" ID="AcceptButton" runat="server" OnClick="AcceptButton_Click" Text="I accept" Width="80px" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <asp:Button CssClass="buttonfont" ID="DontAcceptButton" runat="server" OnClick="DontAcceptButton_Click" Text="I do not accept" Width="100px" />
                    <img src="../Images/spacer.gif" width="10px" height="1" />
                    <input class="buttonfont" type="button" value="Back" style="width: 80px" onclick="javascript: document.location.href='AgentRegistration.aspx'" />
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
                    <table border="0" cellspacing="2" cellpadding="1" width="98%" align="center">
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                If the payment details are as per your requirements, read and accept the
                                Terms of Service by clicking the <i>'I accept'</i> button.</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                If you wish to change the account or personal details; click the 'Back' button.</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <img width="12" height="8" src="Images/arrow_orange.gif"></td>
                            <td class="Notes">
                                If you would like to cancel the transaction; click on the 'I do not accept' button. If you
                                                cancel all the registration data will be lost.</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../Images/spacer.gif" width="1" height="8" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
