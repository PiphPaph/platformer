using UnityEngine;

public class FireballWarning : MonoBehaviour
{
    private SpawnFireballs _fireballProperty;
    public GameObject warningIndication;
    public GameObject cam;
    public Vector2 warningSpawnPosition;
    private float _destroyWarningIndication = 0.8f;
    private float _leftDistanceForSpawn = 8.5f;
    void Start()
    {
        _fireballProperty = GetComponent<SpawnFireballs>();
        cam = GameObject.Find("Main Camera");
    }
    public void SpawnWarning()
    {
            warningSpawnPosition = new Vector2(cam.transform.position.x + _leftDistanceForSpawn, _fireballProperty.spawnPosition.y);
            var destroyWarningIndication = Instantiate(warningIndication, warningSpawnPosition, Quaternion.identity);
            Destroy(destroyWarningIndication, _destroyWarningIndication);
    }
}
