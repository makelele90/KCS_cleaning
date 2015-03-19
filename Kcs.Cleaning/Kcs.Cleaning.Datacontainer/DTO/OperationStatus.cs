using System;
using System.Diagnostics;

namespace Kcs.Cleaning.Datacontainer.DTO
{
    [DebuggerDisplay("Status = {Status},Message={Message}")]
    public class OperationStatus
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public int RecordsAffected { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string ExceptionInnerMessage { get; set; }
        public string ExceptionnInnerStackTrace { get; set; }

        public static OperationStatus CreateFromExeption(Exception ex, string message)
        {
            var operationStatus = new OperationStatus();

            operationStatus.Status = false;
            operationStatus.Message = message;
            operationStatus.RecordsAffected = 0;
            operationStatus.ExceptionMessage = ex.Message;
            operationStatus.ExceptionStackTrace = ex.StackTrace;

            if (ex.InnerException != null)
            {
                operationStatus.ExceptionInnerMessage = ex.InnerException.Message;
                operationStatus.ExceptionnInnerStackTrace = ex.InnerException.StackTrace;
            }

            return operationStatus;
        }
    }
}
