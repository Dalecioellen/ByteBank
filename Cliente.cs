using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    public class Cliente
    {
        private string _cpf;
        public string Nome { get; set; }

        public string CPF
        {
            get { return _cpf; }

            set
            {
                // Aqui escrevo a minha lógica de negócio//

                _cpf = value;
            }
        }

        public string Profissao { get; set; }
    }
}
