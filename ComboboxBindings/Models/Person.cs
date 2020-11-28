using System.Collections.Generic;

namespace ComboboxBindings.Models
{
    public class Person
    {
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public List<Address> Addresses {get; set;} = new List<Address>();
        public Address PrimaryAddress { get; set; }

        public string GetFullName
        {
            get
            {
                return $"{NameFirst} {NameLast}";
            }
        }
    }
}
