using System;
using System.Collections.Generic;
using System.Web.Services;
using BLL;
using Entities;

namespace SOAP
{
    /// <summary>
    /// Servicio SOAP para la gestión de evaluaciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class EvaluacionService : WebService
    {
        private EvaluacionLogic _logic = new EvaluacionLogic();

        #region Métodos de Evaluación

        [WebMethod]
        public string AgregarEvaluacion(int cursoId, string titulo, DateTime fecha, int puntuacionMaxima)
        {
            try
            {
                Evaluaciones evaluacion = new Evaluaciones
                {
                    CursoID = cursoId,
                    Titulo = titulo,
                    Fecha = fecha,
                    PuntuacionMaxima = puntuacionMaxima
                };

                _logic.Create(evaluacion);

                return "Evaluación agregada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al agregar la evaluación: {ex.Message}";
            }
        }

        [WebMethod]
        public List<Evaluaciones> ObtenerEvaluaciones()
        {
            try
            {
                var evaluaciones = _logic.RetrieveAll();

                // Validar que no sea null
                if (evaluaciones == null)
                {
                    return new List<Evaluaciones>();
                }

                return evaluaciones;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las evaluaciones: {ex.Message}");
            }
        }


        [WebMethod]
        public string ActualizarEvaluacion(int evaluacionId, int cursoId, string titulo, DateTime fecha, int puntuacionMaxima)
        {
            try
            {
                Evaluaciones evaluacion = new Evaluaciones
                {
                    EvaluacionID = evaluacionId,
                    CursoID = cursoId,
                    Titulo = titulo,
                    Fecha = fecha,
                    PuntuacionMaxima = puntuacionMaxima
                };

                bool result = _logic.Update(evaluacion);
                return result ? "Evaluación actualizada correctamente." : "Evaluación no encontrada.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar la evaluación: {ex.Message}";
            }
        }

        [WebMethod]
        public string EliminarEvaluacion(int evaluacionId)
        {
            try
            {
                bool result = _logic.Delete(evaluacionId);
                return result ? "Evaluación eliminada correctamente." : "Evaluación no encontrada o no se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la evaluación: {ex.Message}";
            }
        }

        #endregion
    }
}
