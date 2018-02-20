using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConferenceTrackManagement.Model;
namespace ConferenceTrackManagement.Parser
{
   public class InputParser
    {
        public static Talk Parse(string _topicTitle)
        {
            Talk RtnVal = new Talk();
            
            //fecth the duration and talk title-->
            string tempDuration = Regex.Match(_topicTitle, @"\d+").Value;
            if (tempDuration != "")
            {
                string tempNumber = Regex.Match(_topicTitle.Replace(tempDuration, ""), @"\d+").Value;
                if (tempNumber != "")
                    throw new Exception("Title Cannot contain two Numeric values "+ _topicTitle);
                if (tempDuration.Length > 2)
                    throw new Exception("Invalid Talk Duration" + _topicTitle);
                RtnVal.Topic = _topicTitle.Replace(tempDuration, "").Replace("min", "").Replace("MIN", "").Replace("Min", "").Replace("Programg", "Programming");
                RtnVal.Duration = int.Parse(tempDuration);
               
            }
            else
            {
                if ((_topicTitle.ToLower().Contains("lightning")))
                {
                    RtnVal.Topic = _topicTitle;
                    RtnVal.Duration = 5;
                }
                
            }
            if (RtnVal.Topic == null|| RtnVal.Topic.Trim()=="")
                throw new Exception("Title Cannot be empty");

            if (Regex.IsMatch(RtnVal.Topic, @"[0-9]+$"))
                throw new Exception("Title Cannot contain Numeric values"+ RtnVal.Topic);
            if ((RtnVal.Duration < 0) || (RtnVal.Duration > 60))
                throw new Exception("Invalid Talk Duration"+ RtnVal.Duration);
            return RtnVal;
        }
      
    }
}
