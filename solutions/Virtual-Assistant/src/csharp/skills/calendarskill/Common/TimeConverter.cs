﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarSkill.Common
{
    public static class TimeConverter
    {
        public static DateTime ConvertLuisLocalToUtc(DateTime time, TimeZoneInfo timeZone)
        {
            if (time.Kind != DateTimeKind.Local && time.Kind != DateTimeKind.Unspecified)
            {
                throw new Exception("Input time is not a Lius time.");
            }

            DateTime unspecified = DateTime.SpecifyKind(time, DateTimeKind.Unspecified);
            DateTime utc = TimeZoneInfo.ConvertTimeToUtc(unspecified, timeZone);
            return utc;
        }

        public static DateTime ConvertUtcToUserTime(DateTime time, TimeZoneInfo timeZone)
        {
            if (time.Kind != DateTimeKind.Utc)
            {
                throw new Exception("Input time is not a UTC time.");
            }

            DateTime userTime = TimeZoneInfo.ConvertTimeFromUtc(time, timeZone);
            return userTime;
        }
    }
}
