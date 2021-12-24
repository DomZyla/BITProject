using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class TimeSlots : List<TimeSlot>
    {
        public TimeSlots()
        {
        //Get all the timeslots details from the db
        SQLHelper db = new SQLHelper();

        string sql = "select timeslotId,slotStartTime from TimeSlot";

        DataTable timeslotsDataTable = db.ExecuteSQL(sql);

            foreach (DataRow row in timeslotsDataTable.Rows)
            {
                TimeSlot timeSlot = new TimeSlot(row);
                this.Add(timeSlot);
            }
        }

    }
}
