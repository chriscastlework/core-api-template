namespace CoreGrainInterfaces;


public interface ICreateQuote : Orleans.IGrainWithGuidKey
{
    Task<string> SayHello(string greeting);
}
