namespace ViewModels
{
    public class DonkeyViewModel : ViewModel
    {
        public int Id { get; }
        public string Name { get; }

        public DonkeyViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}