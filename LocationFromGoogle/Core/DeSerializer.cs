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
        //internal static readonly string selection = @".\LocationHistory";
        private static List<string> fileNames = new();
        private static Queue<string> folders = new();

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
                foreach (string filePath in fileNames)
                    timeLineObjCollectionList = GetDataListFromJsonFile(filePath);

                
            }
            //else
            //{
            //    MessageBox.Show("{0} is not a valid file or directory.", selection);
            //}
            return timeLineObjCollectionList;
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

        //internal static readonly string filePath = @".\LocationHistory\2016\2016_AUGUST.json";
        private static string? jsonString;
        private static TimelineObjectCollection? timeLineObjCollection;
        private static List<TimelineObject>? timeLineObjCollectionList;

        //static TSToDTDelegate toDT = Duration.UnixTimeStampToDateTime;

        internal static List<TimelineObject> GetDataListFromJsonFile(string filePath)
        {
            jsonString = ReadJsonFile(filePath);
            timeLineObjCollection = DeSerializeJsonString(jsonString);
            timeLineObjCollectionList = CombineActivitySegmentAndPlaceVisitToTimeLineObject(timeLineObjCollection);

            return timeLineObjCollectionList;
        }

        private static string ReadJsonFile(string fp)
        {
            string s = File.ReadAllText(fp);

            s = s.Replace("\n", "");

            return s;
        }

        private static TimelineObjectCollection DeSerializeJsonString(string s)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                ObjectCreationHandling = ObjectCreationHandling.Reuse
            };

            TimelineObjectCollection? tloc = JsonConvert.DeserializeObject<TimelineObjectCollection>(s, settings);

            return tloc;
        }

        private static List<TimelineObject> CombineActivitySegmentAndPlaceVisitToTimeLineObject(TimelineObjectCollection tloc)
        {
            List<TimelineObject>? tlol = new();
            if (timeLineObjCollection != null)
            {
                for (int i = 1; i < timeLineObjCollection.TimelineObjects.Count; i++)
                {
                    if (timeLineObjCollection.TimelineObjects[i-1].ActivitySegment != null)
                    {
                        if (timeLineObjCollection.TimelineObjects[i].ActivitySegment == null)
                        {
                            timeLineObjCollection.TimelineObjects[i-1].PlaceVisit = timeLineObjCollection.TimelineObjects[i].PlaceVisit;
                        }
                        tlol.Add(timeLineObjCollection.TimelineObjects[i-1]);
                    }
                }
            }
            return tlol;
        }

        //public static TimelineObject GenerateTimeLineObject()
        //{

        //    #region Activity Segment
        //    List<Waypoint> wpList = new List<Waypoint>()
        //{
        //    new Waypoint() { latE7 = 495327186, lngE7 = 110194549 },
        //    new Waypoint() { latE7 = 494657974, lngE7 = 110705738 }
        //};

        //    WaypointPath wpPath = new WaypointPath() { waypoints = wpList };

        //    List<Activity> actList = new List<Activity>()
        //{
        //    new Activity() {activityType = activityType.IN_PASSENGER_VEHICLE.ToString(), probability = 0.0 },
        //    new Activity() {activityType = activityType.IN_VEHICLE.ToString(), probability = 0.0 },
        //    new Activity() {activityType = activityType.CYCLING.ToString(), probability = 0.0 }
        //};

        //    Duration duraActSeg = new Duration() { startTimestampMs = toDT(1470049187672), endTimestampMs = toDT(1470049964000) };

        //    EndLocation endLoc = new EndLocation() { latitudeE7 = 494658334, longitudeE7 = 110705606 };

        //    StartLocation startLoc = new StartLocation() { latitudeE7 = 495326933, longitudeE7 = 110193657 };

        //    ActivitySegment actSegm = new ActivitySegment()
        //    {
        //        startLocation = startLoc,
        //        endLocation = endLoc,
        //        duration = duraActSeg,
        //        distance = 9085,
        //        confidence = confidence.MEDIUM.ToString(),
        //        activities = actList,
        //        waypointPath = wpPath,
        //        editConfirmationStatus = editConfirmationStatus.NOT_CONFIRMED.ToString()
        //    };
        //    #endregion

        //    #region  Place Visit
        //    SourceInfo si = new SourceInfo() { deviceTag = 440714938 };

        //    Location loc = new Location()
        //    {
        //        latitudeE7 = 494657786,
        //        longitudeE7 = 110699426,
        //        placeId = "ChIJD1x5PLVXn0cREUcPwiz8PMc",
        //        address = "Juvenellstraße 16\n90408 Nürnberg\nDeutschland",
        //        name = "Physiotherapie Nord",
        //        sourceInfo = si,
        //        locationConfidence = 89.90597
        //    };

        //    Duration duraPlaceVisit = new Duration() { startTimestampMs = toDT(1470049964000), endTimestampMs = toDT(1470054814000) };

        //    List<OtherCandidateLocation> othCandLocList = new List<OtherCandidateLocation>()
        //    {
        //        new OtherCandidateLocation() { latitudeE7 =494731430, longitudeE7=110733900, placeId="ChIJpxrmqEpWn0cRk-DB4Z8VXzE", name="Johanniter International Assistance e.V., Regional Association of Middle Franconia", locationConfidence=0.9110114},
        //        new OtherCandidateLocation() { latitudeE7 =494661232, longitudeE7=110696077, placeId="ChIJG8wnOLVXn0cRXjKgubIaKcM", name="EDEKA Gass", locationConfidence=0.8925801},
        //        new OtherCandidateLocation() { latitudeE7 =494659677, longitudeE7=110697008, placeId="ChIJSaygObVXn0cREsnmuyxFAZI", name="Rossmann Drogeriemarkt", locationConfidence=0.7153267},
        //        new OtherCandidateLocation() { latitudeE7 =494658198, longitudeE7=110697746, placeId="ChIJQZm_O7VXn0cR1-bTwoT0Oic", name="Barthelmess-Mösler Sabina Dr.med.", locationConfidence=0.5491459},
        //        new OtherCandidateLocation() { latitudeE7 =494659634, longitudeE7=110693866, placeId="ChIJmzX-ObVXn0cRIhtp93rF0M0", name="Juvenellstr.", locationConfidence=0.54425377},
        //        new OtherCandidateLocation() { latitudeE7 =494658029, longitudeE7=110701123, placeId="ChIJpx7BYm6fDEER2HSFM2RI_o0", name="Ilhami Ayaz", locationConfidence=0.39114636},
        //        new OtherCandidateLocation() { latitudeE7 =494657146, longitudeE7=110691866, placeId="ChIJ2VDwL7VXn0cRsBZUXBlO7Vs", name="Doro-Thea", locationConfidence=0.36454007},
        //        new OtherCandidateLocation() { latitudeE7 =494658610, longitudeE7=110697310, placeId="ChIJQZm_O7VXn0cRksL8wZeoZ60", locationConfidence=0.34425837},
        //        new OtherCandidateLocation() { latitudeE7 =494654105, longitudeE7=110699799, placeId="ChIJMSjPfm6fDEERZ4_EqlDh5kg", name="Tele-Internet-Café", locationConfidence=0.2825305}
        //    };

        //    PlaceVisit plaVis = new PlaceVisit()
        //    {
        //        location = loc,
        //        duration = duraPlaceVisit,
        //        placeConfidence = placeConfidence.HIGH_CONFIDENCE.ToString(),
        //        centerLatE7 = 494658313,
        //        centerLngE7 = 110699093,
        //        visitConfidence = 73,
        //        otherCandidateLocations = othCandLocList,
        //        editConfirmationStatus = editConfirmationStatus.NOT_CONFIRMED.ToString()
        //    };
        //    #endregion

        //    #region timeline Object
        //    TimelineObject tlo = new TimelineObject() { activitySegment = actSegm, placeVisit = plaVis };
        //    #endregion

        //    return tlo;
        //}
    }
}
