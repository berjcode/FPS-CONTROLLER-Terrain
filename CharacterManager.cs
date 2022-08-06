using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    Rigidbody rb;
    Transform anaKamera, mermiYeri;
    public int Hiz = 5;
    float hizlanma = 5000f, yavaslamaSuresi = 5000f;
    float mermiHizi = 1000f;
    private Vector2 Hareket;
    private bool yerde = false;
    public float fareHassasiyeti = 2f;
    private Vector3 yavaslamaRef;
    public GameObject mermi;
    float dikey = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anaKamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        mermiYeri = GameObject.FindGameObjectWithTag("BulletSpawn").transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(mermiSure());
        }
        FareKontrol();
    }
    private void FixedUpdate()
    {
        HareketEt();
    }
    void HareketEt()
    {

        Hareket = new Vector2(rb.velocity.x, rb.velocity.z);
        if (Hareket.magnitude > Hiz)
        {
            Hareket = Hareket.normalized;
            Hareket *= Hiz;
        }
        rb.velocity = new Vector3(Hareket.x, rb.velocity.y, Hareket.y);
        if (yerde)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector3(0, rb.velocity.y, 0), ref yavaslamaRef, yavaslamaSuresi);
            rb.AddRelativeForce(Input.GetAxis("Horizontal") * hizlanma * Time.deltaTime, 0, Input.GetAxis("Vertical") * hizlanma * Time.deltaTime);
        }
        else
        {
            rb.AddRelativeForce(Input.GetAxis("Horizontal") * hizlanma / 2 * Time.deltaTime, 0, Input.GetAxis("Vertical") * hizlanma / 2 * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            yavaslamaSuresi = 0.5f;
        }
        else
        {
            yavaslamaSuresi = 0.1f;
        }

    }
    void FareKontrol()
    {

        float yatay = Input.GetAxis("Mouse X") * fareHassasiyeti;
        dikey += Input.GetAxis("Mouse Y") * fareHassasiyeti;
        dikey = Mathf.Clamp(dikey, -60, 80);
        anaKamera.transform.localRotation = Quaternion.Euler(-dikey, 0f, 0f);
        transform.Rotate(0f, yatay, 0f);
    }
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector2.Angle(contact.normal, Vector3.up) < 60)
            {
                yerde = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        yerde = false;
    }

    IEnumerator mermiSure()
    {

        GameObject mermiOlustu = Instantiate(mermi, mermiYeri.transform.position, mermiYeri.transform.rotation);
        mermiOlustu.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * mermiHizi);
        yield return new WaitForSeconds(1);
        Destroy(mermiOlustu);
    }

}
