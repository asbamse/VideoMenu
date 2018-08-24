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
    class GenreDAO
    {
        private List<Genre> genres;

        /**
         * <summary>
         * Initialize fields.
         * </summary>
         **/
        public GenreDAO()
        {
            genres = new List<Genre>();
        }

        /**
         * <summary>
         * Adds genre to data.
         * </summary>
         **/
        public bool addGenre(Genre genre)
        {
            genres.Add(genre);
            return true;
        }

        /**
         * <summary>
         * Gets the data of genres.
         * </summary>
         **/
        public List<Genre> getGenres()
        {
            return genres;
        }

        /**
         * <summary>
         * Updates a genre already existing in the data.
         * </summary>
         **/
        public bool updateGenre(int index, Genre genre)
        {
            genres[index] = genre;
            return true;
        }

        /**
         * <summary>
         * Deletes a specific genre from data.
         * </summary>
         **/
        public bool deleteGenre(Genre genre)
        {
            genres.Remove(genre);
            return true;
        }
    }
}
