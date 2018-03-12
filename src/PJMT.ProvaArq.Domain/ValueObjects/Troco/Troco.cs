using PJMT.ProvaArq.Domain.Entities.Pagamento;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Cedula;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda;
using PJMT.ProvaArq.Domain.ValueObjects.Montante;

namespace PJMT.ProvaArq.Domain.ValueObjects.Troco
{
    public class Troco
    {
        public Montante.Montante Montante { get; private set; }

        public Pagamento Pagamento { get; private set; }

        public Troco(Pagamento pagamento)
        {
            Pagamento = pagamento;
            CalcularTroco();
        }

        public void CalcularTroco()
        {
            var montanteBuilder = new MontanteBuilder();

            var troco = Pagamento.ValorEfetivamentePago - Pagamento.ValorTotal;

            //TODO: Chain of responsability
            HandleTroco(troco, Cedula.CinquentaReais, Cedula.CemReais, montanteBuilder);
            HandleTroco(troco, Cedula.DezReais, Cedula.CinquentaReais, montanteBuilder);
            HandleTroco(troco, Cedula.CincoReais, Cedula.DezReais, montanteBuilder);
            HandleTroco(troco, Cedula.UmReal, Cedula.CincoReais, montanteBuilder);
            HandleTroco(troco, Moeda.CinquentaCentavos, Cedula.UmReal, montanteBuilder);
            HandleTroco(troco, Moeda.DezCentavos, Moeda.CinquentaCentavos, montanteBuilder);
            HandleTroco(troco, Moeda.CincoCentavos, Moeda.DezCentavos, montanteBuilder);
            HandleTroco(troco, Moeda.UmCentavo, Moeda.CincoCentavos, montanteBuilder);

            Montante = montanteBuilder.ObterMontante();
        }

        private void HandleTroco(decimal troco, IDinheiro faixaInicial, IDinheiro faixaFinal, MontanteBuilder montanteBuilder)
        {
            if (troco >= faixaInicial.Valor && troco < faixaFinal.Valor)
            {
                while (troco > faixaInicial.Valor - 0.01M)
                {
                    montanteBuilder.Adicionar(faixaInicial);
                    troco -= faixaInicial.Valor;
                }
            }
        }
    }
}
