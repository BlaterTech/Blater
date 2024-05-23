namespace Blater.Utilities
{
    public struct ShortGuid : IEquatable<ShortGuid>
    {
        #region Static
        
        /// <summary>
        /// A read-only instance of the ShortGuid class whose value 
        /// is guaranteed to be all zeroes. 
        /// </summary>
        public static readonly ShortGuid Empty = new(Guid.Empty);
        
        #endregion
        
        #region Fields
        
        private Guid _guid;
        private string _value;
        
        #endregion
        
        #region Contructors
        
        /// <summary>
        /// Creates a ShortGuid from a new Guid
        /// </summary>
        public ShortGuid()
        {
            _guid = SequentialGuidGenerator.NewGuid();
            _value = Encode(_guid);
        }
        
        /// <summary>
        /// Creates a ShortGuid from a base64 encoded string
        /// </summary>
        /// <param name="value">The encoded guid as a 
        /// base64 string</param>
        public ShortGuid(string value)
        {
            _value = value;
            _guid = Decode(value);
        }
        
        /// <summary>
        /// Creates a ShortGuid from a Guid
        /// </summary>
        /// <param name="guidValue">The Guid to encode</param>
        public ShortGuid(Guid guidValue)
        {
            _value = Encode(guidValue);
            _guid = guidValue;
        }
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets/sets the underlying Guid
        /// </summary>
        public Guid GuidValue
        {
            get => _guid;
            set
            {
                if (value == _guid)
                {
                    return;
                }
                
                _guid = value;
                _value = Encode(value);
            }
        }
        
        /// <summary>
        /// Gets/sets the underlying base64 encoded string
        /// </summary>
        public string Value
        {
            get => _value;
            set
            {
                if (value == _value)
                {
                    return;
                }
                
                _value = value;
                _guid = Decode(value);
            }
        }
        
        #endregion
        
        #region ToString
        
        /// <summary>
        /// Returns the base64 encoded guid as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _value;
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
                ShortGuid guid => _guid.Equals(guid._guid),
                Guid guid      => _guid.Equals(guid),
                string         => _guid.Equals(((ShortGuid)obj)._guid),
                _              => false
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
            return _guid.GetHashCode();
        }
        
        #endregion
        
        #region NewGuid
        
        /// <summary>
        /// Initialises a new instance of the ShortGuid class
        /// </summary>
        /// <returns></returns>
        public static ShortGuid NewGuid()
        {
            return new ShortGuid(SequentialGuidGenerator.NewGuid());
        }
        
        #endregion
        
        #region Encode
        
        /// <summary>
        /// Creates a new instance of a Guid using the string value, 
        /// then returns the base64 encoded version of the Guid.
        /// </summary>
        /// <param name="value">An actual Guid string (i.e. not a ShortGuid)</param>
        /// <returns></returns>
        public static string Encode(string value)
        {
            var guid = new Guid(value);
            return Encode(guid);
        }
        
        /// <summary>
        /// Encodes the given Guid as a base64 string that is 22 
        /// characters long.
        /// </summary>
        /// <param name="guidValue">The Guid to encode</param>
        /// <returns></returns>
        public static string Encode(Guid guidValue)
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
        public static Guid Decode(string value)
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
            return x._guid == y._guid;
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
            
            return x._guid == y.Value._guid;
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
            
            return x.Value._guid == y.Value._guid;
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
            return shortGuid._value;
        }
        
        /// <summary>
        /// Implicitly converts the ShortGuid to it's Guid equivalent
        /// </summary>
        /// <param name="shortGuid"></param>
        /// <returns></returns>
        public static implicit operator Guid(ShortGuid shortGuid)
        {
            return shortGuid._guid;
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
            return _guid.Equals(other._guid);
        }
        
        #endregion
    }
}