using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDemoWebAPI.Model
{
    public class Actor
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }

        [Required]
        public string ActorName { get; set; }

        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public ICollection<Movie>? Movies { get; set; }
    }
}
