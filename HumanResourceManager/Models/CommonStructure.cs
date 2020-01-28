using System;

namespace HumanResourceManager.Models
{
    public class CommonStructure
    {
        public int Id { get; }
        public string Name { get; set; }

        public CommonStructure(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public CommonStructure(string name)
        {
            Name = name;
        }

        public CommonStructure(){ }

        // Возвращает объект в виде строки с параметрами
        public string SerializeToString()
        {
            string result = $"{Id.ToString()}~{Name}";

            return result;
        }

        // Собирает объект из параметров
        protected static CommonStructure Desirialize(string value)
        {
            string[] parameters = value.Split('~');

            return new CommonStructure(

                Convert.ToInt32(parameters[0]),
                parameters[1]

            );
        }
    }
}
