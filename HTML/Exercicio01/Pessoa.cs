

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class Pessoa
    {
        public string nome = "Beatriz";

        public int idade = 16;

        public void apresentar()
        {
            System.Console.WriteLine($"ola meu nome e {nome} e eu tenho {idade} anos");
        }

    
        
    }
}