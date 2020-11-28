namespace ComboboxBindings.Models
{
    public class Address
    {
        public string CityName { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string Hause { get; set; }

        public string GetFullAddress
        {
            get
            {
                return $"Индекс {PostCode}, {CityName}, {Street}, д.{Hause}";
            }
        }

    }
}
