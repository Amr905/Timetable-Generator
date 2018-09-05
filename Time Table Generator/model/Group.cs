using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.model
{
    public class Group
    {
        private int groupId;
        private int groupSize;
        private int[] moduleIds;

        /**
         * Initialize Group
         * 
         * @param groupId
         * @param groupSize
         * @param moduleIds
         */
        public Group(int groupId, int groupSize, int[] moduleIds)
        {
            this.groupId = groupId;
            this.groupSize = groupSize;
            this.moduleIds = moduleIds;
        }

        /**
         * Get groupId
         * 
         * @return groupId
         */
        public int getGroupId()
        {
            return this.groupId;
        }

        /**
         * Get groupSize
         * 
         * @return groupSize
         */
        public int getGroupSize()
        {
            return this.groupSize;
        }

        /**
         * Get array of group's moduleIds
         * 
         * @return moduleIds
         */
        public int[] getModuleIds()
        {
            return this.moduleIds;
        }
    }
}
