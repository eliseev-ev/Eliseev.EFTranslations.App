using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eliseev.EFTranslations.App.Models
{
    public class SomeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Property1 { get; private set; }
        
        public string Property2 { get; private set; } = "NoGen";
        
        public string Property3 { get; set; }

        public string Property4 { get; set; }
    }
}
