using CastleCoreApp.Attributes;

namespace CastleCoreApp.Services
{
    public class CustomerService : ICustomerService
    {
        [Log]
        [Mail]
        public void CreateCustomer()
        {
            // Business logic
        }

        [Mail]
        public void GetCustomerById()
        {
            // Business logic
        }

        [Log]
        public void UpdateCustomerDetails()
        {
            // Business logic
        }

        [Cache]
        [Log]
        [Mail]
        public void DeleteCustomer()
        {
            // Business logic
        }
    }
}
