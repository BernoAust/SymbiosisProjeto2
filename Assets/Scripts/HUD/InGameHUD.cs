using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    GameObject Joysticks;
    GameObject PauseMenu;
    GameObject DeathMenu;
    Text PointsLabel;
    Slider HealthSlider;
    Image HealthFilling;

    public Gradient HealthGradient;

    void Start() {
        this.PauseMenu = this.transform.Find("GameHUD/PauseMenu").gameObject;
        this.Joysticks = this.transform.Find("Joystick").gameObject;
        this.DeathMenu = this.transform.Find("GameHUD/DeathMenu").gameObject;
        this.PointsLabel = this.transform.Find("GameHUD/Points").gameObject.GetComponent<Text>();
        this.HealthSlider = this.transform.Find("GameHUD/LifeBar").gameObject.GetComponent<Slider>();
        this.HealthFilling = this.transform.Find("GameHUD/LifeBar/Inner").gameObject.GetComponent<Image>();

        this.HealthSlider.maxValue = PlayerBase.Health;
        this.HealthSlider.value = PlayerBase.Health;
        this.HealthFilling.color = this.HealthGradient.Evaluate(1f);

        PlayerEvents.updatePlayerPoints.AddListener(UpdatePoints);
        PlayerEvents.updatePlayerHealth.AddListener(UpdateHealth);
        PlayerEvents.playerDeath.AddListener(ShowDeathMenu);
    }

    public void OnPausePress() {
        AudioEvent.playAudio.Invoke("HUD_Click");
        Time.timeScale = 0f;
        this.PauseMenu.SetActive(true);
    }

    public void OnContinuePress() {
        AudioEvent.playAudio.Invoke("HUD_Click");
        this.PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnExitPress() {
        AudioEvent.playAudio.Invoke("HUD_Click");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    void UpdatePoints(int points) {
        this.PointsLabel.text = points.ToString();
    }

    void UpdateHealth(int health) {
        this.HealthSlider.value = health;
        this.HealthFilling.color = this.HealthGradient.Evaluate(this.HealthSlider.normalizedValue);
    }

    public void OnNextLevelPress() {
        AudioEvent.playAudio.Invoke("HUD_Click");
        SceneManager.LoadScene("City");
        Time.timeScale = 1f;
    }

    void ShowDeathMenu() {
        this.Joysticks.SetActive(false);
        this.DeathMenu.SetActive(true);
    }
}
