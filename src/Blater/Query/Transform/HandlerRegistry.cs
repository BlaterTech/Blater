using System;
using System.Collections.Generic;
using Blater.Query.Transform.Handlers;
using Blater.Query.Transform.Handlers.BinaryHandlers;
using Blater.Query.Transform.Handlers.CollectionHandlers;
using Blater.Query.Transform.Handlers.Dictionaries;
using Blater.Query.Transform.Handlers.InNotInHandlers;
using Blater.Query.Transform.Handlers.StringHandlers;

namespace Blater.Query.Transform;

/// <summary>
/// Registry of all the handlers used to convert the linq where clauses into mongo json object.
/// </summary>
public static class HandlerRegistry
{
    public static readonly Dictionary<Type, List<IHandler>?> Handlers = new();

    static HandlerRegistry()
    {
        Register<AndOrVisitorHandler>();

        Register<EqualityHandler>();
        Register<NotHandler>();
        Register<LessAndGreaterThanHandler>();

        Register<StringContainsHandler>();
        Register<StringStartsWithHandler>();
        Register<StringEndsWithHandler>();

        Register<AnyHandler>();

        Register<DictionaryContainsKeyHandler>();
        Register<IndexHandler>();

        Register<InHandler>();
        Register<NotInHandler>();

        Register<BooleanEqualityHandler>();
    }

    public static void Register<T>() where T : IHandler, new()
    {
        var handler = new T();

        if (!Handlers.TryGetValue(handler.HandleTypeOf, out var handlers))
        {
            handlers = new List<IHandler>();
            Handlers.Add(handler.HandleTypeOf, handlers);
        }

        handlers?.Add(handler);
    }
}