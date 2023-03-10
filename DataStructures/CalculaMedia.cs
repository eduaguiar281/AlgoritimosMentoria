
using System.Text;

namespace AlgoritimosMentoria.DataStructures
{
    public  static class CalculaMedia
    {
        public static void LerAlunos()
        {
            bool continuar = true;
            Console.WriteLine("Digite sair para sair a qualquer momento...");
            var listaAluno = new List<Aluno>();
            do
            {
                var aluno = new Aluno();
                aluno.Nome = ObterDado("Informe o nome do aluno:", ref continuar);
                if (!continuar)
                    break;
                aluno.Disciplina = ObterDado("Informe o nome do disciplina:", ref continuar);
                if (!continuar)
                    break;

                int contador = 0;
                while (continuar && contador < 4)
                {
                    ObterNotas(contador, aluno, ref continuar);
                    if (continuar)
                    {
                        contador++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (contador > 3)
                {
                    Calcular(aluno);
                    listaAluno.Add(aluno);
                    Console.WriteLine("Pressione qualquer tecla continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (continuar);
            Salvar(listaAluno);
            Console.WriteLine("Pressione qualquer tecla para finalizar!");
            Console.ReadKey();
        }

        private static void Salvar(List<Aluno> listaAluno)
        {
            if (!listaAluno.Any())
                return;
            Console.WriteLine("Deseja Salvar? (S/N)");
            if (Console.ReadLine().Equals("sim", StringComparison.OrdinalIgnoreCase))
            {
                var texto = new StringBuilder();
                foreach(var aluno in listaAluno)
                    texto.AppendLine($"{aluno.Nome}, {aluno.Disciplina}, {aluno.Notas[0]}, {aluno.Notas[1]}, {aluno.Notas[2]}, {aluno.Notas[3]}");

                TextWriter w = new StreamWriter("c:\\TioAguiar\\alunos.csv");
                w.Write(texto.ToString());
                w.Flush();
                w.Close();
            }
        }

        private static void ObterNotas(int bimestre, Aluno aluno, ref bool continuar)
        {
            string dado = ObterDado($"Informe o nota do {bimestre + 1}º bimestre", ref continuar);
            if (!continuar)
                return;
            aluno.Notas[bimestre] = Convert.ToDecimal(dado);
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
            decimal media = aluno.Notas.Average();
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
