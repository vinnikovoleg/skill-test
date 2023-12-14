namespace DataAccess.Entities;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public UserType Type { get; set; }

    public int SalaryId { get; set; }
    public virtual Salary Salary { get; set; }

    public int AddressId { get; set; }
    public virtual Address Address { get; set; }

    public decimal? MaxExpenseAmount { get; set; }
}

public enum UserType
{
    Employee = 1,
    Manager = 2,
    Supervisor = 3
}