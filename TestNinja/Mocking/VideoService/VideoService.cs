using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;

        public VideoService(IFileReader fileReader = null)
           => _fileReader = fileReader ?? new FileReader();


        public string ReadVideoTitle()
        {
            string str = _fileReader.Read("video.txt");
            Video video = JsonConvert.DeserializeObject<Video>(str);

            if (video == null)
            {
                string message = "Error parsing the video.";

                return message;
            }

            return video.Title;
        }


        public string GetUnprocessedVideosAsCsv()
        {
            List<int> videoIds = new List<int>();

            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                foreach (Video v in videos)
                {
                    videoIds.Add(v.Id);
                }

                return string.Join(",", videoIds);
            }
        }
    }
}