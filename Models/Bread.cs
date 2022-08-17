using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{

    // enumeration, enum
    public enum BreadType
    {
        Sourdough,      // 0
        Rye,            // 1
        MarbleRye,      // 2
        French,
        HoneyWheat,
    }

    public class Bread 
    {
        public int id {get; set;}
        public string name {get; set;}
        public string description {get; set;}

        // need a bread type
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BreadType type {get; set;}

        public int count {get; set;}

        // relation to Baker
        [ForeignKey("bakedBy")]
        public int bakedById {get; set;}

        // the actual Baker object from DB (Join)
        public Baker bakedBy {get; set;}
    }
}
