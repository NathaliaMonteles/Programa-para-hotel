namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public int Capacidade { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*

            if (hospedes == null || hospedes.Count == 0)
            {
                throw new ArgumentException("A lista de hóspedes não pode ser nula ou vazia.");
            }

            if (hospedes.Count <= Capacidade)
            {
                Hospedes = new List<Pessoa>(hospedes);
            }
            else
            {
                throw new InvalidOperationException("A capacidade do quarto é menor que o número de hóspedes.");
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentNullException(nameof(suite), "A suíte não pode ser nula.");
            Capacidade = suite.Capacidade; // Define a capacidade da reserva com base na suíte
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valorDiaria = Suite.ValorDiaria;
            decimal valor = DiasReservados * valorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                decimal desconto = 0.10M;
                valor = Suite.ValorDiaria - (Suite.ValorDiaria * desconto);
                valor = 0;
            }
            
            return valor;
        }
    }
}