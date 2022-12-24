using System;
using UnityEngine;

namespace Scripts.Mediator
{
    public class Mediator : SingletonMono<Mediator>
    {
        protected override void UseThisInsteadOfAwake()
        {
            //
        }

        public void SendEvent<T>(T @this, object[] args) where T : Type
        {
            throw new NotImplementedException();
        }

        public void Subscribe(Delegate @delegate, Type @this)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(Delegate @delegate, Type @this)
        {
            throw new NotImplementedException();
        }
    }
}