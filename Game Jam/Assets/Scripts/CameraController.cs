using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player ;
    private Vector3 offset;
    public float minX;
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
      offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      Vector3 setPosition = transform.position;
          setPosition.x = player.transform.position.x + offset.x;
          setPosition.z = player.transform.position.z + offset.z;
          transform.position = setPosition;
    }
}
