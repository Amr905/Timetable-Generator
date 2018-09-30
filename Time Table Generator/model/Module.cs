using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Table_Generator.RandomizerNamespace;

namespace Time_Table_Generator.model
{
    public class Module
    {
        private int moduleId;
        private String moduleCode;
        private String module;
        private int[] professorIds;

        /**
         * Initialize new Module
         * 
         * @param moduleId
         * @param moduleCode
         * @param module
         * @param professorIds
         */
        public Module(int moduleId, String moduleCode, String module, int[] professorIds)
        {
            this.moduleId = moduleId;
            this.moduleCode = moduleCode;
            this.module = module;
            this.professorIds = professorIds;
        }

        /**
         * Get moduleId
         * 
         * @return moduleId
         */
        public int getModuleId()
        {
            return this.moduleId;
        }

        /**
         * Get module code
         * 
         * @return moduleCode
         */
        public String getModuleCode()
        {
            return this.moduleCode;
        }

        /**
         * Get module name
         * 
         * @return moduleName
         */
        public String getModuleName()
        {
            return this.module;
        }

        /**
         * Get random professor Id
         * 
         * @return professorId
         */
        public int getRandomProfessorId()
        {
            
            
            int professorId = professorIds[(int)(professorIds.Length * Randomizer.NextDouble())];
            return professorId;
        }
    }
}
