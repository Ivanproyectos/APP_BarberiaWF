using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Usuario : Repository<T_M_USUARIO>
    {
        public List<Cls_Ent_UsuarioWForm> Listar_Usuario(int idEmpresa,ref Cls_Ent_Auditoria auditoria)
        {
            List<Cls_Ent_UsuarioWForm> lista = new List<Cls_Ent_UsuarioWForm>();
            List<T_M_USUARIO> temp = new List<T_M_USUARIO>();
            auditoria.Limpiar();
            // SOLO FUNCIONA USANDO BD
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    temp = db.T_M_USUARIO.Where(t => t.FLG_ESTADO == "1" && t.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_USUARIO).ToList();
                    foreach (var item in temp)
                    {
                        lista.Add(new Cls_Ent_UsuarioWForm
                        {
                            ID_USUARIO = item.ID_USUARIO,
                            USUARIO = item.USUARIO,
                            CLAVE = item.CLAVE,
                            PERFIL = item.T_M_PERFIL.DESCRIPCION,
                            ID_PERSONAL = item.ID_PERSONAL,
                            PERSONAL = item.T_M_PERSONAL.NOMBRES + " " + item.T_M_PERSONAL.APELLIDO_PAT + " " + item.T_M_PERSONAL.APELLIDO_MAT,
                            FLG_ESTADO = item.FLG_ESTADO,
                            USU_CREACION = item.USU_CREACION,
                            FEC_CREACION = item.FEC_CREACION,
                            USU_MODIFICA = item.USU_MODIFICA,
                            FEC_MODIFICA = item.FEC_MODIFICA
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            

            //temp = GetAll().OrderByDescending(t => t.ID_USUARIO).ToList();
            //foreach (var item in temp)
            //{
            //    lista.Add(new Cls_Ent_Usuario
            //    {
            //        ID_USUARIO = item.ID_USUARIO,
            //        USUARIO = item.USUARIO,
            //        CLAVE = item.CLAVE,
            //        PERFIL = item.T_M_PERFIL.DESCRIPCION,
            //        USU_INGRESO = item.USU_INGRESO,
            //        FEC_INGRESO = item.FEC_INGRESO,
            //        USU_MODIFICA = item.USU_MODIFICA,
            //        FEC_MODIFICA = item.FEC_MODIFICA
            //    });
            //}

            return lista;
        }

        public T_M_USUARIO ListarUno_Cargo(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_USUARIO entidad = new T_M_USUARIO();
            try
            {

                entidad = Find(x => x.ID_USUARIO == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<Cls_Ent_UsuarioWForm> Buscar_Usuario(T_M_USUARIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<Cls_Ent_UsuarioWForm> lista = new List<Cls_Ent_UsuarioWForm>();
            IQueryable<T_M_USUARIO> query = Entities;
            auditoria.Limpiar();
            try
            {
                query = query.Where(c => c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (!string.IsNullOrEmpty(entidad.USUARIO))
                    query = query.Where(c => c.USUARIO.Contains(entidad.USUARIO));

                if (entidad.ID_PERFIL > 0)
                    query = query.Where(c => c.ID_PERFIL == entidad.ID_PERFIL);

                if (entidad.ID_PERSONAL > 0)
                    query = query.Where(c => c.ID_PERSONAL == entidad.ID_PERSONAL);

                query = query.OrderByDescending(c => c.ID_USUARIO);
                lista = (List<Cls_Ent_UsuarioWForm>)query.ToList().Select(c => new Cls_Ent_UsuarioWForm
                {
                    ID_USUARIO = c.ID_USUARIO,
                    USUARIO = c.USUARIO,
                    CLAVE = c.CLAVE,
                    PERFIL = c.T_M_PERFIL.DESCRIPCION,
                    PERSONAL =  c.T_M_PERSONAL.NOMBRES + " " + c.T_M_PERSONAL.APELLIDO_PAT + " " + c.T_M_PERSONAL.APELLIDO_MAT,
                    FLG_ESTADO = c.FLG_ESTADO,
                    USU_CREACION = c.USU_CREACION,
                    FEC_CREACION = c.FEC_CREACION,
                    USU_MODIFICA = c.USU_MODIFICA,
                    FEC_MODIFICA = c.FEC_MODIFICA
                }).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Usuario(T_M_USUARIO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            List<T_M_USUARIO> lista = new List<T_M_USUARIO>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = FindAll(c => c.USUARIO == entidad.USUARIO && c.ID_EMPRESA == entidad.ID_EMPRESA).Where(c => c.FLG_ESTADO == "1").ToList();
                if (lista.Count > 0)
                {
                    exito = false;
                }

                if (exito)
                {
                    //_context.T_M_USUARIO.Add(entidad);
                    //_context.SaveChanges();
                    Add(entidad);
                }    
            }
            catch (Exception ex) //DbEntityValidationException dbEx
            {
                auditoria.Error(ex);
                //foreach (var validationErrors in dbEx.EntityValidationErrors)
                //{
                //    foreach (var validationError in validationErrors.ValidationErrors)
                //    {
                //        Trace.TraceInformation("Property: {0} Error: {1}",
                //            validationError.PropertyName,
                //            validationError.ErrorMessage);
                //    }
                //}
            }
            return exito;
        }

        public bool Actualizar_Usuario(T_M_USUARIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_USUARIO lista = new T_M_USUARIO();
            bool exito = false;
            auditoria.Limpiar();
            try
            {

                lista = Find(c => c.USUARIO == entidad.USUARIO && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null)
                {
                    if (lista.ID_USUARIO == entidad.ID_USUARIO)
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_USUARIO == entidad.ID_USUARIO);
                    exito = true;
                }

                if (exito)
                {
                    lista.USUARIO = entidad.USUARIO;
                    lista.CLAVE = entidad.CLAVE;
                    lista.ID_PERFIL = entidad.ID_PERFIL;
                    lista.ID_PERSONAL = entidad.ID_PERSONAL;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    Update(lista, entidad.ID_USUARIO);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Usuario(T_M_USUARIO entidad, ref Cls_Ent_Auditoria auditoria)
        {

            List<T_M_USUARIO> lista = new List<T_M_USUARIO>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                if (entidad.ID_USUARIO > 0)
                {
                    lista = FindAll(c => c.ID_USUARIO == entidad.ID_USUARIO).ToList();
                    if (lista.Count > 0)
                    {
                        foreach (var item in lista)
                        {
                            item.FLG_ESTADO = entidad.FLG_ESTADO;
                            item.USU_MODIFICA = entidad.USU_MODIFICA;
                            item.FEC_MODIFICA = entidad.FEC_MODIFICA;
                            Update(item);
                        }
                    }
                    else
                    {
                        exito = false;
                    }
                }
                else
                {
                    lista = FindAll(c => c.ID_PERFIL == entidad.ID_PERFIL).ToList();
                    if (lista.Count > 0)
                    {
                        foreach (var item in lista)
                        {
                            item.FLG_ESTADO = entidad.FLG_ESTADO;
                            item.USU_MODIFICA = entidad.USU_MODIFICA;
                            item.FEC_MODIFICA = entidad.FEC_MODIFICA;
                            Update(item);
                        }
                    }
                    else
                    {
                        exito = false;
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public string Login_Usuario(string user, string pass, out int idPerfil, out int idPersonal, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_USUARIO lista = new T_M_USUARIO();
            string mensaje = "";
            idPerfil = 0;
            idPersonal = 0;
            auditoria.Limpiar();
            try
            {
                lista = Find(x=> x.USUARIO == user && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    lista = Find(x => x.CLAVE == pass && x.USUARIO == user && x.FLG_ESTADO == "1");
                    if (lista == null)
                        mensaje = "La contraseña es incorrecta";
                    else
                    {
                        idPerfil = lista.ID_PERFIL;
                        idPersonal = lista.ID_PERSONAL;
                    }
                        
                }
                else
                {
                    mensaje = "El usuario no existe";
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            
            return mensaje;
        }

    }
}
