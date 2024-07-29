using System.Buffers;
using MessagePack;
using MessagePack.Resolvers;

namespace Blater.Extensions;

public static class MessagePackExtensions
{
    public static IFormatterResolver Resolvers { get; set; } = CompositeResolver.Create(
        Cysharp.Serialization.MessagePack.UlidMessagePackResolver.Instance,
        ContractlessStandardResolver.Instance);

    public static MessagePackSerializerOptions DefaultOptions { get; set; } = ContractlessStandardResolver.Options.WithResolver(Resolvers);

    public static Memory<byte> ToMessagePack<T>(this T obj)
    {
        return MessagePackSerializer.Serialize(obj, DefaultOptions);
    }

    public static T FromMessagePack<T>(this ReadOnlySequence<byte> bytes)
    {
        return MessagePackSerializer.Deserialize<T>(in bytes, DefaultOptions);
    }

    public static T FromMessagePack<T>(this ReadOnlyMemory<byte> bytes)
    {
        return MessagePackSerializer.Deserialize<T>(bytes, DefaultOptions);
    }

    public static T FromMessagePack<T>(this byte[] bytes)
    {
        return MessagePackSerializer.Deserialize<T>(bytes, DefaultOptions);
    }

    public static T FromMessagePack<T>(this Memory<byte> bytes)
    {
        return MessagePackSerializer.Deserialize<T>(bytes, DefaultOptions);
    }

    public static T FromMessagePack<T>(this Span<byte> bytes)
    {
        return MessagePackSerializer.Deserialize<T>(bytes.ToArray(), DefaultOptions);
    }
}