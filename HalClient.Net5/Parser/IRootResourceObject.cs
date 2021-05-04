using System;

namespace HalClient.Net5.Parser
{
	public interface IRootResourceObject : IResourceObject
	{
		Uri GetDocumentationUri(IHaveLinkRelation link);
	}
}