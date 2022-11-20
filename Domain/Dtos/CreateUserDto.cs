using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
    }
}
