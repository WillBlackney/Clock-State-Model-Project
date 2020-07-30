using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockModelEngine
{
    public abstract class State
    {
        public ClockModel myClockModel;
        public virtual void OnStateSet()
        {
            
        }
        public virtual void OnStateExit()
        {

        }
    }
}

