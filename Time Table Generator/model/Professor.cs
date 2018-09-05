﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.model
{
    public class Professor
    {
        private int professorId;
        private String professorName;

        /**
         * Initalize new Professor
         * 
         * @param professorId The ID for this professor
         * @param professorName The name of this professor
         */
        public Professor(int professorId, String professorName)
        {
            this.professorId = professorId;
            this.professorName = professorName;
        }

        /**
         * Get professorId
         * 
         * @return professorId
         */
        public int getProfessorId()
        {
            return this.professorId;
        }

        /**
         * Get professor's name
         * 
         * @return professorName
         */
        public String getProfessorName()
        {
            return this.professorName;
        }
    }
}
