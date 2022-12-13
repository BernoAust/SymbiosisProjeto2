using UnityEngine;

public class FarmSceneController : MonoBehaviour
{
    public int POINTS_TO_NEXT_LEVEL = 2000;

    public GameObject EndLevelScene;

    private void Awake() {
        PlayerEvents.updatePlayerPoints.AddListener(this.CheckPlayerPoints);
    }

    void CheckPlayerPoints(int points) {
        if (points >= POINTS_TO_NEXT_LEVEL) {
            Time.timeScale = 0;
            EndLevelScene.SetActive(true);
        }
    }
}
