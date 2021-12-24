using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class Clients : List<Client>
    {
        public Clients()
        {
            //Get all the clients details from the db
            SQLHelper db = new SQLHelper();

            string sql = "select Client_Id, Business, ABN, Title, FirstName, LastName, Street, Suburb, City, PostCode, State, Phone, Mobile, Email, Gender, Username, Password, Person_ID, Status from Client, Person Where Person_ID = Person_ID_Ref AND Status = 1";

            DataTable clientsDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in clientsDataTable.Rows)
            {
                Client client = new Client(row);
                this.Add(client);

            }
        }
    }
}
