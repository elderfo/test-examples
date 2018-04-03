using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IBatchService
    {
        Batch Create(Batch batch);
        IEnumerable<Batch> getAll();
    }
}