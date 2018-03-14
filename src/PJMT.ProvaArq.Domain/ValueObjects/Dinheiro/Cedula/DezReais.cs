namespace PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Cedula
{
    public class DezReais : ICedula
    {
        public decimal Valor => 10M;

        public override string ToString() => "Dez Reais";
    }
}