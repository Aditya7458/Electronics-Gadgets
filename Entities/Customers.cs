using System;

namespace OrderManagementSystem
{
    public class Customers
    {
        private int customerId;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;

        public Customers(int customerId, string firstName, string lastName, string email, string phone, string address)
        {
            this.CustomerID = customerId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }

        public int CustomerID
        {
            get { return customerId; }
            private set { customerId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (!value.Contains("@"))
                    throw new ArgumentException("Invalid email format.");
                email = value;
            }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public void GetCustomerDetails()
        {
            Console.WriteLine($"Customer ID: {CustomerID}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {Phone}, Address: {Address}");
        }

        public void UpdateCustomerInfo(string newEmail, string newPhone, string newAddress)
        {
            this.Email = newEmail;
            this.Phone = newPhone;
            this.Address = newAddress;
        }

        public int CalculateTotalOrders()
        {
            return 0;
        }
    }
}
