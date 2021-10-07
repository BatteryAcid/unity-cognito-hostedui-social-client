using UnityEngine;

public class AuthUtilities
{
   public static string GetUserSubFromIdToken(string idToken)
   {
      string[] parts = idToken.Split('.');
      string payload = parts[1];

      // add padding if necessary, src: https://stackoverflow.com/a/1228744/1956540
      payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');

      string payloadJson = payload.DecodeBase64();

      TokenPayload payloadData = JsonUtility.FromJson<TokenPayload>(payloadJson);
      // Debug.Log(payloadData.getSub());
      return payloadData.getSub();
   }
}
