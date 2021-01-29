using FileProcessing.Entities;
using System;
using System.Collections.Generic;

namespace FileProcessing.Services
{
    public class DataFormattingService : IDataFormattingService
    {
        public List<InputData> GetInputDataFromFileData(string[] inputDataLines)
        {
            var inputData = new List<InputData>();

            for (int i = 0; i < inputDataLines.Length; i++)
            {
                var values = inputDataLines[i].Split(';');

                if (values[0] == "Konto")
                    continue;

                inputData.Add(new InputData(values[0], values[1], values[2], values[3]));
            }

            return inputData;
        }



        public TransferType GetTransferType(DateTime dateTime, string referenceTime)
        {
            var referenceDate = DateTime.Parse(referenceTime).Date;
            if (dateTime.Date < referenceDate)
            {
                return TransferType.OLD;
            }
            else if (dateTime.Date == referenceDate)
            {
                return TransferType.ACTIVE;
            }
            else
            {
                return TransferType.FUTURE;
            }
        }
    }
}
