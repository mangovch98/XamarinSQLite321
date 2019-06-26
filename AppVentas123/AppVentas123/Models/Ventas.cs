using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVentas.Models
{
    [Table("ventas")]
    public class Ventas
    {
        [PrimaryKey,AutoIncrement]
        public int VentaId { get; set; }

        [MaxLength(70)]
        public string Producto { get; set; }

        [NotNull]
        public int Cantidad { get; set; }
        
        public DateTime Fecha { get; set; }
       
    }
}
