using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ClockEngine
{    
    public class ClockController : MonoBehaviour
    {
        /*
        // Singleton Pattern
        #region
        public static ClockController Instance;
        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        // Set Clock State
        #region
        public void SetClockPowerState(Clock clock, PowerState powerState)
        {
            Debug.Log("ClockController.SetClockPowerState() called...");
            clock.powerState = powerState;
            Debug.Log("Clock state is now: " + powerState.ToString());
        }
        public void EnableAlarm(Clock clock)
        {
            if (clock.timeSettingState == TimeSettingState.TimeSet)
            {
                clock.alarmState = AlarmState.AlarmOn;
                AutoScheduleNextAlarmRingEvent(clock);
            }
        }
        public void DisableAlarm(Clock clock)
        {
            if(clock.alarmState == AlarmState.AlarmRinging)
            {

            }
            else if(clock.alarmState == AlarmState.AlarmOn)
            {
                clock.alarmState = AlarmState.AlarmOff;
                clock.currentSnoozeCount = 0;
            }
            
        }
        public void StartPlayAlarm(Clock clock)
        {
            clock.alarmState = AlarmState.AlarmRinging;
        }
        #endregion

        // Modify alarm timing
        #region
        public void SetAlarmTime(Clock clock, DateTime time)
        {
            if (clock.timeIsSet)
            {
                clock.timeSettingState = TimeSettingState.TimeSet;
                clock.alarmSetTime = time;
                clock.nextAlarmRingTime = time;

                // Should setting the alarm time clear all snooze settings?
                // This would allow them to bypass the max snooze button presses
                clock.currentSnoozeCount = 0;
            }
        }
        public void ClearAlarmTime(Clock clock)
        {
            clock.timeSettingState = TimeSettingState.NoTimeSet;
        }
        #endregion

        // Set Time
        #region
        public void SetClockCurrentTime(Clock clock, DateTime newTime)
        {
            clock.currentTime = newTime;
            // update view model text
        }
        #endregion
        // Schedule alarm events
        #region
        private void AutoScheduleNextAlarmRingEvent(Clock clock)
        {
            clock.nextAlarmRingTime.AddMinutes(clock.currentSnoozeCount * clock.snoozeDurationInMinutes);
        }
        private void AutoSetAlarmTomorow(Clock clock)
        {
            SetAlarmTime(clock, clock.alarmSetTime.AddDays(1));
        }
        private void ClearAllScheduledAlarmEvents(Clock clock) 
        { 
        }
        #endregion

        // Button Press Events
        #region
        public void HandleSnoozeButtonPressedEvent(Clock clock)
        {
            if (clock.alarmState == AlarmState.AlarmRinging &&
                clock.currentSnoozeCount < clock.maxSnoozes)
            {
                clock.currentSnoozeCount++;

                if (clock.currentSnoozeCount >= clock.maxSnoozes)
                {
                    DisableAlarm(clock);
                    AutoSetAlarmTomorow(clock);
                }
                else
                {
                    EnableAlarm(clock);
                }

            }
        }
        public void HandlePowerButtonPressedEvent(Clock clock)
        {
            switch (clock.powerState)
            {
                case PowerState.On:
                    clock.powerState = PowerState.Off;
                    break;

                case PowerState.Off:
                    clock.powerState = PowerState.On;
                    break;
            }
        }
        #endregion
*/
    }
    
}

