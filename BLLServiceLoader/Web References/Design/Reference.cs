﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Irmac.MailingCycle.BLLServiceLoader.Design {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DesignServiceSoap", Namespace="http://irmac.com/webservices/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(object[]))]
    public partial class DesignService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetSummaryOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetListOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetListAllOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDesignStatusesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public DesignService() {
            this.Url = global::Irmac.MailingCycle.BLLServiceLoader.Properties.Settings.Default.Irmac_MailingCycle_BLLServiceLoader_Design_DesignService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetSummaryCompletedEventHandler GetSummaryCompleted;
        
        /// <remarks/>
        public event GetListCompletedEventHandler GetListCompleted;
        
        /// <remarks/>
        public event GetListAllCompletedEventHandler GetListAllCompleted;
        
        /// <remarks/>
        public event UpdateCompletedEventHandler UpdateCompleted;
        
        /// <remarks/>
        public event GetCompletedEventHandler GetCompleted;
        
        /// <remarks/>
        public event DeleteCompletedEventHandler DeleteCompleted;
        
        /// <remarks/>
        public event GetDesignStatusesCompletedEventHandler GetDesignStatusesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://irmac.com/webservices/GetSummary", RequestNamespace="http://irmac.com/webservices/", ResponseNamespace="http://irmac.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] GetSummary() {
            object[] results = this.Invoke("GetSummary", new object[0]);
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public void GetSummaryAsync() {
            this.GetSummaryAsync(null);
        }
        
        /// <remarks/>
        public void GetSummaryAsync(object userState) {
            if ((this.GetSummaryOperationCompleted == null)) {
                this.GetSummaryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSummaryOperationCompleted);
            }
            this.InvokeAsync("GetSummary", new object[0], this.GetSummaryOperationCompleted, userState);
        }
        
        private void OnGetSummaryOperationCompleted(object arg) {
            if ((this.GetSummaryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSummaryCompleted(this, new GetSummaryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://irmac.com/webservices/GetList", RequestNamespace="http://irmac.com/webservices/", ResponseNamespace="http://irmac.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DesignInfo[] GetList(int userId) {
            object[] results = this.Invoke("GetList", new object[] {
                        userId});
            return ((DesignInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetListAsync(int userId) {
            this.GetListAsync(userId, null);
        }
        
        /// <remarks/>
        public void GetListAsync(int userId, object userState) {
            if ((this.GetListOperationCompleted == null)) {
                this.GetListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListOperationCompleted);
            }
            this.InvokeAsync("GetList", new object[] {
                        userId}, this.GetListOperationCompleted, userState);
        }
        
        private void OnGetListOperationCompleted(object arg) {
            if ((this.GetListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetListCompleted(this, new GetListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://irmac.com/webservices/GetListAll", RequestNamespace="http://irmac.com/webservices/", ResponseNamespace="http://irmac.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DesignInfo[] GetListAll(int userId) {
            object[] results = this.Invoke("GetListAll", new object[] {
                        userId});
            return ((DesignInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetListAllAsync(int userId) {
            this.GetListAllAsync(userId, null);
        }
        
        /// <remarks/>
        public void GetListAllAsync(int userId, object userState) {
            if ((this.GetListAllOperationCompleted == null)) {
                this.GetListAllOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListAllOperationCompleted);
            }
            this.InvokeAsync("GetListAll", new object[] {
                        userId}, this.GetListAllOperationCompleted, userState);
        }
        
        private void OnGetListAllOperationCompleted(object arg) {
            if ((this.GetListAllCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetListAllCompleted(this, new GetListAllCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://irmac.com/webservices/Update", RequestNamespace="http://irmac.com/webservices/", ResponseNamespace="http://irmac.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Update(int userId, DesignInfo design) {
            this.Invoke("Update", new object[] {
                        userId,
                        design});
        }
        
        /// <remarks/>
        public void UpdateAsync(int userId, DesignInfo design) {
            this.UpdateAsync(userId, design, null);
        }
        
        /// <remarks/>
        public void UpdateAsync(int userId, DesignInfo design, object userState) {
            if ((this.UpdateOperationCompleted == null)) {
                this.UpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateOperationCompleted);
            }
            this.InvokeAsync("Update", new object[] {
                        userId,
                        design}, this.UpdateOperationCompleted, userState);
        }
        
        private void OnUpdateOperationCompleted(object arg) {
            if ((this.UpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://irmac.com/webservices/Get", RequestNamespace="http://irmac.com/webservices/", ResponseNamespace="http://irmac.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DesignInfo Get(int designId) {
            object[] results = this.Invoke("Get", new object[] {
                        designId});
            return ((DesignInfo)(results[0]));
        }
        
        /// <remarks/>
        public void GetAsync(int designId) {
            this.GetAsync(designId, null);
        }
        
        /// <remarks/>
        public void GetAsync(int designId, object userState) {
            if ((this.GetOperationCompleted == null)) {
                this.GetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOperationCompleted);
            }
            this.InvokeAsync("Get", new object[] {
                        designId}, this.GetOperationCompleted, userState);
        }
        
        private void OnGetOperationCompleted(object arg) {
            if ((this.GetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCompleted(this, new GetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://irmac.com/webservices/Delete", RequestNamespace="http://irmac.com/webservices/", ResponseNamespace="http://irmac.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Delete(int designId, int userId) {
            this.Invoke("Delete", new object[] {
                        designId,
                        userId});
        }
        
        /// <remarks/>
        public void DeleteAsync(int designId, int userId) {
            this.DeleteAsync(designId, userId, null);
        }
        
        /// <remarks/>
        public void DeleteAsync(int designId, int userId, object userState) {
            if ((this.DeleteOperationCompleted == null)) {
                this.DeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteOperationCompleted);
            }
            this.InvokeAsync("Delete", new object[] {
                        designId,
                        userId}, this.DeleteOperationCompleted, userState);
        }
        
        private void OnDeleteOperationCompleted(object arg) {
            if ((this.DeleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://irmac.com/webservices/GetDesignStatuses", RequestNamespace="http://irmac.com/webservices/", ResponseNamespace="http://irmac.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DesignStatusInfo[] GetDesignStatuses(int userId, int category, int status) {
            object[] results = this.Invoke("GetDesignStatuses", new object[] {
                        userId,
                        category,
                        status});
            return ((DesignStatusInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetDesignStatusesAsync(int userId, int category, int status) {
            this.GetDesignStatusesAsync(userId, category, status, null);
        }
        
        /// <remarks/>
        public void GetDesignStatusesAsync(int userId, int category, int status, object userState) {
            if ((this.GetDesignStatusesOperationCompleted == null)) {
                this.GetDesignStatusesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDesignStatusesOperationCompleted);
            }
            this.InvokeAsync("GetDesignStatuses", new object[] {
                        userId,
                        category,
                        status}, this.GetDesignStatusesOperationCompleted, userState);
        }
        
        private void OnGetDesignStatusesOperationCompleted(object arg) {
            if ((this.GetDesignStatusesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDesignStatusesCompleted(this, new GetDesignStatusesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DesignStatusInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DesignInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LookupInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public abstract partial class BaseInfo {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public partial class DesignStatusInfo : BaseInfo {
        
        private int agentIdField;
        
        private string agentNameField;
        
        private string phoneField;
        
        private string categoryField;
        
        private string statusField;
        
        private string lastModifyDateField;
        
        private int daysInStatusField;
        
        /// <remarks/>
        public int AgentId {
            get {
                return this.agentIdField;
            }
            set {
                this.agentIdField = value;
            }
        }
        
        /// <remarks/>
        public string AgentName {
            get {
                return this.agentNameField;
            }
            set {
                this.agentNameField = value;
            }
        }
        
        /// <remarks/>
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
        
        /// <remarks/>
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string LastModifyDate {
            get {
                return this.lastModifyDateField;
            }
            set {
                this.lastModifyDateField = value;
            }
        }
        
        /// <remarks/>
        public int DaysInStatus {
            get {
                return this.daysInStatusField;
            }
            set {
                this.daysInStatusField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public partial class DesignInfo : BaseInfo {
        
        private int designIdField;
        
        private int userIdField;
        
        private LookupInfo categoryField;
        
        private LookupInfo typeField;
        
        private SizeF sizeField;
        
        private string genderField;
        
        private string onDesignNameField;
        
        private JustificationType justificationField;
        
        private string gutterField;
        
        private RectangleF messageRectangleField;
        
        private string lowResolutionFileField;
        
        private string highResolutionFileField;
        
        private string extraFileField;
        
        private LookupInfo statusField;
        
        private System.DateTime createDateField;
        
        private System.DateTime lastModifyDateField;
        
        private int lastModifyByField;
        
        private System.DateTime approveDateField;
        
        private int approveByField;
        
        private string commentsField;
        
        private string historyField;
        
        private DesignUsed usedField;
        
        /// <remarks/>
        public int DesignId {
            get {
                return this.designIdField;
            }
            set {
                this.designIdField = value;
            }
        }
        
        /// <remarks/>
        public int UserId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        public LookupInfo Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        public LookupInfo Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public SizeF Size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
        
        /// <remarks/>
        public string Gender {
            get {
                return this.genderField;
            }
            set {
                this.genderField = value;
            }
        }
        
        /// <remarks/>
        public string OnDesignName {
            get {
                return this.onDesignNameField;
            }
            set {
                this.onDesignNameField = value;
            }
        }
        
        /// <remarks/>
        public JustificationType Justification {
            get {
                return this.justificationField;
            }
            set {
                this.justificationField = value;
            }
        }
        
        /// <remarks/>
        public string Gutter {
            get {
                return this.gutterField;
            }
            set {
                this.gutterField = value;
            }
        }
        
        /// <remarks/>
        public RectangleF MessageRectangle {
            get {
                return this.messageRectangleField;
            }
            set {
                this.messageRectangleField = value;
            }
        }
        
        /// <remarks/>
        public string LowResolutionFile {
            get {
                return this.lowResolutionFileField;
            }
            set {
                this.lowResolutionFileField = value;
            }
        }
        
        /// <remarks/>
        public string HighResolutionFile {
            get {
                return this.highResolutionFileField;
            }
            set {
                this.highResolutionFileField = value;
            }
        }
        
        /// <remarks/>
        public string ExtraFile {
            get {
                return this.extraFileField;
            }
            set {
                this.extraFileField = value;
            }
        }
        
        /// <remarks/>
        public LookupInfo Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime LastModifyDate {
            get {
                return this.lastModifyDateField;
            }
            set {
                this.lastModifyDateField = value;
            }
        }
        
        /// <remarks/>
        public int LastModifyBy {
            get {
                return this.lastModifyByField;
            }
            set {
                this.lastModifyByField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime ApproveDate {
            get {
                return this.approveDateField;
            }
            set {
                this.approveDateField = value;
            }
        }
        
        /// <remarks/>
        public int ApproveBy {
            get {
                return this.approveByField;
            }
            set {
                this.approveByField = value;
            }
        }
        
        /// <remarks/>
        public string Comments {
            get {
                return this.commentsField;
            }
            set {
                this.commentsField = value;
            }
        }
        
        /// <remarks/>
        public string History {
            get {
                return this.historyField;
            }
            set {
                this.historyField = value;
            }
        }
        
        /// <remarks/>
        public DesignUsed Used {
            get {
                return this.usedField;
            }
            set {
                this.usedField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public partial class LookupInfo : BaseInfo {
        
        private int lookupIdField;
        
        private string nameField;
        
        /// <remarks/>
        public int LookupId {
            get {
                return this.lookupIdField;
            }
            set {
                this.lookupIdField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public partial class SizeF {
        
        private float widthField;
        
        private float heightField;
        
        /// <remarks/>
        public float Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
            }
        }
        
        /// <remarks/>
        public float Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public enum JustificationType {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        Left,
        
        /// <remarks/>
        Right,
        
        /// <remarks/>
        Center,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public partial class RectangleF {
        
        private PointF locationField;
        
        private SizeF sizeField;
        
        private float xField;
        
        private float yField;
        
        private float widthField;
        
        private float heightField;
        
        /// <remarks/>
        public PointF Location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
        
        /// <remarks/>
        public SizeF Size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
        
        /// <remarks/>
        public float X {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        public float Y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
        
        /// <remarks/>
        public float Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
            }
        }
        
        /// <remarks/>
        public float Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public partial class PointF {
        
        private float xField;
        
        private float yField;
        
        /// <remarks/>
        public float X {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        public float Y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://irmac.com/webservices/")]
    public enum DesignUsed {
        
        /// <remarks/>
        Never,
        
        /// <remarks/>
        Found,
        
        /// <remarks/>
        FoundActive,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetSummaryCompletedEventHandler(object sender, GetSummaryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSummaryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSummaryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetListCompletedEventHandler(object sender, GetListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DesignInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DesignInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetListAllCompletedEventHandler(object sender, GetListAllCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetListAllCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetListAllCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DesignInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DesignInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void UpdateCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetCompletedEventHandler(object sender, GetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DesignInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DesignInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void DeleteCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetDesignStatusesCompletedEventHandler(object sender, GetDesignStatusesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDesignStatusesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDesignStatusesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DesignStatusInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DesignStatusInfo[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591