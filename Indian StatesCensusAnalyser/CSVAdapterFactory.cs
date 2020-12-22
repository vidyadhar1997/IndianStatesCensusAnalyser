using Indian_StatesCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_StatesCensusAnalyser
{
    public class CSVAdapterFactory
    {
        /// <summary>
        /// Loads the CSV data.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="Indian_StatesCensusAnalyser.CensusAnalyserException">No such country</exception>
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, "No such country");
            }
        }
    }
}
