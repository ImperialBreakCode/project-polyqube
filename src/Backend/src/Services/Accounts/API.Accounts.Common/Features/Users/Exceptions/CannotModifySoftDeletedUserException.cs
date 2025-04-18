﻿using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class CannotModifySoftDeletedUserException : BadRequestException
    {
        private const string MESSAGE = "Cannot modify. User is already deleted.";

        public CannotModifySoftDeletedUserException() : base(MESSAGE)
        {
        }
    }
}
