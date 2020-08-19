namespace Session07.Es.CustomerManagement.ApplicationServices.People.Dtoes
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerId { get; set; }

        public AddressDto Address { get; set; }
    }
}
