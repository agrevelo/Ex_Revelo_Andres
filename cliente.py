from zeep import Client
from zeep.exceptions import Fault

# URL del WSDL del servicio SOAP
wsdl = "http://localhost:49698/EvaluacionService.asmx?WSDL"

# Crear cliente SOAP
client = Client(wsdl=wsdl)

# Funciones para interactuar con el servicio SOAP
def agregar_evaluacion(curso_id, titulo, fecha, puntuacion_maxima):
    try:
        response = client.service.AgregarEvaluacion(
            cursoId=curso_id,
            titulo=titulo,
            fecha=fecha,
            puntuacionMaxima=puntuacion_maxima
        )
        print("Respuesta:", response)
    except Fault as e:
        print("Error al agregar evaluación:", e)

def obtener_evaluaciones():
    try:
        response = client.service.ObtenerEvaluaciones()
        print("Evaluaciones obtenidas:")
        for evaluacion in response:
            print(f"ID: {evaluacion['EvaluacionID']}, Curso ID: {evaluacion['CursoID']}, Título: {evaluacion['Titulo']}, Fecha: {evaluacion['Fecha']}, Puntuación Máxima: {evaluacion['PuntuacionMaxima']}")
    except Fault as e:
        print("Error al obtener evaluaciones:", e)

def actualizar_evaluacion(evaluacion_id, curso_id, titulo, fecha, puntuacion_maxima):
    try:
        response = client.service.ActualizarEvaluacion(
            evaluacionId=evaluacion_id,
            cursoId=curso_id,
            titulo=titulo,
            fecha=fecha,
            puntuacionMaxima=puntuacion_maxima
        )
        print("Respuesta:", response)
    except Fault as e:
        print("Error al actualizar evaluación:", e)

def eliminar_evaluacion(evaluacion_id):
    try:
        response = client.service.EliminarEvaluacion(evaluacionId=evaluacion_id)
        print("Respuesta:", response)
    except Fault as e:
        print("Error al eliminar evaluación:", e)

# Ejemplo de uso
if __name__ == "__main__":
    # Agregar una evaluación
    #agregar_evaluacion(3, "Distribuidas", "2024-12-23", 17)

    # Listar evaluaciones
    obtener_evaluaciones()

    # Actualizar una evaluación
    #actualizar_evaluacion(3, 5, "Título Actualizado2", "2024-12-23", 90)

    # Eliminar una evaluación
    #eliminar_evaluacion(7)
