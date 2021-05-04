using System;
using Tavis.UriTemplates;

namespace HalClient.Net5.Parser
{
	public interface ILinkObject : IHaveLinkRelation
	{
		Uri Href { get; }
		bool Templated { get; }
		string Template { get; }
		string Type { get; }
		Uri Deprecation { get; }
		string Name { get; }
		Uri Profile { get; }
		string Title { get; }
		string HrefLang { get; }

		ILinkObject ResolveTemplated(Func<UriTemplate, string> hrefResolver);
		// FUTURE: IANA rels
		// FUTURE: Rel as Uri
		// FUTURE: Curies
		// FUTURE: Support multiple of these as specified here: http://tools.ietf.org/html/rfc5988#section-5.4 
	}
}