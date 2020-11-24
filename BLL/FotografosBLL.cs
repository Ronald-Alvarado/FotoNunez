using DAL;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    class FotografosBLL
    {
        public static bool Guardar(Fotografos fotografos)
        {
            if (!Existe(fotografos.FotografoId))
            {
                return Insertar(fotografos);
            }
            else
            {
                return Modificar(fotografos);
            }


        }

        private static bool Insertar(Fotografos fotografos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Fotografos.Add(fotografos) != null)
                {
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Fotografos fotografos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(fotografos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        private static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Fotografos.Any(d => d.FotografoId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }


        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = db.Fotografos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Fotografos Buscar(int id)
        {
            Contexto db = new Contexto();
            Fotografos fotografos = new Fotografos();

            try
            {
                fotografos = db.Fotografos.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return fotografos;
        }


        public static List<Fotografos> GetList(Expression<Func<Fotografos, bool>> fotografos)
        {
            Contexto db = new Contexto();
            List<Fotografos> listado = new List<Fotografos>();

            try
            {
                listado = db.Fotografos.Where(fotografos).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return listado;
        }
    }
}
