using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimatorTrigger : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PPlayer"))
        {
            anim.SetTrigger("Flash");
            Debug.Log("Player entered! Animation triggered.");
        }
    }


}    
