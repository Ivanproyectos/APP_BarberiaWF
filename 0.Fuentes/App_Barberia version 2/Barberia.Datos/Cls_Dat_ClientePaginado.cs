using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
namespace Barberia.Datos
{
    public class Cls_Dat_ClientePaginado : Repository<Cls_Ent_V_Cliente>
    {


        public List<Cls_Ent_V_Cliente> ListarPaginado_Cliente(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref Cls_Ent_Auditoria auditoria)
        {
            var TABLA = "";
            auditoria.Limpiar();
            DbDataReader dr = null;
            List<Cls_Ent_V_Cliente> lista = new List<Cls_Ent_V_Cliente>();
            try
            {
                using (var command = _context.GetStoredProcedureCommand("USP_CLIENTE_PAGINADO",
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
                    int pos_ID_CLIENTE = dr.GetOrdinal("ID_CLIENTE");
                    int pos_ID_EMPRESA = dr.GetOrdinal("ID_EMPRESA");
                    int pos_PERSONA = dr.GetOrdinal("PERSONA");
                    int pos_NOMBRE = dr.GetOrdinal("NOMBRE");
                    int pos_R_SOCIAL = dr.GetOrdinal("R_SOCIAL");
                    int pos_REPRESENTANTE_LEGAL = dr.GetOrdinal("REPRESENTANTE_LEGAL");
                    int pos_NOMBRES = dr.GetOrdinal("NOMBRES");
                    int pos_APELLIDO_PAT = dr.GetOrdinal("APELLIDO_PAT");
                    int pos_APELLIDO_MAT = dr.GetOrdinal("APELLIDO_MAT");
                    int pos_DOCUMENTO = dr.GetOrdinal("DOCUMENTO");
                    int pos_NUM_DOC = dr.GetOrdinal("NUM_DOC");
                    int pos_DEPARTAMENTO = dr.GetOrdinal("DEPARTAMENTO");
                    int pos_PROVINCIA = dr.GetOrdinal("PROVINCIA");
                    int pos_DISTRITO = dr.GetOrdinal("DISTRITO");
                    int pos_DIRECCION = dr.GetOrdinal("DIRECCION");
                    int pos_CORREO = dr.GetOrdinal("CORREO");
                    int pos_TELEFONO = dr.GetOrdinal("TELEFONO");
                    int pos_USU_CREACION = dr.GetOrdinal("USU_CREACION");
                    int pos_FEC_CREACION = dr.GetOrdinal("FEC_CREACION");
                    int pos_USU_MODIFICA = dr.GetOrdinal("USU_MODIFICA");
                    int pos_FEC_MODIFICA = dr.GetOrdinal("FEC_MODIFICA");

                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Cls_Ent_V_Cliente entidad = new Cls_Ent_V_Cliente();

                            if (dr.IsDBNull(pos_ID_CLIENTE)) entidad.ID_CLIENTE = 0;
                            else entidad.ID_CLIENTE = int.Parse(dr[pos_ID_CLIENTE].ToString());

                            if (dr.IsDBNull(pos_ID_EMPRESA)) entidad.ID_EMPRESA = 0;
                            else entidad.ID_EMPRESA = int.Parse(dr[pos_ID_EMPRESA].ToString());

                            if (dr.IsDBNull(pos_PERSONA)) entidad.PERSONA = "";
                            else entidad.PERSONA = dr[pos_PERSONA].ToString();

                            if (dr.IsDBNull(pos_NOMBRE)) entidad.NOMBRE = "";
                            else entidad.NOMBRE = dr[pos_NOMBRE].ToString();

                            if (dr.IsDBNull(pos_R_SOCIAL)) entidad.R_SOCIAL = "";
                            else entidad.R_SOCIAL = dr[pos_R_SOCIAL].ToString();

                            if (dr.IsDBNull(pos_REPRESENTANTE_LEGAL)) entidad.REPRESENTANTE_LEGAL = "";
                            else entidad.REPRESENTANTE_LEGAL = dr[pos_REPRESENTANTE_LEGAL].ToString();

                            if (dr.IsDBNull(pos_NOMBRES)) entidad.NOMBRES = "";
                            else entidad.NOMBRES = dr[pos_NOMBRES].ToString();

                            if (dr.IsDBNull(pos_APELLIDO_PAT)) entidad.APELLIDO_PAT = "";
                            else entidad.APELLIDO_PAT = dr[pos_APELLIDO_PAT].ToString();

                            if (dr.IsDBNull(pos_APELLIDO_MAT)) entidad.APELLIDO_MAT = "";
                            else entidad.APELLIDO_MAT = dr[pos_APELLIDO_MAT].ToString();

                            if (dr.IsDBNull(pos_DOCUMENTO)) entidad.DOCUMENTO = "";
                            else entidad.DOCUMENTO = dr[pos_DOCUMENTO].ToString();

                            if (dr.IsDBNull(pos_NUM_DOC)) entidad.NUM_DOC = "";
                            else entidad.NUM_DOC = dr[pos_NUM_DOC].ToString();

                            if (dr.IsDBNull(pos_DEPARTAMENTO)) entidad.DEPARTAMENTO = "";
                            else entidad.DEPARTAMENTO = dr[pos_DEPARTAMENTO].ToString();

                            if (dr.IsDBNull(pos_PROVINCIA)) entidad.PROVINCIA = "";
                            else entidad.PROVINCIA = dr[pos_PROVINCIA].ToString();

                            if (dr.IsDBNull(pos_DISTRITO)) entidad.DISTRITO = "";
                            else entidad.DISTRITO = dr[pos_DISTRITO].ToString();

                            if (dr.IsDBNull(pos_DIRECCION)) entidad.DIRECCION = "";
                            else entidad.DIRECCION = dr[pos_DIRECCION].ToString();

                            if (dr.IsDBNull(pos_CORREO)) entidad.CORREO = "";
                            else entidad.CORREO = dr[pos_CORREO].ToString();

                            if (dr.IsDBNull(pos_TELEFONO)) entidad.TELEFONO = "";
                            else entidad.TELEFONO = dr[pos_TELEFONO].ToString();

                            if (dr.IsDBNull(pos_USU_CREACION)) entidad.USU_CREACION = "";
                            else entidad.USU_CREACION = dr[pos_USU_CREACION].ToString();

                            if (dr.IsDBNull(pos_FEC_CREACION)) entidad.FEC_CREACION = "";
                            else entidad.FEC_CREACION = dr[pos_FEC_CREACION].ToString();

                            if (dr.IsDBNull(pos_USU_MODIFICA)) entidad.USU_MODIFICA = "";
                            else entidad.USU_MODIFICA = dr[pos_USU_MODIFICA].ToString();

                            if (dr.IsDBNull(pos_FEC_MODIFICA)) entidad.FEC_MODIFICA = "";
                            else entidad.FEC_MODIFICA = dr[pos_FEC_MODIFICA].ToString();

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
