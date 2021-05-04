using System.Net.Http;
using HalClient.Net5.Parser;

namespace HalClient.Net5
{
	public interface IHalHttpResponseMessage
	{
		HttpResponseMessage Message { get; }
		bool IsHalResponse { get; }
		IRootResourceObject Resource { get; }
	}
}