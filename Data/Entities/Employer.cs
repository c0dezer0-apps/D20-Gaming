namespace D20.Data.Entities
{
  interface IEmployer
  {
    string EmployerName { get; set; }
    string EmployerLocation { get; set; }
    string Industry { get; set; }
    int NumberOfEmployees { get; set; }
    DateTime Founded { get; set; }
  }
  public class Employer : IEmployer
  {
    public string EmployerName { get; set; }
    public string EmployerLocation { get; set; }
    public string Industry { get; set; }
    public int NumberOfEmployees { get; set; }
    public DateTime Founded { get; set; }

    public Employer(string employerName, string employerLocation, string industry, DateTime founded, int numberOfEmployees = 0)
    {
      EmployerName = employerName;
      EmployerLocation = employerLocation;
      Industry = industry;
      NumberOfEmployees = numberOfEmployees;
      Founded = founded;
    }
  }
}
