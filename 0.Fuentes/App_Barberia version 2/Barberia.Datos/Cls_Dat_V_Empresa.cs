using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_Empresa : Repository<V_EMPRESA>
    {
        public List<V_EMPRESA> Listar_V_Empresa(ref Cls_Ent_Auditoria auditoria)
        {
            List<V_EMPRESA> listEmpresa = new List<V_EMPRESA>();
            auditoria.Limpiar();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    listEmpresa = db.V_EMPRESA.OrderBy(x => x.ID_EMPRESA).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return listEmpresa;
        }


    }
}
