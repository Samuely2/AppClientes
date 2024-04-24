using Cadastro;

namespace Repositorio;

public class ClienteRepositorio
{
    public List<Cliente> clientes = new List<Cliente>();//Pega a classe Cliente e da o nome dessa propriedade de clientes, e instancia essa coleção

    public void GravarDadosClientes()
    {
        //Serializar a nossa coleção cliente, transformar esses objetos que estão na memória para uma string gravar em um arquivo.
        var json = System.Text.Json.JsonSerializer.Serialize(clientes); // Pegar os objetos e transformar em uma string objeto json

        File.WriteAllText("clientes.txt", json);
    }
    public void LerDadosClientes()
    {
        if(File.Exists("clientes.txt"))
        {
            // Pegar a string e transformar para objetos, e atribuir o objeto para instância chamada clientes, a gente vai deserializar

            var dados = File.ReadAllText("clientes.txt"); // ler os dados desse arquivo
            var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados); // Variável do tipo coleção de clientes

            // Pegar a lista de clientes e adicionar a instância clientes, que é a coleção de clientes.

            clientes.AddRange(clientesArquivo); // Adicionar uma coleção em uma coleção
        }
    }
    public void ExcluirCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirCliente(cliente);
        clientes.Remove(cliente); // Método remove da lista de clientes, e passa a instância do cliente que quer remover dentro da lista.
        Console.WriteLine("Cliente removido com sucesso! [Enter]");
        Console.ReadKey();
    }

    public void EditarCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo)); // Pede para informar o código do cliente, recupera o código e utiliza o firstOrDefault para procurar o código digitado na coleção. Através do lambda acessa a propriedade da variável da instância da cliente dentro da coleção, o primeiro p é a variável que utiliza.

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirCliente(cliente);

        Console.Write("Nome do cliente: ");
    }

    public void CadastrarCliente()
    {
        Console.Clear();

        Console.Write("Nome do cliente: ");
        var nome = Console.ReadLine(); // Para recuperar informação que o usuário inputar
        Console.Write(Environment.NewLine); // Quebra a linha

        Console.Write("Data de nascimento: ");
        var dataNascimento = DateOnly.Parse(Console.ReadLine()); // Converte em string em determinado tipo de objeto
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine()); // Converte string em decimal
        Console.Write(Environment.NewLine);

        var cliente = new Cliente(); // Cria uma instância da classe cliente
        cliente.Id = clientes.Count +1; // Verifica quantos clientes tem, pega a quantidade que já tem e adiciona mais um
        cliente.Nome = nome; // Adiciona os atributos desse cliente
        cliente.DataNascimento = dataNascimento;
        cliente.Desconto = desconto;
        cliente.CadastradoEm = DateTime.Now; // Pega a data e hora atual

        clientes.Add(cliente); // Adiciona utilizando o método add na coleção clientes, na instância chamada cliente

        Console.WriteLine("Cliente cadastrado com sucesso! [Enter]");
        ImprimirCliente(cliente);
        Console.ReadKey();

    }

    public void ImprimirCliente(Cliente cliente) // Passa como parâmetro a instância de um cliente que contém as informações, id, nome, datadenascimento, tudo vai estar na instância Cliente da classe Cliente, passou o nome desse parâmetro para cliente.
    {
        Console.WriteLine("ID................: " + cliente.Id);
        Console.WriteLine("Nome................: " + cliente.Nome);
        Console.WriteLine("Desconto................: " + cliente.Desconto.ToString("0.00"));
        Console.WriteLine("Data Nascimento................: " + cliente.DataNascimento);
        Console.WriteLine("Data Cadastro................: " + cliente.CadastradoEm);
        Console.WriteLine("---------------------------------------------");
    }

    public void ExibirClientes()
    {
        Console.Clear();
        foreach (var cliente in clientes) // Foreach para percorrer a coleção cliente
        {
            ImprimirCliente(cliente);
        }

        Console.ReadKey();
    }
}