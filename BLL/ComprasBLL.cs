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
    public class ComprasBLL
    {
        public static bool Guardar(Compras compras)
        {
            if (!Existe(compras.CompraId))
            {
                return Insertar(compras);
            }
            else
            {
                return Modificar(compras);
            }

        }

        public static bool Insertar(Compras compras)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {


                if (db.Compras.Add(compras) != null)
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

        public static bool Modificar(Compras compras)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Database.ExecuteSqlRaw($"DELETE FROM ComprasDetalle Where CompraId={compras.CompraId}");

                foreach (var item in compras.ComprasDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(compras).State = EntityState.Modified;
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
                encontrado = db.Compras.Any(d => d.CompraId == id);
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

                var eliminar = db.Compras.Find(id);
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

        public static Compras Buscar(int id)
        {
            Contexto db = new Contexto();
            Compras compras = new Compras();

            try
            {
                compras = db.Compras.Include(x => x.ComprasDetalle).
                    Where(x => x.CompraId == id).
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
            return compras;
        }

        public static List<Compras> GetList(Expression<Func<Compras, bool>> compras)
        {
            Contexto db = new Contexto();
            List<Compras> listado = new List<Compras>();

            try
            {
                listado = db.Compras.Where(compras).ToList();
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

        public static void ObtenerCantidad(Compras compras)
        {
            List<Articulos> articulos = ArticulosBLL.GetList(ar => true);

            if (articulos != null)
            {
                foreach (var articulo in articulos)
                {
                    decimal Cantidad = articulo.Stock;

                    foreach (var compra in compras.ComprasDetalle)
                    {
                        Cantidad += compra.CantidadArticulos;
                    }

                    articulo.Stock = Cantidad;

                    ArticulosBLL.Guardar(articulo);
                }

            }

        }

        public static void ObtenerCosto(Compras compras)
        {
            List<Articulos> articulos = ArticulosBLL.GetList(ar => true);

            if (articulos != null)
            {
                foreach (var articulo in articulos)
                {
                    decimal Costo = articulo.Costo;

                    foreach (var compra in compras.ComprasDetalle)
                    {
                        if (articulo.ArticuloId == compra.ArticuloId)
                        {
                            if (articulo.Costo != 0)
                            {
                                articulo.Costo = Costo;
                            }
                            else
                            {
                                Costo += compra.Costo;
                            }
                        }

                    }

                    articulo.Costo = Costo;

                    ArticulosBLL.Guardar(articulo);
                }

            }

        }


        public static void BorrarCantidad(Compras compras)
        {
            List<Articulos> articulos = ArticulosBLL.GetList(ar => true);

            if (articulos != null)
            {
                foreach (var articulo in articulos)
                {
                    decimal Cantidad = articulo.Stock;

                    foreach (var compra in compras.ComprasDetalle)
                    {
                        Cantidad -= compra.CantidadArticulos;
                    }

                    if (Cantidad < 0)
                    {
                        Cantidad = 0;
                        articulo.Stock = Cantidad;
                    }
                    else
                    {
                        articulo.Stock = Cantidad;
                    }

                    ArticulosBLL.Guardar(articulo);
                }

            }


        }

        public static void BorrarCosto(Compras compras)
        {
            List<Articulos> articulos = ArticulosBLL.GetList(ar => true);

            if (articulos != null)
            {
                foreach (var articulo in articulos)
                {
                    decimal Costo = articulo.Costo;

                    foreach (var compra in compras.ComprasDetalle)
                    {
                        Costo -= compra.Costo;
                    }

                    if (Costo < 0)
                    {
                        Costo = 0;
                        articulo.Costo = Costo;
                    }
                    else
                    {
                        articulo.Costo = Costo;
                    }

                    ArticulosBLL.Guardar(articulo);
                }

            }

        }

    }

}
