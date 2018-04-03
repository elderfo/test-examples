using System;
using BusinessLogic;

namespace ViewModels
{
    public class WeakEventManager
    {
        private EventHandler<Batch> _eventHandler;

        public void AddListener(EventHandler<Batch> eventHandler)
        {
            _eventHandler = eventHandler;
        }

        public void Dispatch(Batch batch)
        {
            _eventHandler?.Invoke(null, batch);
        }
    }
}