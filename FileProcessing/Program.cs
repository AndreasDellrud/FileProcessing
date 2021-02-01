using FileProcessing.Entities;
using FileProcessing.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine($"Program only takes 3 arguments. Filename, output directory, Reference date.");
                Console.ReadKey();
                return;
            }

            var fileName = args[0];
            var outputDirectory = args[1];
            var referenceDate = args[2];

            var dataFormattingService = new DataFormattingService();

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File does not exist: {fileName}");
                Console.ReadKey();
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            var lines = File.ReadAllLines($@".\{fileName}");

            var inputData = dataFormattingService.GetInputDataFromFileData(lines);

            var banks = new List<Bank>();

            foreach (var item in inputData)
            {
                var bank = banks.FirstOrDefault(b => b.Name == item.Bank);
                if (bank == null)
                {
                    bank = new Bank { Name = item.Bank, Transfers = new List<Transfer>() };
                    banks.Add(bank);
                }

                var transfer = new Transfer
                {
                    Account = item.Account,
                    Amount = item.Amount,
                    Date = DateTime.Parse(item.Date)
                };

                transfer.Type = dataFormattingService.GetTransferType(transfer.Date, referenceDate);

                bank.Transfers.Add(transfer);
            }

            foreach (var bank in banks)
            {
                var outputFileName = $@"{outputDirectory}\{bank.Name}.txt";
                if (!File.Exists(outputFileName))
                {
                    File.WriteAllText(outputFileName, "Konto;Belopp;Datum;Typ" + Environment.NewLine);
                }

                foreach (var transfer in bank.Transfers)
                {
                    File.AppendAllText(outputFileName, $"{transfer.Account};{transfer.Amount};{transfer.Date.ToShortDateString()};{transfer.Type.ToString().ToUpper()}" + Environment.NewLine);
                }
            }
        }
    }
}
