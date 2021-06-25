namespace Lab03.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Required(ErrorMessage = "Không được để trống")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(255, ErrorMessage = "Nhập quá ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(255)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(255, ErrorMessage = "Nhập quá ký tự")]
        public string Images { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(1000, 1000000, ErrorMessage = "tu 1k den 1M")]
        public int? Price { get; set; }
    }
}
