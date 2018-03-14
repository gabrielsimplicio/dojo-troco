namespace PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Cedula
{
    public class CinquentaReais : ICedula
    {
        public decimal Valor => 50M;

        public override string ToString() => "Cinquenta Reais";
    }
}