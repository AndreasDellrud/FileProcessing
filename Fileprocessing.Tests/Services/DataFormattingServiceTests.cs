using NUnit.Framework;
using System;

namespace FileProcessing.Services.Tests
{
    [TestFixture()]
    public class DataFormattingServiceTests
    {
        private IDataFormattingService dataFormattingService;
        private readonly string[] fileData = { "20114; -2313; 2020-01-28; SEB", "132412; +2313; 2020-01-29; SEB", "13452; 2345; 2020-01-30; HSB" };
        [SetUp]
        public void Init()
        {
            dataFormattingService = new DataFormattingService();
        }
        [Test()]
        public void GetInputDataFromFileDataShouldHaveCorrectData()
        {
            var inputData = dataFormattingService.GetInputDataFromFileData(fileData);

            Assert.AreEqual("132412", inputData[2].Account);
        }

        [Test()]
        public void GetTransferTypeShouldReturnOldForPastDate()
        {
            var referenceDate = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd");
            var date = DateTime.Now;
            var type = dataFormattingService.GetTransferType(date, referenceDate);
            Assert.AreEqual(TransferType.OLD, type);
        }
        [Test()]
        public void GetTransferTypeShouldReturnActiveForCurrentDate()
        {
            var referenceDate = DateTime.Now.ToString("yyyy-MM-dd");
            var date = DateTime.Now;
            var type = dataFormattingService.GetTransferType(date, referenceDate);
            Assert.AreEqual(TransferType.ACTIVE, type);
        }
        [Test()]
        public void GetTransferTypeShouldReturnFutureForFutureDateDate()
        {
            var referenceDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd");
            var date = DateTime.Now;
            var type = dataFormattingService.GetTransferType(date, referenceDate);
            Assert.AreEqual(TransferType.FUTURE, type);
        }
    }
}