using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu
{
    /**
     * <summary>
     * Handler for data.
     * </summary>
     **/
    class VideoDAO
    {
        private List<Video> videos;

        /**
         * <summary>
         * Initialize fields.
         * </summary>
         **/
        public VideoDAO()
        {
            videos = new List<Video>();
        }

        /**
         * <summary>
         * Adds video to data.
         * </summary>
         **/
        public bool addVideo(Video video)
        {
            videos.Add(video);
            return true;
        }

        /**
         * <summary>
         * Gets the data of videos.
         * </summary>
         **/
        public List<Video> getVideos()
        {
            return videos;
        }

        /**
         * <summary>
         * Updates a video already existing in the data.
         * </summary>
         **/
        public bool updateVideo(int index, Video video)
        {
            videos[index] = video;
            return true;
        }
        
        /**
         * <summary>
         * Deletes a specific video from data.
         * </summary>
         **/
        public bool deleteVideo(Video video)
        {
            videos.Remove(video);
            return true;
        }
    }
}
