using evaluacion2api.Models;
using Microsoft.AspNetCore.Mvc;

namespace evaluacion2api.Responses
{

    public class UsuarioResponse : ResponseBase<Usuario>
    {

    }

    public class UsuariosResponse : ResponseBase<List<Usuario>>
    {

    }

    public class NuevoUsuarioResponse : ResponseBase<bool>
    {

    }


    public class UpdateUsuarioResponse : ResponseBase<bool>
    {
    }
}
