﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=integrationAdm" +
        "inTokenServiceV1")]
    public partial class GenericFault : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string traceField;
        
        private GenericFaultParameter[] parametersField;
        
        private WrappedError[] wrappedErrorsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Trace {
            get {
                return this.traceField;
            }
            set {
                this.traceField = value;
                this.RaisePropertyChanged("Trace");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public GenericFaultParameter[] Parameters {
            get {
                return this.parametersField;
            }
            set {
                this.parametersField = value;
                this.RaisePropertyChanged("Parameters");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public WrappedError[] WrappedErrors {
            get {
                return this.wrappedErrorsField;
            }
            set {
                this.wrappedErrorsField = value;
                this.RaisePropertyChanged("WrappedErrors");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=integrationAdm" +
        "inTokenServiceV1")]
    public partial class GenericFaultParameter : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=integrationAdm" +
        "inTokenServiceV1")]
    public partial class WrappedError : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        private GenericFaultParameter[] parametersField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public GenericFaultParameter[] parameters {
            get {
                return this.parametersField;
            }
            set {
                this.parametersField = value;
                this.RaisePropertyChanged("parameters");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=integrationAdm" +
        "inTokenServiceV1")]
    public partial class IntegrationAdminTokenServiceV1CreateAdminAccessTokenResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("result");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=integrationAdm" +
        "inTokenServiceV1")]
    public partial class IntegrationAdminTokenServiceV1CreateAdminAccessTokenRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string usernameField;
        
        private string passwordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("password");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=integrationAdm" +
        "inTokenServiceV1", ConfigurationName="Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV" +
        "1PortType")]
    public interface integrationAdminTokenServiceV1PortType {
        
        // CODEGEN: Generating message contract since the operation integrationAdminTokenServiceV1CreateAdminAccessToken is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="integrationAdminTokenServiceV1CreateAdminAccessToken", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.GenericFault), Action="integrationAdminTokenServiceV1CreateAdminAccessToken", Name="GenericFault")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1 integrationAdminTokenServiceV1CreateAdminAccessToken(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="integrationAdminTokenServiceV1CreateAdminAccessToken", ReplyAction="*")]
        System.Threading.Tasks.Task<MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1> integrationAdminTokenServiceV1CreateAdminAccessTokenAsync(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1 request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=integrationAdm" +
            "inTokenServiceV1", Order=0)]
        public MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.IntegrationAdminTokenServiceV1CreateAdminAccessTokenRequest integrationAdminTokenServiceV1CreateAdminAccessTokenRequest;
        
        public integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1() {
        }
        
        public integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.IntegrationAdminTokenServiceV1CreateAdminAccessTokenRequest integrationAdminTokenServiceV1CreateAdminAccessTokenRequest) {
            this.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest = integrationAdminTokenServiceV1CreateAdminAccessTokenRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=integrationAdm" +
            "inTokenServiceV1", Order=0)]
        public MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.IntegrationAdminTokenServiceV1CreateAdminAccessTokenResponse integrationAdminTokenServiceV1CreateAdminAccessTokenResponse;
        
        public integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1() {
        }
        
        public integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.IntegrationAdminTokenServiceV1CreateAdminAccessTokenResponse integrationAdminTokenServiceV1CreateAdminAccessTokenResponse) {
            this.integrationAdminTokenServiceV1CreateAdminAccessTokenResponse = integrationAdminTokenServiceV1CreateAdminAccessTokenResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface integrationAdminTokenServiceV1PortTypeChannel : MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1PortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class integrationAdminTokenServiceV1PortTypeClient : System.ServiceModel.ClientBase<MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1PortType>, MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1PortType {
        
        public integrationAdminTokenServiceV1PortTypeClient() {
        }
        
        public integrationAdminTokenServiceV1PortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public integrationAdminTokenServiceV1PortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public integrationAdminTokenServiceV1PortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public integrationAdminTokenServiceV1PortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1 MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1PortType.integrationAdminTokenServiceV1CreateAdminAccessToken(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1 request) {
            return base.Channel.integrationAdminTokenServiceV1CreateAdminAccessToken(request);
        }
        
        public MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.IntegrationAdminTokenServiceV1CreateAdminAccessTokenResponse integrationAdminTokenServiceV1CreateAdminAccessToken(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.IntegrationAdminTokenServiceV1CreateAdminAccessTokenRequest integrationAdminTokenServiceV1CreateAdminAccessTokenRequest) {
            MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1 inValue = new MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1();
            inValue.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest = integrationAdminTokenServiceV1CreateAdminAccessTokenRequest;
            MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1 retVal = ((MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1PortType)(this)).integrationAdminTokenServiceV1CreateAdminAccessToken(inValue);
            return retVal.integrationAdminTokenServiceV1CreateAdminAccessTokenResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1> MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1PortType.integrationAdminTokenServiceV1CreateAdminAccessTokenAsync(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1 request) {
            return base.Channel.integrationAdminTokenServiceV1CreateAdminAccessTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenResponse1> integrationAdminTokenServiceV1CreateAdminAccessTokenAsync(MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.IntegrationAdminTokenServiceV1CreateAdminAccessTokenRequest integrationAdminTokenServiceV1CreateAdminAccessTokenRequest) {
            MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1 inValue = new MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest1();
            inValue.integrationAdminTokenServiceV1CreateAdminAccessTokenRequest = integrationAdminTokenServiceV1CreateAdminAccessTokenRequest;
            return ((MagentoAccess.Magento2integrationAdminTokenServiceV1_v_2_1_0_0_CE.integrationAdminTokenServiceV1PortType)(this)).integrationAdminTokenServiceV1CreateAdminAccessTokenAsync(inValue);
        }
    }
}
