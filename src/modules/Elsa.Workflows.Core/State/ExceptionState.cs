﻿using System.Text.Json.Serialization;

// ReSharper disable NotAccessedPositionalProperty.Global

namespace Elsa.Workflows.State;

/// <summary>
/// A simplified, serializable model representing an exception.
/// </summary>
public record ExceptionState(Type Type, string Message, string? StackTrace, ExceptionState? InnerException)
{
    /// <summary>
    /// Constructor
    /// </summary>
    [JsonConstructor]
    public ExceptionState() : this(default!, default!, default, default)
    {
        
    }
    
    /// <summary>
    /// Creates a new <see cref="ExceptionState"/> from the specified exception. 
    /// </summary>
    public static ExceptionState? FromException(Exception? ex)
    {
        return ex == null ? null : new ExceptionState(ex.GetType(), ex.Message, ex.StackTrace, FromException(ex.InnerException));
    }
}