using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common
{
    public record Erorr(string Code, string Message,  ErorrType ErorrType= ErorrType.Failure)
    {
        public static Erorr Failure(string code="FAILURE", string description="An error occurred.") => new Erorr(code, description, ErorrType.Failure);
        public static Erorr Validation(string code="VALIDATION", string description="A validation error occurred.") => new Erorr(code, description, ErorrType.Validation);
        public static Erorr NotFound(string code="NOT_FOUND", string description="The requested resource was not found.") => new Erorr(code, description, ErorrType.NotFound);
        public static Erorr Unauthorized(string code="UNAUTHORIZED", string description="The request is not authorized.") => new Erorr(code, description, ErorrType.Unauthorized);
        public static Erorr Forbidden(string code="FORBIDDEN", string description="The request is forbidden.") => new Erorr(code, description, ErorrType.Forbidden);
        public static Erorr Conflict(string code="CONFLICT", string description="A conflict occurred.") => new Erorr(code, description, ErorrType.Conflict);
        public static Erorr InvalidCredentials(string code="INVALID_CREDENTIALS", string description="The provided credentials are invalid.") => new Erorr(code, description, ErorrType.InvalidCredentials);
    }

    public enum ErorrType
    {
        Failure,
        Validation,
        NotFound,
        Unauthorized,
        Forbidden,
        Conflict,
        InvalidCredentials,
    }
}
