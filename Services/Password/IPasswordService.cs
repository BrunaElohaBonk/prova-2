namespace Prova2.Services.Password;

// interface com funções para fazer o hash (criptografia) e comparar as senhas
public interface IPasswordService
{
    string Hash(string password);
    bool Compare(string password, string hash);
}