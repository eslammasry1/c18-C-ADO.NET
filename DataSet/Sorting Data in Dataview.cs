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
            EmployeesDataTable.Columns.Add("Name", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(Double));
            EmployeesDataTable.Columns.Add("Date", typeof(DateTime));
            EmployeesDataTable.Rows.Add(1, "Mohammed Abu-Hadhoud", "Jordan", 5000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA", 525.5, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Lina Kamal", "Jordan", 730.5, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Fadi Jameel", "Egypt", 800, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "Omar Mahmoud", "Lebanon", 7000, DateTime.Now);

            DataView EmployeesDataView1 = EmployeesDataTable.DefaultView;

            EmployeesDataView1.Sort = "Name ASC ";
            for (int i = 0; i < EmployeesDataView1.Count; i++)
            {
                Console.WriteLine("{0},{1},{2},{3},{4}",
                EmployeesDataView1[i][0], EmployeesDataView1[i][1],
                EmployeesDataView1[i][2], EmployeesDataView1[i][3], EmployeesDataView1[i][4]);
            }
        }
    }
}
