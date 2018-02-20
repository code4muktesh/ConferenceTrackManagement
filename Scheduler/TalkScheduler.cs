using ConferenceTrackManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceTrackManagement.Scheduler
{
    public class TalkScheduler
    {
        public static void Schedule(List<Talk> _talkList, List<ConferenceTrack> _conferenceTrack)//method to schedule the final program
        {
            foreach (ConferenceTrack CT in _conferenceTrack)
            {
                bool MorningSessionFull = false;
                bool EveningSessionFull = false;

                //morning session -->
                TimeSpan morningTS = CT.MorningSession.Duration;
                double tempTime = morningTS.TotalMinutes;
                for (int i = _talkList.Count - 1; i >= 0; i--)
                {
                    //for morning Session -->
                    if ((tempTime >= double.Parse(_talkList[i].Duration.ToString())) && (!MorningSessionFull))
                    {
                        CT.MorningSession.SessionTalks.Add(_talkList[i]);
                        tempTime = tempTime - double.Parse(_talkList[i].Duration.ToString());
                        _talkList.RemoveAt(i);
                        if (tempTime == 0)
                        {
                            MorningSessionFull = true;
                        }
                    }
                }

                CT.TimeSaved += int.Parse(tempTime.ToString());//total time saved in the morning session only

                //evening session -->
                TimeSpan eveningTS = CT.EveningSession.Duration;
                tempTime = eveningTS.TotalMinutes;
                for (int i = _talkList.Count - 1; i >= 0; i--)
                {
                    //for evening session -->
                    if (MorningSessionFull)
                    {
                        if ((tempTime >= double.Parse(_talkList[i].Duration.ToString())) && (!EveningSessionFull))
                        {
                            CT.EveningSession.SessionTalks.Add(_talkList[i]);
                            tempTime = tempTime - double.Parse(_talkList[i].Duration.ToString());
                            _talkList.RemoveAt(i);
                            if (tempTime == 0)
                            {
                                EveningSessionFull = true;
                            }
                        }
                    }
                }

                CT.TimeSaved += int.Parse(tempTime.ToString());//total time saved in the whole track

            }
        }
    }
}
