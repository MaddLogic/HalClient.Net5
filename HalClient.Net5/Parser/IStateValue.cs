namespace HalClient.Net5.Parser
{
	public interface IStateValue
	{
		string Name { get; }
		string Value { get; }
		string Type { get; }
	}
}