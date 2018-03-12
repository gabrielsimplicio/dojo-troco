using FluentAssertions;
using PJMT.ProvaArq.Domain.Entities.Pagamento;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Cedula;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda;
using PJMT.ProvaArq.Domain.ValueObjects.Troco;
using System.Linq;
using Xunit;

namespace PJMT.ProvaArq.Tests
{
    public class TrocoSpecs
    {
        [Fact]
        public void Deve_retornar_troco_de_quatro_centavos_com_pagamento_de_cincos_centavos_e_valor_de_um_centavo()
        {
            var pagamento = new Pagamento(0.01M, 0.05M);
            var troco = new Troco(pagamento);

            troco.Montante.Dinheiros.Count().Should().Be(4);
            troco.Montante.Dinheiros.ElementAt(0).Should().BeOfType<UmCentavo>();
            troco.Montante.Dinheiros.ElementAt(1).Should().BeOfType<UmCentavo>();
            troco.Montante.Dinheiros.ElementAt(2).Should().BeOfType<UmCentavo>();
            troco.Montante.Dinheiros.ElementAt(3).Should().BeOfType<UmCentavo>();
        }

        [Fact]
        public void Deve_retornar_troco_de_cinco_centavos_com_pagamento_de_dez_centavos_e_valor_de_cinco_centavos()
        {
            var pagamento = new Pagamento(0.05M, 0.1M);
            var troco = new Troco(pagamento);

            troco.Montante.Dinheiros.Count().Should().Be(1);
            troco.Montante.Dinheiros.ElementAt(0).Should().BeOfType<CincoCentavos>();
        }

        [Fact]
        public void Deve_retornar_troco_de_40_centavos_com_pagamento_de_50_centavos_e_valor_de_10_centavos()
        {
            var pagamento = new Pagamento(0.10M, 0.5M);
            var troco = new Troco(pagamento);

            troco.Montante.Dinheiros.Count().Should().Be(4);
            troco.Montante.Dinheiros.ElementAt(0).Should().BeOfType<DezCentavos>();
            troco.Montante.Dinheiros.ElementAt(1).Should().BeOfType<DezCentavos>();
            troco.Montante.Dinheiros.ElementAt(2).Should().BeOfType<DezCentavos>();
            troco.Montante.Dinheiros.ElementAt(3).Should().BeOfType<DezCentavos>();
        }

        [Fact]
        public void Deve_retornar_troco_de_50_centavos_com_pagamento_de_1_real_e_valor_de_50_centavos()
        {
            var pagamento = new Pagamento(0.5M, 1M);
            var troco = new Troco(pagamento);

            troco.Montante.Dinheiros.Count().Should().Be(1);
            troco.Montante.Dinheiros.ElementAt(0).Should().BeOfType<CinquentaCentavos>();
        }

        [Fact]
        public void Deve_retornar_troco_de_4_reais_com_pagamento_de_5_reais_e_valor_de_1_real()
        {
            var pagamento = new Pagamento(1M, 5M);
            var troco = new Troco(pagamento);

            troco.Montante.Dinheiros.Count().Should().Be(4);
            troco.Montante.Dinheiros.ElementAt(0).Should().BeOfType<UmReal>();
            troco.Montante.Dinheiros.ElementAt(1).Should().BeOfType<UmReal>();
            troco.Montante.Dinheiros.ElementAt(2).Should().BeOfType<UmReal>();
            troco.Montante.Dinheiros.ElementAt(3).Should().BeOfType<UmReal>();
        }

        [Fact]
        public void Deve_retornar_troco_de_5_reais_com_pagamento_de_10_reais_e_valor_de_5_reais()
        {
            var pagamento = new Pagamento(5M, 10M);
            var troco = new Troco(pagamento);

            troco.Montante.Dinheiros.Count().Should().Be(1);
            troco.Montante.Dinheiros.ElementAt(0).Should().BeOfType<CincoReais>();
        }

        [Fact]
        public void Deve_retornar_troco_de_40_reais_com_pagamento_de_50_reais_e_valor_de_10_reais()
        {
            var pagamento = new Pagamento(10M, 50M);
            var troco = new Troco(pagamento);

            troco.Montante.Dinheiros.Count().Should().Be(4);
            troco.Montante.Dinheiros.ElementAt(0).Should().BeOfType<DezReais>();
            troco.Montante.Dinheiros.ElementAt(1).Should().BeOfType<DezReais>();
            troco.Montante.Dinheiros.ElementAt(2).Should().BeOfType<DezReais>();
            troco.Montante.Dinheiros.ElementAt(3).Should().BeOfType<DezReais>();
        }

        [Fact]
        public void Deve_retornar_troco_de_50_reais_com_pagamento_de_50_reais_e_valor_de_100_reais()
        {
            var pagamento = new Pagamento(50M, 100M);
            var troco = new Troco(pagamento);

            troco.Montante.Dinheiros.Count().Should().Be(1);
            troco.Montante.Dinheiros.ElementAt(0).Should().BeOfType<CinquentaReais>();
        }
    }
}
