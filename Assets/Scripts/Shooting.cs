using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public GameObject slash;
    public Transform bulletTransform;
    public bool canFire;
    public bool canSlash;
    private float timer;
    public float timeBetweenFiring;
    public float timeBetweenSlashing;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                canSlash = true;
                timer = 0;
            }
        }
        if(!canSlash && canFire == true)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenSlashing)
            {
                canSlash = true;
                timer = 0;
            }
        }
        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            canSlash=false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }

        if(Input.GetMouseButtonDown(1) && canSlash)
        {
            canSlash=false;
            Instantiate(slash, bulletTransform.position, Quaternion.identity);
        }
    }
}
