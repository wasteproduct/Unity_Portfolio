using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public GameObject focus;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(30.0f, 45.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = focus.GetComponent<TestPlayerDungeonSettings>().CameraFocus.transform.position + offset;
        //this.transform.position = focus.position + offset;
    }
}
