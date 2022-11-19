using System;
namespace State.Structural
{
    /// <summary>
    /// State Design Pattern
    /// </summary>
    public class StatePattern
    {
        public static void Main(string[] args)
        {
            // Setup context in a state
            var context = new Context(new ConcreteStateA());
            // Issue requests, which toggles state
            context.Request();
            context.Request();
            context.Request();
            context.Request();
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    public abstract class State
    {
        public abstract void Handle(Context context);
    }
    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }
    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }
    /// <summary>
    /// The 'Context' class
    /// </summary>
    public class Context
    {
        State _state;
        // Constructor
        public Context(State state)
        {
            this.State = state;
        }
        // Gets or sets the state
        public State State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                Console.WriteLine("State: " + _state.GetType().Name);
            }
        }
        public void Request()
        {
            _state.Handle(this);
        }
    }
}