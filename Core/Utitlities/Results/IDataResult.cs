﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Results
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
