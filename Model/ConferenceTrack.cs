using System;
using System.Collections.Generic;
using System.Text;
using ConferenceTrackManagement.Model.Sessions;
namespace ConferenceTrackManagement.Model
{
    public class ConferenceTrack
    {   public int TrackNumber;
        public TrackSession MorningSession;
        public NonTrackSession Lunch;
        public TrackSession EveningSession;
        public NonTrackSession NetworkingEvent;
        public int TimeSaved;
        public ConferenceTrack(int trackNumber){
            TrackNumber = trackNumber;
            MorningSession = new TrackSession("MorningSession", 3);
            Lunch = new NonTrackSession("Lunch",1);
            EveningSession = new TrackSession("EveningSession", 4);
            NetworkingEvent = new NonTrackSession("NetworkingEvent",1);
            TimeSaved = 0;
        }
    }
}
