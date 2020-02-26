using System.Collections.Generic;

namespace Ninja_Price.API.PoeNinja.Classes
{
    public class Currency
    {
        public class Pay
        {
            public int    Id             { get; set; }
            public int    LeagueId       { get; set; }
            public int    PayCurrencyId  { get; set; }
            public int    GetCurrencyId  { get; set; }
            public string SampleTimeUtc  { get; set; }
            public int    Count          { get; set; }
            public double Value          { get; set; }
            public int    DataPointCount { get; set; }
        }

        public class Receive
        {
            public int    Id             { get; set; }
            public int    LeagueId       { get; set; }
            public int    PayCurrencyId  { get; set; }
            public int    GetCurrencyId  { get; set; }
            public string SampleTimeUtc  { get; set; }
            public int    Count          { get; set; }
            public double Value          { get; set; }
            public int    DataPointCount { get; set; }
        }

        public class PaySparkLine
        {
            public List<object> Data        { get; set; }
            public double       TotalChange { get; set; }
        }

        public class ReceiveSparkLine
        {
            public List<object> Data        { get; set; }
            public double       TotalChange { get; set; }
        }

        public class Line
        {
            public string           CurrencyTypeName { get; set; }
            public Pay              Pay              { get; set; }
            public Receive          Receive          { get; set; }
            public PaySparkLine     PaySparkLine     { get; set; }
            public ReceiveSparkLine ReceiveSparkLine { get; set; }
            public double           ChaosEquivalent  { get; set; }
        }

        public class CurrencyDetail
        {
            public int          Id         { get; set; }
            public string       Name       { get; set; }
            public int          PoeTradeId { get; set; }
            public List<string> Shorthands { get; set; }
            public string       Icon       { get; set; }
            public int          Type       { get; set; }
        }

        public class RootObject
        {
            public List<Line>           Lines           { get; set; }
            public List<CurrencyDetail> CurrencyDetails { get; set; }
        }
    }
}