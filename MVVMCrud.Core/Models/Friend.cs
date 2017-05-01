using System;

namespace MVVMCrud.Core.Models
{
    public class Friend : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
