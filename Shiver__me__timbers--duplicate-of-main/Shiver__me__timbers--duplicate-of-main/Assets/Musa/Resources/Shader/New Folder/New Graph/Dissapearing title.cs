using UnityEngine;

public class Dissapearingtitle : MonoBehaviour
{
    private Animator anim;
    public float dist;
    public GameObject Target;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("PPlayer").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        dist = Vector3.Distance(player.position, Target.transform.position);
        if (dist > 0)
        {
            anim.Play("Blinking");
        }

    }
}
