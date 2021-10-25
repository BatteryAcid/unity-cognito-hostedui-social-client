using System;
using UnityEngine;

// Handles deep link events into the Unity app on a mobile device.  Not tested or supported on desktop applications.
// Class is linked to ProcessDeepLinkContainer in Unity Editor
// source: https://docs.unity3d.com/Manual/enabling-deep-linking.html
public class ProcessDeepLinkManager : MonoBehaviour
{
   public static ProcessDeepLinkManager Instance { get; private set; }

   private string deeplinkURL;
   private UIInputManager _uiInputManager;

   private void onDeepLinkActivated(string url)
   {
      // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
      deeplinkURL = url;

      _uiInputManager = FindObjectOfType<UIInputManager>();
      _uiInputManager.ProcessDeepLink(deeplinkURL);
   }

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;

         // setup deeplink callback
         Application.deepLinkActivated += onDeepLinkActivated;

         if (!String.IsNullOrEmpty(Application.absoluteURL))
         {
            // Debug.Log("deep link: " + Application.absoluteURL);
            onDeepLinkActivated(Application.absoluteURL);
         }
         else
         {
            deeplinkURL = "NONE";
         }

         // we want to reuse this object between scene loading, which makes sure it is available when receiving a deep link url 
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         // I think this would destroy a new instance that was attempted to be created when one already exists
         Destroy(gameObject);
      }
   }

   public string GetDeepLink()
   {
      return deeplinkURL;
   }
}