using LocationFromGoogle.Classes;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;
using System;
using System.Diagnostics;

namespace LocationFromGoogle
{
    internal class DeSerializer
    {
        private static List<string> fileNames = new();
        private static Queue<string> folders = new();
        private static List<TimelineObject>? FullTimeLineObjectsList = new();

        public static List<TimelineObject> Process(string selection)
        {

            if (File.Exists(selection))
            {
                ProcessFile(selection);
            }
            else if (Directory.Exists(selection))
            {
                ProcessDirectory(selection);

                // Process al Files found in all directories found
                List<TimelineObject>? tlol = new();
                foreach (string filePath in fileNames)
                {
                    tlol = null;
                    tlol = GetDataListFromJsonFile(filePath);

                    foreach (var item in tlol)
                    {
                        FullTimeLineObjectsList.Add(item);
                    }

                }
            }
            //else
            //{
            //    MessageBox.Show("{0} is not a valid file or directory.", selection);
            //}
            return FullTimeLineObjectsList;
        }

        private static void ProcessDirectory(string targetDirectory)
        {
            // Add all Filepaths to files List found in this directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string file in fileEntries)
                fileNames.Add(file);

            // Recurse into all subdirectories process them.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                folders.Enqueue(subdirectory);
            while (folders.Count > 0)
            {
                ProcessDirectory(folders.Dequeue());
            }
        }

        private static void ProcessFile(string path)
        {
            Debug.WriteLine("Processed file '{0}'.", path);
        }


        // Deserializer
        internal static List<TimelineObject> GetDataListFromJsonFile(string filePath)
        {
            string jsonString = ReadJsonFile(filePath); // From JSON Raw Data to JSON String
            TimelineObjectCollection tloc = DeSerializeJsonString(jsonString); // From JSON string to Object List
            List<TimelineObject> tlol = CombineActivitySegmentAndPlaceVisitToTimeLineObject(tloc); // From unsorted Collection to List

            return tlol;
        }

        /// <summary>
        /// Reads JSON File and removes \n
        /// </summary>
        /// <param name="fp">Path of the File read</param>
        /// <returns>String with JSON RAW Data</returns>
        private static string ReadJsonFile(string fp)
        {
            string s = File.ReadAllText(fp);

            s = s.Replace("\n", "");

            return s;
        }

        /// <summary>
        /// Reads the RAW Data from an JSON String and makes Objects out of it
        /// </summary>
        /// <param name="s">String with JSON RAW Data</param>
        /// <returns>Collection of TimeLineObjects</returns>
        private static TimelineObjectCollection DeSerializeJsonString(string s)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                ObjectCreationHandling = ObjectCreationHandling.Reuse
            };

            var tempList = JsonConvert.DeserializeObject<TimelineObjectCollection>(s, settings);

            return tempList;
        }

        /// <summary>
        /// Reads Collection of RAW TimeLineObjects and combines them to full TimeLineObjects
        /// </summary>
        /// <param name="tloc">Collection of TimeLineObjects from JSON</param>
        /// <returns>List of TimeLineObjects</returns>
        private static List<TimelineObject> CombineActivitySegmentAndPlaceVisitToTimeLineObject(TimelineObjectCollection tloc)
        {
            List<TimelineObject>? tlol = new();
            if (tloc != null)
            {
                for (int i = 1; i < tloc.TimelineObjects.Count; i++)
                {
                    if (tloc.TimelineObjects[i - 1].ActivitySegment != null)
                    {
                        if (tloc.TimelineObjects[i].ActivitySegment == null)
                        {
                            tloc.TimelineObjects[i - 1].PlaceVisit = tloc.TimelineObjects[i].PlaceVisit;
                        }
                        tlol.Add(tloc.TimelineObjects[i - 1]);
                    }
                }
            }
            return tlol;
        }
    }
}
