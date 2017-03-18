namespace Telerik.ILS.Common
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;
	using System.Text.RegularExpressions;

	public static class StringExtensions
	{
		/// <summary>
		/// Calculates the MD5 hash of a specified string.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>The MD5 hash of the string as a hexadecimal string.</returns>
		public static string ToMd5Hash(this string input)
		{
			var md5Hash = MD5.Create();

			// Convert the input string to a byte array and compute the hash.
			var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

			// Create a new StringBuilder to collect the bytes
			// and create a string.
			var builder = new StringBuilder();

			// Loop through each byte of the hashed data 
			// and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++)
			{
				builder.Append(data[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return builder.ToString();
		}

		/// <summary>
		/// Converts the string representation of a number to its boolean equivalent.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>true if the value is "true", "ok", "yes", "1" or "да"; false otherwise </returns>
		public static bool ToBoolean(this string input)
		{
			var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
			return stringTrueValues.Contains(input.ToLower());
		}

		/// <summary>
		/// Converts the string representation of a number to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>A 16-bit signed integer equivalent to the number specified in input.</returns>
		public static short ToShort(this string input)
		{
			short.TryParse(input, out short shortValue);
			return shortValue;
		}

		/// <summary>
		/// Converts the string representation of a number to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>A 32-bit signed integer equivalent to the number specified in input.</returns>
		public static int ToInteger(this string input)
		{
			int.TryParse(input, out int integerValue);
			return integerValue;
		}

		/// <summary>
		/// Converts the string representation of a number to its 64-bit signed integer equivalent.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>A 64-bit signed integer equivalent to the number specified in input.</returns>
		public static long ToLong(this string input)
		{
			long.TryParse(input, out long longValue);
			return longValue;
		}

		/// <summary>
		/// Converts the string representation of a date and time to its System.DateTime equivalent.
		/// </summary>
		/// <param name="input">A string that contains a date and time to convert.</param>
		/// <returns>An object that is equivalent to the date and time contained in input or null if the parse failed.</returns>
		public static DateTime ToDateTime(this string input)
		{
			DateTime.TryParse(input, out DateTime dateTimeValue);
			return dateTimeValue;
		}

		/// <summary>
		/// Returns the input string where the first character is capitalized.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>The input string where the first character is capitalized.</returns>
		public static string CapitalizeFirstLetter(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}

			return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
		}

		/// <summary>
		/// Returns a string contained between startString and endString in the input string (exclusive).
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <param name="startString">The start string</param>
		/// <param name="endString">The end string</param>
		/// <param name="startFrom">Optional index to start searching from (inclusive).</param>
		/// <returns>The converted string or empty string if it does not exist.</returns>
		public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
		{
			input = input.Substring(startFrom);
			startFrom = 0;
			if (!input.Contains(startString) || !input.Contains(endString))
			{
				return string.Empty;
			}

			var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
			if (startPosition == -1)
			{
				return string.Empty;
			}

			var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
			if (endPosition == -1)
			{
				return string.Empty;
			}

			return input.Substring(startPosition, endPosition - startPosition);
		}

		/// <summary>
		/// Returns the input string with all Cyrillic characters converted to their Latin representation
		/// (some characters are converted to a two letter string).
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>The converted string.</returns>
		public static string ConvertCyrillicToLatinLetters(this string input)
		{
			var bulgarianLetters = new[]
			{
			"а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
			"р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
			};
			var latinRepresentationsOfBulgarianLetters = new[]
			{
				"a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
				"l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
				"c", "ch", "sh", "sht", "u", "i", "yu", "ya"
			};
			for (var i = 0; i < bulgarianLetters.Length; i++)
			{
				input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
				input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
			}

			return input;
		}

		/// <summary>
		/// Returns the input string with all Latin characters converted to their Cyrillic representation.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>The converted string.</returns>
		public static string ConvertLatinToCyrillicKeyboard(this string input)
		{
			var latinLetters = new[]
			{
				"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
				"q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
			};

			var bulgarianRepresentationOfLatinKeyboard = new[]
			{
				"а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
				"л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
				"в", "ь", "ъ", "з"
			};

			for (int i = 0; i < latinLetters.Length; i++)
			{
				input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
				input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
			}

			return input;
		}

		/// <summary>
		/// Returns the input string with all characters except Latin letters, numbers, underscores and dots removed 
		/// and all Cyrilic letters replaced with their Latin representation.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>The converted string.</returns>
		public static string ToValidUsername(this string input)
		{
			input = input.ConvertCyrillicToLatinLetters();
			return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
		}

		/// <summary>
		/// Returns the input string with all characters except Latin letters, numbers, underscores, dashes and dots removed
		/// and all Cyrilic letters replaced with their Latin representation.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>The converted string.</returns>
		public static string ToValidLatinFileName(this string input)
		{
			input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
			return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
		}

		/// <summary>
		/// Returns the input string up to the specified length
		/// or the whole string if charsCount is bigger then the string length.
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <param name="charsCount">The length of the substring.</param>
		/// <returns>The substring up to charsCount, the whole string if charsCount is bigger than the string length.</returns>
		public static string GetFirstCharacters(this string input, int charsCount)
		{
			return input.Substring(0, Math.Min(input.Length, charsCount));
		}

		/// <summary>
		/// Returns the part of the input string after the last dot.
		/// </summary>
		/// <param name="fileName">The input string.</param>
		/// <returns>The part of the input string after the last dot or empty string if null.</returns>
		public static string GetFileExtension(this string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				return string.Empty;
			}

			string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
			if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
			{
				return string.Empty;
			}

			return fileParts.Last().Trim().ToLower();
		}

		/// <summary>
		/// Returns the content type for some popular file extensions.
		/// The default is "application/octet-stream".
		/// </summary>
		/// <param name="fileExtension">The input string.</param>
		/// <returns>The content type for some popular file extensions.</returns>
		public static string ToContentType(this string fileExtension)
		{
			var fileExtensionToContentType = new Dictionary<string, string>
			{
				{ "jpg", "image/jpeg" },
				{ "jpeg", "image/jpeg" },
				{ "png", "image/x-png" },
				{
					"docx",
					"application/vnd.openxmlformats-officedocument.wordprocessingml.document"
				},
				{ "doc", "application/msword" },
				{ "pdf", "application/pdf" },
				{ "txt", "text/plain" },
				{ "rtf", "application/rtf" }
			};
			if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
			{
				return fileExtensionToContentType[fileExtension.Trim()];
			}

			return "application/octet-stream";
		}

		/// <summary>
		/// Converts the input string to an array of unsigned 8-bit integers
		/// </summary>
		/// <param name="input"></param>
		/// <returns>The byte array representation of the string</returns>
		public static byte[] ToByteArray(this string input)
		{
			var bytesArray = new byte[input.Length * sizeof(char)];
			Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
			return bytesArray;
		}
	}
}
