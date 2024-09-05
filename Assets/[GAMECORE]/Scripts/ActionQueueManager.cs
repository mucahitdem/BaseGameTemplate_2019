using System;
using System.Collections.Generic;
using UnityEngine;


namespace GAME.Scripts.Helpers
{
    public class ActionQueueManager // last dequed action is the one ended ? This can be checked
    {
        public bool AreTasksCompleted => actions.Count == 0;
        private readonly Queue<Action> actions = new Queue<Action>();
        private bool isInProcess;

        public void OnActionEnd()
        {
            if (actions.Count > 0)
            {
                actions.Dequeue()?.Invoke();
                return;
            }
            
            isInProcess = false;
        }
        public void AddAction(Action action)
        {
            if (isInProcess)
            {
               Enqueue(action);
            }
            else
            {
                if (actions.Count == 0)
                {
                    isInProcess = true;
                    action?.Invoke();
                }
                else
                {
                    Enqueue(action);
                }
            }
        }

        
        
        private void Enqueue(Action action)
        {
            actions.Enqueue(()=>
            {
                action?.Invoke();
            });
        }
    }
}