using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Rigidbody2D Rb;
    public AudioClip PlayerJumpAudio;

    float force = 5;

    // Awake is called refer to data in other scripts
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.IsGameOver && !GameplayScripts.Instance.IsPausePanelOn)      //In this condition game over is "FALSE" then>>>
        {
            if (Input.GetMouseButtonDown(0))
            {
                Rb.velocity = Vector2.up * force;
                PlayerJumpSound();
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)      //In this function Player collide on taged object then>>>
    {
        if (collision.gameObject.tag == "Obstacel" || collision.gameObject.tag == "Ground")
        {
            GameManager.Instance.IsGameOver = true;
        }

    }

    public void PlayerJumpSound()
    {
        GameplayScripts.Instance.GameAudio.PlayOneShot(PlayerJumpAudio);
    }
}