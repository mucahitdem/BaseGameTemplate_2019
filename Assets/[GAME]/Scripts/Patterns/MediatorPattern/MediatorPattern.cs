using System;
using UnityEngine;

namespace Scripts.Patterns.MediatorPattern
{
    public class MediatorPattern : MonoBehaviour
    {
        private void Awake()
        {
            Main();
        }
        
        void Main()
        {
            // The client code.
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggers operation A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }
        
        // The Mediator interface declares a method used by components to notify the
        // mediator about various events. The Mediator may react to these events and
        // pass the execution to other components.
        private interface IMediator
        {
            void Notify(object sender, string ev);
        }

        // Concrete Mediators implement cooperative behavior by coordinating several
        // components.                                                                
        class ConcreteMediator : IMediator
        {
            private readonly Component1 _component1;
            private readonly Component2 _component2;

            public ConcreteMediator(Component1 component1, Component2 component2)
            {
                this._component1 = component1;
                this._component1.SetMediator(this);
                this._component2 = component2;
                this._component2.SetMediator(this);
            }

            public void Notify(object sender, string ev)
            {
                if (ev == "A")
                {
                    Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
                    this._component2.DoC();
                }

                if (ev == "D")
                {
                    Console.WriteLine("Mediator reacts on D and triggers following operations:");
                    this._component1.DoB();
                    this._component2.DoC();
                }
            }
        }

        // The Base Component provides the basic functionality of storing a
        // mediator's instance inside component objects.
        class BaseComponent
        {
            protected IMediator Mediator;

            protected BaseComponent(IMediator mediator = null)
            {
                Mediator = mediator;
            }

            public void SetMediator(IMediator mediator)
            {
                Mediator = mediator;
            }
        }

        // Concrete Components implement various functionality. They don't depend on
        // other components. They also don't depend on any concrete mediator
        // classes.
        class Component1 : BaseComponent
        {
            public void DoA()
            {
                Console.WriteLine("Component 1 does A.");

                this.Mediator.Notify(this, "A");
            }

            public void DoB()
            {
                Console.WriteLine("Component 1 does B.");

                this.Mediator.Notify(this, "B");
            }
        }

        class Component2 : BaseComponent
        {
            public void DoC()
            {
                Console.WriteLine("Component 2 does C.");

                this.Mediator.Notify(this, "C");
            }

            public void DoD()
            {
                Console.WriteLine("Component 2 does D.");

                this.Mediator.Notify(this, "D");
            }
        }
    }
}