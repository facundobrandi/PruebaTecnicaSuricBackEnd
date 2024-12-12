using System;
using System.Collections.Generic;

namespace PruebaTecnicaConfig.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Deposito { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
