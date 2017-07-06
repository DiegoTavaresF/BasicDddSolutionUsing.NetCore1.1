using System.Collections.Generic;
using System.Linq;

namespace Application.Base.Dto
{
    public class MainDtoError
    {
        public IList<ValidationFailureDto> Errors { get; set; }

        public bool IsValid()
        {
            return !Errors.Any();
        }
    }

    public class ValidationFailureDto
    {
        public ValidationFailureDto(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }

        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}