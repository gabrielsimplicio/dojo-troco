namespace PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Cedula
{
    public class CemReais : ICedula
    {
        public decimal Valor => 100M;

        public override string ToString() => "Cem Reais";
    }
}