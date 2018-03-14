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
        private readonly Guid _pagamentoId = Guid.NewGuid();

        [Fact]
        public void Deve_acusar_erro_ao_inserir_pagamento_id_vazio()
        {
            Action act = () => new Pagamento(Guid.Empty, _umCentavo, _umCentavo);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_acusar_erro_ao_inserir_valor_total_inválido(decimal valorTotal)
        {
            Action act = () => new Pagamento(_pagamentoId, valorTotal, _umCentavo);
            act.Should().Throw<ValorTotalInseridoNoPagamentoOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_acusar_erro_ao_inserir_valor_efetivamente_pago_inválido(decimal valorEfetivamentePago)
        {
            Action act = () => new Pagamento(_pagamentoId, _umCentavo, valorEfetivamentePago);
            act.Should().Throw<ValorEfetivamentePagoInseridoNoPagamentoOutOfRangeException>();
        }

        [Fact]
        public void Deve_acusar_erro_ao_passar_valor_efetivamente_pago_menor_que_valor_total()
        {
            Action act = () => new Pagamento(_pagamentoId, 0.02M, _umCentavo);
            act.Should().Throw<ValorEfetivamentePagoMenorQueValorTotalException>();
        }

        [Fact]
        public void Deve_atribuir_ao_pagamento_id_corretamente()
        {
            var pagamento = new Pagamento(_pagamentoId, _umCentavo, _umCentavo);
            pagamento.PagamentoId.Should().Be(_pagamentoId);
        }

        [Fact]
        public void Deve_atribuir_ao_valor_total_corretamente()
        {
            var pagamento = new Pagamento(_pagamentoId, _umCentavo, _umCentavo);
            pagamento.ValorTotal.Should().Be(_umCentavo);
        }

        [Fact]
        public void Deve_atribuir_ao_montante_do_valor_efetivamente_pago_corretamente()
        {
            var pagamento = new Pagamento(_pagamentoId, _umCentavo, _umCentavo);
            pagamento.ValorEfetivamentePago.Should().Be(_umCentavo);
        }
    }
}
