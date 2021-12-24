using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class TimeSlot
    {

        /// <summary>
        /// Private properties
        /// </summary>
        private int _timeSlotId;
        private TimeSpan _slotStartTime;


        /// <summary>
        /// Public properties
        /// </summary>
        public int TimeSlotId
        {
            get
            {
                return _timeSlotId;
            }
            set
            {
                _timeSlotId = value;
            }
        }

        public TimeSpan SlotStartTime
        {
            get
            {
                return _slotStartTime;
            }
            set
            {
                _slotStartTime = value;
            }
        }

        /// <summary>
        /// Datarow for timeslots
        /// </summary>
        /// <param name="row"></param>
        public TimeSlot(DataRow row)
        {
            TimeSlotId = Convert.ToInt32(row["timeslotId"]);
            SlotStartTime = (TimeSpan)row["slotStartTime"];
        }
    }
}
