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
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            if (!Existe(articulos.ArticuloId))
            {
                return Insertar(articulos);
            }
            else
            {
                return Modificar(articulos);
            }


        }

        private static bool Insertar(Articulos articulos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Articulos.Add(articulos) != null)
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

        private static bool Modificar(Articulos articulos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(articulos).State = EntityState.Modified;
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
                encontrado = db.Articulos.Any(d => d.ArticuloId == id);
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
                var eliminar = db.Articulos.Find(id);
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

        public static Articulos Buscar(int id)
        {
            Contexto db = new Contexto();
            Articulos articulos = new Articulos();

            try
            {
                articulos = db.Articulos.Include(x => x.ComprasDetalle).
                    Where(x => x.ArticuloId == id).
                    SingleOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return articulos;
        }


        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulos)
        {
            Contexto db = new Contexto();
            List<Articulos> listado = new List<Articulos>();

            try
            {
                listado = db.Articulos.Where(articulos).ToList();
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