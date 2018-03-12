using FluentAssertions;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Cedula;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda;
using PJMT.ProvaArq.Domain.ValueObjects.Montante;
using System.Linq;
using Xunit;

namespace PJMT.ProvaArq.Tests
{
    public class MontanteSpecs
    {
        private readonly MontanteBuilder _montanteBuilder = new MontanteBuilder();

        [Fact]
        public void Deve_ter_valor_total_de_um_centavo()
        {
            var montante = _montanteBuilder.AdicionarUmCentavo().ObterMontante();
            montante.ValorTotal.Should().Be(0.01M);
        }

        [Fact]
        public void Deve_ter_valor_total_de_cinco_centavos()
        {
            var montante = _montanteBuilder.AdicionarCincoCentavos().ObterMontante();
            montante.ValorTotal.Should().Be(0.05M);
        }

        [Fact]
        public void Deve_ter_valor_total_de_dez_centavos()
        {
            var montante = _montanteBuilder.AdicionarDezCentavos().ObterMontante();
            montante.ValorTotal.Should().Be(0.1M);
        }

        [Fact]
        public void Deve_ter_valor_total_de_cinquenta_centavos()
        {
            var montante = _montanteBuilder.AdicionarCinquentaCentavos().ObterMontante();
            montante.ValorTotal.Should().Be(0.5M);
        }

        [Fact]
        public void Deve_ter_valor_total_de_um_real()
        {
            var montante = _montanteBuilder.AdicionarUmReal().ObterMontante();
            montante.ValorTotal.Should().Be(1M);
        }

        [Fact]
        public void Deve_ter_valor_total_de_cinco_reais()
        {
            var montante = _montanteBuilder.AdicionarCincoReais().ObterMontante();
            montante.ValorTotal.Should().Be(5M);
        }

        [Fact]
        public void Deve_ter_valor_total_de_dez_reais()
        {
            var montante = _montanteBuilder.AdicionarDezReais().ObterMontante();
            montante.ValorTotal.Should().Be(10M);
        }

        [Fact]
        public void Deve_ter_valor_total_de_cinquenta_reais()
        {
            var montante = _montanteBuilder.AdicionarCinquentaReais().ObterMontante();
            montante.ValorTotal.Should().Be(50M);
        }

        [Fact]
        public void Deve_ter_valor_total_de_cem_reais()
        {
            var montante = _montanteBuilder.AdicionarCemReais().ObterMontante();
            montante.ValorTotal.Should().Be(100M);
        }

        [Fact]
        public void Deve_ter_montante_com_uma_moeda_de_um_centavo()
        {
            var montante = _montanteBuilder.AdicionarUmCentavo().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<UmCentavo>();
        }

        [Fact]
        public void Deve_ter_montante_com_uma_moeda_de_cinco_centavos()
        {
            var montante = _montanteBuilder.AdicionarCincoCentavos().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<CincoCentavos>();
        }

        [Fact]
        public void Deve_ter_montante_com_uma_moeda_de_dez_centavos()
        {
            var montante = _montanteBuilder.AdicionarDezCentavos().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<DezCentavos>();
        }

        [Fact]
        public void Deve_ter_montante_com_uma_moeda_de_cinquenta_centavos()
        {
            var montante = _montanteBuilder.AdicionarCinquentaCentavos().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<CinquentaCentavos>();
        }

        [Fact]
        public void Deve_ter_montante_com_uma_cédula_de_um_real()
        {
            var montante = _montanteBuilder.AdicionarUmReal().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<UmReal>();
        }

        [Fact]
        public void Deve_ter_montante_com_uma_cédula_de_cinco_reais()
        {
            var montante = _montanteBuilder.AdicionarCincoReais().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<CincoReais>();
        }

        [Fact]
        public void Deve_ter_montante_com_uma_cédula_de_dez_reais()
        {
            var montante = _montanteBuilder.AdicionarDezReais().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<DezReais>();
        }

        [Fact]
        public void Deve_ter_montante_com_uma_cédula_de_cinquenta_reais()
        {
            var montante = _montanteBuilder.AdicionarCinquentaReais().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<CinquentaReais>();
        }

        [Fact]
        public void Deve_ter_montante_com_uma_cédula_de_cem_reais()
        {
            var montante = _montanteBuilder.AdicionarCemReais().ObterMontante();

            montante.Dinheiros.Count().Should().Be(1);
            montante.Dinheiros.ElementAt(0).Should().BeOfType<CemReais>();
        }
    }
}
