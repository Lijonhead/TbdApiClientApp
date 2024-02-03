using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbdApiConsoleApp.ViewModels
{
    internal class GenreViewModel
    {
        public int genreId { get; set; }
        public string title { get; set; }



        public List<GenreViewModel> genres { get; set; }
    }
}
