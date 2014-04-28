﻿using System;
using System.IO;
using System.Text;

namespace Mustache
{
    /// <summary>
    /// Substitutes a key placeholder with the textual representation of the associated object.
    /// </summary>
    internal sealed class KeyGenerator : IGenerator
    {
        private readonly string _key;
        private readonly string _format;
        private readonly bool _isVariable;
        private readonly bool _shouldHtmlEscape;
        /// <summary>
        /// Initializes a new instance of a KeyGenerator.
        /// </summary>
        /// <param name="key">The key to substitute with its value.</param>
        /// <param name="alignment">The alignment specifier.</param>
        /// <param name="formatting">The format specifier.</param>
        public KeyGenerator(string key, string alignment, string formatting, bool shouldHtmlEscape = true)
        {
            if (key.StartsWith("@"))
            {
                _key = key.Substring(1);
                _isVariable = true;
            }
            else
            {
                _key = key;
                _isVariable = false;
            }
            _format = getFormat(alignment, formatting);
            _shouldHtmlEscape = shouldHtmlEscape;
        }

        private static string getFormat(string alignment, string formatting)
        {
            StringBuilder formatBuilder = new StringBuilder();
            formatBuilder.Append("{0");
            if (!String.IsNullOrWhiteSpace(alignment))
            {
                formatBuilder.Append(",");
                formatBuilder.Append(alignment.TrimStart('+'));
            }
            if (!String.IsNullOrWhiteSpace(formatting))
            {
                formatBuilder.Append(":");
                formatBuilder.Append(formatting);
            }
            formatBuilder.Append("}");
            return formatBuilder.ToString();
        }

        void IGenerator.GetText(Scope scope, TextWriter writer, Scope context)
        {
            object value = _isVariable ? context.Find(_key, _shouldHtmlEscape) : scope.Find(_key, _shouldHtmlEscape);
            if (_shouldHtmlEscape)
                writer.Write(_format, System.Net.WebUtility.HtmlEncode(value as string));
            else writer.Write(_format, value);
        }
    }
}