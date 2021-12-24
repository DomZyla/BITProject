using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class Contractors : List<Contractor>
    {
        public Contractors()
        {
            //Get all the contractors details from the db
            SQLHelper db = new SQLHelper();

            string sql = "select Person_ID, Contractor_ID, Title, FirstName, LastName, Street, Suburb, City, PostCode, State, Phone, Mobile, Email, Gender, UserName, Password, HourlyRate, Status, Rating from Person, Contractor WHERE Person_ID = Person_ID_Ref AND Status = 1";

            DataTable contractorsDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in contractorsDataTable.Rows)
            {
                Contractor contractor = new Contractor(row);
                this.Add(contractor);

            }
        }
    }
}
