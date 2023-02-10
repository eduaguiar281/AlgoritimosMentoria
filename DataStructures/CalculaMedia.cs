using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritimosMentoria.DataStructures
{
    public  static class CalculaMedia
    {
        public static void LerAlunos()
        {
            bool continuar = true;
            Console.WriteLine("Digite sair para sair a qualquer momento...");
            var aluno = new Aluno();
            aluno.Nome = ObterDado("Informe o nome do aluno:", ref continuar);
            aluno.Disciplina = ObterDado("Informe o nome do disciplina:", ref continuar);
            int contador = 1;
            while (continuar && contador <= 4)
            {
                ObterNotas(contador, aluno, ref  continuar);
                if (continuar)
                {
                    contador++;
                }
                else
                {
                    break;
                }
            }
            if (contador > 4)
            {
                Calcular(aluno);
            }
            Console.WriteLine("Pressione qualquer tecla para finalizar!");
            Console.ReadKey();
        }

        private static void ObterNotas(int bimestre, Aluno aluno, ref bool continuar)
        {
            string dado = ObterDado($"Informe o nota do {bimestre}º bimestre", ref continuar);
            if (!continuar)
                return;

            switch (bimestre)
            {
                case 1: aluno.Nota1 = Convert.ToDecimal(dado); break;
                case 2: aluno.Nota2 = Convert.ToDecimal(dado); break;
                case 3: aluno.Nota3 = Convert.ToDecimal(dado); break;
                case 4: aluno.Nota4 = Convert.ToDecimal(dado); break;
            }
        }


        private static string ObterDado(string mensagem, ref bool continuar)
        {
            Console.WriteLine(mensagem);
            string valor =  Console.ReadLine();
            if (valor.Equals("sair", StringComparison.OrdinalIgnoreCase))
                continuar = false;
            return valor;
        }

        public static void Calcular(Aluno aluno)
        {
            decimal totalNotas = aluno.Nota1 + aluno.Nota2 + aluno.Nota3 + aluno.Nota4;
            decimal media = totalNotas / 4;
            if (media < 5.0m)
                Console.WriteLine($"""
                    O aluno {aluno.Nome} teve a média de {media} em {aluno.Disciplina}. 
                    {aluno.Nome} está reprovado
                    """);
            else if (media < 7.0m)
                Console.WriteLine($"""
                    O aluno {aluno.Nome} teve a média de {media} em {aluno.Disciplina}. 
                    {aluno.Nome} está de recuperação
                    """);
            else
                Console.WriteLine($"""
                    O aluno {aluno.Nome} teve a média de {media} em {aluno.Disciplina}. 
                    {aluno.Nome} está aprovado
                    """);
        }
    }
}
