using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicianBandsApp.Models
{
    /// <summary>
    /// Группа.
    /// </summary>
    public class Band
    {
        /// <summary>
        /// Id группы.
        /// </summary>
        [Required]
        public int BandId { get; set; }
        /// <summary>
        /// Название группы.
        /// </summary>
        [Display(Name = "Название группы")]
        public string BandName { get; set; }
        /// <summary>
        /// Дата создания группы.
        /// </summary>
        [Display(Name = "Дата создания группы")]
        public int BandDateOfCreation { get; set; }
        /// <summary>
        /// Страна группы.
        /// </summary>
        [Display(Name = "Страна группы")]
        public string BandCountry { get; set; }
        /// <summary>
        /// Жанр группы.
        /// </summary>
        [Display(Name = "Жанр группы")]
        public string BandGenre { get; set; }
        /// <summary>
        /// Фотография группы.
        /// </summary>
        [Display(Name = "Фотография группы")]
        public string BandImage { get; set; }
        /// <summary>
        /// Музыканты в группе.
        /// </summary>
        [Display(Name = "Музыканты в группе")]
        public ICollection<Musician> Musicians { get; set; }
        public Band()
        {
            Musicians = new List<Musician>();
        }
    }
}