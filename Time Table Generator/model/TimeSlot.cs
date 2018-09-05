using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.model
{
    public class Timeslot
    {
        private int timeslotId;
        private String timeslot;

        /**
         * Initalize new Timeslot
         * 
         * @param timeslotId The ID for this timeslot
         * @param timeslot The timeslot being initalized
         */
        public Timeslot(int timeslotId, String timeslot)
        {
            this.timeslotId = timeslotId;
            this.timeslot = timeslot;
        }

        /**
         * Returns the timeslotId
         * 
         * @return timeslotId
         */
        public int getTimeslotId()
        {
            return this.timeslotId;
        }

        /**
         * Returns the timeslot
         * 
         * @return timeslot
         */
        public String getTimeslot()
        {
            return this.timeslot;
        }
    }
}
