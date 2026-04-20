using JetBrains.Annotations;
using UnityEngine;

public class ShootDistraction : MonoBehaviour
{

    public GameObject distractionPrefab;
    public Transform spawnPoint;
    float aimScope = 0.0f;

    public float attackTime;
    private float attackTimeCounter;

    private bool attacking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawnDistraction();

        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            attacking = true;
            attackTimeCounter = attackTime;

            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + -90f);
            GameObject projectile = (GameObject)Instantiate(distractionPrefab, myPos, rotation);
        }
        

        if (attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter < 0)
        {
            attacking = false;
        }*/

    }



    void SpawnDistraction()
    {
        Vector3 mousePos = Input.mousePosition;


        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        worldPosition.z = 0f;
        Vector2 direction = (Vector2)worldPosition - (Vector2)spawnPoint.transform.position;

        // 3. Calculate angle and apply rotation (assuming sprite faces Right by default)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spawnPoint.transform.rotation = Quaternion.Euler(0, 0, angle);



        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject clone=Instantiate(distractionPrefab, spawnPoint.position, Quaternion.identity);
            Destroy(clone, 5f);
        }
       

    }


}
