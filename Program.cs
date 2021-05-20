using System;
using System.Collections.Generic;

namespace Bank.DIO
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            var opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "0")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        ExtratoConta();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Transferir();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("    -------------------------");
            Console.WriteLine(">>> | OBRIGADO POR UTILIZAR | <<<\n>>> |    NOSSOS SERVIÇOS    | <<<");
            Console.WriteLine("    -------------------------");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine(">>> Bem vindo ao DIO Bank <<<\n");
            Console.WriteLine("/----------------------------\\");
            Console.WriteLine("| Informe a opção desejada:  |");
            Console.WriteLine("| 1. Lista contas            |");
            Console.WriteLine("| 2. Inserir nova conta      |");
            Console.WriteLine("| 3. Ver extrato da conta    |");
            Console.WriteLine("| 4. Sacar                   |");
            Console.WriteLine("| 5. Depositar               |");
            Console.WriteLine("| 6. Tranferir               |");
            Console.WriteLine("| 0. Sair                    |");
            Console.WriteLine("\\----------------------------/\n");

            string opcaoUsuaio = Console.ReadLine();
            Console.Clear();
            return opcaoUsuaio;
        }

        private static void ListarContas()
        {
            Console.WriteLine(">>> TODAS AS CONTAS <<<\n");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada, favor tentar novamente!");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Console.Write($"#{i} - ");
                listaContas[i].ExibirDadosConta();
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine(">>> INSERIR NOVA CONTA <<<\n");

            Console.Write("Digite 1 para Conta Física e 2 para Conta Jurídica: ");
            var entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            var entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            var entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            var entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
            saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listaContas.Add(novaConta); 
        }

        private static void ExtratoConta()
        {
            Console.WriteLine(">>> EXTRADO DA CONTA <<<\n");

            Console.Write("Entre o nome o nome da conta desejada: ");
            var contaNome = Console.ReadLine();
            Conta contaEscolhida;
            
            if (listaContas.Find(c => c.getNome() == contaNome) != null)
            {
                contaEscolhida = listaContas.Find(c => c.getNome() == contaNome);
                contaEscolhida.ExtratoConta();
                return;
            }
            else
            {
                Console.WriteLine("Conta não cadastrada no nosso sistema, favor tentar novamente.\n");
                return;
            }
        }

        private static void Sacar()
        {
            Console.WriteLine(">>> SAQUE DA CONTA <<<\n");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorDesejado = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorDesejado);
        }

        private static void Depositar()
        {
            Console.WriteLine(">>> DEPOSITO NA CONTA <<<\n");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDesejado = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDesejado);
        }

        private static void Transferir()
        {
            Console.WriteLine(">>> TRANFERÊNCIA ENTRE CONTA <<<\n");
            
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser tranferido: ");
            double valorDesejado = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Tranferir(valorDesejado, listaContas[indiceContaDestino]);
        }
    }
}
