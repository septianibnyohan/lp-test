using System.ComponentModel.DataAnnotations.Schema;

namespace Soal1_2_3.Models
{
    [Table("MasterJenisBuku")]
    public class MasterJenisBuku
    {
        public int Id { get; set; }
        public string JenisBuku { get; set; }
    }
}
