namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim() ?? string.Empty;

            // Verifica se a placa tem exatamente 7 caracteres
            if (placa.Length != 7)
            {
                Console.WriteLine("Placa inválida! A placa deve conter exatamente 7 caracteres. Tente novamente.");
                return;
            }

            // Verifica se o veículo já está estacionado
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Desculpe, esse veículo já está estacionado.");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo {placa} foi estacionado com sucesso!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Selecione o número do veículo para remover:");
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados para remover.");
                return;
            }
            for (var i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {veiculos[i].ToUpper()}");
            }

            // Lê o número escolhido pelo usuário
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= veiculos.Count)
            {
                string placa = veiculos[escolha - 1];

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine() ?? "0");
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.RemoveAt(escolha - 1);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            Console.WriteLine($"Total de veículos estacionados: {veiculos.Count}");
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (var i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- {veiculos[i].ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
