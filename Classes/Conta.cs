using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DIO
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }    
        
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito*-1))
            {
                Console.WriteLine("\nSaldo insuficiente!");
                return false;
            }
            
            this.Saldo -= valorSaque;

            Console.WriteLine($"\nSaldo atual da conta de {this.Nome} é R$ {this.Saldo}");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine($"\nSaldo atual da conta de {this.Nome} é R$ {this.Saldo}");
        }

        public void Tranferir(double valorTranferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
            }
        }

        public override string ToString()
        {
            string retorno = $"TipoConta: {this.TipoConta} | Nome: {this.Nome} | Saldo: R$ {this.Saldo} | Crédito: R$ {this.Credito}";
            return retorno;
        }

        public void ExibirDadosConta()
        {
            Console.WriteLine(this.ToString());
        }

        public string getNome()
        {
            return this.Nome;
        }

        public void ExtratoConta()
        {
            var extrato = $"# Nome: {this.Nome} | Saldo: R$ {this.Saldo} | Crédito: R$ {this.Credito}";
            Console.WriteLine(extrato);
        }
    }

}