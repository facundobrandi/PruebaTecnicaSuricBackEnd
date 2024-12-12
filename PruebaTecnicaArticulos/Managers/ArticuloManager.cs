using Microsoft.EntityFrameworkCore;
using PruebaTecnicaConfig.Models;
using PruebaTecnicaConfig.Utils;
using System.Text.RegularExpressions;

namespace PruebaTecnicaArticulos.Managers
{
    public class ArticuloManager
    {
        private PruebaTecnicaConfig.Models.PruebaTecnicaSurisContext _context;

        public ArticuloManager(PruebaTecnicaSurisContext context)
        {
            _context = context;
        }
        
        public async Task<Responce> GetArticulos() 
        {
            var users = await _context.Articulos.ToListAsync();

            return new Responce((int)SystemEnums.CodesResponce.Ok, users, "Articulos");
        }

        public async Task<Responce> PostPedidos(int[] pedidosIds , string name)
        {

            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            var pedidos = await _context.Articulos.Where(i=> pedidosIds.Contains(i.Id)).ToListAsync();

            if (pedidos.Count == 0)
            {
                return new Responce((int)SystemEnums.CodesResponce.Error,null, "array is null");
            }

            var pedidosFiltrados = pedidos.Where(i => i.Precio > 0 && i.Deposito == 1 && regexItem.IsMatch(i.Descripcion)).ToList();

            if (pedidosFiltrados.Count != pedidos.Count)
            {
                return new Responce((int)SystemEnums.CodesResponce.Error, null, "Uno de los pedidos fue rechazado");
            }

            if (string.IsNullOrEmpty(name))
            {
                return new Responce((int)SystemEnums.CodesResponce.Error, null, "name is null");
            }

            var ListPedidos = new List<Pedido>();

            foreach (var item in pedidosFiltrados)
            {
                var Pedido = new Pedido {Name = name , ArticuloId = item.Id };

                await this._context.Pedidos.AddAsync(Pedido);
            }

            await this._context.SaveChangesAsync();

            return new Responce((int)SystemEnums.CodesResponce.Ok, null, "Pedidos se an guardado");
        }
    }
}
