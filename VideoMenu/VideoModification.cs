using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu
{
    class VideoModification
    {
        private VideoDAO vdao = new VideoDAO();
        private int nextId;

        public VideoModification()
        {
            nextId = 1;
        }

        /**
         * <summary>
         * Adds video to data.
         * </summary>
         **/
        public bool addVideo(String name)
        {
            vdao.addVideo(new Video(nextId, name));
            nextId++;
            return true;
        }

        /**
         * <summary>
         * Gets the data of videos.
         * </summary>
         **/
        public List<Video> getVideos()
        {
            return vdao.getVideos();
        }

        /**
         * <summary>
         * Updates a video already existing in the data.
         * </summary>
         **/
        public bool updateVideo(int id, string name)
        {
            List<Video> videos = getVideos();
            for (int i = 0; i < videos.Count; i++)
            {
                if (videos[i].Id == id)
                {
                    vdao.updateVideo(i, new Video(id, name));
                    return true;
                }
            }
            return false;
        }

        /**
         * <summary>
         * Deletes a specific video from data.
         * </summary>
         **/
        public bool deleteVideo(int id)
        {
            List<Video> videos = getVideos();
            for (int i = 0; i < videos.Count; i++)
            {
                if (videos[i].Id == id)
                {
                    vdao.deleteVideo(videos[i]);
                    return true;
                }
            }
            return false;
        }

        /**
         * <summary>
         * Search for video with name containing keyword.
         * </summary>
         **/
        public List<Video> searchVideo(string keyword)
        {
            List<Video> videos = getVideos();
            List<Video> foundVideos = new List<Video>();
            for (int i = 0; i < videos.Count; i++)
            {
                if (videos[i].Name.Contains(keyword))
                {
                    foundVideos.Add(videos[i]);
                }
            }

            return foundVideos;
        }
    }
}
