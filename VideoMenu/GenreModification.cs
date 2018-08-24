using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu
{
    class GenreModification
    {
        private GenreDAO gdao = new GenreDAO();
        private int nextId;

        public GenreModification()
        {
            nextId = 1;
        }

        /**
         * <summary>
         * Adds genre to data.
         * </summary>
         **/
        public bool addGenre(String name)
        {
            gdao.addGenre(new Genre(nextId, name));
            nextId++;
            return true;
        }

        /**
         * <summary>
         * Gets the data of genres.
         * </summary>
         **/
        public List<Genre> getGenres()
        {
            return gdao.getGenres();
        }

        /**
         * <summary>
         * Updates a genre already existing in the data.
         * </summary>
         **/
        public bool updateGenre(int id, string name)
        {
            List<Genre> genres = getGenres();
            for (int i = 0; i < genres.Count; i++)
            {
                if (genres[i].Id == id)
                {
                    gdao.updateGenre(i, new Genre(id, name));
                    return true;
                }
            }
            return false;
        }

        /**
         * <summary>
         * Deletes a specific genre from data.
         * </summary>
         **/
        public bool deleteGenre(int id)
        {
            List<Genre> genres = getGenres();
            for (int i = 0; i < genres.Count; i++)
            {
                if (genres[i].Id == id)
                {
                    gdao.deleteGenre(genres[i]);
                    return true;
                }
            }
            return false;
        }

        /**
         * <summary>
         * Search for genre with name containing keyword.
         * </summary>
         **/
        public List<Genre> searchGenre(string keyword)
        {
            List<Genre> genres = getGenres();
            List<Genre> foundGenres = new List<Genre>();
            for (int i = 0; i < genres.Count; i++)
            {
                if (genres[i].Name.Contains(keyword))
                {
                    foundGenres.Add(genres[i]);
                }
            }

            return foundGenres;
        }
    }
}
