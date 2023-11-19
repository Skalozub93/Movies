using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    internal class MovieLibrary
    {

        private bool _isTimeRestricted;

        private List<string> _ordinaryMovies = new List<string>()
        {
            "001 - Raiders of the Lost Arc ",
            "002 - Shrek",
            "003 - Toy Story",
            "004 - Cast Away",
            "005 - Harry Potter"
        };

        private List<string> _onlyAdultsMovies = new List<string>()
        {
            "006 - Alien",
            "007 - One Cut Of The Dead",
            "008 - King Kong",
            "009 - Halloween",
            "020 - The Invisible Man"
        };

        public MovieLibrary()
        {
            _isTimeRestricted = CheckingTimeRestriction();
        }

        public bool CheckingTimeRestriction()
        {
            DateTime currentTime = DateTime.Now;
            return currentTime.Hour >= 7 && currentTime.Hour <= 23;
        }

        public string this[int index]
        {
            get
            {
                if(_isTimeRestricted)
                {
                    if(index >= 0 && index < _onlyAdultsMovies.Count)
                    {
                        return _ordinaryMovies[index];
                    }
                }
                else
                {
                    return AdultsMovies[index];
                }
                return null;
            }
        }
        public string this[int index, string category]
        {
            get
            {
                List<string> selectedList = (category == "Adults") ? _onlyAdultsMovies : _ordinaryMovies;

                if (index >= 0 && index < selectedList.Count)
                {
                    string movieTitle = selectedList[index];
                    int defisIndex = movieTitle.IndexOf('-');

                    if (defisIndex >= 0 && defisIndex != -1)
                    {
                        return movieTitle.Substring(0, defisIndex).Trim();
                    }
                    else
                    {
                        return movieTitle.Trim();
                    }
                }

                return null;
            }
        }

        
        public string GetArticle(int index, string category)
        {
            try
            {
                return this[index, category];
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
                
            }
        }

        public string GetMovie(int movieNum)
        {
            return this[movieNum];
           
        }

        public bool TimeRestricted
        {
            get { return _isTimeRestricted; }
            set { _isTimeRestricted = value; }
        }

        public List<string> OrdinaryMovies
        {
            get { return _ordinaryMovies; }
            set { _ordinaryMovies = value; }
        }

        public List<string> AdultsMovies
        {
            get { return _onlyAdultsMovies; }
            set { _onlyAdultsMovies = value; }
        }
            


    }
}
