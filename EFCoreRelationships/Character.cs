﻿using System.Text.Json.Serialization;

namespace EFCoreRelationships
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        [JsonIgnore]
        public User User { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public Weapon Weapon { get; set; }
        [JsonIgnore]
        public List<Skill> Skills { get; set; }
    }
}
