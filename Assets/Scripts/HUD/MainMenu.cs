using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject MainMenuGO;
    GameObject Credits;

    void Awake() {
        this.MainMenuGO = this.transform.Find("MainMenu").gameObject;
        this.Credits = this.transform.Find("Credits").gameObject;
    }

    public void StartGame() {
        Debug.Log("StartGame");
        SceneManager.LoadScene("Farm");
    } // TODO

    public void ShowCredits() {
        this.MainMenuGO.SetActive(false);
        this.Credits.SetActive(true);
    }

    public void ShowMainMenu() {
        this.MainMenuGO.SetActive(true);
        this.Credits.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
