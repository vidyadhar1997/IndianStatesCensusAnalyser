using Indian_StatesCensusAnalyser;
using Indian_StatesCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static Indian_StatesCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"\Users\hp\source\repos\IndianStateDemo\CensusAnalyserTests\CSVFile\IndianStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"\Users\hp\source\repos\IndianStateDemo\CensusAnalyserTests\CSVFile\WrongIndianStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"\Users\hp\source\repos\Indian StatesCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongIndianStateCensusFileType.txt";
        static string delimiterIndianCensusData= @"\Users\hp\source\repos\Indian StatesCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\DelimiterIndianCensusData.csv";
        static string wrongHeaderIndianStateCensusData= @"\Users\hp\source\repos\Indian StatesCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongHeaderIndianStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Test Case 1.1 Given the indian census data file when reader should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReade_ThenShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// <summary>
        /// Test Case 1.2 Given the indian census data file when incorrect then return File not found exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException =Assert.Throws<CensusAnalyserException>(()=> censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.exceptionType);
        }

        /// <summary>
        /// Test Case 1.3 Given the indian census data csv file when correct but type incoorect then return invalid file type exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenFileTypeIncorrect_ThenShouldReturnInvalidFileTypeException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.exceptionType);
        }

        /// <summary>
        /// Test Case 1.4 Given the indian census data csv file when correct but delimiter incoorect then return incorrect delimiter exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenDelimiterIncorrect_ThenShouldReturnInvalidDelimiterException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusData, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.exceptionType);
        }

        /// <summary>
        /// Test Case 1.5 Given the indian census data csv file when correct but header incoorect then return incorrect delimiter exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenHeaderIncorrect_ThenShouldReturnInvalidHeaderException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCensusData, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.exceptionType);
        }
    }
}