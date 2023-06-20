using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;

    private PlayerSpriteRenderer activeRenderer;

    private DeathAnimation deathAnimation;
    private CapsuleCollider2D capsuleCollider;

    public AudioClip deathClip;

    public bool dead => deathAnimation.enabled;

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        activeRenderer = smallRenderer;
    }

    public void Hit()
    {
        if (!dead)
        {
                Death();
        }
    }

    private void Death()
    {
        smallRenderer.enabled = false;
        deathAnimation.enabled = true;

        AudioSource.PlayClipAtPoint(deathClip, transform.position);

        GameManager.instance.ResetLevel(3f);
    }   
    
}
