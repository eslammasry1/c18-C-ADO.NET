using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_table
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

            Console.WriteLine("\nEmployees List\n");
            foreach (DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
                row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
                Console.WriteLine();
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3}\t Date: {4}",
                row[0], row[1], row[2], row[3], row[4]);
                Console.WriteLine("\n\n");
            }
            Console.ReadKey();
        }
    
    }
}
