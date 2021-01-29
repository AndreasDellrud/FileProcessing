using System;

namespace FileProcessing.Entities
{
    public class Transfer
    {
        public DateTime Date { get; set; }
        public string Account { get; set; }
        public string Amount { get; set; }
        public TransferType Type { get; set; }
    }
}
