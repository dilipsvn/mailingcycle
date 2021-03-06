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

namespace Irmac.MailingCycle.BLLServiceLoader.Acca {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="AccaServiceSoap", Namespace="http://localhost:2676/BLLService/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AccaInfo[]))]
    public partial class AccaService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCreditCardDetailsForScheduledEventsOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateEventInfoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AccaService() {
            this.Url = global::Irmac.MailingCycle.BLLServiceLoader.Properties.Settings.Default.Irmac_MailingCycle_BLLServiceLoader_Acca_AccaService;
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
        public event GetCreditCardDetailsForScheduledEventsCompletedEventHandler GetCreditCardDetailsForScheduledEventsCompleted;
        
        /// <remarks/>
        public event UpdateEventInfoCompletedEventHandler UpdateEventInfoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost:2676/BLLService/GetCreditCardDetailsForScheduledEvents", RequestNamespace="http://localhost:2676/BLLService/", ResponseNamespace="http://localhost:2676/BLLService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public AccaInfo[] GetCreditCardDetailsForScheduledEvents(System.DateTime eventDate) {
            object[] results = this.Invoke("GetCreditCardDetailsForScheduledEvents", new object[] {
                        eventDate});
            return ((AccaInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCreditCardDetailsForScheduledEventsAsync(System.DateTime eventDate) {
            this.GetCreditCardDetailsForScheduledEventsAsync(eventDate, null);
        }
        
        /// <remarks/>
        public void GetCreditCardDetailsForScheduledEventsAsync(System.DateTime eventDate, object userState) {
            if ((this.GetCreditCardDetailsForScheduledEventsOperationCompleted == null)) {
                this.GetCreditCardDetailsForScheduledEventsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCreditCardDetailsForScheduledEventsOperationCompleted);
            }
            this.InvokeAsync("GetCreditCardDetailsForScheduledEvents", new object[] {
                        eventDate}, this.GetCreditCardDetailsForScheduledEventsOperationCompleted, userState);
        }
        
        private void OnGetCreditCardDetailsForScheduledEventsOperationCompleted(object arg) {
            if ((this.GetCreditCardDetailsForScheduledEventsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCreditCardDetailsForScheduledEventsCompleted(this, new GetCreditCardDetailsForScheduledEventsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost:2676/BLLService/UpdateEventInfo", RequestNamespace="http://localhost:2676/BLLService/", ResponseNamespace="http://localhost:2676/BLLService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public AccaInfo[] UpdateEventInfo(AccaInfo[] eventsInfo) {
            object[] results = this.Invoke("UpdateEventInfo", new object[] {
                        eventsInfo});
            return ((AccaInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void UpdateEventInfoAsync(AccaInfo[] eventsInfo) {
            this.UpdateEventInfoAsync(eventsInfo, null);
        }
        
        /// <remarks/>
        public void UpdateEventInfoAsync(AccaInfo[] eventsInfo, object userState) {
            if ((this.UpdateEventInfoOperationCompleted == null)) {
                this.UpdateEventInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateEventInfoOperationCompleted);
            }
            this.InvokeAsync("UpdateEventInfo", new object[] {
                        eventsInfo}, this.UpdateEventInfoOperationCompleted, userState);
        }
        
        private void OnUpdateEventInfoOperationCompleted(object arg) {
            if ((this.UpdateEventInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateEventInfoCompleted(this, new UpdateEventInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public partial class AccaInfo : BaseInfo {
        
        private string postalTariffField;
        
        private string userNameField;
        
        private string planNameField;
        
        private string farmNameField;
        
        private System.DateTime eventDateField;
        
        private OrderInfo accaOrderInfoField;
        
        private string remarksField;
        
        private int userIdField;
        
        private DesignCategory accaDesignCategoryField;
        
        private int contactCountField;
        
        private ScheduleEventStatus eventStatusField;
        
        private int eventIdField;
        
        private CreditCardInfo accaCreditCardInfoField;
        
        /// <remarks/>
        public string PostalTariff {
            get {
                return this.postalTariffField;
            }
            set {
                this.postalTariffField = value;
            }
        }
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string PlanName {
            get {
                return this.planNameField;
            }
            set {
                this.planNameField = value;
            }
        }
        
        /// <remarks/>
        public string FarmName {
            get {
                return this.farmNameField;
            }
            set {
                this.farmNameField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime EventDate {
            get {
                return this.eventDateField;
            }
            set {
                this.eventDateField = value;
            }
        }
        
        /// <remarks/>
        public OrderInfo AccaOrderInfo {
            get {
                return this.accaOrderInfoField;
            }
            set {
                this.accaOrderInfoField = value;
            }
        }
        
        /// <remarks/>
        public string Remarks {
            get {
                return this.remarksField;
            }
            set {
                this.remarksField = value;
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
        public DesignCategory AccaDesignCategory {
            get {
                return this.accaDesignCategoryField;
            }
            set {
                this.accaDesignCategoryField = value;
            }
        }
        
        /// <remarks/>
        public int ContactCount {
            get {
                return this.contactCountField;
            }
            set {
                this.contactCountField = value;
            }
        }
        
        /// <remarks/>
        public ScheduleEventStatus EventStatus {
            get {
                return this.eventStatusField;
            }
            set {
                this.eventStatusField = value;
            }
        }
        
        /// <remarks/>
        public int EventId {
            get {
                return this.eventIdField;
            }
            set {
                this.eventIdField = value;
            }
        }
        
        /// <remarks/>
        public CreditCardInfo AccaCreditCardInfo {
            get {
                return this.accaCreditCardInfoField;
            }
            set {
                this.accaCreditCardInfoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public partial class OrderInfo : BaseInfo {
        
        private decimal refundAmountField;
        
        private bool transactionStatusField;
        
        private int orderIdField;
        
        private object numberField;
        
        private OrderType typeField;
        
        private System.DateTime dateField;
        
        private decimal amountField;
        
        private int transactionCodeField;
        
        private string transactionMessageField;
        
        private CreditCardInfo creditCardField;
        
        private OrderItemInfo[] itemsField;
        
        private string userNameField;
        
        /// <remarks/>
        public decimal RefundAmount {
            get {
                return this.refundAmountField;
            }
            set {
                this.refundAmountField = value;
            }
        }
        
        /// <remarks/>
        public bool TransactionStatus {
            get {
                return this.transactionStatusField;
            }
            set {
                this.transactionStatusField = value;
            }
        }
        
        /// <remarks/>
        public int OrderId {
            get {
                return this.orderIdField;
            }
            set {
                this.orderIdField = value;
            }
        }
        
        /// <remarks/>
        public object Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
        
        /// <remarks/>
        public OrderType Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        public decimal Amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        /// <remarks/>
        public int TransactionCode {
            get {
                return this.transactionCodeField;
            }
            set {
                this.transactionCodeField = value;
            }
        }
        
        /// <remarks/>
        public string TransactionMessage {
            get {
                return this.transactionMessageField;
            }
            set {
                this.transactionMessageField = value;
            }
        }
        
        /// <remarks/>
        public CreditCardInfo CreditCard {
            get {
                return this.creditCardField;
            }
            set {
                this.creditCardField = value;
            }
        }
        
        /// <remarks/>
        public OrderItemInfo[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StateInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CountryInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AddressInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LookupInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CreditCardInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(OrderItemInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(OrderInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AccaInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public abstract partial class BaseInfo {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public partial class StateInfo : BaseInfo {
        
        private int stateIdField;
        
        private string nameField;
        
        /// <remarks/>
        public int StateId {
            get {
                return this.stateIdField;
            }
            set {
                this.stateIdField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public partial class CountryInfo : BaseInfo {
        
        private int countryIdField;
        
        private string nameField;
        
        private bool isDefaultField;
        
        /// <remarks/>
        public int CountryId {
            get {
                return this.countryIdField;
            }
            set {
                this.countryIdField = value;
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
        
        /// <remarks/>
        public bool IsDefault {
            get {
                return this.isDefaultField;
            }
            set {
                this.isDefaultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public partial class AddressInfo : BaseInfo {
        
        private string address1Field;
        
        private string address2Field;
        
        private string cityField;
        
        private CountryInfo countryField;
        
        private StateInfo stateField;
        
        private string zipField;
        
        private string phoneField;
        
        private string mobileField;
        
        private string faxField;
        
        /// <remarks/>
        public string Address1 {
            get {
                return this.address1Field;
            }
            set {
                this.address1Field = value;
            }
        }
        
        /// <remarks/>
        public string Address2 {
            get {
                return this.address2Field;
            }
            set {
                this.address2Field = value;
            }
        }
        
        /// <remarks/>
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public CountryInfo Country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
        
        /// <remarks/>
        public StateInfo State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public string Zip {
            get {
                return this.zipField;
            }
            set {
                this.zipField = value;
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
        public string Mobile {
            get {
                return this.mobileField;
            }
            set {
                this.mobileField = value;
            }
        }
        
        /// <remarks/>
        public string Fax {
            get {
                return this.faxField;
            }
            set {
                this.faxField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public partial class CreditCardInfo : BaseInfo {
        
        private LookupInfo typeField;
        
        private string numberField;
        
        private string cvvNumberField;
        
        private string holderNameField;
        
        private int expirationMonthField;
        
        private int expirationYearField;
        
        private AddressInfo addressField;
        
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
        public string Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
        
        /// <remarks/>
        public string CvvNumber {
            get {
                return this.cvvNumberField;
            }
            set {
                this.cvvNumberField = value;
            }
        }
        
        /// <remarks/>
        public string HolderName {
            get {
                return this.holderNameField;
            }
            set {
                this.holderNameField = value;
            }
        }
        
        /// <remarks/>
        public int ExpirationMonth {
            get {
                return this.expirationMonthField;
            }
            set {
                this.expirationMonthField = value;
            }
        }
        
        /// <remarks/>
        public int ExpirationYear {
            get {
                return this.expirationYearField;
            }
            set {
                this.expirationYearField = value;
            }
        }
        
        /// <remarks/>
        public AddressInfo Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public partial class OrderItemInfo : BaseInfo {
        
        private string itemIdField;
        
        private string titleField;
        
        private OrderItemType typeField;
        
        private int quantityField;
        
        private decimal rateField;
        
        /// <remarks/>
        public string ItemId {
            get {
                return this.itemIdField;
            }
            set {
                this.itemIdField = value;
            }
        }
        
        /// <remarks/>
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        public OrderItemType Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public int Quantity {
            get {
                return this.quantityField;
            }
            set {
                this.quantityField = value;
            }
        }
        
        /// <remarks/>
        public decimal Rate {
            get {
                return this.rateField;
            }
            set {
                this.rateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public enum OrderItemType {
        
        /// <remarks/>
        Product,
        
        /// <remarks/>
        ProductPackage,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public enum OrderType {
        
        /// <remarks/>
        MembershipFee,
        
        /// <remarks/>
        MailingFee,
        
        /// <remarks/>
        PrePrintedCards,
        
        /// <remarks/>
        ShoppingCart,
        
        /// <remarks/>
        Event,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public enum DesignCategory {
        
        /// <remarks/>
        PowerKard,
        
        /// <remarks/>
        Brochure,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost:2676/BLLService/")]
    public enum ScheduleEventStatus {
        
        /// <remarks/>
        Scheduled,
        
        /// <remarks/>
        InProgress,
        
        /// <remarks/>
        Completed,
        
        /// <remarks/>
        Cancelled,
        
        /// <remarks/>
        ACCAInProgress,
        
        /// <remarks/>
        ACCAError,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetCreditCardDetailsForScheduledEventsCompletedEventHandler(object sender, GetCreditCardDetailsForScheduledEventsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCreditCardDetailsForScheduledEventsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCreditCardDetailsForScheduledEventsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AccaInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AccaInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void UpdateEventInfoCompletedEventHandler(object sender, UpdateEventInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateEventInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateEventInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AccaInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AccaInfo[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591