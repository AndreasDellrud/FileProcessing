namespace FileProcessing.Entities
{
    public class InputData
    {
        public InputData(string account, string amount, string date, string bank)
        {
            Account = account;
            Amount = amount;
            Date = date;
            Bank = bank;
        }

        public string Account { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string Bank { get; set; }
    }
}
