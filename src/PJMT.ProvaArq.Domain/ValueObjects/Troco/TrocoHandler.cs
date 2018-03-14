using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro;
using PJMT.ProvaArq.Domain.ValueObjects.Montante;

namespace PJMT.ProvaArq.Domain.ValueObjects.Troco
{
    public class TrocoHandler
    {
        private IDinheiro _faixaInicial;
        private IDinheiro _faixaFinal;
        private TrocoHandler _proximoHandler;

        public TrocoHandler(IDinheiro faixaInicial, IDinheiro faixaFinal)
        {
            _faixaInicial = faixaInicial;
            _faixaFinal = faixaFinal;
        }

        public TrocoHandler RegistrarSucessor(TrocoHandler proximoHandler)
        {
            _proximoHandler = proximoHandler;
            return this;
        }
        
        public void HandleTroco(decimal troco, MontanteBuilder montanteBuilder)
        {
            if (troco >= _faixaInicial.Valor && troco < _faixaFinal.Valor)
            {
                while (troco > _faixaInicial.Valor - 0.01M)
                {
                    montanteBuilder.Adicionar(_faixaInicial);
                    troco -= _faixaInicial.Valor;
                }
            }

            if(_proximoHandler != null)
            {
                _proximoHandler.HandleTroco(troco, montanteBuilder);
            }
        }
    }
}
