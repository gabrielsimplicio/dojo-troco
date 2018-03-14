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
            var umECincoCentavosTrocoHandler = new TrocoHandler(Moeda.UmCentavo, Moeda.CincoCentavos);

            var cincoEDezCentavosTrocoHandler = new TrocoHandler(Moeda.CincoCentavos, Moeda.DezCentavos)
                .RegistrarSucessor(umECincoCentavosTrocoHandler);

            var dezECinquentaCentavosTrocoHandler = new TrocoHandler(Moeda.DezCentavos, Moeda.CinquentaCentavos)
                .RegistrarSucessor(cincoEDezCentavosTrocoHandler);

            var cinquentaCentavosEUmRealTrocoHandler = new TrocoHandler(Moeda.CinquentaCentavos, Cedula.UmReal)
                .RegistrarSucessor(dezECinquentaCentavosTrocoHandler);

            var umECincoReaisTrocoHandler = new TrocoHandler(Cedula.UmReal, Cedula.CincoReais)
                .RegistrarSucessor(cinquentaCentavosEUmRealTrocoHandler);

            var cincoEDezReaisTrocoHandler = new TrocoHandler(Cedula.CincoReais, Cedula.DezReais)
                .RegistrarSucessor(umECincoReaisTrocoHandler);

            var dezECinquentaReaisTrocoHandler = new TrocoHandler(Cedula.DezReais, Cedula.CinquentaReais)
                .RegistrarSucessor(cincoEDezReaisTrocoHandler);

            var cinquentaECemReaisTrocoHandler = new TrocoHandler(Cedula.CinquentaReais, Cedula.CemReais)
                .RegistrarSucessor(dezECinquentaReaisTrocoHandler);

            return cinquentaECemReaisTrocoHandler;
        }
    }
}
