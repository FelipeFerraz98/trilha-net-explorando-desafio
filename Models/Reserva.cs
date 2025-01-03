namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lançar uma exceção caso a capacidade seja insuficiente
                throw new ArgumentException("Número de hóspedes maior do que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor da diária sem desconto
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica um desconto de 10% se os dias reservados forem maior ou igual a 10
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.10m; // Desconto de 10%
            }

            return valor;
        }
    }
}