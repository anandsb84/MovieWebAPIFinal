using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDemoWebAPI.Model
{
    public class Movie
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
        public string MovieName { get; set; }

        public string Plot { get; set; }
        public DateTime DateOfRelease { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Producer? Producer { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public ICollection<Actor>? Actor { get; set; }
    }
}
