using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Shop.web.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Este Campo {0} solo puede contener un maximo de {1} caracteres")]
        [Required]

        public string Nombre { get; set; }


            [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
            public decimal Precio { get; set; }

            [Display(Name = "Imagen")]
            public string UrlImagen { get; set; }

            [Display(Name = "Ultima fecha compra")]
            public DateTime? Ultima_fecha_Compra { get; set; }

            [Display(Name = "Ultima compra")]
            public DateTime? Ultima_Compra { get; set; }

            [Display(Name = "Disponibilidad?")]
            public bool Disponibilidad { get; set; }

            [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
            public double Stock { get; set; }
        


    }
}
