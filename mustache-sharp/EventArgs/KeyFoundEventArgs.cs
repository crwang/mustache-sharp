using System;

namespace Mustache
{
    /// <summary>
    /// Holds the information about a key that was found.
    /// </summary>
    public class KeyFoundEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of a KeyFoundEventArgs.
        /// </summary>
        /// <param name="key">The fully-qualified key.</param>
        internal KeyFoundEventArgs(string key, object value, bool shouldHtmlEscape = true)
        {
            Key = key;
            Value = value;
            ShouldHtmlEscape = shouldHtmlEscape;
        }

        /// <summary>
        /// Gets the fully-qualified key.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the fully-qualified value.
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Gets the fully-qualified shouldHtmlEscape value.
        /// </summary>
        public bool ShouldHtmlEscape { get; private set; }

        /// <summary>
        /// Gets or sets the object to use as the substitute.
        /// </summary>
        public object Substitute { get; set; }
    }
}
