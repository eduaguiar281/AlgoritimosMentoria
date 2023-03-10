namespace AlgoritimosMentoria.DataStructures
{
    public class Aluno
    {
        public string? Nome { get; set; }
        public string? Disciplina { get; set; }
        public decimal[] Notas { get; set; } = new decimal[4];

        // 0 -> 10
        // 1 -> 8
        // 2 -> 4
        // 3 -> 10
    }
}
