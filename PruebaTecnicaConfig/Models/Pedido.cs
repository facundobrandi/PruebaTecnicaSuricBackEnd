using System;
using System.Collections.Generic;

namespace PruebaTecnicaConfig.Models
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ArticuloId { get; set; }

        public virtual Articulo? Articulo { get; set; }
    }
}
