using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DataTableExample1
{
internal class Program
{
static void Main(string[] args)
{
string ConnectionString = "Server=.;Database=HR_DB;User Id=sa;Password=sa123456";
DataSet dataSet = new DataSet();
string Query = "Select * from Employees";
SqlDataAdapter dataAdapter = new SqlDataAdapter(Query, ConnectionString);
SqlConnection Connection=new SqlConnection(ConnectionString);
Connection.Open();
dataAdapter.SelectCommand.Connection = Connection;
dataAdapter.Fill(dataSet,"Employees");
Connection.Close();
DataTable dt = dataSet.Tables["Employees"];
foreach (DataRow row in dt.Rows) {
Console.WriteLine("Customer ID: {0}, Name: {1}, LastName: {2}", row["ID"], row["FirstName"], row["LastName"]);
}
Connection.Open ();
// dataAdapter.UpdateCommand.Connection = Connection;
dataAdapter.UpdateCommand= new SqlCommand("UPDATE Employees SET FirstName = @FirstName, LastName =
@LastName WHERE ID = @ID", Connection);
dataAdapter.Update(dataSet,"Employees");
Connection.Close ();
Console.ReadKey();
}
}
}
