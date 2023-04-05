namespace EMSwebapp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee>? Employees { get; set; }


        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
