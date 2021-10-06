using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Barberia.Datos
{
    public class Cls_Dat_Clientes : Repository<T_M_CLIENTES>
    {
        public List<T_M_CLIENTES> Listar_Clientes(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_CLIENTES> lista;
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    
                     lista = db.T_M_CLIENTES.Where(t => t.FLG_ESTADO == "1" && t.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_CLIENTE).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                lista = new List<T_M_CLIENTES>();
            }
            return lista;
        }

        public T_M_CLIENTES ListarUno_Clientes(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_CLIENTES entidad = new T_M_CLIENTES();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_CLIENTES.Find(id);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_CLIENTES> Buscar_Clientes(T_M_CLIENTES entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_CLIENTES> query = Entities;
            try
            {
                query = query.Where(c => c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (!string.IsNullOrEmpty(entidad.TIPO_DOC))
                    query = query.Where(c => c.TIPO_DOC.Contains(entidad.TIPO_DOC));

                if (!string.IsNullOrEmpty(entidad.NUM_DOC))
                    query = query.Where(c => c.NUM_DOC.Contains(entidad.NUM_DOC));

                if (!string.IsNullOrEmpty(entidad.NOMBRES))
                    query = query.Where(c => c.NOMBRES.Contains(entidad.NOMBRES));

                if (!string.IsNullOrEmpty(entidad.APELLIDO_PAT))
                    query = query.Where(c => c.APELLIDO_PAT.Contains(entidad.APELLIDO_PAT));

                if (!string.IsNullOrEmpty(entidad.APELLIDO_MAT))
                    query = query.Where(c => c.APELLIDO_MAT.Contains(entidad.APELLIDO_MAT));

                if (!string.IsNullOrEmpty(entidad.CORREO))
                    query = query.Where(c => c.CORREO.Contains(entidad.CORREO));

                if (!string.IsNullOrEmpty(entidad.TELEFONO))
                    query = query.Where(c => c.TELEFONO.Contains(entidad.TELEFONO));

                query = query.OrderByDescending(c => c.ID_CLIENTE);

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                
            }
            return query.ToList();
        }

        public T_M_CLIENTES Buscar_Clientes(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_CLIENTES entidad = new  T_M_CLIENTES();
            try
            {
                entidad = Find(x => x.ID_CLIENTE == id);

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public bool Insertar_Clientes(T_M_CLIENTES entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            List<T_M_CLIENTES> lista = new List<T_M_CLIENTES>();
            auditoria.Limpiar();
            bool exito = true;
            try
            {
                lista = FindAll(x => x.NUM_DOC == entidad.NUM_DOC && x.TIPO_DOC == entidad.TIPO_DOC && x.ID_EMPRESA == entidad.ID_EMPRESA).Where(x => x.FLG_ESTADO == "1").ToList();
                if (lista.Count > 0)
                {
                    exito = false;
                }

                if (exito)
                {
                    Add(entidad);
                }    
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                exito = false;
            }
            return exito;
        }

        public bool Actualizar_Clientes(T_M_CLIENTES entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CLIENTES lista = new T_M_CLIENTES();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.TIPO_DOC == entidad.TIPO_DOC && x.NUM_DOC == entidad.NUM_DOC && x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null)
                {
                    if (lista.ID_CLIENTE != entidad.ID_CLIENTE)
                    {
                        exito = false;
                    }
                }
                else
                {
                    lista = Find(x => x.ID_CLIENTE == entidad.ID_CLIENTE);
                }

                if (exito)
                {
                    lista.TIPO_PERSONA = entidad.TIPO_PERSONA;
                    lista.R_SOCIAL = entidad.R_SOCIAL;
                    lista.REPRESENTANTE_LEGAL = entidad.REPRESENTANTE_LEGAL;
                    lista.NOMBRES = entidad.NOMBRES;
                    lista.APELLIDO_PAT = entidad.APELLIDO_PAT;
                    lista.APELLIDO_MAT = entidad.APELLIDO_MAT;
                    lista.TIPO_DOC = entidad.TIPO_DOC;
                    lista.NUM_DOC = entidad.NUM_DOC;
                    lista.FLG_TIPO = entidad.FLG_TIPO;
                    lista.COD_DEPARTAMENTO = entidad.COD_DEPARTAMENTO;
                    lista.COD_PROVINCIA = entidad.COD_PROVINCIA;
                    lista.COD_DISTRITO = entidad.COD_DISTRITO;
                    lista.DIRECCION = entidad.DIRECCION;
                    lista.CORREO = entidad.CORREO;
                    lista.TELEFONO = entidad.TELEFONO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                exito = false;
            }
            return exito;
        }

        public bool Eliminar_Clientes(T_M_CLIENTES entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CLIENTES ent = new T_M_CLIENTES();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                ent = Find(x => x.ID_CLIENTE == entidad.ID_CLIENTE &&  x.FLG_ESTADO == "1");
                if (ent != null)
                {
                    ent.FLG_ESTADO = entidad.FLG_ESTADO;
                    ent.USU_MODIFICA = entidad.USU_MODIFICA;
                    ent.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(ent, ent.ID_CLIENTE);
                }
                else
                {
                    exito = false;
                }

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                exito = false;
            }
            return exito;
        }

        public List<T_M_CLIENTES> ListarEmpresaInt_Clientes(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_CLIENTES> lista;
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {

                    lista = db.T_M_CLIENTES.Where(t => t.FLG_ESTADO == "1" && t.FLG_TIPO == "I" && t.TIPO_PERSONA == "02" && t.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_CLIENTE).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                lista = new List<T_M_CLIENTES>();
            }
            return lista;
        }

        public List<T_M_CLIENTES> ListarEmpresa_Clientes(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_CLIENTES> lista;
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {

                    lista = db.T_M_CLIENTES.Where(t => t.FLG_ESTADO == "1"  && t.TIPO_PERSONA == "02" && t.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_CLIENTE).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                lista = new List<T_M_CLIENTES>();
            }
            return lista;
        }



        public List<T_M_CLIENTES> Reporte_TiempoPromedio(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref Cls_Ent_Auditoria auditoria)
        {
            var TABLA = ""; 
            auditoria.Limpiar();
            DbDataReader dr = null;
            List<T_M_CLIENTES> lista = new List<T_M_CLIENTES>();
            try
            {
                using (var command = _context.GetStoredProcedureCommand("USP_TIEMPO_PROMEDIO",
                new SqlParameter("@PI_PAGINA", PAGINA),
                new SqlParameter("@PI_NROREGISTROS", FILAS),
                new SqlParameter("@PI_ORDEN_COLUMNA", ORDEN_COLUMNA),
                new SqlParameter("@PI_ORDEN", ORDEN),
                new SqlParameter("@PI_WHERE", @WHERE),
                new SqlParameter("@PI_TABLA", TABLA),
                new SqlParameter("PO_CUENTA", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output,
                //new SqlParameter("PO_MENSAJE", OracleDbType.Varchar2, ParameterDirection.Output) { Size = 200 },
                null)
                )
                {
                    dr = command.ExecuteReader();
                    int pos_ID_DOCUMENTO_PROCESO = dr.GetOrdinal("ID_DOCUMENTO_PROCESO");
                    int pos_USU_CREACION = dr.GetOrdinal("USU_CREACION");
                    int pos_TIEMPO_ESCANEO = dr.GetOrdinal("TIEMPO_ESCANEO");
                    int pos_FOLIOS = dr.GetOrdinal("FOLIOS");
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            T_M_CLIENTES entidad = new T_M_CLIENTES();

                            if (dr.IsDBNull(pos_ID_DOCUMENTO_PROCESO)) entidad.ID_CLIENTE = 0;
                            else entidad.ID_CLIENTE = int.Parse(dr[pos_ID_DOCUMENTO_PROCESO].ToString());

                            if (dr.IsDBNull(pos_USU_CREACION)) entidad.USU_CREACION = "";
                            else entidad.USU_CREACION = dr[pos_USU_CREACION].ToString();


                            lista.Add(entidad);
                        }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }







    }
}
