using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ClockEngine;
using System;

namespace Tests
{
    public class EditModeClockTests
    {
        [Test]
        public void CannotSetAlarmTimeIfNormalTimeNotSet()
        {
            // Arrange
            Clock clock = new Clock();
            DateTime newAlarmTime = new DateTime(2000, 1, 1);

            // Act
            clock.SetAlarmTime(newAlarmTime);

            // Assert
            Assert.AreNotEqual(clock.AlarmSetTime, newAlarmTime);
        }

        [Test]
        public void CannotEnableAlarmIfAlarmTimeNotSet()
        {
            // Arrange
            Clock clock = new Clock();

            // Act
            clock.EnableAlarm();

            // Assert
            Assert.IsFalse(clock.AlarmState == AlarmState.AlarmOn);
        }
        [Test]
        public void CannotSnoozeIfAlarmIsNotRinging()
        {
            // Arrange
            Clock clock = new Clock();
            DateTime newClockTime = new DateTime(2000, 1, 1);
            DateTime newAlarmTime = new DateTime(2000, 1, 2);
            int expectedSnoozeCount = 0;

            // Act
            clock.EnableAlarm();
            clock.SetCurrentTime(newClockTime);
            clock.SetAlarmTime(newAlarmTime);
            clock.HandleSnoozeButtonPressedEvent();

            // Assert
            Assert.AreEqual(clock.CurrentSnoozeCount, expectedSnoozeCount);
        }
        [Test]
        public void SettingAlarmTimeSchedulesNextAlarmRingEvent()
        {
            // Arrange
            Clock clock = new Clock();
            DateTime newClockTime = new DateTime(2000, 1, 1);
            DateTime newAlarmTime = new DateTime(2000, 1, 2);

            // Act            
            clock.SetCurrentTime(newClockTime);
            clock.SetAlarmTime(newAlarmTime);

            // Assert
            Assert.AreEqual(clock.NextAlarmRingTime, newAlarmTime);

        }
        [Test]
        public void SnoozeButtonCorrectlySchedulesNextAlarmEvent()
        {
            // Arrange
            Clock clock = new Clock();
            DateTime newClockTime = new DateTime(2000, 1, 1);
            DateTime newAlarmTime = new DateTime(2000, 1, 2, 0, 0, 0);
            DateTime expectedSnoozeAlarmTime = new DateTime(
                newAlarmTime.Year, 
                newAlarmTime.Month, 
                newAlarmTime.Day, 
                newAlarmTime.Hour, 
                newAlarmTime.Minute + clock.SnoozeDurationInMinutes, 
                newAlarmTime.Second);

            // Act            
            clock.SetCurrentTime(newClockTime);
            clock.SetAlarmTime(newAlarmTime);
            clock.StartPlayAlarm();
            clock.HandleSnoozeButtonPressedEvent();

            // Assert
            Assert.AreEqual(clock.NextAlarmRingTime, expectedSnoozeAlarmTime);
        }
        [Test]
        public void ValidSnoozeActionSetsAlarmStateToOn()
        {
            // Arrange
            Clock clock = new Clock();
            DateTime newClockTime = new DateTime(2000, 1, 1);
            DateTime newAlarmTime = new DateTime(2000, 1, 2);
            AlarmState expectedAlarmState = AlarmState.AlarmOn;

            // Act
            clock.EnableAlarm();
            clock.SetCurrentTime(newClockTime);
            clock.SetAlarmTime(newAlarmTime);
            clock.StartPlayAlarm();
            clock.HandleSnoozeButtonPressedEvent();

            // Assert
            Assert.AreEqual(clock.AlarmState, expectedAlarmState);
        }
        [Test]
        public void MaxxingOutSnoozePressesPreventsFurtherSnoozes()
        {
            // Arrange
            Clock clock = new Clock();
            DateTime newClockTime = new DateTime(2000, 1, 1);
            DateTime newAlarmTime = new DateTime(2000, 1, 2);
            AlarmState expectedAlarmState = AlarmState.AlarmOff;

            // Act
            clock.EnableAlarm();
            clock.SetCurrentTime(newClockTime);
            clock.SetAlarmTime(newAlarmTime);

            // Max out snooze presses
            for(int snoozePressLoops = clock.MaxSnoozes; snoozePressLoops < clock.MaxSnoozes; snoozePressLoops++)
            {
                clock.StartPlayAlarm();
                clock.HandleSnoozeButtonPressedEvent();
            }            

            // Assert
            Assert.AreEqual(clock.AlarmState, expectedAlarmState);
        }
        [Test]
        public void TurningOffAlarmDuringRingAutoSetsTomorrowsAlarmTime()
        {
            /*
            // Arrange
            Clock clock = new Clock();
            DateTime newClockTime = new DateTime(2000, 1, 1);
            DateTime initialAlarmTime = new DateTime(2000, 1, 2,0,0,0);
            DateTime expectedAlarmTimeTomorow = (
                
                )
            AlarmState expectedAlarmState = AlarmState.AlarmOff;

            // Act
            clock.EnableAlarm();
            clock.SetCurrentTime(newClockTime);
            clock.SetAlarmTime(newAlarmTime);

            // Max out snooze presses
            for (int snoozePressLoops = clock.MaxSnoozes; snoozePressLoops < clock.MaxSnoozes; snoozePressLoops++)
            {
                clock.StartPlayAlarm();
                clock.HandleSnoozeButtonPressedEvent();
            }

            // Assert
            Assert.AreEqual(clock.AlarmState, expectedAlarmState);
            */
        }

    }
}
