using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Manages all the text and button inputs
// Also acts like the main manager script for the game.
public class UIInputManager : MonoBehaviour
{
   public Button LoginSignupButton;
   public Button StartButton;
   public Button LogoutButton;

   private AuthenticationManager _authenticationManager;
   private GameObject _unauthInterface;
   private GameObject _authInterface;
   private GameObject _loading;
   private GameObject _welcome;
   private GameObject _confirmEmail;

   // WARNING: these fields and the below #defines are for development and testing the code exchange used in the social login.
   // Only for Editor mode, I do not recommend this manual code input method for production!
   public Button urlWithCodeButton;
   public InputField urlWithCodeField;

   private void displayComponentsFromAuthStatus(bool authStatus)
   {
      if (authStatus)
      {
         // Debug.Log("User authenticated, show welcome screen with options");
         _loading.SetActive(false);
         _unauthInterface.SetActive(false);
         _authInterface.SetActive(true);
      }
      else
      {
         // Debug.Log("User not authenticated, activate/stay on login scene");
         _loading.SetActive(false);
         _unauthInterface.SetActive(true);
         _authInterface.SetActive(false);
      }
   }

   public async void ProcessDeepLink(string deepLinkUrl)
   {
      // TODO: add some validation

      // Debug.Log("UIInputManager.ProcessDeepLink: " + deepLinkUrl);
      bool exchangeSuccess = await _authenticationManager.ExchangeAuthCodeForAccessToken(deepLinkUrl);

      if (exchangeSuccess)
      {
         _unauthInterface.SetActive(false);
         _authInterface.SetActive(true);
      }
      // TODO: else show error message in UI
   }

   private void onLoginClicked()
   {
      Debug.Log("onLoginClicked ");
      string loginUrl = _authenticationManager.GetLoginUrl();
      Application.OpenURL(loginUrl);
   }

   private void onLogoutClick()
   {
      _authenticationManager.Logout();
      displayComponentsFromAuthStatus(false);
   }

   private void onStartClick()
   {
      SceneManager.LoadScene("GameScene");
      Debug.Log("Changed to GameScene");
   }

   private async void RefreshToken()
   {
      bool successfulRefresh = await _authenticationManager.CallRefreshTokenEndpoint();
      displayComponentsFromAuthStatus(successfulRefresh);
   }

   void Start()
   {
      Debug.Log("UIInputManager: Start");
      // check if user is already authenticated 
      // We perform the refresh here to keep our user's session alive so they don't have to keep logging in.
      RefreshToken();

      LoginSignupButton.onClick.AddListener(onLoginClicked);
      StartButton.onClick.AddListener(onStartClick);
      LogoutButton.onClick.AddListener(onLogoutClick);

#if UNITY_EDITOR
      // WARNING: For development and testing of the code exchange. Enabled only for editor mode.
      urlWithCodeButton.onClick.AddListener(onCodeClick);
#endif
   }

   void Awake()
   {
      _unauthInterface = GameObject.Find("UnauthInterface");
      _authInterface = GameObject.Find("AuthInterface");
      _loading = GameObject.Find("Loading");
      _welcome = GameObject.Find("Welcome");

      _unauthInterface.SetActive(false); // start as false so we don't just show the login screen during attempted token refresh
      _authInterface.SetActive(false);

      _authenticationManager = FindObjectOfType<AuthenticationManager>();

#if !UNITY_EDITOR
      // WARNING: For development and testing of the code exchange. Hide these when NOT in editor mode.
      urlWithCodeButton.gameObject.SetActive(false);
      urlWithCodeField.gameObject.SetActive(false);
#endif
   }

#if UNITY_EDITOR
   // WARNING: For development and testing of the code exchange. Enabled only for editor mode.
   private void onCodeClick()
   {
      if (urlWithCodeField && urlWithCodeField.text != "")
      {
         ProcessDeepLink(urlWithCodeField.text);
      }
   }
#endif
}
