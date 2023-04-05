namespace EMSwebapp.ViewModels
{
    public class RoleViewModel
    {
        public Guid Id { get; set; } // Unique Global ID 
        // Combination of MAC address(hardware or ip address) and Timestamp (value computed and the computed value will be assign)

        public string Name { get; set; }
    }
}
