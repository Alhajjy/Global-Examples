using System;
using System.Collections.Generic;
class Program
{
    [Flags]
    enum enPermissions
    {
        AdminsManagment = 1,
        UsersManagment = 2,
        ClientsManagment = 4,
        PersonalAccountManagment = 8,
        All = -1
    }
    enum enActions
    {
        ManageAdmins = 1,
        ManageUsers = 2,
        ManageClients = 3,
        ManagePersonalAccount = 4,
        Exit = 5
    }
    class Person
    {
        public string Name { get; set; }
        private enPermissions _Permissions { get; set; }
        public Person(string name, enPermissions permissions)
        {
            Name = name;
            _Permissions = permissions;
        }
        // permissions management
        public void AddPermission(enPermissions permissionToAdd)
        {
            _Permissions |= permissionToAdd;
        }
        public void RemovePermission(enPermissions permissionToRemove)
        {
            _Permissions &= ~permissionToRemove;
        }
        public bool HasPermission(enPermissions permissionToCheck)
        {
            return (_Permissions & permissionToCheck) == permissionToCheck;
        }
    }
    static void PrintMainScreen()
    {
        Console.WriteLine("====== Actions ======");
        Console.WriteLine("1] Manage Admins");
        Console.WriteLine("2] Manage Users");
        Console.WriteLine("3] Manage Clients");
        Console.WriteLine("4] Manage My Personal Account");
        Console.WriteLine("5] Exit");
    }
    static enActions ReadAction()
    {
        Console.WriteLine("Enter a Selection Number (1-5)");
        int temp = -1;
        while (temp > 5 || temp < 1)
        {
            temp = int.Parse(Console.ReadLine());
        }
        return (enActions)temp;
    }
    static void PrintResult(Person person, enPermissions permission)
    {
        if (person.HasPermission(permission))
        {
            Console.WriteLine($"You have permission to {permission}");
        }
        else
        {
            Console.WriteLine($"You don't have permission to {permission}");
        }
    }
    static void HandleSelection(Person CurrentPerson, enActions selection)
    {
        switch (selection)
        {
            case enActions.ManageAdmins:
                PrintResult(CurrentPerson, enPermissions.AdminsManagment);
                break;
            case enActions.ManageUsers:
                PrintResult(CurrentPerson, enPermissions.UsersManagment);
                break;
            case enActions.ManageClients:
                PrintResult(CurrentPerson, enPermissions.ClientsManagment);
                break;
            case enActions.ManagePersonalAccount:
                PrintResult(CurrentPerson, enPermissions.PersonalAccountManagment);
                break;
            case enActions.Exit:
                // exit
                break;
            default:
                break;
        }
    }
    static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person("Ahmad", enPermissions.AdminsManagment | enPermissions.UsersManagment),
            new Person("Ali", enPermissions.ClientsManagment),
            new Person("Omar", enPermissions.PersonalAccountManagment | enPermissions.UsersManagment)
        };
        // read user name
        string Name = "";
        Person CurrentPerson = null;
        while (string.IsNullOrEmpty(Name.Trim()) || CurrentPerson == null)
        {
            Console.WriteLine("Enter Your Name:");
            Name = Console.ReadLine();
            CurrentPerson = people.Find(p => p.Name.Equals(Name, StringComparison.OrdinalIgnoreCase));
        }
        // print main screen
        PrintMainScreen();
        // Perform selection actions & Result
        HandleSelection(CurrentPerson, ReadAction());
    }
}
