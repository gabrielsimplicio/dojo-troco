namespace PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Cedula
{
    public class CincoReais : ICedula
    {
        public decimal Valor => 5M;

        public override string ToString() => "Cinco Reais";
    }
}
