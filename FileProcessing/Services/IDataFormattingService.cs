using FileProcessing.Entities;
using System;
using System.Collections.Generic;

namespace FileProcessing.Services
{
    public interface IDataFormattingService
    {
        List<InputData> GetInputDataFromFileData(string[] inputDataLines);
        TransferType GetTransferType(DateTime dateTime, string referenceTime);
    }
}