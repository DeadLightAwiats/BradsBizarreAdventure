using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    [HideInInspector]
    public float currentHealth;
    private Animator anim;
    private bool Dead;
    private LayerMask Died;
    private LayerMask Player;

    [Header("Iframes")]
    [SerializeField] private float invulnerableDuration;
    [SerializeField] private float numberOffFlashes;
    private SpriteRenderer spriteRend;
    private PlayerMovement playerMovement;
    private Health Phealth;
    [Header("Components")]
    private Behaviour[] components;

    [Header("Audio")]
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip die;
    [SerializeField] private AudioClip respawn;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!Dead)
            {
                anim.SetTrigger("Die");

                if(GetComponent<PlayerMovement>() != null)
                {
                   GetComponent<PlayerMovement>().enabled = false;
                }

                Dead = true;
            }
        }
    }
   
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
           yield return new WaitForSeconds(invulnerableDuration/ (numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerableDuration / (numberOffFlashes * 2));
        }
        //Invulerable Duration
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }
}
