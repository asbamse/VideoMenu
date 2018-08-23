using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu
{
    /**
     * <summary>
     * Business Entity descriping a Video.
     * </summary>
     **/
    class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /**
         * <summary>
         * Force information on creation.
         * </summary>
         **/
        public Video(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
