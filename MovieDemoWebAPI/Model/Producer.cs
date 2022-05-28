using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDemoWebAPI.Model
{
    public class Producer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProducerId { get; set; }

        [Required]
        public string ProducerName { get; set; }

        public string Bio { get; set; }

        public string Company { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<Movie>? Movie { get; set; }
    }
}
