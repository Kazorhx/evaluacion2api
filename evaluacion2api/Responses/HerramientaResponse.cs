using evaluacion2api.Models;
using Microsoft.AspNetCore.Mvc;

namespace evaluacion2api.Responses
{
    public class HerramientaResponse : ResponseBase<Herramienta> 
    {
    }
    // 
    public class HerramientasResponse : ResponseBase<List<Herramienta>> 
    { 
    }
    // nueva herramienta
    public class NuevoHerramientaResponse : ResponseBase<bool> 
    { 
    }
    // actualizar herramienta
    public class UpdateHerramientaResponse : ResponseBase<bool> 
    { 
    }
    // borrar herramienta
    public class DeleteHerramientaResponse : ResponseBase<bool> 
    {
    }
   
}
