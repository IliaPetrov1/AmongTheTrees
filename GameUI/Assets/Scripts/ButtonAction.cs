using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
	public Button button;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);		
	}

	void TaskOnClick()
	{
		var btnName = EventSystem.current.currentSelectedGameObject.name;
		switch (btnName)
		{
			case "PlayButton": SceneManager.LoadScene("GameSetupModeMenu", LoadSceneMode.Single); break;
			case "QuitButton": Application.Quit(); break;
			case "GSetModeBackButton": SceneManager.LoadScene("WelcomeScreen", LoadSceneMode.Single); break;
			case "LModeBackButton": SceneManager.LoadScene("GameSetupModeMenu", LoadSceneMode.Single); break;
			case "LocalPlayButton": SceneManager.LoadScene("LocalGameScreen", LoadSceneMode.Single); break;
			case "OnlinePlayButton": SceneManager.LoadScene("OnlineGameScreen", LoadSceneMode.Single); break;
			case "JoinCodeButton":
			case "FreeplayButton": SceneManager.LoadScene("MapScreen", LoadSceneMode.Single); break;
			default: break;
		}


	}
}
