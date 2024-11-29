using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private static GameObject localInstante;

    private Rigidbody rb;
    [SerializeField] private float speed;

    public static GameObject LocalInstance { get { return localInstante; } }


    private void Awake()
    {
        if(photonView.IsMine)
        {
            localInstante = gameObject;
        }
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!photonView.IsMine || !PhotonNetwork.IsConnected)
        {
            return;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("vertical");
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
    }
}
