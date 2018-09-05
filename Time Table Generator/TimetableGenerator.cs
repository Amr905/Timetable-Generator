using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Table_Generator.model;
namespace Time_Table_Generator
{

    public class TimetableGenerator
    {

        public static void Main(String[] args)
        {
            // Get a Timetable object with all the available information.
            Timetable timetable = initializeTimetable();

            // Initialize GA
            GeneticAlgorithm ga = new GeneticAlgorithm(100, 0.01, 0.9, 2, 5);

            // Initialize population
            Population population = ga.initPopulation(timetable);

            // Evaluate population
            ga.evalPopulation(population, timetable);

            // Keep track of current generation
            int generation = 1;

            // Start evolution loop
            while (ga.isTerminationConditionMet(generation, 1000) == false
                && ga.isTerminationConditionMet(population) == false)
            {
                // Print fitness
                Console.WriteLine("G" + generation + " Best fitness: " + population.getFittest(0).getFitness());

                // Apply crossover
                population = ga.crossoverPopulation(population);

                // Apply mutation
                population = ga.mutatePopulation(population, timetable);

                // Evaluate population
                ga.evalPopulation(population, timetable);

                // Increment the current generation
                generation++;
            }

            // Print fitness
            timetable.createClasses(population.getFittest(0));
            Console.WriteLine();
            Console.WriteLine("Solution found in " + generation + " generations");
            Console.WriteLine("Final solution fitness: " + population.getFittest(0).getFitness());
            Console.WriteLine("Clashes: " + timetable.calcClashes());

            // Print classes
            Console.WriteLine();
            Class[] classes = timetable.getClasses();
            int classIndex = 1;
            foreach (Class bestClass in classes)
            {
                Console.WriteLine("Class " + classIndex + ":");
                Console.WriteLine("Module: " +
                        timetable.getModule(bestClass.getModuleId()).getModuleName());
                Console.WriteLine("Group: " +
                        timetable.getGroup(bestClass.getGroupId()).getGroupId());
                Console.WriteLine("Room: " +
                        timetable.getRoom(bestClass.getRoomId()).getRoomNumber());
                Console.WriteLine("Professor: " +
                        timetable.getProfessor(bestClass.getProfessorId()).getProfessorName());
                Console.WriteLine("Time: " +
                        timetable.getTimeslot(bestClass.getTimeslotId()).getTimeslot());
                Console.WriteLine("-----");
                classIndex++;
            }
        }

        /**
         * Creates a Timetable with all the necessary course information.
         * 
         * Normally you'd get this info from a database.
         * 
         * @return
         */
        private static Timetable initializeTimetable()
        {
            // Create timetable
            Timetable timetable = new Timetable();

            // Set up rooms
            timetable.addRoom(1, "A1", 15);
            timetable.addRoom(2, "B1", 30);
            timetable.addRoom(4, "D1", 20);
            timetable.addRoom(5, "F1", 25);

            // Set up timeslots
            timetable.addTimeslot(1, "Mon 9:00 - 11:00");
            timetable.addTimeslot(2, "Mon 11:00 - 13:00");
            timetable.addTimeslot(3, "Mon 13:00 - 15:00");
            timetable.addTimeslot(4, "Tue 9:00 - 11:00");
            timetable.addTimeslot(5, "Tue 11:00 - 13:00");
            timetable.addTimeslot(6, "Tue 13:00 - 15:00");
            timetable.addTimeslot(7, "Wed 9:00 - 11:00");
            timetable.addTimeslot(8, "Wed 11:00 - 13:00");
            timetable.addTimeslot(9, "Wed 13:00 - 15:00");
            timetable.addTimeslot(10, "Thu 9:00 - 11:00");
            timetable.addTimeslot(11, "Thu 11:00 - 13:00");
            timetable.addTimeslot(12, "Thu 13:00 - 15:00");
            timetable.addTimeslot(13, "Fri 9:00 - 11:00");
            timetable.addTimeslot(14, "Fri 11:00 - 13:00");
            timetable.addTimeslot(15, "Fri 13:00 - 15:00");

            // Set up professors
            timetable.addProfessor(1, "Dr P Smith");
            timetable.addProfessor(2, "Mrs E Mitchell");
            timetable.addProfessor(3, "Dr R Williams");
            timetable.addProfessor(4, "Mr A Thompson");

            // Set up modules and define the professors that teach them
            timetable.addModule(1, "cs1", "Computer Science", new int[] { 1, 2 });
            timetable.addModule(2, "en1", "English", new int[] { 1, 3 });
            timetable.addModule(3, "ma1", "Maths", new int[] { 1, 2 });
            timetable.addModule(4, "ph1", "Physics", new int[] { 3, 4 });
            timetable.addModule(5, "hi1", "History", new int[] { 4 });
            timetable.addModule(6, "dr1", "Drama", new int[] { 1, 4 });

            // Set up student groups and the modules they take.
            timetable.addGroup(1, 10, new int[] { 1, 3, 4 });
            timetable.addGroup(2, 30, new int[] { 2, 3, 5, 6 });
            timetable.addGroup(3, 18, new int[] { 3, 4, 5 });
            timetable.addGroup(4, 25, new int[] { 1, 4 });
            timetable.addGroup(5, 20, new int[] { 2, 3, 5 });
            timetable.addGroup(6, 22, new int[] { 1, 4, 5 });
            timetable.addGroup(7, 16, new int[] { 1, 3 });
            timetable.addGroup(8, 18, new int[] { 2, 6 });
            timetable.addGroup(9, 24, new int[] { 1, 6 });
            timetable.addGroup(10, 25, new int[] { 3, 4 });
            return timetable;
        }
    }
   
    
    

    

    
    

    

    

   
    
}
