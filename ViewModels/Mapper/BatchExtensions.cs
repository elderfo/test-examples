using BusinessLogic;

namespace ViewModels.Mapper
{
    public static class BatchExtensions
    {
        public static DonkeyViewModel ToBatchViewModel(this Donkey donkey)
        {
            return new DonkeyViewModel(donkey.Id, donkey.Name);
        }
    }
}