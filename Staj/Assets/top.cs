using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    public UnityEngine.UI.Text zaman, durum;
    public UnityEngine.UI.Button buton;
    private Rigidbody rg;
    public float H�z = 3.5f;
    float zamanSayaci = 20;
    bool oyunDevam = true;
    bool oyunTamam = false;
    


    void Start()
    {
        rg = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * H�z);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
        
    }

    
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if(!oyunTamam)
        {
            durum.text = "oyun tamamlanamad�";
            buton.gameObject.SetActive(true);
        }
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
        }
 
    }
    void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;
        if (objIsmi.Equals("Bitis"))
        {
            //print("tebriks");
            oyunTamam = true;
            durum.text = "tebrikler! kazand�n�z..";
            buton.gameObject.SetActive(true);
        }
        
       

        
    }
}
