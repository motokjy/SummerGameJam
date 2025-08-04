using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class GameSystem : MonoBehaviour {
 
	public void StartGame() {
		SceneManager.LoadScene ("Ingame");
	}
}