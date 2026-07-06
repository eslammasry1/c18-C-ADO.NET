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
DataColumn dtColumn= new DataColumn();
dtColumn.DataType = typeof(int);
dtColumn.ColumnName = "ID";
dtColumn.AutoIncrement = true;
dtColumn.AutoIncrementSeed = 1;
dtColumn.AutoIncrementStep = 1;
dtColumn.Caption = "Employee ID";
dtColumn.ReadOnly = true;
dtColumn.Unique = true;
EmployeesDataTable.Columns.Add(dtColumn);
/////////////////////////////////////////////
dtColumn = new DataColumn();
dtColumn.DataType = typeof(string);
dtColumn.ColumnName = "Name";
dtColumn.AutoIncrement = false;
dtColumn.Caption = "Name";
dtColumn.ReadOnly = false;
dtColumn.Unique = false;
EmployeesDataTable.Columns.Add(dtColumn);
/////////////////////////////////////////////
dtColumn = new DataColumn();
dtColumn.DataType = typeof(string);
dtColumn.ColumnName = "Country";
dtColumn.AutoIncrement = false;
dtColumn.Caption = "Country";
dtColumn.ReadOnly = false;
dtColumn.Unique = false;
EmployeesDataTable.Columns.Add(dtColumn);
/////////////////////////////////////////////
dtColumn = new DataColumn();
dtColumn.DataType = typeof(double);
dtColumn.ColumnName = "Salary";
dtColumn.AutoIncrement = false;
dtColumn.Caption = "Salary";
dtColumn.ReadOnly = false;
dtColumn.Unique = false;
EmployeesDataTable.Columns.Add(dtColumn);
/////////////////////////////////////////////
dtColumn = new DataColumn();
dtColumn.DataType = typeof(DateTime);
dtColumn.ColumnName = "Date";
dtColumn.AutoIncrement = false;
dtColumn.Caption = "Date";
dtColumn.ReadOnly = false;
dtColumn.Unique = false;
EmployeesDataTable.Columns.Add(dtColumn);
DataColumn[] PrimaryKey = new DataColumn[1];
PrimaryKey[0] = EmployeesDataTable.Columns["ID"];
EmployeesDataTable.PrimaryKey = PrimaryKey;
//////////////////////////////////////////////////////
EmployeesDataTable.Rows.Add(null, "Mohammed Abu-Hadhoud", "Jordan", 5000, DateTime.Now);
EmployeesDataTable.Rows.Add(null, "Ali Maher", "KSA", 525.5, DateTime.Now);
EmployeesDataTable.Rows.Add(null, "Lina Kamal", "Jordan", 730.5, DateTime.Now);
EmployeesDataTable.Rows.Add(null, "Fadi Jameel", "Egypt", 800, DateTime.Now);
EmployeesDataTable.Rows.Add(null, "Omar Mahmoud", "Lebanon", 7000, DateTime.Now);
Console.WriteLine("\nEmployees List\n");
foreach (DataRow row in EmployeesDataTable.Rows) {
Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
row[0], row[1], row[2], row[3], row[4]);
}
Console.ReadKey();
}
}
}
