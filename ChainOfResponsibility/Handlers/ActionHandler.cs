using ChainOfResponsibilty.DTO;

namespace ChainOfResponsibilty.Handlers
{
    public abstract class ActionHandler
    {
        protected ActionHandler _nextHandler;

      
        public ActionHandler SetNext(ActionHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }

      
        public abstract void Handle(ActionRequestDTO request);
    }

}
