using System;
using System.Collections.Generic;

namespace TPMMobileApi.Utility
{
    public static class FxUtil
    {
        public const string buy = "buy";
        public const string sell = "sell";
        public const string cross = "cross";
        public const string CbsConnectionErrorrMsg = "Connection to Core Banking System could not be established. Please contact System Administrator";
        public static List<string> dealTypes = new List<string>() { buy, sell, cross };
        public static decimal RoundDecimal(decimal? value, int decimalPlace)
        {
            return Math.Round(value.GetValueOrDefault(), decimalPlace);
        }

        public static string TrimField(string value)
        {
            return !string.IsNullOrEmpty(value) ? value.Trim() : value;
        }
    }
}