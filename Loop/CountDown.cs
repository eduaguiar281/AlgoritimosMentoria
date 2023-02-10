using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritimosMentoria.Loop
{
    public class CountDown
    {
        public void Iniciar()
        {
            int contador = 10;
            do
            {
                Console.WriteLine($"Contagem regressiva {contador}");
                contador--;
                Task.Delay(1000).Wait();
            }
            while (contador >= 0);
        }
    }
}
