using System;
using System.Data.SqlClient;

namespace ParadiseBookers.Infrastructure.Logging
{
    public static class ExceptionCodes
    {
        private const int ExceptionCodeBase = 5000000;

        public static int GetExceptionCode(Exception ex)
        {
            if (ex is SqlException)
            {
                return ExceptionCodeBase + 100;
            }

            return ExceptionCodeBase;
        }
    }
}