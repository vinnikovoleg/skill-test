namespace DataAccess.Entities;

public class Salary
{
    public int Id { get; set; }
    
    public SalaryType Type { get; set; }
    
    public decimal Amount { get; set; }
}

public enum SalaryType
{
    PayPerHour = 1, 
    
    Annual = 2
}