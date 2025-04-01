using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Infrastructure.Security.Tokens.Access.Generator;

namespace CommonTestUtilities.Tokens;

public class JwtTokenGeneratorBuilder
{
    public static IAcessTokenGenerator Build() => new JtwTokenGenerator(expirationTimeMinutes: 5, signingKey: "tttttttttttttttttttttttttttttttt");
}
