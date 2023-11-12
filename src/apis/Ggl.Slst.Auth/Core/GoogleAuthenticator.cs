using System.Text.Json;
using Ggl.Slst.Auth.Extensions;
using Google.Apis.Auth;

namespace Ggl.Slst.Auth.Core;

public sealed class GoogleAuthenticator : IGoogleAuthenticator
{
    private readonly string clientId = "533477315500-ruouoj52t363pc5v2t9thu27ha2lrnr6.apps.googleusercontent.com";
    private readonly string clientSecret = "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";
    // private readonly string redirectUri = "http://localhost:5079/signin-oidc";
    private readonly string redirectUri = "http://localhost:5079/ext/auth";
    private readonly string tokenEndpoint = "https://oauth2.googleapis.com/token";

    public async Task GoogleSignIn()
    {
        // eyJhbGciOiJSUzI1NiIsImtpZCI6ImY4MzNlOGE3ZmUzZmU0Yjg3ODk0ODIxOWExNjg0YWZhMzczY2E4NmYiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhenAiOiI1MzM0NzczMTU1MDAtcnVvdW9qNTJ0MzYzcGM1djJ0OXRodTI3aGEybHJucjYuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiI1MzM0NzczMTU1MDAtcnVvdW9qNTJ0MzYzcGM1djJ0OXRodTI3aGEybHJucjYuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDU2NzIxNjIyNDQ2OTQ2NzU0NDAiLCJhdF9oYXNoIjoieFBhVVluYnU2bVYweE9xemdDazdmdyIsImlhdCI6MTY5OTc3NTQ3MCwiZXhwIjoxNjk5Nzc5MDcwfQ.dNrT-B_AUbp0duYRj43iRqnH09yK31wckcKVVim8onicSVCxbcDN_E8RnwgLU-rrNk7XlKh7yz2qeDOOldOEtNUhX5i6IVuLkZbWstg_kypbzbZlV7b1Iyjxtu3ItJXRp8rZAPu27UlMLPGuB_G8fd6gaPj9j1mTpF1hhNJglnjfaYxNsbsDUNbG7ZRP8ie2OLL0pbQmDTaK-JLOlm4Xkw6acnzyk_w1RMk5kttO7eF8rh_8pSe5k4c4tGfd7ymqdGWs6mznaIH0Mi_dESDw-cLRPb_9p5htrZHQmupJPZR_Ws3jlPbflGgizz1Jxoi4t0ADj7zTmZfBE17fwGZ0_w";
        // string idToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImY4MzNlOGE3ZmUzZmU0Yjg3ODk0ODIxOWExNjg0YWZhMzczY2E4NmYiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhenAiOiI1MzM0NzczMTU1MDAtcnVvdW9qNTJ0MzYzcGM1djJ0OXRodTI3aGEybHJucjYuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiI1MzM0NzczMTU1MDAtcnVvdW9qNTJ0MzYzcGM1djJ0OXRodTI3aGEybHJucjYuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDU2NzIxNjIyNDQ2OTQ2NzU0NDAiLCJlbWFpbCI6InN0aXBjaWNoLnNpbW9uQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJhdF9oYXNoIjoiTlY3LVNMNGxSX2N1UnpWblBIMEdQZyIsIm5hbWUiOiJTaW1vbiBTdGlwY2ljaCIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NJTTVNQTloR2R4VEx4VHVXY3pJUjZ4QjJ6M3EyOF9MbXJYNkw4S1FZZDdxM2c9czk2LWMiLCJnaXZlbl9uYW1lIjoiU2ltb24iLCJmYW1pbHlfbmFtZSI6IlN0aXBjaWNoIiwibG9jYWxlIjoiZW4tR0IiLCJpYXQiOjE2OTk3NzY2MTgsImV4cCI6MTY5OTc4MDIxOH0.RZSxG0TNy2IVXWz_KDO4DZQkU7nlquueZ8yMocv2wHBAUoSfzvexmeHjgD_zbTupcrlWxHmF85_84rTPXk1UFEin-UGiDJWCppNp5cmvm9P_I2xqx9WlLIqzLee-yW-Hnpkg6l94eShqNO5zWxokQHm--eXR5X7UUckblaSVRYlbPF3PBqSgRzZk4l29SqjGTJQaTdufMG17qTCFwR-ktXl6swh_QIsQmZ0WrN8bwN3rbl-zJ0Dk8-iRTD31i-eCnvl2xh_tqLaEVaBRIh7HjLjfdp5zSBiUmz2z_UiZzE78cSOKPwquar7AkrHIDgBll5SKWH9RAnHJYb5TUwLEiA";
        // string idToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImY4MzNlOGE3ZmUzZmU0Yjg3ODk0ODIxOWExNjg0YWZhMzczY2E4NmYiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhenAiOiI1MzM0NzczMTU1MDAtcnVvdW9qNTJ0MzYzcGM1djJ0OXRodTI3aGEybHJucjYuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiI1MzM0NzczMTU1MDAtcnVvdW9qNTJ0MzYzcGM1djJ0OXRodTI3aGEybHJucjYuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDU2NzIxNjIyNDQ2OTQ2NzU0NDAiLCJlbWFpbCI6InN0aXBjaWNoLnNpbW9uQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJhdF9oYXNoIjoiU3VsZ2c2UFNXZ2RJY0xoaGgxQ1c5ZyIsIm5hbWUiOiJTaW1vbiBTdGlwY2ljaCIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NJTTVNQTloR2R4VEx4VHVXY3pJUjZ4QjJ6M3EyOF9MbXJYNkw4S1FZZDdxM2c9czk2LWMiLCJnaXZlbl9uYW1lIjoiU2ltb24iLCJmYW1pbHlfbmFtZSI6IlN0aXBjaWNoIiwibG9jYWxlIjoiZW4tR0IiLCJpYXQiOjE2OTk3ODI1MDAsImV4cCI6MTY5OTc4NjEwMH0.e2Q8sl3DSTtFS031d_4tkO7dtnXACnv-K2JfIFOz_6TfUjvL_3haJEhB_ePaCKwSnen294ZKTowjx-GDS4pA3QEAGaGUqofbOm_Yuxd0xhhtcj7HcfbOaTjzHLtYwXHirUMwRQmr-xr8YdtzEouv343p6m8mWvGzioIywyx-mOAtu-gIKX4OnLzg5SkX9KT694OPhE0IuONMiXIkhs7-dISStxL4TYE8oox-92h-Qv3q7TSUlXebe55Ky8Ga2GjSJVinPICgjOgZEJPcOv2MMjSiBVzXZ2gO3uOqoo8_GhLX1uJ5aklUmhTx__kYuaNHO3bfy-rWMEcvM-1kPcnFBQ";
        string idToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImY4MzNlOGE3ZmUzZmU0Yjg3ODk0ODIxOWExNjg0YWZhMzczY2E4NmYiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhenAiOiI1MzM0NzczMTU1MDAtcnVvdW9qNTJ0MzYzcGM1djJ0OXRodTI3aGEybHJucjYuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiI1MzM0NzczMTU1MDAtcnVvdW9qNTJ0MzYzcGM1djJ0OXRodTI3aGEybHJucjYuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDU2NzIxNjIyNDQ2OTQ2NzU0NDAiLCJhdF9oYXNoIjoieFBhVVluYnU2bVYweE9xemdDazdmdyIsImlhdCI6MTY5OTc3NTQ3MCwiZXhwIjoxNjk5Nzc5MDcwfQ.dNrT-B_AUbp0duYRj43iRqnH09yK31wckcKVVim8onicSVCxbcDN_E8RnwgLU-rrNk7XlKh7yz2qeDOOldOEtNUhX5i6IVuLkZbWstg_kypbzbZlV7b1Iyjxtu3ItJXRp8rZAPu27UlMLPGuB_G8fd6gaPj9j1mTpF1hhNJglnjfaYxNsbsDUNbG7ZRP8ie2OLL0pbQmDTaK-JLOlm4Xkw6acnzyk_w1RMk5kttO7eF8rh_8pSe5k4c4tGfd7ymqdGWs6mznaIH0Mi_dESDw-cLRPb_9p5htrZHQmupJPZR_Ws3jlPbflGgizz1Jxoi4t0ADj7zTmZfBE17fwGZ0_w";

        GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(idToken, new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new[] { clientId },
        });

        Console.WriteLine(JsonSerializer.Serialize(payload));
    }

    public async Task<ExtAccessTokenResp> GetAccessTokenFromCodeAsync(string code)
    {
        var parameters = new Dictionary<string, string>
        {
            { "code", code },
            { "client_id", clientId },
            { "client_secret", clientSecret },
            { "redirect_uri", redirectUri },
            { "grant_type", "authorization_code" },
            { "access_type", "offline" }
        };

        using var httpClient = new HttpClient();
        var resp = await httpClient.PostAsync(tokenEndpoint, parameters.ToFormUrlEncodedContent());
        var content = await resp.Content.ReadAsStringAsync();

        Console.WriteLine(content);

        var obj = JsonSerializer.Deserialize<ExtAccessTokenResp>(content) ?? throw new Exception("Failed to deserialize response");

        return obj;
    }
}