using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ClockEngine
{
    public class Clock
    {
        // Variables
        #region
        // State variables
        private PowerState powerState;
        private AlarmState alarmState;
        private TimeSettingState timeSettingState;

        // Alarm variables
        private DateTime alarmSetTime;
        private DateTime nextAlarmRingTime;
        private int maxSnoozes;
        private int currentSnoozeCount;
        private int snoozeDurationInMinutes;

        // Time variables
        private DateTime currentTime;
        #endregion

        // Properties
        #region
        public PowerState PowerState
        {
            get { return powerState; }
            private set { powerState = value; }
        }
        public AlarmState AlarmState
        {
            get { return alarmState; }
            private set { alarmState = value; }
        }
        public TimeSettingState TimeSettingState
        {
            get { return timeSettingState; }
            private set { timeSettingState = value; }
        }
        public DateTime AlarmSetTime
        {
            get { return alarmSetTime; }
            private set { alarmSetTime = value; }
        }
        public DateTime NextAlarmRingTime
        {
            get { return nextAlarmRingTime; }
            private set { nextAlarmRingTime = value; }
        }
        public int MaxSnoozes
        {
            get { return maxSnoozes; }
            private set { maxSnoozes = value; }
        }
        public int CurrentSnoozeCount
        {
            get { return currentSnoozeCount; }
            private set { currentSnoozeCount = value; }
        }
        public int SnoozeDurationInMinutes
        {
            get { return snoozeDurationInMinutes; }
            private set { snoozeDurationInMinutes = value; }
        }        
        public DateTime CurrentTime
        {
            get { return currentTime; }
            private set { currentTime = value; }
        }
        #endregion

        // Constructors
        #region
        public Clock()
        {
            // Set default state dictated by requirements
            PowerState = PowerState.Off;
            AlarmState = AlarmState.AlarmOff;
            TimeSettingState = TimeSettingState.NoTimeSet;
            MaxSnoozes = 2;
            SnoozeDurationInMinutes = 10;
        }
        public Clock(int _maxSnoozes, int _snoozeDurationInMinutes)
        {
            // Set default state, override requirements
            PowerState = PowerState.Off;
            AlarmState = AlarmState.AlarmOff;
            TimeSettingState = TimeSettingState.NoTimeSet;

            // Overide requirements
            MaxSnoozes = _maxSnoozes;
            SnoozeDurationInMinutes = _snoozeDurationInMinutes;
        }

        #endregion

        // Logic
        #region

        // Set Clock State
        #region
        public void SetClockPowerState(PowerState _powerState)
        {
            Debug.Log("ClockController.SetClockPowerState() called...");
            PowerState = _powerState;
            Debug.Log("Clock state is now: " + PowerState.ToString());
        }
        public void EnableAlarm()
        {
            if (TimeSettingState == TimeSettingState.TimeSet)
            {
                AlarmState = AlarmState.AlarmOn;
                AutoScheduleNextAlarmRingEvent();
            }
        }
        private void DisableAlarm()
        {
            AlarmState = AlarmState.AlarmOff;
            CurrentSnoozeCount = 0;
        }
        public void StartRingingAlarm()
        {
            AlarmState = AlarmState.AlarmRinging;
        }
        #endregion

        // Modify Alarm Timing
        #region
        public void SetAlarmTime(DateTime time)
        {
            if (TimeSettingState == TimeSettingState.TimeSet)
            {
                AlarmSetTime = time;
                CurrentSnoozeCount = 0;
                AutoScheduleNextAlarmRingEvent();
            }
        }
       
        #endregion

        // Set Time
        #region
        public void SetCurrentTime(DateTime newTime)
        {
            CurrentTime = newTime;
            TimeSettingState = TimeSettingState.TimeSet;
        }
        #endregion

        // Schedule Alarm Events
        #region
        private void AutoScheduleNextAlarmRingEvent()
        {
            NextAlarmRingTime = AlarmSetTime.AddMinutes(CurrentSnoozeCount * SnoozeDurationInMinutes);
        }
        private void AutoSetAlarmTomorow()
        {
            SetAlarmTime(AlarmSetTime.AddDays(1));
        }
        #endregion

        // Button Press Events
        #region
        public void HandleSnoozeButtonPressedEvent()
        {
            if (AlarmState == AlarmState.AlarmRinging && CurrentSnoozeCount < MaxSnoozes)
            {
                CurrentSnoozeCount++;

                if (CurrentSnoozeCount >= MaxSnoozes)
                {
                    DisableAlarm();
                    AutoSetAlarmTomorow();
                }
                else
                {
                    EnableAlarm();
                }

            }
        }
        public void HandleStopAlarmButtonPressedEvent()
        {
            if (AlarmState == AlarmState.AlarmRinging)
            {
                DisableAlarm();
                AutoSetAlarmTomorow();
            }
        }
        public void HandlePowerButtonPressedEvent()
        {
            switch (PowerState)
            {
                case PowerState.On:
                    PowerState = PowerState.Off;
                    break;

                case PowerState.Off:
                    PowerState = PowerState.On;
                    break;
            }
        }
        #endregion

        #endregion
    }
}

    // State Enums
    #region
    public enum PowerState
    {
        Off,
        On
    }
    public enum AlarmState
    {
        AlarmOn,
        AlarmOff,
        AlarmRinging,
    }
    public enum TimeSettingState
    {
        NoTimeSet,
        TimeSet,
    }
    #endregion



