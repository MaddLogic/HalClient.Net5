using System;
using System.Net.Http;
using System.Threading.Tasks;
using HalClient.Net5.Parser;

namespace HalClient.Net5
{
	internal class HalHttpResponseMessage : IHalHttpResponseMessage, IDisposable
	{
		private HalHttpResponseMessage(HttpResponseMessage response)
		{
			Message = response;

			if (response.Content.Headers.ContentType == null)
				return;

			var mediaType = response.Content.Headers.ContentType.MediaType;

			IsHalResponse = mediaType.Equals(MediaType.ApplicationHalPlusJson, StringComparison.OrdinalIgnoreCase);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public HttpResponseMessage Message { get; private set; }
		public bool IsHalResponse { get; }
		public IRootResourceObject Resource { get; private set; }

		public static async Task<IHalHttpResponseMessage> CreateAsync(HttpResponseMessage response, IHalJsonParser parser)
		{
			if (response == null)
				throw new ArgumentNullException(nameof(response));

			if (parser == null)
				throw new ArgumentNullException(nameof(parser));

			var message = new HalHttpResponseMessage(response);

			if (message.IsHalResponse)
			{
				var content = await response.Content.ReadAsStringAsync();

				if (content.Length > 0)
				{
					var result = parser.Parse(content);

					message.Resource = new RootResourceObject(result);
				}
				else
				{
					message.Resource = new RootResourceObject();
				}
			}

			return message;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing)
				return;

			if (Message == null)
				return;

			Message.Dispose();
			Message = null;
		}

		~HalHttpResponseMessage()
		{
			Dispose(false);
		}
	}
}