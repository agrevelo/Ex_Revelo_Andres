using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class EvaluacionLogic
    {
        public Evaluaciones Create(Evaluaciones evaluacion)
        {
            Evaluaciones _evaluacion = null;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                Evaluaciones _result = repository.Retrieve<Evaluaciones>(e => e.Titulo == evaluacion.Titulo && e.CursoID == evaluacion.CursoID);

                if (_result == null)
                {
                    _evaluacion = repository.Create(evaluacion);
                }
                else
                {
                    throw new Exception("La evaluación ya existe.");
                }
            }

            return _evaluacion;
        }

        public Evaluaciones RetrieveById(int id)
        {
            Evaluaciones _evaluacion = null;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                _evaluacion = repository.Retrieve<Evaluaciones>(e => e.EvaluacionID == id);
            }
            return _evaluacion;
        }

        public bool Update(Evaluaciones evaluacion)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                // Busca la entidad original en la base de datos
                var existingEvaluacion = repository.Retrieve<Evaluaciones>(e => e.EvaluacionID == evaluacion.EvaluacionID);

                if (existingEvaluacion == null)
                {
                    throw new Exception("La evaluación no existe.");
                }

                // Actualiza manualmente las propiedades necesarias
                existingEvaluacion.CursoID = evaluacion.CursoID;
                existingEvaluacion.Titulo = evaluacion.Titulo;
                existingEvaluacion.Fecha = evaluacion.Fecha;
                existingEvaluacion.PuntuacionMaxima = evaluacion.PuntuacionMaxima;

                // Guarda los cambios
                return repository.Update(existingEvaluacion);
            }
        }

        public bool Delete(int id)
        {
            bool _delete = false;
            var _evaluacion = RetrieveById(id);
            if (_evaluacion != null)
            {
                using (var repository = RepositoryFactory.CreateRepository())
                {
                    _delete = repository.Delete(_evaluacion);
                }
            }
            return _delete;
        }

        public List<Evaluaciones> RetrieveAll()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                // Usar una expresión lambda para devolver una lista de Evaluaciones
                var evaluaciones = repository.Filter<Evaluaciones>(e => e.EvaluacionID > 0).ToList();
                return evaluaciones;
            }
        }
    }
}
