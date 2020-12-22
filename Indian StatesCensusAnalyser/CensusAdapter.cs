﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Indian_StatesCensusAnalyser
{
    public abstract class CensusAdapter
    {
        /// <summary>
        /// Gets the census data.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyserException">
        /// File not found
        /// or
        /// Invalid file type
        /// or
        /// Incorrect header in data
        /// </exception>
        public string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "File not found");

            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, "Invalid file type");
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, "Incorrect header in data");
            }
            return censusData;
        }
    }
}
