#region (C) Irmac USA Inc 2006
/***************************************************************** 

	* All rights are reserved. 
    * File				: Exception.cs
    * Created Date      : 30/Oct/2006
	* Last Modify Date  : 30/Oct/20056
	* Author			: Irmac Development Team 
	* Comment			: Represents the exception that is thrown when a duplicate database record is encountered during an insert or update operation.
	* Source			: PrintManagement\BLL\Exception.cs

	****************************************************************/
#endregion

#region NameSpaces
using System;
#endregion

namespace Irmac.MailingCycle.BLL
{
	/// <summary>
	/// Represents the exception that is thrown when a duplicate database record 
	/// is encountered during an insert or update operation.
	/// </summary>
	public class DuplicateNameException: ApplicationException
	{
		public DuplicateNameException()
		{
			//
		}

		public DuplicateNameException(string message)
			: base(message)
		{
			//
		}

		public DuplicateNameException(string message, Exception inner)
			: base(message, inner)
		{
			//
		}
	}

    /// <summary>
    /// Represents the exception that is thrown when no data found during a get operation.
    /// </summary>
    public class NoDataException : ApplicationException
    {
        public NoDataException()
        {
            //
        }

        public NoDataException(string message)
            : base(message)
        {
            //
        }

        public NoDataException(string message, Exception inner)
            : base(message, inner)
        {
            //
        }
    }

    /// <summary>
    /// Represents the exception that is thrown when the data format is invalid.
    /// </summary>
    public class InvalidFormatException : ApplicationException
    {
        public InvalidFormatException()
        {
            //
        }

        public InvalidFormatException(string message)
            : base(message)
        {
            //
        }

        public InvalidFormatException(string message, Exception inner)
            : base(message, inner)
        {
            //
        }
    }


    /// <summary>
    /// Represents the exception that is thrown when the Uploaded File is Invalid.
    /// </summary>
    public class InvalidFileException : ApplicationException
    {
        public InvalidFileException()
        {
            //
        }

        public InvalidFileException(string message)
            : base(message)
        {
            //
        }

        public InvalidFileException(string message, Exception inner)
            : base(message, inner)
        {
            //
        }
    }

    /// <summary>
    /// Represents the exception that is thrown when the data is invalid.
    /// </summary>
    public class InvalidFieldDataException : ApplicationException
    {
        public InvalidFieldDataException()
        {
            //
        }

        public InvalidFieldDataException(string message)
            : base(message)
        {
            //
        }

        public InvalidFieldDataException(string message, Exception inner)
            : base(message, inner)
        {
            //
        }
    }
}
