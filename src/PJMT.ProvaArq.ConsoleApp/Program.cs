using PJMT.ProvaArq.Domain.Entities.Pagamento;
using PJMT.ProvaArq.Domain.ValueObjects.Troco;
using System;
using System.Globalization;

namespace PJMT.ProvaArq.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finalizarPrograma = false;
            while (!finalizarPrograma)
            {
                Console.Clear();
                Iniciar();

                Console.WriteLine();
                Console.Write("Deseja começar novamente (S/N)? ");
                var comecarNovamente = Console.ReadLine();
                if (!comecarNovamente.Equals("s") && !comecarNovamente.Equals("S"))
                    finalizarPrograma = true;
            }
        }

        private static void Iniciar()
        {
            try
            {
                decimal valorTotal = ObterDecimalValido("valor total");
                decimal valorEfetivamentePago = ObterDecimalValido("efetivamente pago");

                var pagamento = new Pagamento(Guid.NewGuid(), valorTotal, valorEfetivamentePago);
                var troco = new Troco(pagamento);

                Console.WriteLine();

                var trocoFormatado = troco.Montante.ValorTotal.ToString().Replace('.', ',');
                Console.WriteLine($"O troco tem o valor de R$ {trocoFormatado}");

                Console.WriteLine();
                Console.WriteLine("O montante a ser devolvido deve ser o seguinte:");
                foreach (var dinheiro in troco.Montante.Dinheiros)
                {
                    Console.WriteLine(dinheiro.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static decimal ObterDecimalValido(string titulo)
        {
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("pt-BR");
            bool valorValido = false;
            decimal valor = 0;

            while (!valorValido)
            {
                Console.Write($"Insira o valor {titulo}: ");
                var valorEfetivamentePago = Console.ReadLine();

                if (!Decimal.TryParse(valorEfetivamentePago, style, culture, out valor))
                {
                    Console.WriteLine($"Insira um valor {titulo} válido");
                }
                else
                {
                    valorValido = true;
                }
            }

            return valor;
        }
    }
}
