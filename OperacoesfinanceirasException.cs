using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    public class OperacoesfinanceirasException : Exception
    {
        public OperacoesfinanceirasException()
        {

        }

        public OperacoesfinanceirasException(string message)
            : base(message)
        {

        }

        public OperacoesfinanceirasException(string message, Exception excecaoInterna)
            : base(message, excecaoInterna)
        {

        }
    }
}

// É sempre uma boa prática as classesde excessões terem esses três construtores// 
// um vazio, um com a mensagem e um com a innerexception//