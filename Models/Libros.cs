using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libro_Store.Data
{
   
    
        public class Libros
        {
            [Key]
            public string Title { get; set; }
            [StringLength(maximumLength: 450)]
            public string Author { get; set; }
            [StringLength(maximumLength: 450)]

            [DataType(DataType.Currency)]
            [Column(TypeName = "money")]
            public Nullable<decimal> Price { get; set; }
            public string? Description { get; set; }


            public byte[]? ImageData { get; set; }


        }

    
}
