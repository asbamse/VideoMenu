using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu
{
    /**
     * <summary>
     * Business Entity descriping a Genre.
     * </summary>
     **/
    class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /**
         * <summary>
         * Force information on creation.
         * </summary>
         **/
        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
