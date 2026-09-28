namespace NorthwindEmployeeAdoNetService;

/// <summary>
/// A service for interacting with the "Employees" table using ADO.NET.
/// </summary>
public sealed class EmployeeAdoNetService
{
    private const string SelectAllEmployeesSql = "SELECT * FROM Employees ORDER BY EmployeeID";

    private const string SelectEmployeeByIdSql = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

    private const string InsertEmployeeSql =
        "INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, " +
        "Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath) " +
        "VALUES (@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, " +
        "@Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Notes, @ReportsTo, @PhotoPath)";

    private const string UpdateEmployeeSql =
        "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title, " +
        "TitleOfCourtesy = @TitleOfCourtesy, BirthDate = @BirthDate, HireDate = @HireDate, Address = @Address, " +
        "City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, HomePhone = @HomePhone, " +
        "Extension = @Extension, Notes = @Notes, ReportsTo = @ReportsTo, PhotoPath = @PhotoPath " +
        "WHERE EmployeeID = @EmployeeID";

    private const string DeleteEmployeeSql = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

    private const string LastInsertRowIdSql = "SELECT last_insert_rowid()";

    private readonly DbProviderFactory dbFactory;
    private readonly string connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeAdoNetService"/> class.
    /// </summary>
    /// <param name="dbFactory">The database provider factory used to create database connection and command instances.</param>
    /// <param name="connectionString">The connection string used to establish a database connection.</param>
    /// <exception cref="ArgumentNullException">Thrown when either <paramref name="dbFactory"/> or <paramref name="connectionString"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="connectionString"/> is empty or contains only white-space characters.</exception>
    public EmployeeAdoNetService(DbProviderFactory dbFactory, string connectionString)
    {
        ArgumentNullException.ThrowIfNull(dbFactory);
        ArgumentNullException.ThrowIfNull(connectionString);

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string cannot be empty or contain only white-space characters.", nameof(connectionString));
        }

        this.dbFactory = dbFactory;
        this.connectionString = connectionString;
    }

    /// <summary>
    /// Retrieves a list of all employees from the Employees table of the database.
    /// </summary>
    /// <returns>A list of Employee objects representing the retrieved employees.</returns>
    public IList<Employee> GetEmployees()
    {
        var employees = new List<Employee>();

        using DbConnection connection = this.OpenConnection();
        using DbCommand command = connection.CreateCommand();
        command.CommandText = SelectAllEmployeesSql;

        using DbDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            employees.Add(CreateEmployee(reader));
        }

        return employees;
    }

    /// <summary>
    /// Retrieves an employee with the specified employee ID.
    /// </summary>
    /// <param name="employeeId">The ID of the employee to retrieve.</param>
    /// <returns>The retrieved an <see cref="Employee"/> instance.</returns>
    /// <exception cref="EmployeeServiceException">Thrown if the employee is not found.</exception>
    public Employee GetEmployee(long employeeId)
    {
        using DbConnection connection = this.OpenConnection();
        using DbCommand command = connection.CreateCommand();
        command.CommandText = SelectEmployeeByIdSql;
        AddParameter(command, "@EmployeeID", employeeId);

        using DbDataReader reader = command.ExecuteReader();
        if (!reader.Read())
        {
            throw new EmployeeServiceException("Employee not found.");
        }

        return CreateEmployee(reader);
    }

    /// <summary>
    /// Adds a new employee to Employee table of the database.
    /// </summary>
    /// <param name="employee">The  <see cref="Employee"/> object containing the employee's information.</param>
    /// <returns>The ID of the newly added employee.</returns>
    /// <exception cref="EmployeeServiceException">Thrown when an error occurs while adding the employee.</exception>
    public long AddEmployee(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        using DbConnection connection = this.OpenConnection();

        using (DbCommand command = connection.CreateCommand())
        {
            command.CommandText = InsertEmployeeSql;
            AddInsertParameters(command, employee);

            int affectedRows;
            try
            {
                affectedRows = command.ExecuteNonQuery();
            }
            catch (DbException e)
            {
                throw new EmployeeServiceException("Inserting an employee failed.", e);
            }

            if (affectedRows == 0)
            {
                throw new EmployeeServiceException("Inserting an employee failed.");
            }
        }

        using DbCommand idCommand = connection.CreateCommand();
        idCommand.CommandText = LastInsertRowIdSql;
        object? result = idCommand.ExecuteScalar();

        return result is not null
            ? Convert.ToInt64(result, CultureInfo.InvariantCulture)
            : throw new EmployeeServiceException("Inserting an employee failed.");
    }

    /// <summary>
    /// Removes an employee from the the Employee table of the database based on the provided employee ID.
    /// </summary>
    /// <param name="employeeId">The ID of the employee to remove.</param>
    /// <exception cref="EmployeeServiceException"> Thrown when an error occurs while attempting to remove the employee.</exception>
    public void RemoveEmployee(long employeeId)
    {
        using DbConnection connection = this.OpenConnection();
        using DbCommand command = connection.CreateCommand();
        command.CommandText = DeleteEmployeeSql;
        AddParameter(command, "@EmployeeID", employeeId);

        try
        {
            _ = command.ExecuteNonQuery();
        }
        catch (DbException e)
        {
            throw new EmployeeServiceException("Removing an employee failed.", e);
        }
    }

    /// <summary>
    /// Updates an employee record in the Employee table of the database.
    /// </summary>
    /// <param name="employee">The employee object containing updated information.</param>
    /// <exception cref="EmployeeServiceException">Thrown when there is an issue updating the employee record.</exception>
    public void UpdateEmployee(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);

        using DbConnection connection = this.OpenConnection();
        using DbCommand command = connection.CreateCommand();
        command.CommandText = UpdateEmployeeSql;
        AddInsertParameters(command, employee);
        AddParameter(command, "@EmployeeID", employee.Id);

        int affectedRows;
        try
        {
            affectedRows = command.ExecuteNonQuery();
        }
        catch (DbException e)
        {
            throw new EmployeeServiceException("Employee is not updated.", e);
        }

        if (affectedRows == 0)
        {
            throw new EmployeeServiceException("Employee is not updated.");
        }
    }

    private static void AddInsertParameters(DbCommand command, Employee employee)
    {
        AddParameter(command, "@LastName", employee.LastName);
        AddParameter(command, "@FirstName", employee.FirstName);
        AddParameter(command, "@Title", employee.Title);
        AddParameter(command, "@TitleOfCourtesy", employee.TitleOfCourtesy);
        AddParameter(command, "@BirthDate", employee.BirthDate);
        AddParameter(command, "@HireDate", employee.HireDate);
        AddParameter(command, "@Address", employee.Address);
        AddParameter(command, "@City", employee.City);
        AddParameter(command, "@Region", employee.Region);
        AddParameter(command, "@PostalCode", employee.PostalCode);
        AddParameter(command, "@Country", employee.Country);
        AddParameter(command, "@HomePhone", employee.HomePhone);
        AddParameter(command, "@Extension", employee.Extension);
        AddParameter(command, "@Notes", employee.Notes);
        AddParameter(command, "@ReportsTo", employee.ReportsTo);
        AddParameter(command, "@PhotoPath", employee.PhotoPath);
    }

    private static void AddParameter(DbCommand command, string name, object? value)
    {
        DbParameter parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value ?? DBNull.Value;
        command.Parameters.Add(parameter);
    }

    private static Employee CreateEmployee(DbDataReader record)
    {
        return new Employee(record.GetInt64(record.GetOrdinal("EmployeeID")))
        {
            LastName = GetString(record, "LastName") ?? string.Empty,
            FirstName = GetString(record, "FirstName") ?? string.Empty,
            Title = GetString(record, "Title"),
            TitleOfCourtesy = GetString(record, "TitleOfCourtesy"),
            BirthDate = GetDateTime(record, "BirthDate"),
            HireDate = GetDateTime(record, "HireDate"),
            Address = GetString(record, "Address"),
            City = GetString(record, "City"),
            Region = GetString(record, "Region"),
            PostalCode = GetString(record, "PostalCode"),
            Country = GetString(record, "Country"),
            HomePhone = GetString(record, "HomePhone"),
            Extension = GetString(record, "Extension"),
            Notes = GetString(record, "Notes"),
            ReportsTo = GetInt64(record, "ReportsTo"),
            PhotoPath = GetString(record, "PhotoPath"),
        };
    }

    private static string? GetString(DbDataReader record, string columnName)
    {
        int ordinal = record.GetOrdinal(columnName);
        return record.IsDBNull(ordinal) ? null : record.GetString(ordinal);
    }

    private static long? GetInt64(DbDataReader record, string columnName)
    {
        int ordinal = record.GetOrdinal(columnName);
        return record.IsDBNull(ordinal) ? null : record.GetInt64(ordinal);
    }

    private static DateTime? GetDateTime(DbDataReader record, string columnName)
    {
        int ordinal = record.GetOrdinal(columnName);
        if (record.IsDBNull(ordinal))
        {
            return null;
        }

        object value = record.GetValue(ordinal);
        return value switch
        {
            DateTime dateTime => dateTime,
            string text => DateTime.Parse(text, CultureInfo.InvariantCulture, DateTimeStyles.None),
            _ => Convert.ToDateTime(value, CultureInfo.InvariantCulture),
        };
    }

    private DbConnection OpenConnection()
    {
        DbConnection connection = this.dbFactory.CreateConnection()
            ?? throw new EmployeeServiceException("Unable to create a database connection.");
        connection.ConnectionString = this.connectionString;
        connection.Open();
        return connection;
    }
}
