using System.Globalization;
using Repositorio;

namespace AppClientes;
class Program
{
    static ClienteRepositorio _clienteRepositorio = new ClienteRepositorio(); // Variável estatica que é do tipo clienteRepositorio, criando uma instância do objeto ClienteRepositorio

    static void Main(string[] args) // Ponto de partida do programa método main
    {
        var cultura = new CultureInfo("pt-BR"); // Resolve o formato da data e de número para br
        Thread.CurrentThread.CurrentCulture = cultura;
        Thread.CurrentThread.CurrentUICulture = cultura;

        _clienteRepositorio.LerDadosClientes();
        while(true)
        {
            Menu();

            Console.ReadKey(); // Vai ficar travada até que o usuário pressione alguma tecla
        }
    }

    // Método estático que não retorna valor

    static void Menu()
    {
        Console.Clear(); // Limpa o console através do método clear

        Console.WriteLine("Cadastro de Clientes");
        Console.WriteLine("--------------------");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Exibir Clientes");
        Console.WriteLine("3 - Editar Cliente");
        Console.WriteLine("4 - Excluir Cliente");
        Console.WriteLine("5 - Sair");   
        Console.WriteLine("--------------------");

        EscolherOpcao();
    }

    static void EscolherOpcao()
    {
        Console.WriteLine("Escolha uma opção: ");

        var opcao = Console.ReadLine();

        switch (int.Parse(opcao))
        {
            case 1:
            {
                _clienteRepositorio.CadastrarCliente(); // Vai utilizar a instancia que criou e chamar o método lá dentro chamado cadastrarCliente
                Menu(); // Dps escreve novamento o menu dps de utilizar tudo que tinha dentro do CadastrarCliente
                break;
            }
            case 2:
            {
                _clienteRepositorio.ExibirClientes();
                Menu();
                break;
            }
            case 3:
            {
                _clienteRepositorio.EditarCliente();
                Menu();
                break;
            }
            case 4:
            {
                _clienteRepositorio.ExcluirCliente();
                Menu();
                break;
            }
            case 5:
            {
                _clienteRepositorio.GravarDadosClientes();
                Environment.Exit(0); // Vai fechar a aplicação através do método exit
                break;
            }
            default:
            {
                Console.Clear();
                Console.WriteLine("Opção inválida!");
                break;
            }
            

        }
    }
}
