[System.Serializable]
public class BADAuthenticationResultType
{
   public string access_token;
   public int expires_in;
   public string id_token;
   public string refresh_token;
   public string token_type;

   public string getAccessToken()
   {
      return access_token;
   }

   public void setAccessToken(string accessToken)
   {
      access_token = accessToken;
   }

   public int getExpiresIn()
   {
      return expires_in;
   }

   public void setExpiresIn(int expiresIn)
   {
      expires_in = expiresIn;
   }

   public string getIdToken()
   {
      return id_token;
   }

   public void setIdToken(string idToken)
   {
      id_token = idToken;
   }

   public string getRefreshToken()
   {
      return refresh_token;
   }

   public void setRefreshToken(string refreshToken)
   {
      refresh_token = refreshToken;
   }

   public string getTokenType()
   {
      return token_type;
   }

   public void setTokenType(string tokenType)
   {
      token_type = tokenType;
   }
}
