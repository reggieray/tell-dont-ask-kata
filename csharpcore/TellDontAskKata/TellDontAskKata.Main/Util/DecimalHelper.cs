namespace TellDontAskKata.Main.Util
{
    public static class DecimalHelper
    {
        public static decimal Round(decimal amount) => decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
    }
}
