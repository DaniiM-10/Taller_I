using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tecUnica
{
    public class Cost
    {
        [JsonPropertyName("Food")]
        public int Food { get; set; }

        [JsonPropertyName("Gold")]
        public int Gold { get; set; }
    }

    public class tecUnica
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

        [JsonPropertyName("develops_in")]
        public string DevelopsIn { get; set; }

        [JsonPropertyName("cost")]
        public Cost Cost { get; set; }

        [JsonPropertyName("build_time")]
        public int BuildTime { get; set; }

        [JsonPropertyName("applies_to")]
        public List<string> AppliesTo { get; set; }
    }
}