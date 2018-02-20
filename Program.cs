using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using ConferenceTrackManagement.Controller;

namespace ConferenceTrackManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string WorkingDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);//fetch the directory of the DLL

                string InputFileNamePath= WorkingDir + "/Input.txt";

                string OutputFileNamePath= WorkingDir + "/Output.txt"; 
                int NumberOfTracks=2;
               
                SchedulerController SchedulerController = new SchedulerController(
                    InputFileNamePath, OutputFileNamePath, NumberOfTracks
                    );

                SchedulerController.Run();
                Console.WriteLine("Output available at " + OutputFileNamePath);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

       


    }
}
