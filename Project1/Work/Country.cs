namespace Project1.Work
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AnimalsName { get; set; }
        public int Area { get; set; }
        public Town[] Towns { get; set; }
        public string Description
        {
            get
            {
                return $"{ID} {Name} {AnimalsName} {Area}";
            }
        }
    }
}
