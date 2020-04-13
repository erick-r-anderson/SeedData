using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeedData.Data
{
    public partial class Seed
    {
        public int SeedId { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public byte? Prairie { get; set; }
        public byte? Savanna { get; set; }
        public byte? Woodland { get; set; }
        public byte? Dry { get; set; }
        public byte? Drymesic { get; set; }
        public byte? Mesic { get; set; }
        public byte? Wetmesic { get; set; }
        public byte? Wet { get; set; }
        public int? Color1Id { get; set; }
        public int? StartMonthId { get; set; }
        public int? EndMonthId { get; set; }
        public int? BloomMonthId { get; set; }
        public int? Color2Id { get; set; }
        public int? Color3Id { get; set; }
        public int? BloomMonthEndId { get; set; }

        public Month BloomMonth { get; set; }
        public Month BloomMonthEnd { get; set; }
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color Color3 { get; set; }
        public Month EndMonth { get; set; }
        public Month StartMonth { get; set; }

        [NotMapped]
        public String SunExposure { get; set; }
        [NotMapped]
        public String Moisture { get; set; }

        [NotMapped]
        public bool DisplayPrairie
        {
            get { return Convert.ToBoolean(this.Prairie); }
            set { this.Prairie = Convert.ToByte(value); }
        }

        [NotMapped]
        public bool DisplaySavanna
        {
            get { return Convert.ToBoolean(this.Savanna); }
            set { this.Savanna = Convert.ToByte(value); }
        }

        [NotMapped]
        public bool DisplayWoodland
        {
            get { return Convert.ToBoolean(this.Woodland); }
            set { this.Woodland = Convert.ToByte(value); }
        }

        [NotMapped]
        public bool DisplayDry
        {
            get { return Convert.ToBoolean(this.Dry); }
            set { this.Dry = Convert.ToByte(value); }
        }

        [NotMapped]
        public bool DisplayDryMesic
        {
            get { return Convert.ToBoolean(this.Drymesic); }
            set { this.Drymesic = Convert.ToByte(value); }
        }

        [NotMapped]
        public bool DisplayMesic
        {
            get { return Convert.ToBoolean(this.Mesic); }
            set { this.Mesic = Convert.ToByte(value); }
        }

        [NotMapped]
        public bool DisplayWetMesic
        {
            get { return Convert.ToBoolean(this.Wetmesic); }
            set { this.Wetmesic = Convert.ToByte(value); }
        }

        [NotMapped]
        public bool DisplayWet
        {
            get { return Convert.ToBoolean(this.Wet); }
            set { this.Wet = Convert.ToByte(value); }
        }

        public void SetProperties()
        {
            var sunExposures = SunExposure.Split(',');
            var moistures = Moisture.Split(',');

            foreach (string s in sunExposures)
            {
                if (s == "P")
                    this.Prairie = 1;
                if (s == "S")
                    this.Savanna = 1;
                if (s == "W")
                    this.Woodland = 1;
            }

            foreach (string s in moistures)
            {
                if (s == "D")
                    this.Drymesic = 1;
                if (s == "DM")
                    this.Drymesic = 1;
                if (s == "M")
                    this.Mesic = 1;
                if (s == "WM")
                    this.Wetmesic = 1;
                if (s == "W")
                    this.Wet = 1;
            }
        }
    }
}
