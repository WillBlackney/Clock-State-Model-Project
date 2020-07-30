using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockModelEngine
{
    public class ClockModel : StateMachine
    {
        public State powerState;
        public State alarmState;
        public State timeSettingState;

        public override void SetState(State newState)
        {

        }

    }
}

