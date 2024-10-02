using evaluacion2api.Models;

namespace evaluacion2api.Responses
{
        public class TareaResponse : ResponseBase<Tarea>
        {
        }

        public class TareasResponse : ResponseBase<List<Tarea>>
        {
        }

        public class NuevaTareaResponse : ResponseBase<bool>
        {
        }

        public class UpdateTareaResponse : ResponseBase<bool>
        {
        }

        public class DeleteTareaResponse : ResponseBase<bool>
        {
        }

    }


