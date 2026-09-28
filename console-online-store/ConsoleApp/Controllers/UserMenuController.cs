using ConsoleMenu;
using ConsoleMenu.Builder;
using StoreBLL.Services;
using StoreDAL.Data;
using StoreDAL.Data.InitDataFactory;

namespace ConsoleApp1;

/// <summary>
/// The roles a session can be operating as. Determines which main menu is shown.
/// </summary>
public enum UserRoles
{
    /// <summary>An unauthenticated visitor.</summary>
    Guest,

    /// <summary>A signed-in administrator.</summary>
    Administrator,

    /// <summary>A signed-in registered customer.</summary>
    RegistredCustomer,
}

/// <summary>
/// Owns the current session (who is logged in, as which role) and drives the top-level menu loop.
/// </summary>
public static class UserMenuController
{
    /// <summary>
    /// The identifier of the "Administrator" role, matching the fixed user-role seed data.
    /// </summary>
    private const int AdministratorRoleId = 1;

    /// <summary>
    /// The identifier of the "Registered" role, matching the fixed user-role seed data.
    /// </summary>
    private const int RegisteredRoleId = 2;

    private static readonly Dictionary<UserRoles, Menu> RolesToMenu;
    private static int userId;
    private static UserRoles userRole;
    private static StoreDbContext context;

    static UserMenuController()
    {
        userId = 0;
        userRole = UserRoles.Guest;
        RolesToMenu = new Dictionary<UserRoles, Menu>();
        var factory = new StoreDbFactory(new TestDataFactory());
        context = factory.CreateContext();
        RolesToMenu.Add(UserRoles.Guest, new GuestMainMenu().Create(context));
        RolesToMenu.Add(UserRoles.RegistredCustomer, new UserMainMenu().Create(context));
        RolesToMenu.Add(UserRoles.Administrator, new AdminMainMenu().Create(context));
    }

    /// <summary>
    /// Gets the database context shared for the lifetime of the console session.
    /// </summary>
    public static StoreDbContext Context
    {
        get { return context; }
    }

    /// <summary>
    /// Gets the identifier of the currently signed-in user, or 0 when nobody is signed in.
    /// </summary>
    public static int CurrentUserId
    {
        get { return userId; }
    }

    /// <summary>
    /// Gets the role the current session is operating as.
    /// </summary>
    public static UserRoles CurrentUserRole
    {
        get { return userRole; }
    }

    /// <summary>
    /// Prompts for a login/password and, on success, switches the session into the matching role's menu.
    /// </summary>
    public static void Login()
    {
        Console.WriteLine("Login: ");
        var login = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Password: ");
        var password = Console.ReadLine() ?? string.Empty;

        var service = new UserService(context);
        var user = service.Authenticate(login, password);
        if (user == null)
        {
            Console.WriteLine("Invalid login or password.");
            return;
        }

        userId = user.Id;
        userRole = user.RoleId switch
        {
            AdministratorRoleId => UserRoles.Administrator,
            RegisteredRoleId => UserRoles.RegistredCustomer,
            _ => UserRoles.Guest,
        };
        Console.WriteLine($"Welcome, {user.Name} {user.LastName}!");
    }

    /// <summary>
    /// Ends the current session and returns to the guest role.
    /// </summary>
    public static void Logout()
    {
        userId = 0;
        userRole = UserRoles.Guest;
    }

    /// <summary>
    /// Runs the top-level menu loop for the current role until the user exits.
    /// </summary>
    public static void Start()
    {
        ConsoleKey resKey;
        bool updateItems = true;
        do
        {
                resKey = RolesToMenu[userRole].RunOnce(ref updateItems);
        }
        while (resKey != ConsoleKey.Escape);
    }
}
