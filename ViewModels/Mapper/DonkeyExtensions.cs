using BusinessLogic;

namespace ViewModels.Mapper
{
    public static class DonkeyExtensions
    {
        public static DonkeyViewModel ToBatchViewModel(this Donkey donkey)
        {
            return new DonkeyViewModel(donkey.Id, donkey.Name);
        }
    }
}
