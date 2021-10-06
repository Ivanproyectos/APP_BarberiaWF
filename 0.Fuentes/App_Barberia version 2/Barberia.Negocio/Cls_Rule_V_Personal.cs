using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_Personal
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_V_Personal VistaPersonal = new Cls_V_Personal();

        public List<V_PERSONAL> Listar_Personal(int idEmpresa,ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PERSONAL> lista = new List<V_PERSONAL>();
            try
            {
                lista = VistaPersonal.Listar_Personal(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<V_PERSONAL> Buscar_Personal(V_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PERSONAL> lista = new List<V_PERSONAL>();
            try
            {
                lista = VistaPersonal.Buscar_Personal(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
