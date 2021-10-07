[System.Serializable]
public class TokenPayload
{
   public string sub;

   public string getSub()
   {
      return sub;
   }

   public void setSub(string subIn)
   {
      sub = subIn;
   }
}
