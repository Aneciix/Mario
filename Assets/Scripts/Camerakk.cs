using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerakk : MonoBehaviour
{
    public GameObject player;

    private float xplayer;

    public float xmin, xmax;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        xplayer = Mathf.Clamp(player.transform.position.x, xmin, xmax);
        transform.position = new Vector3(xplayer, transform.position.y, transform.position.z);
    }
}
