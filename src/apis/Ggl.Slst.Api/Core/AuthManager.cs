namespace Ggl.Slst.Api.Core;

internal class AuthManager : BaseManager, IManager<AuthReq, AuthResp>
{
    private readonly IGoogleAuthenticator _googleAuthenticator;
    private readonly IJwtService _jwtService; 

    public AuthManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess,
        ITypeMapper typeMapper,
        IGoogleAuthenticator googleAuthenticator,
        IJwtService jwtService
    ) : base(writeDbResourceAccess, readDbResourceAccess, typeMapper)
    {
        this._googleAuthenticator = googleAuthenticator ?? throw new ArgumentNullException(nameof(googleAuthenticator));
        this._jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
    }
    
    public async Task<AuthResp> ManageAsync(
        AuthReq req,
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        var accessToken = await this._googleAuthenticator.GetAccessTokenFromCodeAsync(req.ExtAuthCode);
        var user = await this._googleAuthenticator.ValidateIdTokenAsync(accessToken.IdToken);

        var dbCmd = this._TypeMapper.Map<User, UpsertUsrDbCmd>(ref user);
        await this._WriteDbResourceAccess.ExecuteAsync(dbCmd, cancellationToken);
        var tokenDbCmd = new UpsertExtAccessTokenDbCmd 
        { 
            UsrId = dbCmd.Result.Id,
            Token = accessToken.AccessToken,
            RefreshToken = accessToken.RefreshToken,
        };
        user.Id = dbCmd.Result.Id;
        await this._WriteDbResourceAccess.ExecuteAsync(tokenDbCmd, cancellationToken);

        var claims = this._jwtService.BuildClaims(ref user);
        string jwt = this._jwtService.BuildToken(ref claims);

        return new AuthResp { Jwt = jwt };
    }
}