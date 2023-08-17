using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SqlRepository
{
    public class BaseRepository<T>
        where T : class
    {
        protected DbContext Contexto = new Contexto();
        protected DbSet<T> DbSet;

        public BaseRepository()
        {
            DbSet = Contexto.Set<T>();
        }


        public T Insertar(T entidad)
        {
            var entidadAgregada = DbSet.Add(entidad);
            GuardarCambios();
            return entidadAgregada;
        }

        public void Eliminar(T entidad)
        {
            if (Contexto.Entry(entidad).State == EntityState.Detached)
            {
                DbSet.Attach(entidad);
            }
            DbSet.Remove(entidad);
            GuardarCambios();
        }

        public void Actualizar(T entidad)
        {
            if (Contexto.Entry(entidad).State == EntityState.Detached)
            {
                DbSet.Attach(entidad);
                Contexto.Entry(entidad).State = EntityState.Modified;
            }
            GuardarCambios();
        }

        public IQueryable<T> Filtrar(Expression<Func<T, bool>> expresion)
        {
            return DbSet.Where(expresion);
        }

        public T ObtenerPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> ObtenerPorNombre(Expression<Func<T, bool>> expresion)
        {
            return DbSet.Where(expresion);
        }

        public IQueryable<T> ObtenerTodos()
        {
            return DbSet;
        }

        public void GuardarCambios()
        {
            try
            {
                Contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        sb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                entityValidationErrors.Entry.Entity.GetType().Name,
                                entityValidationErrors.Entry.State));
                        sb.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                            validationError.PropertyName,
                                            validationError.ErrorMessage));
                    }
                }
                throw;
            }
        }
    }
}
