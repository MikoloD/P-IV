using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFramework
{
    public class Zajecia
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("NazwaPrzedmiotu")]
        public string Nazwa { get; set; }
        public DateTime GodzinaRozpoczecia { get; set; }
    }
}
