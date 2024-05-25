namespace Blater.Utilities;

public struct ShortGuid : IEquatable<ShortGuid>
{
    /// <summary>
    /// A read-only instance of the ShortGuid class whose value 
    /// is guaranteed to be all zeroes. 
    /// </summary>
    public static readonly ShortGuid Empty = new(Guid.Empty);
    
    /// <summary>
    /// Creates a ShortGuid from a new Guid
    /// </summary>
    public ShortGuid()
    {
        Value = Encode(SequentialGuidGenerator.NewGuid());
    }
    
    /// <summary>
    /// Creates a ShortGuid from a base64 encoded string
    /// </summary>
    /// <param name="value">The encoded guid as a 
    /// base64 string</param>
    public ShortGuid(string value)
    {
        Value = value;
    }
    
    /// <summary>
    /// Creates a ShortGuid from a Guid
    /// </summary>
    /// <param name="guidValue">The Guid to encode</param>
    public ShortGuid(Guid guidValue)
    {
        Value = Encode(guidValue);
    }
    
    #region Properties
    
    /// <summary>
    /// Gets/sets the underlying base64 encoded string
    /// </summary>
    private string Value { get; set; }
    
    #endregion
    
    #region ToString
    
    /// <summary>
    /// Returns the base64 encoded guid as a string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Value;
    }
    
    #endregion
    
    #region Equals
    
    /// <summary>
    /// Returns a value indicating whether this instance and a 
    /// specified Object represent the same type and value.
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            ShortGuid sid => sid.Equals(this),
            string        => obj.ToString() == Value,
            _             => false
        };
    }
    
    #endregion
    
    #region GetHashCode
    
    /// <summary>
    /// Returns the HashCode for underlying Guid.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return Value.GetHashCode(StringComparison.Ordinal);
    }
    
    #endregion
    
    #region NewShortId
    
    /// <summary>
    /// Initialises a new instance of the ShortGuid class
    /// </summary>
    /// <returns></returns>
    public static ShortGuid NewShortId()
    {
        return new ShortGuid(SequentialGuidGenerator.NewGuid());
    }
    
    #endregion
    
    #region Encode
    
    /// <summary>
    /// Encodes the given Guid as a base64 string that is 22 
    /// characters long.
    /// </summary>
    /// <param name="guidValue">The Guid to encode</param>
    /// <returns></returns>
    private static string Encode(Guid guidValue)
    {
        var encoded = Convert.ToBase64String(guidValue.ToByteArray());
        
        encoded = encoded
                 .Replace("/", "_", StringComparison.OrdinalIgnoreCase)
                 .Replace("+", "-", StringComparison.OrdinalIgnoreCase);
        
        
        return encoded[..22];
    }
    
    #endregion
    
    #region Decode
    
    /// <summary>
    /// Decodes the given base64 string
    /// </summary>
    /// <param name="value">The base64 encoded string of a Guid</param>
    /// <returns>A new Guid</returns>
    private static Guid Decode(string value)
    {
        value = value
               .Replace("_", "/", StringComparison.OrdinalIgnoreCase)
               .Replace("-", "+", StringComparison.OrdinalIgnoreCase);
        var buffer = Convert.FromBase64String(value + "==");
        return new Guid(buffer);
    }
    
    #endregion
    
    #region Operators
    
    public static bool operator ==(ShortGuid x, ShortGuid y)
    {
        return x.GetHashCode() == y.GetHashCode();
    }
    
    public static bool operator !=(ShortGuid x, ShortGuid y)
    {
        return !(x == y);
    }
    
    public static bool operator ==(ShortGuid x, ShortGuid? y)
    {
        if (y is null)
        {
            return false;
        }
        
        return x.GetHashCode() == y.GetHashCode();
    }
    
    public static bool operator !=(ShortGuid x, ShortGuid? y)
    {
        return !(x == y);
    }
    
    /// <summary>
    /// Determines if both ShortGuids have the same underlying 
    /// Guid value.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static bool operator ==(ShortGuid? x, ShortGuid? y)
    {
        if (x is null || y is null)
        {
            return false;
        }
        
        return x.GetHashCode() == y.GetHashCode();
    }
    
    /// <summary>
    /// Determines if both ShortGuids do not have the 
    /// same underlying Guid value.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static bool operator !=(ShortGuid? x, ShortGuid? y)
    {
        return !(x == y);
    }
    
    /// <summary>
    /// Implicitly converts the ShortGuid to its string equivalent
    /// </summary>
    /// <param name="shortGuid"></param>
    /// <returns></returns>
    public static implicit operator string(ShortGuid shortGuid)
    {
        return shortGuid.Value;
    }
    
    /// <summary>
    /// Implicitly converts the ShortGuid to it's Guid equivalent
    /// </summary>
    /// <param name="shortGuid"></param>
    /// <returns></returns>
    public static implicit operator Guid(ShortGuid shortGuid)
    {
        return Decode(shortGuid);
    }
    
    /// <summary>
    /// Implicitly converts the string to a ShortGuid
    /// </summary>
    /// <param name="shortGuid"></param>
    /// <returns></returns>
    public static implicit operator ShortGuid(string shortGuid)
    {
        return new ShortGuid(shortGuid);
    }
    
    /// <summary>
    /// Implicitly converts the Guid to a ShortGuid 
    /// </summary>
    /// <param name="guidValue"></param>
    /// <returns></returns>
    public static implicit operator ShortGuid(Guid guidValue)
    {
        return new ShortGuid(guidValue);
    }
    
    public bool Equals(ShortGuid other)
    {
        return Value == other.Value;
    }
    
    #endregion
}