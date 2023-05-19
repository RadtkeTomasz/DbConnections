public abstract class DbConnection : IDisposable
{
    protected string _connectionString;
    protected int _connectionTimeout;
    public bool Opened { get; set; }

    public DbConnection(string connectionString, int connectionTimeout)
    {
        _connectionString = connectionString;
        _connectionTimeout = connectionTimeout;
    }

    public abstract void OpenConnection();
    public abstract void CloseConnection();
    public abstract void Dispose();
}

public class OracleDbConnection : DbConnection
{
    public OracleDbConnection(string connection, int timeout) : base(connection, timeout) { }
    public override void OpenConnection()
    {
        if (!Opened)
        {
            Console.WriteLine("OpenOracleSomehow");
            Opened = true;
        }
        else
        {
            throw new InvalidOperationException("Connection already opened.");
        }
    }
    public override void CloseConnection()
    {
        if (Opened)
        {
            Console.WriteLine("CloseOracleSomehow");
            Opened = false;
        }
        else
        {
            throw new InvalidOperationException("Connection was not opened.");
        }
    }

    public override void Dispose()
    {
        Console.WriteLine("Disposing");
    }
}

public class SqlDbConnection : DbConnection
{
    public SqlDbConnection(string connection, int timeout) : base(connection, timeout) { }

    public override void OpenConnection()
    {
        if (!Opened)
        {
            Console.WriteLine("OpenSQLSomehow");
            Opened = true;
        }
        else
        {
            throw new InvalidOperationException("Connection already opened.");
        }
    }
    public override void CloseConnection()
    {
        if (Opened)
        {
            Console.WriteLine("CloseSQLSomehow");
            Opened = false;
        }
        else
        {
            throw new InvalidOperationException("Connection was not opened.");
        }
    }
    public override void Dispose()
    {
        Console.WriteLine("Disposing");
    }
}
public class DbCommand
{
    private string _commandText { get; set; }
    private DbConnection _dbConnection { get; set; }
    public DbCommand(string commandText, DbConnection dbConnection)
    {
        _commandText = commandText;
        _dbConnection = dbConnection;
    }
    public void Execute()
    {
        if (_dbConnection.Opened)
        {
            Console.WriteLine($"Executing command using query: {_commandText}");
            _dbConnection.CloseConnection();
        }
        else
        {
            _dbConnection.OpenConnection();
            Console.WriteLine($"Executing command using query: {_commandText}");
            _dbConnection.CloseConnection();
        }
    }
}