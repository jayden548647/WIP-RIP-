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
    public bool paused;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused == false)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    canSlash = true;
                    timer = 0;
                }
            }
            if (!canSlash && canFire == true)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenSlashing)
                {
                    canSlash = true;
                    timer = 0;
                }
            }
            if (Input.GetMouseButtonDown(0) && canFire && Manager.instance.GetRangeUpgrade() != 0)
            {
                if (Manager.instance.GetRangeUpgrade() < 4)
                {
                    canFire = false;
                    canSlash = false;
                }
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                MusicManager.instance.PlaySFX("Throw");
            }

            if (Input.GetMouseButtonDown(1) && canSlash)
            {
                canSlash = false;
                Instantiate(slash, bulletTransform.position, Quaternion.identity);
                MusicManager.instance.PlaySFX("Slash");
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
        }
    }

    public void Unpause()
    {
        paused = false;
    }
}
