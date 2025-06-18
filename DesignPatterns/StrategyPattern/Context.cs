namespace DesignPatterns.StrategyPattern
{
    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public IStrategy Strategy
        {
            set
            {
                _strategy = value;
            }
        }

        //public void SetStrategy (IStrategy value)
        //{
        //    _strategy = value;
        //}

        public void DoSomenthing()
        {
            _strategy.Execute();
        }
    }
}
