using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacoesfinanceirasException
    {
        public double SaldoDaConta { get; }

        public double ValorDeSaque { get; }

        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(double saldoDaConta, double valorDeSaque) : this("Tentativa de saque ou transferência no valor de :" + valorDeSaque + " em uma conta com saldo de  " + saldoDaConta)

        {
            SaldoDaConta = saldoDaConta;
            ValorDeSaque = valorDeSaque;


        }
        public SaldoInsuficienteException(string message) : base(message)
        {

        }

        public SaldoInsuficienteException(string message, Exception excecaoInterna) :
            base(message, excecaoInterna)
        {

        }

    }
}
