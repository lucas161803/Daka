using Daka.WebApi.Middleware;
using Microsoft.AspNetCore.Http;

namespace Daka.WebApi.Test;

public class AuthorizationHeaderMiddlewareTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NoHeader_Should_ThrowExceptionAndMessage()
    {
        var target = new AuthorizationHeaderMiddleware(_ => null!);
        var httpContext = new DefaultHttpContext();

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async Task() => await target.Invoke(httpContext));
        Assert.That(exception?.Message, Is.EqualTo("Missing header !!"));
    }
}