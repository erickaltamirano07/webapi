using webapi;
using webapi.Models;

namespace webapi.Services;

public class TareaService:ITareasService
{

    TareasContext context;

    public TareaService(TareasContext dbcontext)
    {
        context=dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task SaveAsincrono(Tarea tarea)
    {
        context.Tareas.Add(tarea);
        await context.SaveChangesAsync();
    }

     public async Task Update(Guid id, Tarea Tarea)
    {
        var TareaActual = context.Tareas.Find(id);

        if(TareaActual != null)
        {
            TareaActual.Titulo = Tarea.Titulo;
            Tarea.Descripcion = Tarea.Descripcion;
            Tarea.PrioridadTarea = Tarea.PrioridadTarea;
            Tarea.CategoriaId = Tarea.CategoriaId;
            
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var TareaActual = context.Tareas.Find(id);

        if(TareaActual != null)
        {
            context.Remove(TareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task SaveAsincrono(Tarea tarea);

    Task Update(Guid id, Tarea Tarea);

    Task Delete(Guid id);
}