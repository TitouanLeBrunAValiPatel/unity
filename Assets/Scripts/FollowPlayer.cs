using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private readonly Vector3 _cameraPosition = new Vector3(2.70000005f,22.2000008f,-31.5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + _cameraPosition;

    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
