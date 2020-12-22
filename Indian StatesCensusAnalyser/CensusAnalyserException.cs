using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_StatesCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        /// <summary>
        /// enum ExceptionType for diffrent exception which is cponstant
        /// </summary>
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_HEADER, INCORRECT_DELIMITER, NO_SUCH_COUNTRY
        }

        public ExceptionType exceptionType;

        /// <summary>
        /// Parametrized Constructor Initializes a new instance of the <see cref="CensusAnalyserException"/> class.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="message">The message.</param>
        public CensusAnalyserException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
