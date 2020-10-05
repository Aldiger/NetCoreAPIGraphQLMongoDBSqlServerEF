using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NortB.Services.Dto;

namespace NortB.Services.Result
{
    public interface ICallResult
    {
        IList<ValidationResult> ValidationResults { get; set; }
    }
    public class CallResult : ICallResult
    {
        public IList<ValidationResult> ValidationResults { get; set; }

        public bool HasErrors => ValidationResults != null && ValidationResults.Any(g => !string.IsNullOrEmpty(g?.ErrorMessage));

        public string Errors
        {
            get { return HasErrors ? string.Join("\n", ValidationResults.Where(g => !string.IsNullOrEmpty(g?.ErrorMessage)).Select(g => g.ErrorMessage)) : string.Empty; }
        }
    }

    public class UserResult : CallResult
    {
        public IList<UserDto> Users { get; set; }
    }
    public class ValidationResult
    {
        public ValidationResult()
        {
        }

        public ValidationResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public int Count { get; set; }

        public string ErrorMessage { get; set; }
    }
}
