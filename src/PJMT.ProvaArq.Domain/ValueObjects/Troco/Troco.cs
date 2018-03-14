using PJMT.ProvaArq.Domain.Entities.Pagamento;
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

        private void CalcularTroco()
        {
            var montanteBuilder = new MontanteBuilder();

            var troco = Pagamento.ValorEfetivamentePago - Pagamento.ValorTotal;

            var handlers = RegistrarTrocoHandlers();
            handlers.HandleTroco(troco, montanteBuilder);

            Montante = montanteBuilder.ObterMontante();
        }

        private TrocoHandler RegistrarTrocoHandlers()
        {
            var umACincoCentavosTrocoHandler = new TrocoHandler(Moeda.UmCentavo, Moeda.CincoCentavos);

            var cincoADezCentavosTrocoHandler = new TrocoHandler(Moeda.CincoCentavos, Moeda.DezCentavos)
                .RegistrarSucessor(umACincoCentavosTrocoHandler);

            var dezACinquentaCentavosTrocoHandler = new TrocoHandler(Moeda.DezCentavos, Moeda.CinquentaCentavos)
                .RegistrarSucessor(cincoADezCentavosTrocoHandler);

            var cinquentaCentavosAUmRealTrocoHandler = new TrocoHandler(Moeda.CinquentaCentavos, Cedula.UmReal)
                .RegistrarSucessor(dezACinquentaCentavosTrocoHandler);

            var umACincoReaisTrocoHandler = new TrocoHandler(Cedula.UmReal, Cedula.CincoReais)
                .RegistrarSucessor(cinquentaCentavosAUmRealTrocoHandler);

            var cincoADezReaisTrocoHandler = new TrocoHandler(Cedula.CincoReais, Cedula.DezReais)
                .RegistrarSucessor(umACincoReaisTrocoHandler);

            var dezACinquentaReaisTrocoHandler = new TrocoHandler(Cedula.DezReais, Cedula.CinquentaReais)
                .RegistrarSucessor(cincoADezReaisTrocoHandler);

            var cinquentaACemReaisTrocoHandler = new TrocoHandler(Cedula.CinquentaReais, Cedula.CemReais)
                .RegistrarSucessor(dezACinquentaReaisTrocoHandler);

            return cinquentaACemReaisTrocoHandler;
        }
    }
}
