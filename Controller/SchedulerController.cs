using ConferenceTrackManagement.InputReader;
using ConferenceTrackManagement.Model;
using ConferenceTrackManagement.OutputWriter;
using ConferenceTrackManagement.Parser;
using ConferenceTrackManagement.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConferenceTrackManagement.Controller
{
   public class SchedulerController
    {
      
        public string InputFileNamePath;
        
        public string OutputFileNamePath;
        public int NumberOfTracks;
        public SchedulerController(string InputFileNamePath, string OutputFileNamePath,int NumberOfTracks)
        {
            this.InputFileNamePath = InputFileNamePath;
            this.OutputFileNamePath = OutputFileNamePath;
            this.NumberOfTracks = NumberOfTracks;
        }
        public void Run()
        {
            
            string[] _readlines = InputFromFile.Read(InputFileNamePath);

            List<Talk> _talkList = CreateTalkList(_readlines);//create a sorted (ascending) list of all the Talks in it
            List<ConferenceTrack> _conferenceTrack = CreateTracks(this.NumberOfTracks);//create empty Conference Tracks based on input NumberOfTracks

            Scheduler(_talkList, _conferenceTrack);//schedule the final program by allocating talk based on the available timeslots
            WriteOutput(_conferenceTrack, OutputFileNamePath);//write the final program in ConferenceProgram.txt file
           
        }
        public static List<Talk> CreateTalkList(string[] _lines)//method to create a sorted chosen TalkList
        {
            List<Talk> SelectedTalks = new List<Talk>();
            foreach (string line in _lines)
            {
                SelectedTalks.Add(InputParser.Parse(line));
            }
            List<Talk> SortedTalkList = SelectedTalks.OrderBy(o => o.Duration).ToList();
            return SortedTalkList;
        }

        public static List<ConferenceTrack> CreateTracks(int NumberOfTracks)//method to create Conference Tracks
        {
            List<ConferenceTrack> CT = new List<ConferenceTrack>();
            ConferenceTrack TrackProgram;
            for (int i = 0; i < NumberOfTracks; i++)
            {
                TrackProgram = new ConferenceTrack(i + 1);
                CT.Add(TrackProgram);
            }
            return CT;
        }

        public static void Scheduler(List<Talk> _talkList, List<ConferenceTrack> _conferenceTrack)//method to schedule the final program
        {
            TalkScheduler.Schedule(_talkList, _conferenceTrack);
        }

        public static void WriteOutput(List<ConferenceTrack> _conferenceTrack,string OutputFileNamePath)//method to write the final program
        {
            OutputToTextFile.Write(_conferenceTrack, OutputFileNamePath);
        }
    }
}
