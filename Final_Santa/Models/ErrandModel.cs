using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Santa.Models
{
    internal class ErrandModel
    {

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string ErrandDescription { get; set; } = null!;

        public DateTime ErrandDate { get; set; }

        public int ErrandStatus { get; set; }

        public int CustomerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

    }
}
