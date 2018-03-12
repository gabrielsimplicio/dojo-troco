using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Cedula;
using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda;
using System;
using System.Collections.Generic;

namespace PJMT.ProvaArq.Domain.ValueObjects.Montante
{
    public class MontanteBuilder
    {
        private List<IDinheiro> _dinheiros = new List<IDinheiro>();

        public MontanteBuilder AdicionarUmCentavo()
        {
            Adicionar<UmCentavo>();
            return this;
        }

        public MontanteBuilder AdicionarCincoCentavos()
        {
            Adicionar<CincoCentavos>();
            return this;
        }

        public MontanteBuilder AdicionarDezCentavos()
        {
            Adicionar<DezCentavos>();
            return this;
        }

        public MontanteBuilder AdicionarCinquentaCentavos()
        {
            Adicionar<CinquentaCentavos>();
            return this;
        }

        public MontanteBuilder AdicionarUmReal()
        {
            Adicionar<UmReal>();
            return this;
        }

        public MontanteBuilder AdicionarCincoReais()
        {
            Adicionar<CincoReais>();
            return this;
        }

        public MontanteBuilder AdicionarDezReais()
        {
            Adicionar<DezReais>();
            return this;
        }

        public MontanteBuilder AdicionarCinquentaReais()
        {
            Adicionar<CinquentaReais>();
            return this;
        }

        public MontanteBuilder AdicionarCemReais()
        {
            Adicionar<CemReais>();
            return this;
        }

        public MontanteBuilder Adicionar<T>() where T : IDinheiro
        {
            var dinheiro = Activator.CreateInstance<T>();
            _dinheiros.Add(dinheiro);
            return this;
        }

        public MontanteBuilder Adicionar<T>(T dinheiro) where T : IDinheiro
        {
            _dinheiros.Add(dinheiro);
            return this;
        }

        public Montante ObterMontante()
        {
            return new Montante(_dinheiros);
        }
    }
}
