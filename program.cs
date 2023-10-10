using GenericExample;



IEnumerable<Person> people = new List<Employee> // It's not <Employee> anymore.
{
    new Employee("Andrew"),
    new RemoteEmployee("Karen","USA")
};

var employeesRepository = new FileRepository<Employee>();
AddEmployees(employeesRepository);  // Add a list of employees to a repository
ReadAndPrintRepository(employeesRepository);     // Read the repository and print users.

static void AddEmployees(IWriteOnlyRepository<Employee> repository)
    => new List<Employee>
        {
            new RemoteEmployee("Karen","Usa"),
            new Employee("Karen")
        }.ForEach(repository.Insert);


static void ReadAndPrintRepository(IReadOnlyRepository<Person> repository)
    => repository
        .GetAll()
        .ToList()
        .ForEach(Console.WriteLine);

static void AddRemoteEmployees(IWriteOnlyRepository<RemoteEmployee> repository)
{
    //some operations only valid for RemoteEmployee
    //OnlyRemoteEmployeeMethod(remoteEmployee)
    repository.Insert(new RemoteEmployee("Andrew", "Canada"));
    repository.Insert(new RemoteEmployee("Carol", "UK"));
}
