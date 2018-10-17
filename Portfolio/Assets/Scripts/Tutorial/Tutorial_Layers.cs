using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Layers : MonoBehaviour
{
    public Manager_Layers layers;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //this.gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
    }
}
