namespace ValidateCNPJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite um número de CNPJ (apenas dígitos): ");
            string cnpj = Console.ReadLine();

            if (ValidarCNPJ(cnpj))
                Console.WriteLine("CNPJ válido!");
            else
                Console.WriteLine("CNPJ inválido!");
        }

        static bool ValidarCNPJ(string cnpj)
        {
            // Remover caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            if (cnpj.Distinct().Count() == 1)
                return false;

            int[] pesoPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += (cnpj[i] - '0') * pesoPrimeiroDigito[i];

            int primeiroDigito = (soma % 11);
            if (primeiroDigito < 2)
                primeiroDigito = 0;
            else
                primeiroDigito = 11 - primeiroDigito;

            int[] pesoSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += (cnpj[i] - '0') * pesoSegundoDigito[i];

            int segundoDigito = (soma % 11);
            if (segundoDigito < 2)
                segundoDigito = 0;
            else
                segundoDigito = 11 - segundoDigito;

            // Verificar se os dígitos verificadores calculados coincidem com os dígitos do CNPJ
            return (cnpj[12] - '0' == primeiroDigito) && (cnpj[13] - '0' == segundoDigito);
        }
    }
}