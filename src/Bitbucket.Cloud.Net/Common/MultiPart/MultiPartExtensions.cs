using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public static class MultipartExtensions
	{
		public static IEnumerable<TSource> SkipUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			return _();
			IEnumerable<TSource> _()
			{
				using var enumerator = source.GetEnumerator();

				do
				{
					if (!enumerator.MoveNext())
					{
						yield break;
					}
				}
				while (!predicate(enumerator.Current));

				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
			}
		}

		public static IEnumerable<TSource> SkipLast<TSource>(this IEnumerable<TSource> source, int count = 1)
		{
			var q = new Queue<TSource>();

			foreach (var item in source)
			{
				q.Enqueue(item);

				if (q.Count > count)
				{
					yield return q.Dequeue();
				}
			}
		}

		public static IEnumerable<TResult> SelectTwo<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> selector)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (selector == null)
			{
				throw new ArgumentNullException(nameof(selector));
			}

			return _();
			IEnumerable<TResult> _()
			{
				using var enumerator = source.GetEnumerator();
				var item2 = default(TSource);
				int i = 0;
				while (enumerator.MoveNext())
				{
					var item1 = item2;
					item2 = enumerator.Current;
					i++;

					if (i >= 2)
					{
						yield return selector(item1, item2);
					}
				}
			}
		}

		private static string FromBase64String(this string base64)
		{
			var bytes = Convert.FromBase64String(base64);
			return Encoding.UTF8.GetString(bytes);
		}

		private static string GetContentType(this IEnumerable<string> lines)
		{
			string line = lines.FirstOrDefault(x => x.StartsWith("Content-Type:"));
			var parts = line?.Split(new[] { ": " }, StringSplitOptions.None);
			parts = parts?[1]?.Split(new[] { "; " }, StringSplitOptions.None);
			return parts?[0];
		}

		private static string GetTransferEncoding(this IEnumerable<string> lines)
		{
			string line = lines.FirstOrDefault(x => x.StartsWith("Content-Transfer-Encoding:"));
			var parts = line?.Split(new[] { ": " }, StringSplitOptions.None);
			return parts?[1].Trim();
		}

		private static string GetContentDispositionName(this IEnumerable<string> lines)
		{
			string line = lines.FirstOrDefault(x => x.StartsWith("Content-Disposition:"));
			var parts = line?.Split(new[] { ": " }, StringSplitOptions.None);
			parts = parts?[1].Split(new[] { "; " }, StringSplitOptions.None);
			line = parts?.FirstOrDefault(x => x.StartsWith("name", StringComparison.OrdinalIgnoreCase));
			parts = line?.Split('=');
			return parts?[1].Trim('"');
		}

		private static string GetContentDispositionFileName(this IEnumerable<string> lines)
		{
			string line = lines.FirstOrDefault(x => x.StartsWith("Content-Disposition:"));
			var parts = line?.Split(new[] { ": " }, StringSplitOptions.None);
			parts = parts?[1].Split(new[] { "; " }, StringSplitOptions.None);
			line = parts?.FirstOrDefault(x => x.StartsWith("filename", StringComparison.OrdinalIgnoreCase));
			parts = line?.Split('=');
			return parts?[1].Trim('"');
		}

		private static string GetContents(this IEnumerable<string> lines)
		{
			return string.Concat(lines
				.SkipUntil(x => x.Length == 0)
				.TakeWhile(x => x.Length != 0));
		}

		private static MultipartContentSection ToMultipartContentSection(this MultipartContentBlock multipartContentBlock)
		{
			var lines = multipartContentBlock.Lines;

			string contentType = lines.GetContentType();
			string transferEncoding = lines.GetTransferEncoding();
			string contentDispositionName = lines.GetContentDispositionName();
			string contentDispositionFileName = lines.GetContentDispositionFileName();
			string contents = lines.GetContents();

			if (transferEncoding?.Equals("base64", StringComparison.OrdinalIgnoreCase) == true)
			{
				contents = contents.FromBase64String();
			}

			return new MultipartContentSection(contentType, transferEncoding, contentDispositionName, contentDispositionFileName, contents);
		}

		private static List<MultipartContentSection> ToMultipartContentSections(this IEnumerable<MultipartContentBlock> nultipartContentBlocks)
		{
			return nultipartContentBlocks
				.Select(ToMultipartContentSection)
				.ToList();
		}

		private static IEnumerable<IEnumerable<string>> GetContentLineBlocks(this IList<string> lines, IEnumerable<int> boundaries)
		{
			return boundaries.SelectTwo((low, high) =>
			{
				var contentLineBlock = new List<string>();
				for (int i = low; i < high; i++)
				{
					contentLineBlock.Add(lines[i]);
				}
				return contentLineBlock;
			});
		}

		private static IEnumerable<int> GetLineNumbers(this IList<string> lines, string boundary)
		{
			var results = new List<int>();

			for (int i = 0; i < lines.Count; i++)
			{
				string line = lines[i];
				if (line.StartsWith($"--{boundary}"))
				{
					results.Add(i);
				}
			}

			return results;
		}

		private static List<MultipartContentBlock> ParseContentBlocks(this IList<string> contentLines, string boundary)
		{
			if (boundary == null)
			{
				throw new ArgumentNullException(nameof(boundary));
			}

			var boundaries = contentLines.GetLineNumbers(boundary);
			var contentLineBlocks = contentLines.GetContentLineBlocks(boundaries);

			var results = new List<MultipartContentBlock>();
			foreach (var contentLineBlock in contentLineBlocks)
			{
				results.Add(new MultipartContentBlock(contentLineBlock
					.SkipWhile(x => !x.Contains(boundary)).Skip(1)
					.TakeWhile(x => !x.Contains(boundary))));
			}
			return results;
		}

		private static string FindMultipartBoundary(this IEnumerable<string> contentLines)
		{
			var lines = contentLines.ToList();
			string line = lines.Find(x => x.StartsWith("Content-Type:"));
			if (line == null)
			{
				return null;
			}

			var parts = line.Split(new[] { "; " }, StringSplitOptions.None);
			string boundaryPart = Array.Find(parts, part => part.StartsWith("boundary"));

			string result = boundaryPart?.Split(new[] { '=' }, 2)[1] ?? lines.Find(x => x.StartsWith("--"));
			return result.Trim('\"', '\r');
		}

		public static List<MultipartContentSection> ReadMultipartContent(this string content)
		{
			var contentLines = content.Split(new[] { '\n' }, StringSplitOptions.None).ToList();

			string boundary = contentLines.FindMultipartBoundary();
			var contentBlocks = contentLines.ParseContentBlocks(boundary);
			return contentBlocks.ToMultipartContentSections();
		}
	}
}
