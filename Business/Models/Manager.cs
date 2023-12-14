namespace Business.Models;

public class Manager: UserBase
{
    public decimal AnnualSalary { get; set; }
    public decimal MaxExpenseAmount { get; set; }
}