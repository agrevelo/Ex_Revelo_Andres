using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface IEvaluacionesService
    {
        // Crear un producto
        Evaluaciones CreateEvaluaciones(Evaluaciones evaluaciones);

        // Eliminar un producto por ID
        bool Delete(int id);

        // Obtener todos los productos
        List<Evaluaciones> GetAll();

        // Obtener un producto por ID
        Evaluaciones GetById(int id);

        // Actualizar un producto
        bool UpdateProduct(Evaluaciones evaluaciones);
    }
}
