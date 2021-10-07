using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text;
using UnityEngine;

public static class ExtensionMethods
{
   // src: https://gist.github.com/mattyellen/d63f1f557d08f7254345bff77bfdc8b3
   public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
   {
      var tcs = new TaskCompletionSource<object>();
      asyncOp.completed += obj => { tcs.SetResult(null); };
      return ((Task)tcs.Task).GetAwaiter();
   }

   // src: https://jasonwatmore.com/post/2020/09/12/c-encode-and-decode-base64-strings
   public static string EncodeBase64(this string value)
   {
      var valueBytes = Encoding.UTF8.GetBytes(value);
      return Convert.ToBase64String(valueBytes);
   }

   public static string DecodeBase64(this string value)
   {
      var valueBytes = System.Convert.FromBase64String(value);
      return Encoding.UTF8.GetString(valueBytes);
   }

   // source: https://stackoverflow.com/a/3210462/1956540
   public static string removeAllNonAlphanumericCharsExceptDashes(this string value)
   {
      // doesn't remove dashes "-"
      char[] arr = value.ToCharArray();
      arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c) || c == '-')));
      return new string(arr);
   }
}
