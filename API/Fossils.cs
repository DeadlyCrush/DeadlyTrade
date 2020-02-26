using System;
using System.Collections.Generic;

namespace Ninja_Price.API.PoeNinja.Classes
{
    public class Fossils
    {
        public enum ItemType
        {
            Unknown
        }

        public class RootObject
        {
            public List<Line> Lines { get; set; }
        }

        public class Line
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public Uri Icon { get; set; }
            public long MapTier { get; set; }
            public long LevelRequired { get; set; }
            public object BaseType { get; set; }
            public long StackSize { get; set; }
            public object Variant { get; set; }
            public object ProphecyText { get; set; }
            public object ArtFilename { get; set; }
            public long Links { get; set; }
            public long ItemClass { get; set; }
            public Sparkline Sparkline { get; set; }
            public Sparkline LowConfidenceSparkline { get; set; }
            public List<object> ImplicitModifiers { get; set; }
            public List<ExplicitModifier> ExplicitModifiers { get; set; }
            public string FlavourText { get; set; }
            public bool Corrupted { get; set; }
            public long GemLevel { get; set; }
            public long GemQuality { get; set; }
            public ItemType ItemType { get; set; }
            public double ChaosValue { get; set; }
            public double ExaltedValue { get; set; }
            public long Count { get; set; }
            public string DetailsId { get; set; }
        }

        public class ExplicitModifier
        {
            public string Text { get; set; }
            public bool Optional { get; set; }
        }

        public class Sparkline
        {
            public List<double?> Data { get; set; }
            public double TotalChange { get; set; }
        }
    }
}