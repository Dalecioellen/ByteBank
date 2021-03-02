using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    public class ContaCorrente
    {
        public int ContadorSaquesNaoPermitos { get; private set; }

        public int ContadorDeTransferenciasNaoPermitidos { get; set; }
        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int Agencia { get; }

        //Ao remover o set da propriedade, ela fica somente leitura
        //e só poderá ser atribuído valores pelo construtor ao instanciar//

        public int Numero { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }

            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int numero, int agencia)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("Não podemos criar uma conta menor ou igual a 0.", nameof(numero));
            }
            if (agencia <= 0)
            {
                throw new ArgumentException("Não podemos criar uma agência com número menor ou igual a 0.", nameof(agencia));
            }

            //O operador nameof serve para nos lembrar a alterar a string de acordo com o nome da propriedade caso ela seja modificada.

            Numero = numero;
            Agencia = agencia;
            TotalDeContasCriadas++;
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                ContadorSaquesNaoPermitos++;
                throw new ArgumentException("Não é permitido saques menores que 0.", nameof(valor));
            }
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;

        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Não é permitido depositos menores que 0.", nameof(valor));
            }
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Não é permitida a transferência de valores iguais ou menores do que 0.", nameof(valor));
            }
            try  //  Tente sacar se for saldo insficiente, como já avaliado no método sacar, cai no catch lança a excpetion 
                 // e alimenta o contador de transferencias inválidas//
            {

                Sacar(valor);
                contaDestino.Depositar(valor);
            }

            catch (SaldoInsuficienteException ex)
            {
                ContadorDeTransferenciasNaoPermitidos++;

                throw new OperacoesfinanceirasException("Operação não realizada", ex);


                //pegar onde se originou a exception innerexception neste caso na SaldoInsuficiente no sacar
            }

        }
    }
}
