using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IDonkeyService
    {
        Donkey Create(string batchName);
        
        IEnumerable<Donkey> getAll();
        
        void Delete(int batchId);
    }
}