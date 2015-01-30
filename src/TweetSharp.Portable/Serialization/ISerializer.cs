﻿using System;
using System.Text;

namespace TweetSharp
{
    public interface ISerializer
    {
        string Serialize(object instance, Type type);
        string ContentType { get; }
        Encoding ContentEncoding { get; }
    }
}