using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConferenceTrackManagement.InputReader
{
    public class InputFromFile
    {
        public static string[] Read(string InputFileNamePath)
        {
            
            string[] _readlines = null;
  
            try
            {
                _readlines = System.IO.File.ReadAllLines(@"" + InputFileNamePath); 
            }
            catch (FileNotFoundException fbf) {
                throw new Exception(InputFileNamePath+" with proposal list is not available!");
                
            }catch (Exception ex)
            {
                throw ex;
            }
            
            return _readlines;
        }
    }
}
