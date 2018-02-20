using ConferenceTrackManagement.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConferenceTrackManagement.OutputWriter
{
   public class OutputToTextFile
    {
        public static void Write(List<ConferenceTrack> _conferenceTrack,string OutputPathWithFileName)
        {
            using (FileStream fs = File.OpenWrite((OutputPathWithFileName)))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("Conference Track Program:");
                fs.Write(info, 0, info.Length);
                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fs.Write(newline, 0, newline.Length);
                foreach (ConferenceTrack CT in _conferenceTrack)
                {
                    var currentTime = new TimeSpan(9, 0, 0);
                    //trackNumber
                    info = new UTF8Encoding(true).GetBytes("Track " + CT.TrackNumber.ToString() + ":");
                    fs.Write(info, 0, info.Length);
                    fs.Write(newline, 0, newline.Length);

                    //calculate the time ->//morning
                    TimeSpan resultTimeMorning = TimeSpan.FromHours(9);
                    resultTimeMorning = TimeSpan.FromMinutes(resultTimeMorning.TotalMinutes);
                    string fromTimeStringM = resultTimeMorning.ToString("hh':'mm");
                    //evening
                    TimeSpan resultTimeEvening = TimeSpan.FromHours(1);
                    resultTimeEvening = TimeSpan.FromMinutes(resultTimeEvening.TotalMinutes);
                    string fromTimeStringE = resultTimeEvening.ToString("hh':'mm");
                    //<- time calculation ends here

                    info = new UTF8Encoding(true).GetBytes("Morning Session:");
                    fs.Write(info, 0, info.Length);
                    fs.Write(newline, 0, newline.Length);
                    for (int i = 0; i < CT.MorningSession.SessionTalks.Count; i++)
                    {


                        fromTimeStringM = resultTimeMorning.ToString("hh':'mm");
                        info = new UTF8Encoding(true).GetBytes(fromTimeStringM + "AM " + CT.MorningSession.SessionTalks[i].Topic);
                        fs.Write(info, 0, info.Length);
                        fs.Write(newline, 0, newline.Length);

                        int time = CT.MorningSession.SessionTalks[i].Duration;
                        resultTimeMorning = TimeSpan.FromMinutes(resultTimeMorning.TotalMinutes + time);

                    }

                    info = new UTF8Encoding(true).GetBytes("12:00PM Lunch");
                    fs.Write(info, 0, info.Length);
                    fs.Write(newline, 0, newline.Length);

                    info = new UTF8Encoding(true).GetBytes("Evening Session:");
                    fs.Write(info, 0, info.Length);
                    fs.Write(newline, 0, newline.Length);
                    for (int i = 0; i < CT.EveningSession.SessionTalks.Count; i++)
                    {


                        fromTimeStringE = resultTimeEvening.ToString("hh':'mm");
                        info = new UTF8Encoding(true).GetBytes(fromTimeStringE + "PM " + CT.EveningSession.SessionTalks[i].Topic);
                        fs.Write(info, 0, info.Length);
                        fs.Write(newline, 0, newline.Length);

                        int time = CT.EveningSession.SessionTalks[i].Duration;
                        resultTimeEvening = TimeSpan.FromMinutes(resultTimeEvening.TotalMinutes + time);

                    }

                    //networking event
                    if (resultTimeEvening < TimeSpan.FromHours(4))
                        resultTimeEvening = TimeSpan.FromHours(4);
                    if (resultTimeEvening > TimeSpan.FromHours(5))
                        resultTimeEvening = TimeSpan.FromHours(5);
                    fromTimeStringE = resultTimeEvening.ToString("hh':'mm");
                    info = new UTF8Encoding(true).GetBytes(fromTimeStringE + "PM Networking Event");
                    fs.Write(info, 0, info.Length);
                    fs.Write(newline, 0, newline.Length);

                }

            }
        }

    }
}
