using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public void RestartScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void ClickExit()     
    {
    	Application.Quit();
    }


}
