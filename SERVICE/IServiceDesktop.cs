﻿using ENTITY.Cliente.View;
using ENTITY.com.CompraIngreso.View;
using ENTITY.com.CompraIngreso_01;
using ENTITY.inv.Sucursal.View;
using ENTITY.Libreria.View;
using ENTITY.Producto.View;
using ENTITY.Proveedor.View;
using ENTITY.reg.Precio.View;
using ENTITY.reg.PrecioCategoria.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SERVICE
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceDesktop
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        ///**********INICIO******************
        #region Libreria
        [OperationContract]
        List<VLibreria> LibreriaListarCombo(int idGrupo, int idOrden);

        [OperationContract]
        bool LibreriaGuardar(VLibreriaLista vlibreria);
        #endregion
        #region Cliente

        [OperationContract]
        List<VCliente> ClienteListar();

        [OperationContract]
        bool ClienteGuardar(VCliente cliente, ref int id);
        [OperationContract]
        bool ClienteModificar(VCliente cliente, int id);
        [OperationContract]
        bool ClienteEliminar(int id);

        [OperationContract]
        List<VCliente> ClienteListar1(int id);

        [OperationContract]
        List<VClienteLista> ClientesListar();


        #endregion
        #region Proveedor
        [OperationContract]
        bool ProveedorGuardar(VProveedor proveedor, List<VProveedor_01Lista> detalle, ref int id, string usuario);

        [OperationContract]
        List<VProveedor> ProveedorListarXId(int id);

        [OperationContract]
        List<VProveedorLista> ProveedorListar();
        #endregion
        #region Proveedor_01
        [OperationContract]
        List<VProveedor_01Lista> Proveedor_01ListarXId(int Id);
        #endregion
        #region Producto
        [OperationContract]
        bool ProductoGuardar(VProducto proveedor, ref int id);
        [OperationContract]
        bool ProductoModificar(VProducto proveedor, int id);
        [OperationContract]
        bool ProductoEliminar(int id);

        [OperationContract]
        List<VProducto> ProductoListarXId(int id);

        [OperationContract]
        List<VProductoLista> ProductoListar();

        [OperationContract]
        bool ProductoExisteEnCompra(int id);
        #endregion
        #region Sucursal
        [OperationContract]
        List<VSucursalCombo> SucursalListarCombo();
        #endregion
        #region Precio Categoria
        [OperationContract]
        List<VPrecioCategoria> PrecioCategoriaListar();
        #endregion
        #region Precio 
        [OperationContract]
        List<VPrecioLista> PrecioProductoListar(int idSucursal);
        #endregion
        #region Compra Ingreso 
        [OperationContract]
        List<VCompraIngreso> CmmpraIngresoListar();

        [OperationContract]
        List<VCompraIngresoLista> CmmpraIngresoListarXId(int id);
        #endregion
        #region Compra Ingreso_01
        [OperationContract]
        List<VCompraIngreso_01> CmmpraIngreso_01ListarXId(int id);
        [OperationContract]
        List<VCompraIngreso_01> CmmpraIngreso_01ListarXId2();
        #endregion
        // TODO: agregue aquí sus operaciones de servicio
    }
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}