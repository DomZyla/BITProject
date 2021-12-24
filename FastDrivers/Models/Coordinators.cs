using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class Coordinators : List<Coordinator>
    {
        public Coordinators()
        {
            //Get all the coordinators details from the db
            SQLHelper db = new SQLHelper();

            string sql = "select person_Id, Coordinator_ID, Title, FirstName, LastName, Street, Suburb, City, PostCode, State, Phone, Mobile, Email, Gender, UserName, Password, Status from Person, Coordinator WHERE Person_ID = Person_ID_Ref AND Status = 1";

            DataTable coordinatorsDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in coordinatorsDataTable.Rows)
            {
                Coordinator coordinator = new Coordinator(row);
                this.Add(coordinator);

            }
        }
    }
}
