namespace Ggl.Slst.Auth.Integration.Tests;

public class GoogleTests
{
    public GoogleTests() : base() { }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();

        var g = new GoogleAuthenticator();

        await g.GoogleSignIn();
    }
}