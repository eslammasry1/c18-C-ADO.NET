using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsContactsDataAccess
    {
        public static bool GetContactInfoByID(int ID, ref string FirstName, ref string LastName,
            ref string Email, ref string Phone, ref string Address,
            ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];
                    ImagePath = reader["ImagePath"] == DBNull.Value ? "Image Is Null" : (string)reader["ImagePath"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewContact(string FirstName,string LastName,string Email,string Phone,string Address ,DateTime DateOfBirth,int CountryID,string ImagePath)
        {
            int ContactId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string quiry = @"insert into Contacts ( FirstName, LastName, Email, Phone, Address , DateOfBirth, CountryID, ImagePath)
                             Values (@FirstName, @LastName, @Email, @Phone, @Address , @DateOfBirth, @CountryID, @ImagePath);
                             Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(quiry, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath",System.DBNull.Value);
            }
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    ContactId = insertedID;
                }
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message); 
                ContactId = -1;
            }
            finally
            { 
                connection.Close(); 
            }
            return ContactId;
        }

        public static bool UpdateContact(int ID ,string FirstName, string LastName, string Email,
                                         string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            int result = 0; ;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string quiry = @"Update Contacts set
                             FirstName=@FirstName,
                             LastName=@LastName,
                             Email=@Email,
                             Phone=@Phone,
                             Address=@Address,
                             DateOfBirth=@DateOfBirth,
                             CountryID=@CountryID,
                             ImagePath=@ImagePath
                             Where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(quiry, connection);
            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false ;
            }
            finally
            {
                connection.Close();
            }
            return result > 0;
        }
        public static bool DeleteContact(int ID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Delete Contacts Where ContactID=@ContactID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erorr" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return RowsAffected > 0;

        }

        public static DataTable GetAllContact()
        {
            DataTable DT = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select * from Contacts";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DT.Load(reader);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            finally
            {
                connection.Close();
            }
            return DT;


        }

        public static bool ExistContact(int ID)
        {
            bool isExist = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select Found = 1 from Contacts Where ContactID=@ContactID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isExist;

        }

    }
}

