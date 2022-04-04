using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bottom;
    public Transform top;
    public SpriteRenderer flag;

    public GameHandler gameHanlder;
    void Start()
    {
        flag.transform.position = bottom.position;
    }

    // Update is called once per frame
    void Update()
    {
        flag.transform.position = Vector3.Lerp(bottom.position, top.position, gameHanlder.getAwarenessRatio());
    }
}
