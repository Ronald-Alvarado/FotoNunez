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
    public class CategoriasBLL
    {
        public static bool Guardar(Categorias categorias)
        {
            if (!Existe(categorias.CategoriaId))
            {
                return Insertar(categorias);
            }
            else
            {
                return Modificar(categorias);
            }

        }

        public static bool Insertar(Categorias categorias)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Categorias.Add(categorias) != null)
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

        public static bool Modificar(Categorias categorias)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(categorias).State = EntityState.Modified;
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
                encontrado = db.Categorias.Any(d => d.CategoriaId == id);
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
                var eliminar = db.Categorias.Find(id);
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

        public static Categorias Buscar(int id)
        {
            Contexto db = new Contexto();
            Categorias categorias = new Categorias();

            try
            {
                categorias = db.Categorias.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return categorias;
        }

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> categorias)
        {
            Contexto db = new Contexto();
            List<Categorias> listado = new List<Categorias>();

            try
            {
                listado = db.Categorias.Where(categorias).ToList();
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