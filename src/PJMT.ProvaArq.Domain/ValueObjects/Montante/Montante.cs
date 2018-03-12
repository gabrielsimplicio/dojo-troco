using PJMT.ProvaArq.Domain.ValueObjects.Dinheiro;
using System.Collections.Generic;
using System.Linq;

namespace PJMT.ProvaArq.Domain.ValueObjects.Montante
{
    public class Montante
    {
        private List<IDinheiro> _dinheiros = new List<IDinheiro>();

        public IReadOnlyCollection<IDinheiro> Dinheiros => _dinheiros.AsReadOnly();
        public decimal ValorTotal => _dinheiros.Sum(x => x.Valor);

        public Montante(List<IDinheiro> dinheiros)
        {
            _dinheiros = dinheiros;
        }
    }
}
