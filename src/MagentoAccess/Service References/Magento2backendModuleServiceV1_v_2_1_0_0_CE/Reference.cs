﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=backendModuleS" +
        "erviceV1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=backendModuleS" +
        "erviceV1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=backendModuleS" +
        "erviceV1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=backendModuleS" +
        "erviceV1")]
    public partial class BackendModuleServiceV1GetModulesResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string[] resultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public string[] result {
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=backendModuleS" +
        "erviceV1")]
    public partial class BackendModuleServiceV1GetModulesRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=backendModuleS" +
        "erviceV1", ConfigurationName="Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1PortType")]
    public interface backendModuleServiceV1PortType {
        
        // CODEGEN: Generating message contract since the operation backendModuleServiceV1GetModules is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="backendModuleServiceV1GetModules", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.GenericFault), Action="backendModuleServiceV1GetModules", Name="GenericFault")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesResponse1 backendModuleServiceV1GetModules(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesRequest1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="backendModuleServiceV1GetModules", ReplyAction="*")]
        System.Threading.Tasks.Task<MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesResponse1> backendModuleServiceV1GetModulesAsync(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesRequest1 request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class backendModuleServiceV1GetModulesRequest1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=backendModuleS" +
            "erviceV1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.BackendModuleServiceV1GetModulesRequest backendModuleServiceV1GetModulesRequest;
        
        public backendModuleServiceV1GetModulesRequest1() {
        }
        
        public backendModuleServiceV1GetModulesRequest1(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.BackendModuleServiceV1GetModulesRequest backendModuleServiceV1GetModulesRequest) {
            this.backendModuleServiceV1GetModulesRequest = backendModuleServiceV1GetModulesRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class backendModuleServiceV1GetModulesResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://hereshouldbeyourmagentostoreurl.com/soap/default?services=backendModuleS" +
            "erviceV1", Order=0)]
        public MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.BackendModuleServiceV1GetModulesResponse backendModuleServiceV1GetModulesResponse;
        
        public backendModuleServiceV1GetModulesResponse1() {
        }
        
        public backendModuleServiceV1GetModulesResponse1(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.BackendModuleServiceV1GetModulesResponse backendModuleServiceV1GetModulesResponse) {
            this.backendModuleServiceV1GetModulesResponse = backendModuleServiceV1GetModulesResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface backendModuleServiceV1PortTypeChannel : MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1PortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class backendModuleServiceV1PortTypeClient : System.ServiceModel.ClientBase<MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1PortType>, MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1PortType {
        
        public backendModuleServiceV1PortTypeClient() {
        }
        
        public backendModuleServiceV1PortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public backendModuleServiceV1PortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public backendModuleServiceV1PortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public backendModuleServiceV1PortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesResponse1 MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1PortType.backendModuleServiceV1GetModules(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesRequest1 request) {
            return base.Channel.backendModuleServiceV1GetModules(request);
        }
        
        public MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.BackendModuleServiceV1GetModulesResponse backendModuleServiceV1GetModules(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.BackendModuleServiceV1GetModulesRequest backendModuleServiceV1GetModulesRequest) {
            MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesRequest1 inValue = new MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesRequest1();
            inValue.backendModuleServiceV1GetModulesRequest = backendModuleServiceV1GetModulesRequest;
            MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesResponse1 retVal = ((MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1PortType)(this)).backendModuleServiceV1GetModules(inValue);
            return retVal.backendModuleServiceV1GetModulesResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesResponse1> MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1PortType.backendModuleServiceV1GetModulesAsync(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesRequest1 request) {
            return base.Channel.backendModuleServiceV1GetModulesAsync(request);
        }
        
        public System.Threading.Tasks.Task<MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesResponse1> backendModuleServiceV1GetModulesAsync(MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.BackendModuleServiceV1GetModulesRequest backendModuleServiceV1GetModulesRequest) {
            MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesRequest1 inValue = new MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1GetModulesRequest1();
            inValue.backendModuleServiceV1GetModulesRequest = backendModuleServiceV1GetModulesRequest;
            return ((MagentoAccess.Magento2backendModuleServiceV1_v_2_1_0_0_CE.backendModuleServiceV1PortType)(this)).backendModuleServiceV1GetModulesAsync(inValue);
        }
    }
}
