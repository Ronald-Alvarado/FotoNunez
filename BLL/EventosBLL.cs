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
    class EventosBLL
    {
        public static bool Guardar(Eventos eventos)
        {
            if (!Existe(eventos.EventoId))
            {
                return Insertar(eventos);
            }
            else
            {
                return Modificar(eventos);
            }

        }

        public static bool Insertar(Eventos eventos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Eventos.Add(eventos) != null)
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

        public static bool Modificar(Eventos eventos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(eventos).State = EntityState.Modified;
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
                encontrado = db.Eventos.Any(d => d.EventoId == id);
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
                var eliminar = db.Eventos.Find(id);
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

        public static Eventos Buscar(int id)
        {
            Contexto db = new Contexto();
            Eventos eventos = new Eventos();

            try
            {
                eventos = db.Eventos.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return eventos;
        }

        public static List<Eventos> GetList(Expression<Func<Eventos, bool>> eventos)
        {
            Contexto db = new Contexto();
            List<Eventos> listado = new List<Eventos>();

            try
            {
                listado = db.Eventos.Where(eventos).ToList();
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

        public static decimal ObtenerPrecio(int id)
        {
            Eventos eventos = Buscar(id);
            if (eventos == null)
                return 0.0m;
            else
                return eventos.Precio;
        }

    }
}
