namespace HalClient.Net5.Parser
{
	public interface IHalJsonParser
	{
		HalJsonParseResult Parse(string json);
	}
}