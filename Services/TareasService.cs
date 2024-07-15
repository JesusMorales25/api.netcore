using webapi.Models;
namespace webapi.Services;
public class TareasService: ITareasService
{
	
	TareasContext context;

	public TareasService(TareasContext dbContext)
	{
		context = dbContext;
	}

	public IEnumerable<Tarea> GetTareas()
	{
		return context.Tareas;
	}

	public async Task Save(Tarea tareas)
	{
		context.Add(tareas);
		await context.SaveChangesAsync();
	}

	public async Task Update(Guid id, Tarea tarea)
	{
		var tareaActual = context.Tareas.Find(id);

		if (tareaActual != null)
		{
			tareaActual.Titulo = tarea.Titulo;
			tarea.Resumen = tarea.Resumen;
			tarea.Descripcion = tarea.Descripcion;
			tarea.Categoria = tarea.Categoria;

			await context.SaveChangesAsync();

		}
	
	}

	public async Task Delete(Guid id)
	{
		var tareaActual = context.Tareas.Find(id);

		if (tareaActual != null)
		{
			context.Remove(tareaActual);
			await context.SaveChangesAsync();
		}
	}
}
public interface ITareasService
{
	IEnumerable<Tarea> GetTareas();
	Task Save(Tarea tareas);

	Task Update(Guid id, Tarea tarea);

	Task Delete(Guid id);


}