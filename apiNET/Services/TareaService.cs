using apiNET.Models;
using apiNET;

namespace apiNET.Services;

public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext tareasContext)
    {
        context = tareasContext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);

        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.FechaCreacion = tarea.FechaCreacion;
            tareaActual.Resumen = tarea.Resumen;
        }

        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {
            context.Remove(tareaActual);
        }

        await context.SaveChangesAsync();
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Delete(Guid id);
    Task Update(Guid id, Tarea tarea);
}
