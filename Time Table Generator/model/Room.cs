using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.model
{
    public class Room
    {
        private int roomId;
        private String roomNumber;
        private int capacity;

        /**
         * Initialize new Room
         * 
         * @param roomId
         *            The ID for this classroom
         * @param roomNumber
         *            The room number
         * @param capacity
         *            The room capacity
         */
        public Room(int roomId, String roomNumber, int capacity)
        {
            this.roomId = roomId;
            this.roomNumber = roomNumber;
            this.capacity = capacity;
        }

        /**
         * Return roomId
         * 
         * @return roomId
         */
        public int getRoomId()
        {
            return this.roomId;
        }

        /**
         * Return room number
         * 
         * @return roomNumber
         */
        public String getRoomNumber()
        {
            return this.roomNumber;
        }

        /**
         * Return room capacity
         * 
         * @return capacity
         */
        public int getRoomCapacity()
        {
            return this.capacity;
        }
    }
}
