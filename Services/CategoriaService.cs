using webapi;
using webapi.Models;

namespace webapi.Services;


public class CategoriaService:ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context=dbcontext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;

    }

    public void Save(Categoria categoria)
    {
        context.Add(categoria);
        context.SaveChanges();
    }

     public async Task SaveAsincrona(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsincrona(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual!=null)
        {
            categoriaActual.Nombre=categoria.Nombre;
            categoria.Descripcion=categoria.Descripcion;
            categoria.Peso=categoria.Peso;
            
            await context.SaveChangesAsync();
        }
        
        
    }

    
    public async Task DeleteAsincrona(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual!=null)
        {
            context.Remove(categoriaActual);       
            await context.SaveChangesAsync();
        }
        
        
    }

}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    void Save(Categoria categoria);
    Task SaveAsincrona(Categoria categoria);
    Task UpdateAsincrona(Guid id, Categoria categoria);
    Task DeleteAsincrona(Guid id);


}