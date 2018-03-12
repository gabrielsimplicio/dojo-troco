using FluentAssertions;
using PJMT.ProvaArq.Domain.Entities.Pagamento;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda;
using System;
using Xunit;

namespace PJMT.ProvaArq.Tests
{
    public class PagamentoSpecs
    {
        private readonly decimal _umCentavo = Moeda.UmCentavo.Valor;

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_acusar_erro_ao_inserir_valor_total_inv�lido(decimal valorTotal)
        {
            Action act = () => new Pagamento(valorTotal, _umCentavo);
            act.Should().Throw<ValorTotalInseridoNoPagamentoOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_acusar_erro_ao_inserir_valor_efetivamente_pago_inv�lido(decimal valorEfetivamentePago)
        {
            Action act = () => new Pagamento(_umCentavo, valorEfetivamentePago);
            act.Should().Throw<ValorEfetivamentePagoInseridoNoPagamentoOutOfRangeException>();
        }

        [Fact]
        public void Deve_acusar_erro_ao_passar_valor_efetivamente_pago_menor_que_valor_total()
        {
            Action act = () => new Pagamento(0.02M, _umCentavo);
            act.Should().Throw<ValorEfetivamentePagoMenorQueValorTotalException>();
        }

        [Fact]
        public void Deve_atribuir_ao_valor_total_corretamente()
        {
            var pagamento = new Pagamento(_umCentavo, _umCentavo);
            pagamento.ValorTotal.Should().Be(_umCentavo);
        }

        [Fact]
        public void Deve_atribuir_ao_montante_do_valor_efetivamente_pago_corretamente()
        {
            var pagamento = new Pagamento(_umCentavo, _umCentavo);
            pagamento.ValorEfetivamentePago.Should().Be(_umCentavo);
        }
    }
}
