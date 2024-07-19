using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using civilizaciones;

namespace unidadUnica
{
    public class Cost
    {
        [JsonPropertyName("Food")]
        public int Food { get; set; }

        [JsonPropertyName("Gold")]
        public int Gold { get; set; }
    }

    public class unidadUnica
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("expansion")]
        public string Expansion { get; set; }

        [JsonPropertyName("age")]
        public string Age { get; set; }

        [JsonPropertyName("created_in")]
        public string CreatedIn { get; set; }

        [JsonPropertyName("cost")]
        public Cost Cost { get; set; }

        [JsonPropertyName("build_time")]
        public int BuildTime { get; set; }

        [JsonPropertyName("reload_time")]
        public double ReloadTime { get; set; }

        [JsonPropertyName("attack_delay")]
        public double AttackDelay { get; set; }

        [JsonPropertyName("movement_rate")]
        public double MovementRate { get; set; }

        [JsonPropertyName("line_of_sight")]
        public int LineOfSight { get; set; }

        [JsonPropertyName("hit_points")]
        public int HitPoints { get; set; }

        [JsonPropertyName("range")]
        public int Range { get; set; }

        [JsonPropertyName("attack")]
        public int Attack { get; set; }

        [JsonPropertyName("armor")]
        public string Armor { get; set; }

        [JsonPropertyName("attack_bonus")]
        public List<string> AttackBonus { get; set; }
    }
}