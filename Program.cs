using System;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(00, 222222);

                ContaCorrente conta2 = new ContaCorrente(4433, 0123456);

                conta.Titular = new Cliente();
                conta.Titular.CPF = "23456";

                // conta2.Sacar(400);

                //conta2.Transferir(10000, conta);



            }

            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine("Erro no saque");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (OperacoesfinanceirasException ex)
            {
                Console.WriteLine("Erro na trasferência");
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException e)

            {
                // Console.WriteLine(ex.ParamName);
                Console.WriteLine("Erro no argumento (parametro)");
                Console.WriteLine(e.Message);

            }

        }
    }
}
