using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Object PlayerPrefab;

    private void Awake() {
        Object player = Instantiate(PlayerPrefab, this.transform.position, Quaternion.identity);

        player.name = "Player";
    }
}
