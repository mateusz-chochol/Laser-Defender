using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private static MenuManager menuManager;

    private void Awake() {
        if(menuManager == null) {
            menuManager = this;
        }
        else {
            DestroyObject(gameObject);
        }
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Debug.Log("Quiting the game");
    }
}
