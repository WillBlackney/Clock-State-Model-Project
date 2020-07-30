using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockMachineEngine
{
    // Base abstract class
    public abstract class StateMachine
    {
        protected State myCurrentState;
        public abstract void SetState(State newState);
    }
}

