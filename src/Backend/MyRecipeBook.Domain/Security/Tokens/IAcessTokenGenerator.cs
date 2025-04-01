namespace MyRecipeBook.Domain.Security.Tokens;

public interface IAcessTokenGenerator
{
    public string Generate(Guid userIdentifier);
}
