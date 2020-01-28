namespace HumanResourceManager.Models
{
    public class OrganizationalType : CommonStructure
    {
        public OrganizationalType(int id, string name) : base(id, name) { }

        public OrganizationalType() : base() { }

        // Собирает объект из параметров
        public static OrganizationalType DesirializeToOrganizationalType(string value)
        {
            var structure = Desirialize(value);

            return new OrganizationalType(structure.Id, structure.Name);
        }
    }
}
