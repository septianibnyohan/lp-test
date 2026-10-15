namespace Soal1_2_3.Dto
{
    public record BukuDto
    (
        string Judul,
        string Penulis,
        int JenisBukuId,
        DateTime TanggalRilis,
        int JumlahHalaman
    );
}
