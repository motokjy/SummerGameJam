using UnityEngine;

public class SlimeSpawner : MonoBehaviour {
    public GameObject slimePrefab; // インスペクターでスライムプレハブを指定
    private bool hasSpawned = false;

    void Start() {
        if (!hasSpawned) {
            Instantiate(slimePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            hasSpawned = true;
        }
    }
}