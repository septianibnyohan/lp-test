using System.ComponentModel.DataAnnotations.Schema;

namespace Soal1_2_3.Models
{
    [Table("Buku")]
    public class Buku
    {
        public int Id { get; set; }
        public string Judul { get; set; } = string.Empty;
        public string Penulis { get; set; } = string.Empty;
        public int JenisBukuId { get; set; }
        public DateTime TanggalRilis { get; set; }
        public int JumlahHalaman { get; set; }

        [ForeignKey(nameof(JenisBukuId))]
        public MasterJenisBuku? MasterJenisBuku { get; set; }
    }
}
