﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRESENTER.ServiceDesktop {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/SERVICE")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceDesktop.IServiceDesktop")]
    public interface IServiceDesktop {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/GetData", ReplyAction="http://tempuri.org/IServiceDesktop/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/GetData", ReplyAction="http://tempuri.org/IServiceDesktop/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IServiceDesktop/GetDataUsingDataContractResponse")]
        PRESENTER.ServiceDesktop.CompositeType GetDataUsingDataContract(PRESENTER.ServiceDesktop.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IServiceDesktop/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<PRESENTER.ServiceDesktop.CompositeType> GetDataUsingDataContractAsync(PRESENTER.ServiceDesktop.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/LibreriaListarCombo", ReplyAction="http://tempuri.org/IServiceDesktop/LibreriaListarComboResponse")]
        ENTITY.Libreria.View.VLibreria[] LibreriaListarCombo(int idGrupo, int idOrden);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/LibreriaListarCombo", ReplyAction="http://tempuri.org/IServiceDesktop/LibreriaListarComboResponse")]
        System.Threading.Tasks.Task<ENTITY.Libreria.View.VLibreria[]> LibreriaListarComboAsync(int idGrupo, int idOrden);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/LibreriaGuardar", ReplyAction="http://tempuri.org/IServiceDesktop/LibreriaGuardarResponse")]
        bool LibreriaGuardar(ENTITY.Libreria.View.VLibreriaLista vlibreria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/LibreriaGuardar", ReplyAction="http://tempuri.org/IServiceDesktop/LibreriaGuardarResponse")]
        System.Threading.Tasks.Task<bool> LibreriaGuardarAsync(ENTITY.Libreria.View.VLibreriaLista vlibreria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteListar", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteListarResponse")]
        ENTITY.Cliente.View.VCliente[] ClienteListar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteListar", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteListarResponse")]
        System.Threading.Tasks.Task<ENTITY.Cliente.View.VCliente[]> ClienteListarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteGuardar", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteGuardarResponse")]
        PRESENTER.ServiceDesktop.ClienteGuardarResponse ClienteGuardar(PRESENTER.ServiceDesktop.ClienteGuardarRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteGuardar", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteGuardarResponse")]
        System.Threading.Tasks.Task<PRESENTER.ServiceDesktop.ClienteGuardarResponse> ClienteGuardarAsync(PRESENTER.ServiceDesktop.ClienteGuardarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteModificar", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteModificarResponse")]
        bool ClienteModificar(ENTITY.Cliente.View.VCliente cliente, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteModificar", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteModificarResponse")]
        System.Threading.Tasks.Task<bool> ClienteModificarAsync(ENTITY.Cliente.View.VCliente cliente, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteEliminar", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteEliminarResponse")]
        bool ClienteEliminar(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteEliminar", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteEliminarResponse")]
        System.Threading.Tasks.Task<bool> ClienteEliminarAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteListar1", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteListar1Response")]
        ENTITY.Cliente.View.VCliente[] ClienteListar1(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClienteListar1", ReplyAction="http://tempuri.org/IServiceDesktop/ClienteListar1Response")]
        System.Threading.Tasks.Task<ENTITY.Cliente.View.VCliente[]> ClienteListar1Async(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClientesListar", ReplyAction="http://tempuri.org/IServiceDesktop/ClientesListarResponse")]
        ENTITY.Cliente.View.VClienteLista[] ClientesListar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ClientesListar", ReplyAction="http://tempuri.org/IServiceDesktop/ClientesListarResponse")]
        System.Threading.Tasks.Task<ENTITY.Cliente.View.VClienteLista[]> ClientesListarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProveedorGuardar", ReplyAction="http://tempuri.org/IServiceDesktop/ProveedorGuardarResponse")]
        PRESENTER.ServiceDesktop.ProveedorGuardarResponse ProveedorGuardar(PRESENTER.ServiceDesktop.ProveedorGuardarRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProveedorGuardar", ReplyAction="http://tempuri.org/IServiceDesktop/ProveedorGuardarResponse")]
        System.Threading.Tasks.Task<PRESENTER.ServiceDesktop.ProveedorGuardarResponse> ProveedorGuardarAsync(PRESENTER.ServiceDesktop.ProveedorGuardarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProveedorListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/ProveedorListarXIdResponse")]
        ENTITY.Proveedor.View.VProveedor[] ProveedorListarXId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProveedorListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/ProveedorListarXIdResponse")]
        System.Threading.Tasks.Task<ENTITY.Proveedor.View.VProveedor[]> ProveedorListarXIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProveedorListar", ReplyAction="http://tempuri.org/IServiceDesktop/ProveedorListarResponse")]
        ENTITY.Proveedor.View.VProveedorLista[] ProveedorListar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProveedorListar", ReplyAction="http://tempuri.org/IServiceDesktop/ProveedorListarResponse")]
        System.Threading.Tasks.Task<ENTITY.Proveedor.View.VProveedorLista[]> ProveedorListarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/Proveedor_01ListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/Proveedor_01ListarXIdResponse")]
        ENTITY.Proveedor.View.VProveedor_01Lista[] Proveedor_01ListarXId(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/Proveedor_01ListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/Proveedor_01ListarXIdResponse")]
        System.Threading.Tasks.Task<ENTITY.Proveedor.View.VProveedor_01Lista[]> Proveedor_01ListarXIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoGuardar", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoGuardarResponse")]
        PRESENTER.ServiceDesktop.ProductoGuardarResponse ProductoGuardar(PRESENTER.ServiceDesktop.ProductoGuardarRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoGuardar", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoGuardarResponse")]
        System.Threading.Tasks.Task<PRESENTER.ServiceDesktop.ProductoGuardarResponse> ProductoGuardarAsync(PRESENTER.ServiceDesktop.ProductoGuardarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoModificar", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoModificarResponse")]
        bool ProductoModificar(ENTITY.Producto.View.VProducto proveedor, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoModificar", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoModificarResponse")]
        System.Threading.Tasks.Task<bool> ProductoModificarAsync(ENTITY.Producto.View.VProducto proveedor, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoEliminar", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoEliminarResponse")]
        bool ProductoEliminar(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoEliminar", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoEliminarResponse")]
        System.Threading.Tasks.Task<bool> ProductoEliminarAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoListarXIdResponse")]
        ENTITY.Producto.View.VProducto[] ProductoListarXId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoListarXIdResponse")]
        System.Threading.Tasks.Task<ENTITY.Producto.View.VProducto[]> ProductoListarXIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoListar", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoListarResponse")]
        ENTITY.Producto.View.VProductoLista[] ProductoListar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoListar", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoListarResponse")]
        System.Threading.Tasks.Task<ENTITY.Producto.View.VProductoLista[]> ProductoListarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoExisteEnCompra", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoExisteEnCompraResponse")]
        bool ProductoExisteEnCompra(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/ProductoExisteEnCompra", ReplyAction="http://tempuri.org/IServiceDesktop/ProductoExisteEnCompraResponse")]
        System.Threading.Tasks.Task<bool> ProductoExisteEnCompraAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/SucursalListarCombo", ReplyAction="http://tempuri.org/IServiceDesktop/SucursalListarComboResponse")]
        ENTITY.inv.Sucursal.View.VSucursalCombo[] SucursalListarCombo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/SucursalListarCombo", ReplyAction="http://tempuri.org/IServiceDesktop/SucursalListarComboResponse")]
        System.Threading.Tasks.Task<ENTITY.inv.Sucursal.View.VSucursalCombo[]> SucursalListarComboAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/PrecioCategoriaListar", ReplyAction="http://tempuri.org/IServiceDesktop/PrecioCategoriaListarResponse")]
        ENTITY.reg.PrecioCategoria.View.VPrecioCategoria[] PrecioCategoriaListar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/PrecioCategoriaListar", ReplyAction="http://tempuri.org/IServiceDesktop/PrecioCategoriaListarResponse")]
        System.Threading.Tasks.Task<ENTITY.reg.PrecioCategoria.View.VPrecioCategoria[]> PrecioCategoriaListarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/PrecioProductoListar", ReplyAction="http://tempuri.org/IServiceDesktop/PrecioProductoListarResponse")]
        ENTITY.reg.Precio.View.VPrecioLista[] PrecioProductoListar(int idSucursal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/PrecioProductoListar", ReplyAction="http://tempuri.org/IServiceDesktop/PrecioProductoListarResponse")]
        System.Threading.Tasks.Task<ENTITY.reg.Precio.View.VPrecioLista[]> PrecioProductoListarAsync(int idSucursal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/CmmpraIngresoListar", ReplyAction="http://tempuri.org/IServiceDesktop/CmmpraIngresoListarResponse")]
        ENTITY.com.CompraIngreso.View.VCompraIngreso[] CmmpraIngresoListar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/CmmpraIngresoListar", ReplyAction="http://tempuri.org/IServiceDesktop/CmmpraIngresoListarResponse")]
        System.Threading.Tasks.Task<ENTITY.com.CompraIngreso.View.VCompraIngreso[]> CmmpraIngresoListarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/CmmpraIngresoListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/CmmpraIngresoListarXIdResponse")]
        ENTITY.com.CompraIngreso.View.VCompraIngresoLista[] CmmpraIngresoListarXId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/CmmpraIngresoListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/CmmpraIngresoListarXIdResponse")]
        System.Threading.Tasks.Task<ENTITY.com.CompraIngreso.View.VCompraIngresoLista[]> CmmpraIngresoListarXIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/CmmpraIngreso_01ListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/CmmpraIngreso_01ListarXIdResponse")]
        ENTITY.com.CompraIngreso_01.VCompraIngreso_01[] CmmpraIngreso_01ListarXId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/CmmpraIngreso_01ListarXId", ReplyAction="http://tempuri.org/IServiceDesktop/CmmpraIngreso_01ListarXIdResponse")]
        System.Threading.Tasks.Task<ENTITY.com.CompraIngreso_01.VCompraIngreso_01[]> CmmpraIngreso_01ListarXIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/CmmpraIngreso_01ListarXId2", ReplyAction="http://tempuri.org/IServiceDesktop/CmmpraIngreso_01ListarXId2Response")]
        ENTITY.com.CompraIngreso_01.VCompraIngreso_01[] CmmpraIngreso_01ListarXId2();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDesktop/CmmpraIngreso_01ListarXId2", ReplyAction="http://tempuri.org/IServiceDesktop/CmmpraIngreso_01ListarXId2Response")]
        System.Threading.Tasks.Task<ENTITY.com.CompraIngreso_01.VCompraIngreso_01[]> CmmpraIngreso_01ListarXId2Async();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ClienteGuardar", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ClienteGuardarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public ENTITY.Cliente.View.VCliente cliente;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int id;
        
        public ClienteGuardarRequest() {
        }
        
        public ClienteGuardarRequest(ENTITY.Cliente.View.VCliente cliente, int id) {
            this.cliente = cliente;
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ClienteGuardarResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ClienteGuardarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool ClienteGuardarResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int id;
        
        public ClienteGuardarResponse() {
        }
        
        public ClienteGuardarResponse(bool ClienteGuardarResult, int id) {
            this.ClienteGuardarResult = ClienteGuardarResult;
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProveedorGuardar", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ProveedorGuardarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public ENTITY.Proveedor.View.VProveedor proveedor;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public ENTITY.Proveedor.View.VProveedor_01Lista[] detalle;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int id;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string usuario;
        
        public ProveedorGuardarRequest() {
        }
        
        public ProveedorGuardarRequest(ENTITY.Proveedor.View.VProveedor proveedor, ENTITY.Proveedor.View.VProveedor_01Lista[] detalle, int id, string usuario) {
            this.proveedor = proveedor;
            this.detalle = detalle;
            this.id = id;
            this.usuario = usuario;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProveedorGuardarResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ProveedorGuardarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool ProveedorGuardarResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int id;
        
        public ProveedorGuardarResponse() {
        }
        
        public ProveedorGuardarResponse(bool ProveedorGuardarResult, int id) {
            this.ProveedorGuardarResult = ProveedorGuardarResult;
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProductoGuardar", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ProductoGuardarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public ENTITY.Producto.View.VProducto proveedor;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int id;
        
        public ProductoGuardarRequest() {
        }
        
        public ProductoGuardarRequest(ENTITY.Producto.View.VProducto proveedor, int id) {
            this.proveedor = proveedor;
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProductoGuardarResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ProductoGuardarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool ProductoGuardarResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int id;
        
        public ProductoGuardarResponse() {
        }
        
        public ProductoGuardarResponse(bool ProductoGuardarResult, int id) {
            this.ProductoGuardarResult = ProductoGuardarResult;
            this.id = id;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceDesktopChannel : PRESENTER.ServiceDesktop.IServiceDesktop, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceDesktopClient : System.ServiceModel.ClientBase<PRESENTER.ServiceDesktop.IServiceDesktop>, PRESENTER.ServiceDesktop.IServiceDesktop {
        
        public ServiceDesktopClient() {
        }
        
        public ServiceDesktopClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceDesktopClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDesktopClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDesktopClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public PRESENTER.ServiceDesktop.CompositeType GetDataUsingDataContract(PRESENTER.ServiceDesktop.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<PRESENTER.ServiceDesktop.CompositeType> GetDataUsingDataContractAsync(PRESENTER.ServiceDesktop.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public ENTITY.Libreria.View.VLibreria[] LibreriaListarCombo(int idGrupo, int idOrden) {
            return base.Channel.LibreriaListarCombo(idGrupo, idOrden);
        }
        
        public System.Threading.Tasks.Task<ENTITY.Libreria.View.VLibreria[]> LibreriaListarComboAsync(int idGrupo, int idOrden) {
            return base.Channel.LibreriaListarComboAsync(idGrupo, idOrden);
        }
        
        public bool LibreriaGuardar(ENTITY.Libreria.View.VLibreriaLista vlibreria) {
            return base.Channel.LibreriaGuardar(vlibreria);
        }
        
        public System.Threading.Tasks.Task<bool> LibreriaGuardarAsync(ENTITY.Libreria.View.VLibreriaLista vlibreria) {
            return base.Channel.LibreriaGuardarAsync(vlibreria);
        }
        
        public ENTITY.Cliente.View.VCliente[] ClienteListar() {
            return base.Channel.ClienteListar();
        }
        
        public System.Threading.Tasks.Task<ENTITY.Cliente.View.VCliente[]> ClienteListarAsync() {
            return base.Channel.ClienteListarAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PRESENTER.ServiceDesktop.ClienteGuardarResponse PRESENTER.ServiceDesktop.IServiceDesktop.ClienteGuardar(PRESENTER.ServiceDesktop.ClienteGuardarRequest request) {
            return base.Channel.ClienteGuardar(request);
        }
        
        public bool ClienteGuardar(ENTITY.Cliente.View.VCliente cliente, ref int id) {
            PRESENTER.ServiceDesktop.ClienteGuardarRequest inValue = new PRESENTER.ServiceDesktop.ClienteGuardarRequest();
            inValue.cliente = cliente;
            inValue.id = id;
            PRESENTER.ServiceDesktop.ClienteGuardarResponse retVal = ((PRESENTER.ServiceDesktop.IServiceDesktop)(this)).ClienteGuardar(inValue);
            id = retVal.id;
            return retVal.ClienteGuardarResult;
        }
        
        public System.Threading.Tasks.Task<PRESENTER.ServiceDesktop.ClienteGuardarResponse> ClienteGuardarAsync(PRESENTER.ServiceDesktop.ClienteGuardarRequest request) {
            return base.Channel.ClienteGuardarAsync(request);
        }
        
        public bool ClienteModificar(ENTITY.Cliente.View.VCliente cliente, int id) {
            return base.Channel.ClienteModificar(cliente, id);
        }
        
        public System.Threading.Tasks.Task<bool> ClienteModificarAsync(ENTITY.Cliente.View.VCliente cliente, int id) {
            return base.Channel.ClienteModificarAsync(cliente, id);
        }
        
        public bool ClienteEliminar(int id) {
            return base.Channel.ClienteEliminar(id);
        }
        
        public System.Threading.Tasks.Task<bool> ClienteEliminarAsync(int id) {
            return base.Channel.ClienteEliminarAsync(id);
        }
        
        public ENTITY.Cliente.View.VCliente[] ClienteListar1(int id) {
            return base.Channel.ClienteListar1(id);
        }
        
        public System.Threading.Tasks.Task<ENTITY.Cliente.View.VCliente[]> ClienteListar1Async(int id) {
            return base.Channel.ClienteListar1Async(id);
        }
        
        public ENTITY.Cliente.View.VClienteLista[] ClientesListar() {
            return base.Channel.ClientesListar();
        }
        
        public System.Threading.Tasks.Task<ENTITY.Cliente.View.VClienteLista[]> ClientesListarAsync() {
            return base.Channel.ClientesListarAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PRESENTER.ServiceDesktop.ProveedorGuardarResponse PRESENTER.ServiceDesktop.IServiceDesktop.ProveedorGuardar(PRESENTER.ServiceDesktop.ProveedorGuardarRequest request) {
            return base.Channel.ProveedorGuardar(request);
        }
        
        public bool ProveedorGuardar(ENTITY.Proveedor.View.VProveedor proveedor, ENTITY.Proveedor.View.VProveedor_01Lista[] detalle, ref int id, string usuario) {
            PRESENTER.ServiceDesktop.ProveedorGuardarRequest inValue = new PRESENTER.ServiceDesktop.ProveedorGuardarRequest();
            inValue.proveedor = proveedor;
            inValue.detalle = detalle;
            inValue.id = id;
            inValue.usuario = usuario;
            PRESENTER.ServiceDesktop.ProveedorGuardarResponse retVal = ((PRESENTER.ServiceDesktop.IServiceDesktop)(this)).ProveedorGuardar(inValue);
            id = retVal.id;
            return retVal.ProveedorGuardarResult;
        }
        
        public System.Threading.Tasks.Task<PRESENTER.ServiceDesktop.ProveedorGuardarResponse> ProveedorGuardarAsync(PRESENTER.ServiceDesktop.ProveedorGuardarRequest request) {
            return base.Channel.ProveedorGuardarAsync(request);
        }
        
        public ENTITY.Proveedor.View.VProveedor[] ProveedorListarXId(int id) {
            return base.Channel.ProveedorListarXId(id);
        }
        
        public System.Threading.Tasks.Task<ENTITY.Proveedor.View.VProveedor[]> ProveedorListarXIdAsync(int id) {
            return base.Channel.ProveedorListarXIdAsync(id);
        }
        
        public ENTITY.Proveedor.View.VProveedorLista[] ProveedorListar() {
            return base.Channel.ProveedorListar();
        }
        
        public System.Threading.Tasks.Task<ENTITY.Proveedor.View.VProveedorLista[]> ProveedorListarAsync() {
            return base.Channel.ProveedorListarAsync();
        }
        
        public ENTITY.Proveedor.View.VProveedor_01Lista[] Proveedor_01ListarXId(int Id) {
            return base.Channel.Proveedor_01ListarXId(Id);
        }
        
        public System.Threading.Tasks.Task<ENTITY.Proveedor.View.VProveedor_01Lista[]> Proveedor_01ListarXIdAsync(int Id) {
            return base.Channel.Proveedor_01ListarXIdAsync(Id);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PRESENTER.ServiceDesktop.ProductoGuardarResponse PRESENTER.ServiceDesktop.IServiceDesktop.ProductoGuardar(PRESENTER.ServiceDesktop.ProductoGuardarRequest request) {
            return base.Channel.ProductoGuardar(request);
        }
        
        public bool ProductoGuardar(ENTITY.Producto.View.VProducto proveedor, ref int id) {
            PRESENTER.ServiceDesktop.ProductoGuardarRequest inValue = new PRESENTER.ServiceDesktop.ProductoGuardarRequest();
            inValue.proveedor = proveedor;
            inValue.id = id;
            PRESENTER.ServiceDesktop.ProductoGuardarResponse retVal = ((PRESENTER.ServiceDesktop.IServiceDesktop)(this)).ProductoGuardar(inValue);
            id = retVal.id;
            return retVal.ProductoGuardarResult;
        }
        
        public System.Threading.Tasks.Task<PRESENTER.ServiceDesktop.ProductoGuardarResponse> ProductoGuardarAsync(PRESENTER.ServiceDesktop.ProductoGuardarRequest request) {
            return base.Channel.ProductoGuardarAsync(request);
        }
        
        public bool ProductoModificar(ENTITY.Producto.View.VProducto proveedor, int id) {
            return base.Channel.ProductoModificar(proveedor, id);
        }
        
        public System.Threading.Tasks.Task<bool> ProductoModificarAsync(ENTITY.Producto.View.VProducto proveedor, int id) {
            return base.Channel.ProductoModificarAsync(proveedor, id);
        }
        
        public bool ProductoEliminar(int id) {
            return base.Channel.ProductoEliminar(id);
        }
        
        public System.Threading.Tasks.Task<bool> ProductoEliminarAsync(int id) {
            return base.Channel.ProductoEliminarAsync(id);
        }
        
        public ENTITY.Producto.View.VProducto[] ProductoListarXId(int id) {
            return base.Channel.ProductoListarXId(id);
        }
        
        public System.Threading.Tasks.Task<ENTITY.Producto.View.VProducto[]> ProductoListarXIdAsync(int id) {
            return base.Channel.ProductoListarXIdAsync(id);
        }
        
        public ENTITY.Producto.View.VProductoLista[] ProductoListar() {
            return base.Channel.ProductoListar();
        }
        
        public System.Threading.Tasks.Task<ENTITY.Producto.View.VProductoLista[]> ProductoListarAsync() {
            return base.Channel.ProductoListarAsync();
        }
        
        public bool ProductoExisteEnCompra(int id) {
            return base.Channel.ProductoExisteEnCompra(id);
        }
        
        public System.Threading.Tasks.Task<bool> ProductoExisteEnCompraAsync(int id) {
            return base.Channel.ProductoExisteEnCompraAsync(id);
        }
        
        public ENTITY.inv.Sucursal.View.VSucursalCombo[] SucursalListarCombo() {
            return base.Channel.SucursalListarCombo();
        }
        
        public System.Threading.Tasks.Task<ENTITY.inv.Sucursal.View.VSucursalCombo[]> SucursalListarComboAsync() {
            return base.Channel.SucursalListarComboAsync();
        }
        
        public ENTITY.reg.PrecioCategoria.View.VPrecioCategoria[] PrecioCategoriaListar() {
            return base.Channel.PrecioCategoriaListar();
        }
        
        public System.Threading.Tasks.Task<ENTITY.reg.PrecioCategoria.View.VPrecioCategoria[]> PrecioCategoriaListarAsync() {
            return base.Channel.PrecioCategoriaListarAsync();
        }
        
        public ENTITY.reg.Precio.View.VPrecioLista[] PrecioProductoListar(int idSucursal) {
            return base.Channel.PrecioProductoListar(idSucursal);
        }
        
        public System.Threading.Tasks.Task<ENTITY.reg.Precio.View.VPrecioLista[]> PrecioProductoListarAsync(int idSucursal) {
            return base.Channel.PrecioProductoListarAsync(idSucursal);
        }
        
        public ENTITY.com.CompraIngreso.View.VCompraIngreso[] CmmpraIngresoListar() {
            return base.Channel.CmmpraIngresoListar();
        }
        
        public System.Threading.Tasks.Task<ENTITY.com.CompraIngreso.View.VCompraIngreso[]> CmmpraIngresoListarAsync() {
            return base.Channel.CmmpraIngresoListarAsync();
        }
        
        public ENTITY.com.CompraIngreso.View.VCompraIngresoLista[] CmmpraIngresoListarXId(int id) {
            return base.Channel.CmmpraIngresoListarXId(id);
        }
        
        public System.Threading.Tasks.Task<ENTITY.com.CompraIngreso.View.VCompraIngresoLista[]> CmmpraIngresoListarXIdAsync(int id) {
            return base.Channel.CmmpraIngresoListarXIdAsync(id);
        }
        
        public ENTITY.com.CompraIngreso_01.VCompraIngreso_01[] CmmpraIngreso_01ListarXId(int id) {
            return base.Channel.CmmpraIngreso_01ListarXId(id);
        }
        
        public System.Threading.Tasks.Task<ENTITY.com.CompraIngreso_01.VCompraIngreso_01[]> CmmpraIngreso_01ListarXIdAsync(int id) {
            return base.Channel.CmmpraIngreso_01ListarXIdAsync(id);
        }
        
        public ENTITY.com.CompraIngreso_01.VCompraIngreso_01[] CmmpraIngreso_01ListarXId2() {
            return base.Channel.CmmpraIngreso_01ListarXId2();
        }
        
        public System.Threading.Tasks.Task<ENTITY.com.CompraIngreso_01.VCompraIngreso_01[]> CmmpraIngreso_01ListarXId2Async() {
            return base.Channel.CmmpraIngreso_01ListarXId2Async();
        }
    }
}
