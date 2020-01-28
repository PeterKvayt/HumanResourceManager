namespace HumanResourceManager.Models
{
    public class Position : CommonStructure
    {
        public Position(int id, string name):base(id, name){ }

        public Position() : base() { }

        // Собирает объект из параметров
        public static Position DesirializeToPosition(string value)
        {
            var structure = Desirialize(value);

            return new Position(structure.Id, structure.Name);
        }
    }
}
