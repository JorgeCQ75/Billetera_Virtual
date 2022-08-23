namespace Tarjetero_Virtual.Models
{
    public class TarjetaModel
    {
        public int? tar_id { get; set; }
        public string? tar_dueño { get; set; }
        public string? tar_banco { get; set; }
        public string? tar_emisor { get; set; }
        public string? tar_numerotarjeta { get; set; }
        public string? tar_ccv { get; set; }
        public string? tar_fechaexpiracion { get; set; }
        public string? tar_estado { get; set; }
        public string? tar_fotobanco { get; set; }
        public string? tar_fotoemisor { get; set; }
        public string? tar_fotofondo { get; set; }
        public string? tar_ultimosd  { get; set; }
        public int? tar_calculo { get; set; }


    }
}
