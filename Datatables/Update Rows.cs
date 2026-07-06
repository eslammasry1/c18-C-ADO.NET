using System;
using System.Data;
using System.Linq;
namespace DataTableExample1
{
internal class Program
{
static void Main(string[] args)
{
DataTable EmployeesDataTable = new DataTable();
EmployeesDataTable.Columns.Add("ID", typeof(int));
EmployeesDataTable.Columns.Add("Name",typeof(string));
EmployeesDataTable.Columns.Add("Country",typeof(string));
EmployeesDataTable.Columns.Add("Salary",typeof (Double));
EmployeesDataTable.Columns.Add("Date", typeof(DateTime));
EmployeesDataTable.Rows.Add(1,"Mohammed Abu-Hadhoud","Jordan",5000,DateTime.Now);
EmployeesDataTable.Rows.Add(2,"Ali Maher","KSA",525.5,DateTime.Now);
EmployeesDataTable.Rows.Add(3,"Lina Kamal","Jordan",730.5,DateTime.Now);
EmployeesDataTable.Rows.Add(4,"Fadi Jameel","Egypt",800,DateTime.Now);
EmployeesDataTable.Rows.Add(5,"Omar Mahmoud","Lebanon",7000,DateTime.Now);
int EmployeesCount = 0;
double TotalSalaries = 0;
double AverageSalaries = 0;
double MinSalaries = 0;
double MaxSalaries = 0;
//get all employees
EmployeesCount= EmployeesDataTable.Rows.Count;
TotalSalaries = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)",String.Empty));
AverageSalaries = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)",String.Empty));
MinSalaries = Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)",String.Empty));
MaxSalaries = Convert.ToDouble(EmployeesDataTable.Compute("Max(Salary)",String.Empty));
Console.WriteLine("\nEmployees List\n");
foreach (DataRow row in EmployeesDataTable.Rows) {
Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
row[0], row[1], row[2], row[3], row[4]);
}
Console.WriteLine();
// update row id =4
DataRow[] Resultrows = EmployeesDataTable.Select("ID=4");
foreach (DataRow row in Resultrows)
{
row["Name"]="Maha Ahmed";
row["Salary"]=900;
}
EmployeesDataTable.AcceptChanges();
foreach (DataRow row in EmployeesDataTable.Rows)
{
Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
row[0], row[1], row[2], row[3], row[4]);
}
Console.ReadKey();
}
}
}
