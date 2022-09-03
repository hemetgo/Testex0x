using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
	public GameObject gameOverGui;

	public void GameOver()
	{
		gameOverGui.SetActive(true);
	}

    public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
