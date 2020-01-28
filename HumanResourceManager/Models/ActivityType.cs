namespace HumanResourceManager.Models
{
    public class ActivityType : CommonStructure
    {
        public ActivityType(int id, string name) : base(id, name) { }

        public ActivityType() : base() { }

        // Собирает объект из параметров
        public static ActivityType DesirializeToActivityType(string value)
        {
            var structure = Desirialize(value);

            return new ActivityType(structure.Id, structure.Name);
        }
    }
}
