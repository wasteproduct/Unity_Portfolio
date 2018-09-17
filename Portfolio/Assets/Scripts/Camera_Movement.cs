using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = new Vector3(-16.0f, 16.0f, -16.0f);

        this.transform.rotation = Quaternion.Euler(30.0f, 45.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.position + offset;
    }
}
