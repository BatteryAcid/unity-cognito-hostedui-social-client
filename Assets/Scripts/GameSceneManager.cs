using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
   public Button MainMenuButton;
   public Button CallApiButton;

   private ApiManager _apiManager;

   private void onMainMenuClick()
   {
      SceneManager.LoadScene("LoginScene");
      Debug.Log("Changed to Login scene");
   }

   private void onCallApiClick()
   {
      Debug.Log("onCallApiClick");
      _apiManager.CallTestApi();
   }

   void Start()
   {
      // ignore setup during switch back to login scene
      if (MainMenuButton != null)
      {
         MainMenuButton.onClick.AddListener(onMainMenuClick);
      }

      // ignore setup during switch back to login scene
      if (CallApiButton != null)
      {
         CallApiButton.onClick.AddListener(onCallApiClick);
      }

      _apiManager = FindObjectOfType<ApiManager>();
   }
}
