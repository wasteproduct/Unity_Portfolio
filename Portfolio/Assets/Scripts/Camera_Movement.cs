using UnityEngine;
using Player;

public class Camera_Movement : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(30.0f, 45.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.GetComponent<Player_DungeonSettings>().Captain.transform.position + offset;
    }
}
