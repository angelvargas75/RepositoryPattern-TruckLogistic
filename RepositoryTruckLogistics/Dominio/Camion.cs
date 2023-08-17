namespace Dominio
{
    public class Camion
    {
        public int Id { get; set; }
        public string TipoDeCarga { get; set; }
        public string Chasis { get; set; }
        public int RecuentoDeEngranajes { get; set; }
        public string Retardero { get; set; }
        public int EjesAlimentados { get; set; }
        public int PotenciaDelMotor { get; set; }
        public int EsfuerzoDeTorsion { get; set; }
    }
}
