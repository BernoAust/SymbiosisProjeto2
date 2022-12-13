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
        AudioEvent.playAudio.Invoke("HUD_Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowCredits() {
        AudioEvent.playAudio.Invoke("HUD_Click");
        this.MainMenuGO.SetActive(false);
        this.Credits.SetActive(true);
    }

    public void ShowMainMenu() {
        AudioEvent.playAudio.Invoke("HUD_Click");
        this.MainMenuGO.SetActive(true);
        this.Credits.SetActive(false);
    }

    public void ExitGame() {
        AudioEvent.playAudio.Invoke("HUD_Click");
        Application.Quit();
    }
}
