namespace VideoGameApi
{
    public class ApiObject
    {
        public string Id { get; set; } // "id" is a string
        public string Name { get; set; } // "name" is a string
        public Dictionary<string, object> Data { get; set; } // "data" can hold dynamic key-value pairs
    }


}
