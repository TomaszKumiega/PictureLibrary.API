﻿using FluentValidation;
using PictureLibrary.Domain.Exceptions;

namespace PictureLibrary.Api.ErrorMapping
{
    public class ExceptionMapper : IExceptionMapper
    {
        public ErrorDetails Map(Exception exception)
        {
            return exception switch
            {
                ValidationException e => GetValidationError(e),
                InvalidTokenException => GetInvalidTokenError(),
                NotFoundException => GetNotFoundError(),
                AlreadyExistsException e => GetAlreadyExistsError(e),
                _ => GetDefaultError()
            };
        }

        private static ErrorDetails GetValidationError(ValidationException e)
        {
            return new ErrorDetails
            {
                StatusCode = 400,
                ErrorCode = ErrorCode.ValidationError,
                Message = e.Message
            };
        }
        private static ErrorDetails GetInvalidTokenError()
        {
            return new ErrorDetails
            {
                StatusCode = 401,
                ErrorCode = ErrorCode.InvalidToken,
                Message = "Invalid token."
            };
        }
        private static ErrorDetails GetNotFoundError()
        {
            return new ErrorDetails
            {
                StatusCode = 404,
                ErrorCode = ErrorCode.NotFound,
                Message = "Resource not found."
            };
        }
        private static ErrorDetails GetAlreadyExistsError(AlreadyExistsException e)
        {
            return new ErrorDetails
            {
                StatusCode = 409,
                ErrorCode = ErrorCode.AlreadyExists,
                Message = e.Message
            };
        }
        private static ErrorDetails GetDefaultError()
        {
            return new ErrorDetails
            {
                StatusCode = 500,
                Message = "An error occurred"
            };
        }
    }
}
