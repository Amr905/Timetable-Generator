using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.model
{
    public class Timetable
    {
        private Dictionary<int, Room> rooms;
        private Dictionary<int, Professor> professors;
        private Dictionary<int, Module> modules;
        private Dictionary<int, Group> groups;
        private Dictionary<int, Timeslot> timeslots;
        private Class[] classes;

        private int numClasses = 0;

        /**
         * Initialize new Timetable
         */
        public Timetable()
        {
            this.rooms = new Dictionary<int, Room>();
            this.professors = new Dictionary<int, Professor>();
            this.modules = new Dictionary<int, Module>();
            this.groups = new Dictionary<int, Group>();
            this.timeslots = new Dictionary<int, Timeslot>();
        }

        /**
         * "Clone" a timetable. We use this before evaluating a timetable so we have
         * a unique container for each set of classes created by "createClasses".
         * Truthfully, that's not entirely necessary (no big deal if we wipe out and
         * reuse the .classes property here), but Chapter 6 discusses
         * multi-threading for fitness calculations, and in order to do that we need
         * separate objects so that one thread doesn't step on another thread's
         * toes. So this constructor isn't _entirely_ necessary for Chapter 5, but
         * you'll see it in action in Chapter 6.
         * 
         * @param cloneable
         */
        public Timetable(Timetable cloneable)
        {
            this.rooms = cloneable.getRooms();
            this.professors = cloneable.getProfessors();
            this.modules = cloneable.getModules();
            this.groups = cloneable.getGroups();
            this.timeslots = cloneable.getTimeslots();
        }

        private Dictionary<int, Group> getGroups()
        {
            return this.groups;
        }

        private Dictionary<int, Timeslot> getTimeslots()
        {
            return this.timeslots;
        }

        private Dictionary<int, Module> getModules()
        {
            return this.modules;
        }

        private Dictionary<int, Professor> getProfessors()
        {
            return this.professors;
        }

        /**
         * Add new room
         * 
         * @param roomId
         * @param roomName
         * @param capacity
         */
        public void addRoom(int roomId, String roomName, int capacity)
        {
            this.rooms.Add(roomId, new Room(roomId, roomName, capacity));
        }

        /**
         * Add new professor
         * 
         * @param professorId
         * @param professorName
         */
        public void addProfessor(int professorId, String professorName)
        {
            this.professors.Add(professorId, new Professor(professorId, professorName));
        }

        /**
         * Add new module
         * 
         * @param moduleId
         * @param moduleCode
         * @param module
         * @param professorIds
         */
        public void addModule(int moduleId, String moduleCode, String module, int[] professorIds)
        {
            this.modules.Add(moduleId, new Module(moduleId, moduleCode, module, professorIds));
        }

        /**
         * Add new group
         * 
         * @param groupId
         * @param groupSize
         * @param moduleIds
         */
        public void addGroup(int groupId, int groupSize, int[] moduleIds)
        {
            this.groups.Add(groupId, new Group(groupId, groupSize, moduleIds));
            this.numClasses = 0;
        }

        /**
         * Add new timeslot
         * 
         * @param timeslotId
         * @param timeslot
         */
        public void addTimeslot(int timeslotId, String timeslot)
        {
            this.timeslots.Add(timeslotId, new Timeslot(timeslotId, timeslot));
        }

        /**
         * Create classes using individual's chromosome
         * 
         * One of the two important methods in this class; given a chromosome,
         * unpack it and turn it into an array of Class (with a capital C) objects.
         * These Class objects will later be evaluated by the calcClashes method,
         * which will loop through the Classes and calculate the number of
         * conflicting timeslots, rooms, professors, etc.
         * 
         * While this method is important, it's not really difficult or confusing.
         * Just loop through the chromosome and create Class objects and store them.
         * 
         * @param individual
         */
        public void createClasses(Individual individual)
        {
            // Init classes
            Class[] classes = new Class[this.getNumClasses()];

            // Get individual's chromosome
            int[] chromosome = individual.getChromosome();
            int chromosomePos = 0;
            int classIndex = 0;

            foreach (Group group in this.getGroupsAsArray())
            {
                int[] moduleIds = group.getModuleIds();
                foreach (int moduleId in moduleIds)
                {
                    classes[classIndex] = new Class(classIndex, group.getGroupId(), moduleId);

                    // Add timeslot
                    classes[classIndex].addTimeslot(chromosome[chromosomePos]);
                    chromosomePos++;

                    // Add room
                    classes[classIndex].setRoomId(chromosome[chromosomePos]);
                    chromosomePos++;

                    // Add professor
                    classes[classIndex].addProfessor(chromosome[chromosomePos]);
                    chromosomePos++;

                    classIndex++;
                }
            }

            this.classes = classes;
        }

        /**
         * Get room from roomId
         * 
         * @param roomId
         * @return room
         */
        public Room getRoom(int roomId)
        {
            if (!this.rooms.ContainsKey(roomId))
            {
                Console.WriteLine("Rooms doesn't contain key " + roomId);
            }
            return (Room)this.rooms[roomId];
        }

        public Dictionary<int, Room> getRooms()
        {
            return this.rooms;
        }

        /**
         * Get random room
         * 
         * @return room
         */
        public Room getRandomRoom()
        {
            Random random = new Random();
            Object[] roomsArray = this.rooms.Values.ToArray();
            Room room = (Room)roomsArray[(int)(roomsArray.Length * random.NextDouble())];
            return room;
        }

        /**
         * Get professor from professorId
         * 
         * @param professorId
         * @return professor
         */
        public Professor getProfessor(int professorId)
        {
            return (Professor)this.professors[professorId];
        }

        /**
         * Get module from moduleId
         * 
         * @param moduleId
         * @return module
         */
        public Module getModule(int moduleId)
        {
            return (Module)this.modules[moduleId];
        }

        /**
         * Get moduleIds of student group
         * 
         * @param groupId
         * @return moduleId array
         */
        public int[] getGroupModules(int groupId)
        {
            Group group = (Group)this.groups[groupId];
            return group.getModuleIds();
        }

        /**
         * Get group from groupId
         * 
         * @param groupId
         * @return group
         */
        public Group getGroup(int groupId)
        {
            return (Group)this.groups[groupId];
        }

        /**
         * Get all student groups
         * 
         * @return array of groups
         */
        public Group[] getGroupsAsArray()
        {

            //return (Group[])this.groups.Values.ToArray(new Group[this.groups.Count]);
            return (Group[])this.groups.Values.ToArray();
        }

        /**
         * Get timeslot by timeslotId
         * 
         * @param timeslotId
         * @return timeslot
         */
        public Timeslot getTimeslot(int timeslotId)
        {
            return (Timeslot)this.timeslots[timeslotId];
        }

        /**
         * Get random timeslotId
         * 
         * @return timeslot
         */
        public Timeslot getRandomTimeslot()
        {
            Random random = new Random();
            Object[] timeslotArray = this.timeslots.Values.ToArray();
            Timeslot timeslot = (Timeslot)timeslotArray[(int)(timeslotArray.Length * random.NextDouble())];
            return timeslot;
        }

        /**
         * Get classes
         * 
         * @return classes
         */
        public Class[] getClasses()
        {
            return this.classes;
        }

        /**
         * Get number of classes that need scheduling
         * 
         * @return numClasses
         */
        public int getNumClasses()
        {
            if (this.numClasses > 0)
            {
                return this.numClasses;
            }

            int numClasses = 0;
            // Group[] groups = (Group[])this.groups.Values.ToArray(new Group[this.groups.size()]);
            Group[] groups = (Group[])this.groups.Values.ToArray();
            foreach (Group group in groups)
            {
                numClasses += group.getModuleIds().Length;
            }
            this.numClasses = numClasses;

            return this.numClasses;
        }

        /**
         * Calculate the number of clashes between Classes generated by a
         * chromosome.
         * 
         * The most important method in this class; look at a candidate timetable
         * and figure out how many constraints are violated.
         * 
         * Running this method requires that createClasses has been run first (in
         * order to populate this.classes). The return value of this method is
         * simply the number of constraint violations (conflicting professors,
         * timeslots, or rooms), and that return value is used by the
         * GeneticAlgorithm.calcFitness method.
         * 
         * There's nothing too difficult here either -- loop through this.classes,
         * and check constraints against the rest of the this.classes.
         * 
         * The two inner `for` loops can be combined here as an optimization, but
         * kept separate for clarity. For small values of this.classes.length it
         * doesn't make a difference, but for larger values it certainly does.
         * 
         * @return numClashes
         */
        public int calcClashes()
        {
            int clashes = 0;

            foreach (Class classA in this.classes)
            {
                // Check room capacity
                int roomCapacity = this.getRoom(classA.getRoomId()).getRoomCapacity();
                int groupSize = this.getGroup(classA.getGroupId()).getGroupSize();

                if (roomCapacity < groupSize)
                {
                    clashes++;
                }

                // Check if room is taken
                foreach (Class classB in this.classes)
                {
                    if (classA.getRoomId() == classB.getRoomId() && classA.getTimeslotId() == classB.getTimeslotId()
                            && classA.getClassId() != classB.getClassId())
                    {
                        clashes++;
                        break;
                    }
                }

                // Check if professor is available
                foreach (Class classB in this.classes)
                {
                    if (classA.getProfessorId() == classB.getProfessorId() && classA.getTimeslotId() == classB.getTimeslotId()
                            && classA.getClassId() != classB.getClassId())
                    {
                        clashes++;
                        break;
                    }
                }
            }

            return clashes;
        }
    }
}
