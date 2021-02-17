﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace Irmac.MailingCycle.BLLServiceLoader.ShoppingCart {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ShoppingCartServiceSoap", Namespace="http://mc.mkbedev.com/BLLService/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseInfo))]
    public partial class ShoppingCartService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCartItemsOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertCartItemOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateCartItemOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteCartItemOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPromotionDiscountOperationCompleted;
        
        private System.Threading.SendOrPostCallback CalculateGrandTotalOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ShoppingCartService() {
            this.Url = "http://mc1.mkbedev.com/BLLService/ShoppingCartService.asmx";
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
        public event GetCartItemsCompletedEventHandler GetCartItemsCompleted;
        
        /// <remarks/>
        public event InsertCartItemCompletedEventHandler InsertCartItemCompleted;
        
        /// <remarks/>
        public event UpdateCartItemCompletedEventHandler UpdateCartItemCompleted;
        
        /// <remarks/>
        public event DeleteCartItemCompletedEventHandler DeleteCartItemCompleted;
        
        /// <remarks/>
        public event GetPromotionDiscountCompletedEventHandler GetPromotionDiscountCompleted;
        
        /// <remarks/>
        public event CalculateGrandTotalCompletedEventHandler CalculateGrandTotalCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mc.mkbedev.com/BLLService/GetCartItems", RequestNamespace="http://mc.mkbedev.com/BLLService/", ResponseNamespace="http://mc.mkbedev.com/BLLService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ShoppingCartInfo GetCartItems(int userId) {
            object[] results = this.Invoke("GetCartItems", new object[] {
                        userId});
            return ((ShoppingCartInfo)(results[0]));
        }
        
        /// <remarks/>
        public void GetCartItemsAsync(int userId) {
            this.GetCartItemsAsync(userId, null);
        }
        
        /// <remarks/>
        public void GetCartItemsAsync(int userId, object userState) {
            if ((this.GetCartItemsOperationCompleted == null)) {
                this.GetCartItemsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCartItemsOperationCompleted);
            }
            this.InvokeAsync("GetCartItems", new object[] {
                        userId}, this.GetCartItemsOperationCompleted, userState);
        }
        
        private void OnGetCartItemsOperationCompleted(object arg) {
            if ((this.GetCartItemsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCartItemsCompleted(this, new GetCartItemsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mc.mkbedev.com/BLLService/InsertCartItem", RequestNamespace="http://mc.mkbedev.com/BLLService/", ResponseNamespace="http://mc.mkbedev.com/BLLService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool InsertCartItem(ShoppingCartItemInfo cartInfo, int ownerId) {
            object[] results = this.Invoke("InsertCartItem", new object[] {
                        cartInfo,
                        ownerId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void InsertCartItemAsync(ShoppingCartItemInfo cartInfo, int ownerId) {
            this.InsertCartItemAsync(cartInfo, ownerId, null);
        }
        
        /// <remarks/>
        public void InsertCartItemAsync(ShoppingCartItemInfo cartInfo, int ownerId, object userState) {
            if ((this.InsertCartItemOperationCompleted == null)) {
                this.InsertCartItemOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertCartItemOperationCompleted);
            }
            this.InvokeAsync("InsertCartItem", new object[] {
                        cartInfo,
                        ownerId}, this.InsertCartItemOperationCompleted, userState);
        }
        
        private void OnInsertCartItemOperationCompleted(object arg) {
            if ((this.InsertCartItemCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertCartItemCompleted(this, new InsertCartItemCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mc.mkbedev.com/BLLService/UpdateCartItem", RequestNamespace="http://mc.mkbedev.com/BLLService/", ResponseNamespace="http://mc.mkbedev.com/BLLService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ShoppingCartInfo UpdateCartItem(ShoppingCartItemInfo[] cartInfo, int ownerId) {
            object[] results = this.Invoke("UpdateCartItem", new object[] {
                        cartInfo,
                        ownerId});
            return ((ShoppingCartInfo)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateCartItemAsync(ShoppingCartItemInfo[] cartInfo, int ownerId) {
            this.UpdateCartItemAsync(cartInfo, ownerId, null);
        }
        
        /// <remarks/>
        public void UpdateCartItemAsync(ShoppingCartItemInfo[] cartInfo, int ownerId, object userState) {
            if ((this.UpdateCartItemOperationCompleted == null)) {
                this.UpdateCartItemOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateCartItemOperationCompleted);
            }
            this.InvokeAsync("UpdateCartItem", new object[] {
                        cartInfo,
                        ownerId}, this.UpdateCartItemOperationCompleted, userState);
        }
        
        private void OnUpdateCartItemOperationCompleted(object arg) {
            if ((this.UpdateCartItemCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCartItemCompleted(this, new UpdateCartItemCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mc.mkbedev.com/BLLService/DeleteCartItem", RequestNamespace="http://mc.mkbedev.com/BLLService/", ResponseNamespace="http://mc.mkbedev.com/BLLService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ShoppingCartInfo DeleteCartItem(int userId, string productId, int ownerId) {
            object[] results = this.Invoke("DeleteCartItem", new object[] {
                        userId,
                        productId,
                        ownerId});
            return ((ShoppingCartInfo)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteCartItemAsync(int userId, string productId, int ownerId) {
            this.DeleteCartItemAsync(userId, productId, ownerId, null);
        }
        
        /// <remarks/>
        public void DeleteCartItemAsync(int userId, string productId, int ownerId, object userState) {
            if ((this.DeleteCartItemOperationCompleted == null)) {
                this.DeleteCartItemOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteCartItemOperationCompleted);
            }
            this.InvokeAsync("DeleteCartItem", new object[] {
                        userId,
                        productId,
                        ownerId}, this.DeleteCartItemOperationCompleted, userState);
        }
        
        private void OnDeleteCartItemOperationCompleted(object arg) {
            if ((this.DeleteCartItemCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCartItemCompleted(this, new DeleteCartItemCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mc.mkbedev.com/BLLService/GetPromotionDiscount", RequestNamespace="http://mc.mkbedev.com/BLLService/", ResponseNamespace="http://mc.mkbedev.com/BLLService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ShoppingCartInfo GetPromotionDiscount(ShoppingCartInfo cartInfo) {
            object[] results = this.Invoke("GetPromotionDiscount", new object[] {
                        cartInfo});
            return ((ShoppingCartInfo)(results[0]));
        }
        
        /// <remarks/>
        public void GetPromotionDiscountAsync(ShoppingCartInfo cartInfo) {
            this.GetPromotionDiscountAsync(cartInfo, null);
        }
        
        /// <remarks/>
        public void GetPromotionDiscountAsync(ShoppingCartInfo cartInfo, object userState) {
            if ((this.GetPromotionDiscountOperationCompleted == null)) {
                this.GetPromotionDiscountOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPromotionDiscountOperationCompleted);
            }
            this.InvokeAsync("GetPromotionDiscount", new object[] {
                        cartInfo}, this.GetPromotionDiscountOperationCompleted, userState);
        }
        
        private void OnGetPromotionDiscountOperationCompleted(object arg) {
            if ((this.GetPromotionDiscountCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPromotionDiscountCompleted(this, new GetPromotionDiscountCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mc.mkbedev.com/BLLService/CalculateGrandTotal", RequestNamespace="http://mc.mkbedev.com/BLLService/", ResponseNamespace="http://mc.mkbedev.com/BLLService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ShoppingCartInfo CalculateGrandTotal(ShoppingCartInfo cartInfo) {
            object[] results = this.Invoke("CalculateGrandTotal", new object[] {
                        cartInfo});
            return ((ShoppingCartInfo)(results[0]));
        }
        
        /// <remarks/>
        public void CalculateGrandTotalAsync(ShoppingCartInfo cartInfo) {
            this.CalculateGrandTotalAsync(cartInfo, null);
        }
        
        /// <remarks/>
        public void CalculateGrandTotalAsync(ShoppingCartInfo cartInfo, object userState) {
            if ((this.CalculateGrandTotalOperationCompleted == null)) {
                this.CalculateGrandTotalOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCalculateGrandTotalOperationCompleted);
            }
            this.InvokeAsync("CalculateGrandTotal", new object[] {
                        cartInfo}, this.CalculateGrandTotalOperationCompleted, userState);
        }
        
        private void OnCalculateGrandTotalOperationCompleted(object arg) {
            if ((this.CalculateGrandTotalCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CalculateGrandTotalCompleted(this, new CalculateGrandTotalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://mc.mkbedev.com/BLLService/")]
    public partial class ShoppingCartInfo : BaseInfo {
        
        private decimal grandTotalField;
        
        private decimal discountField;
        
        private string promotionCodeField;
        
        private decimal taxField;
        
        private decimal shippingAndHandlingField;
        
        private decimal subTotalField;
        
        private ShoppingCartItemInfo[] cartItemsField;
        
        /// <remarks/>
        public decimal GrandTotal {
            get {
                return this.grandTotalField;
            }
            set {
                this.grandTotalField = value;
            }
        }
        
        /// <remarks/>
        public decimal Discount {
            get {
                return this.discountField;
            }
            set {
                this.discountField = value;
            }
        }
        
        /// <remarks/>
        public string PromotionCode {
            get {
                return this.promotionCodeField;
            }
            set {
                this.promotionCodeField = value;
            }
        }
        
        /// <remarks/>
        public decimal Tax {
            get {
                return this.taxField;
            }
            set {
                this.taxField = value;
            }
        }
        
        /// <remarks/>
        public decimal ShippingAndHandling {
            get {
                return this.shippingAndHandlingField;
            }
            set {
                this.shippingAndHandlingField = value;
            }
        }
        
        /// <remarks/>
        public decimal SubTotal {
            get {
                return this.subTotalField;
            }
            set {
                this.subTotalField = value;
            }
        }
        
        /// <remarks/>
        public ShoppingCartItemInfo[] CartItems {
            get {
                return this.cartItemsField;
            }
            set {
                this.cartItemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://mc.mkbedev.com/BLLService/")]
    public partial class ShoppingCartItemInfo : BaseInfo {
        
        private int userIdField;
        
        private decimal totalPriceField;
        
        private decimal priceField;
        
        private int quantityField;
        
        private string descriptionField;
        
        private string productIdField;
        
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
        public decimal TotalPrice {
            get {
                return this.totalPriceField;
            }
            set {
                this.totalPriceField = value;
            }
        }
        
        /// <remarks/>
        public decimal Price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
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
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string ProductId {
            get {
                return this.productIdField;
            }
            set {
                this.productIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ShoppingCartItemInfo))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ShoppingCartInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://mc.mkbedev.com/BLLService/")]
    public abstract partial class BaseInfo {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetCartItemsCompletedEventHandler(object sender, GetCartItemsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCartItemsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCartItemsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ShoppingCartInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ShoppingCartInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void InsertCartItemCompletedEventHandler(object sender, InsertCartItemCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertCartItemCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertCartItemCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void UpdateCartItemCompletedEventHandler(object sender, UpdateCartItemCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateCartItemCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateCartItemCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ShoppingCartInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ShoppingCartInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void DeleteCartItemCompletedEventHandler(object sender, DeleteCartItemCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteCartItemCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteCartItemCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ShoppingCartInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ShoppingCartInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetPromotionDiscountCompletedEventHandler(object sender, GetPromotionDiscountCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPromotionDiscountCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPromotionDiscountCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ShoppingCartInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ShoppingCartInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void CalculateGrandTotalCompletedEventHandler(object sender, CalculateGrandTotalCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CalculateGrandTotalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CalculateGrandTotalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ShoppingCartInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ShoppingCartInfo)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591