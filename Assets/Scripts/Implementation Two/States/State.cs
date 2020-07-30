using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockMachineEngine
{
    // Abstract Base Class
    public abstract class State
    {
        protected StateMachine myStateMachine;
        public abstract void OnStateEntered();
        public abstract void OnStateExitted();
    }
}

