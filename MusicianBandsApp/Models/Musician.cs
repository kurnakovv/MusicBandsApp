using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicianBandsApp.Models
{
    /// <summary>
    /// Музыкант.
    /// </summary>
    public class Musician
    {
        /// <summary>
        /// Id музыканта.
        /// </summary>
        [Required]
        public int MusicianId { get; set; }
        /// <summary>
        /// Имя музыканта.
        /// </summary>
        [Display(Name = "Имя музыканта")]
        public string MusicianName { get; set; }
        /// <summary>
        /// День рождения музыканта.
        /// </summary>
        [Display(Name = "День рождения музыканта")]
        public int MusicianDateOfBirth { get; set; }
        /// <summary>
        /// Роль музыканта.
        /// </summary>
        [Display(Name = "Роль музыканта")]
        public string MusicianRole { get; set; }
        /// <summary>
        /// Фотография музыканта.
        /// </summary>
        [Display(Name = "Фотография музыканта")]
        public string MusicianImage { get; set; }
        /// <summary>
        /// Id группы музыканта.
        /// </summary>
        public int? BandId { get; set; }
        /// <summary>
        /// Группа музыканта.
        /// </summary>
        [Display(Name = "Группа музыканта")]
        public Band Band { get; set; }
    }
}