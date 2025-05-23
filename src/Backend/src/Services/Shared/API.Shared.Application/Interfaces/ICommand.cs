﻿using MediatR;

namespace API.Shared.Application.Interfaces
{
    public interface ICommand : IRequest;

    public interface ICommand<TResult> : IRequest<TResult>;
}
