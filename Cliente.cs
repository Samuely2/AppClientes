namespace Cadastro;

public class Cliente
{
    // Propriedades, informações de um cliente de fato
    public int Id { get; set; }
    public string? Nome { get; set; } // Interrogação que mostra que aceita valores nulos.
    public DateOnly DataNascimento { get; set; }
    public DateTime CadastradoEm { get; set; }
    public decimal Desconto { get; set; }
}