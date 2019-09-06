
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SQLConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create create1 = new Create();
            //create1.create();
            //game1.Name1 = "Tet";
            //game1.Genre1 = "Bo";
            //game1.Type1 = "S";
            //game1.Review1 = "It";
            //Update update1 = new Update();
            //update1.Supdate();
            Read read1 = new Read();
            read1.Readme();
           // Delete delete1 = new Delete();
            //delete1.Deleteme();
            

           
            //using ( connOBJ = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=CSharpGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            //{
            //    connOBJ.Open();
            //    Console.WriteLine(connOBJ.State);

           

            //lCommand selectCommand = new SqlCommand("SELECT * FROM Game");


        }
    }

    public class Game
    {
        string Name = "";
        string Genre = "";
        string Type = "";
        string Review = "";

        public string Name1 { get => Name; set => Name = value; }
        public string Genre1 { get => Genre; set => Genre = value; }
        public string Type1 { get => Type; set => Type = value; }
        public string Review1 { get => Review; set => Review = value; }

    }

    public class Create
    {
       public  void create()
        {
            Game game1 = new Game();
            
            game1.Name1 = "Tet";
            game1.Genre1 = "Bo";
            game1.Type1 = "S";
            game1.Review1 = "It";
            try
            {
                SqlConnection connOBJ;
                string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=CSharpGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                string insertString = String.Format("INSERT INTO Game(GameName,Genre,GameType,Review) VALUES ('{0}', '{1}', '{2}', '{3}')", game1.Name1, game1.Genre1, game1.Type1, game1.Review1);
                connOBJ = new SqlConnection(connectionString);

                SqlCommand insertCommand = new SqlCommand(insertString, connOBJ);
                connOBJ.Open();
                insertCommand.ExecuteReader();

            }

            catch (SqlException ex)
            {
                Console.WriteLine("Something happen to the server" + ex.Message);
            }

          
        }

    }

    public class Update
    {
        public void Supdate()
        { 
            try
            {
                SqlConnection connOBJ;
                string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=CSharpGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                string updateString = String.Format("UPDATE Game  SET GameName=@NewName, Genre=@NewGenre, GameType=@NewGameType, Review=@NewReviews " + " WHERE id=1");
                connOBJ = new SqlConnection(connectionString);

                SqlCommand updateCommand = new SqlCommand(updateString, connOBJ);
                connOBJ.Open();
                updateCommand.Parameters.AddWithValue("@NewName","Pokemon");
                updateCommand.Parameters.AddWithValue("@NewGenre", "Poke");
                updateCommand.Parameters.AddWithValue("@NewGameType", "Pl");
                updateCommand.Parameters.AddWithValue("@NewReviews", "Awes");
                int rows = updateCommand.ExecuteNonQuery();
               

            }

            catch (SqlException ex)
            {
                Console.WriteLine("Something happen to the server" + ex.Message);
            }
}
    }

    public class Read
    {
        public void Readme()
        {
            try
            {
                SqlConnection connOBJ;
                string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=CSharpGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                string ReadString = String.Format("SELECT * FROM Game");
                connOBJ = new SqlConnection(connectionString);

                SqlCommand ReadCommand = new SqlCommand(ReadString, connOBJ);
                connOBJ.Open();

                SqlDataReader reader = ReadCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("id = " + reader["Id"]);
                        Console.WriteLine("GameName = "+ reader["GameName"]);
                        Console.WriteLine("type = " + reader["GameType"]);
                        Console.WriteLine("review = " + reader["Review"]);
                    }
                }
                reader.Close();
                

            }

            catch (SqlException ex)
            {
                Console.WriteLine("Something happen to the server" + ex.Message);
            }
        }
    }

    public class Delete
    {
        public void Deleteme()
        {
            try
            {
                SqlConnection connOBJ;
                string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=CSharpGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                string deleteString = String.Format("DELETE FROM Game " + " WHERE id=1");
                connOBJ = new SqlConnection(connectionString);

                SqlCommand deleteCommand = new SqlCommand(deleteString, connOBJ);
                connOBJ.Open();
               
                int rows = deleteCommand.ExecuteNonQuery();
                

            }

            catch (SqlException ex)
            {
                Console.WriteLine("Something happen to the server" + ex.Message);
            }
        }

    }
}
