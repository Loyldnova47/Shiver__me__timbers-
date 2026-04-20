using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    private float speed = 10.0f;
    public Vector3 LaunchOffset;
    public float rotationSpeed = 100.0f;
    public bool Thrown;

    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    Vector3 worldPosition;
    public bool targetReached = false;



    private void Start()
    {
        
    }
    private void Update()
    {
        ////An attempt to tie projectile aim to mouse direction

        //Vector2 aimDirection;

        //// Get the mouse delta. This is not in the range -1...1
        //float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //float v = verticalSpeed * Input.GetAxis("Mouse Y");

        //transform.Rotate(v, h, 0);

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0;

        //Vector2 direction = (mousePos - transform.position).normalized;

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0, 0.angle);


        ShootMe();

    }


    void ShootMe()
    {

        Destroy(gameObject, 10.0f);
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);


        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.z = 0f;




        if ((transform.position != worldPosition)&&targetReached==false)
        {
            transform.position = Vector2.MoveTowards(transform.position, worldPosition, speed * Time.deltaTime);
            Debug.Log("Here");

            if (transform.position == worldPosition)
            {
                Debug.Log("Stop");
                transform.position = Vector2.MoveTowards(transform.position, worldPosition, 0 * Time.deltaTime);
                targetReached = true;
            }
        }


    }

    public GameObject hitEffect;

    //void OnCollisionEnter2D(Collision2D collison)
    //{
    //    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

    //    Destroy(gameObject, 5f);
        
    //}





}
