using Npgsql;

namespace ProjetExamen.Database;

/// <summary>
/// Classe permettant de gérer la connexion à la base de données PostgreSQL.
/// Proposer par IA Chatgpt
/// </summary>
public class Data
{
    /// Chaîne de connexion à la base de données.
    /// Contient les informations nécessaires pour se connecter
    private string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=zabb_&§;Database=projetexam";
    
    /// Retourne une nouvelle connexion à la base de données PostgreSQL.
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}