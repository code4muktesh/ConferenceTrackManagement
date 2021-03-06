﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceTrackManagement.Model.Sessions
{
    public class TrackSession
    {
        public string Name;
        public TimeSpan Duration;
        public List<Talk> SessionTalks;

        public TrackSession(string name, int Hours)
        {
            Name = name;
            Duration = new TimeSpan(Hours, 0, 0);
            SessionTalks = new List<Talk>();
        }
    }
}
