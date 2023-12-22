﻿namespace ResponseCaching.API.Common;

public abstract class CommandHandler
{
    protected BaseResult BaseResult;

    protected CommandHandler()
    {
        BaseResult = new BaseResult();
    }

    protected void AddError(string message)
    {
        BaseResult.Errors.Add(message);
    }
}
