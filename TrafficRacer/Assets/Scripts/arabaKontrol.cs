using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class arabaKontrol : MonoBehaviour
{
    //Canvaslarý yönetmek için gereken özellikler
    public Canvas baslangicEkrani;
    public Canvas gameoverEkrani;
    public Text gameOverSkor;
    public Text bestSkor;
    private int skor;
    private int ilkZaman = 0;

    //Sesler için
    public AudioSource bosta;
    public AudioSource demoGaz;
    public AudioSource demoFren;

    //Araba MOTOR Özellikleri
    public List<WheelCollider> tümTekerler;
    public List<WheelCollider> yonVerenTekerler;
    public float maxMotorTorku;
    public float maxFrenTorku;
    private bool frenAktif = true;
    public float maxDireksiyonAcisi;

    //Arbanýn hýz sýnýrlandýrmasý için gerekli deðiþkenler
    public float maxHiz;
    public float hiz;
    public Rigidbody rb;

    private bool oyunAcilisiMi = true;
    


    private void Awake()
    {
        Time.timeScale = 0; 
        skor = PlayerPrefs.GetInt("skor");
        bestSkor.text = ""+skor;
    }

    //Oyun canvas ekranlarý için butonlarýn iþlevleri
    public void oyunBaslat()
    {
        Time.timeScale = 1;
        baslangicEkrani.gameObject.SetActive(false);
        demoGaz.mute = false;
        ilkZaman = (int)Time.realtimeSinceStartup;
    }

    public void yenidenBaslat() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }

    public void Cikis() 
    {
        Debug.Log("Çýktýn");
        Application.Quit();
    }
    //Butonlarýn sonu

    private void frenDuzelt()
    {
        frenAktif = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ceza"))
        {
            frenAktif = false;
            Invoke("frenDuzelt", 10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "karsiArac" || collision.transform.tag == "barikat") 
        {
            gameoverEkrani.gameObject.SetActive(true);

            int skorPuan = ((int)Time.realtimeSinceStartup - ilkZaman)*5;
            gameOverSkor.text = "SKORUNUZ:" + skorPuan;

            if(skor < skorPuan) 
            {
                Debug.Log("ife girdi");
                PlayerPrefs.SetInt("skor", skorPuan);
                skor = skorPuan;
                bestSkor.text = "" + skor;
            }

            Debug.Log("girdi: "+gameoverEkrani.enabled);
            

            demoGaz.enabled = false;
            demoFren.enabled = false;
            bosta.enabled = false;
            gameObject.GetComponent<AudioSource>().enabled = false;
            
            Time.timeScale = 0;
        }
    }


    public void sesFonksiyon()
    {
        if (Input.GetKey(KeyCode.W))
        {
            demoGaz.mute = false;
            demoFren.mute = true;
            bosta.mute = true;
        }
        else if (Input.GetKey(KeyCode.S) && frenAktif)
        {
            demoFren.mute = false;
            demoGaz.mute = true;
            bosta.mute = true;
        }

        else
        {
            if (!baslangicEkrani.isActiveAndEnabled)
            {
                bosta.mute = false;
                demoGaz.mute = true;
                demoFren.mute = true;
            }
        }
    }


    public void tekerleriDondurme(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform tekerGoruntusu = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        tekerGoruntusu.transform.position = position;
        tekerGoruntusu.transform.rotation = rotation;
    }

    public void hizSinirlama() 
    {
        hiz = rb.velocity.magnitude;
        
        if(hiz > maxHiz) 
        {
            rb.velocity = maxHiz * rb.velocity.normalized;
        }
    }

    public void FixedUpdate()
    {
        sesFonksiyon();
        hizSinirlama();

        float motor = maxMotorTorku * Time.deltaTime * Input.GetAxis("Vertical");
        float fren = maxFrenTorku  * Time.deltaTime * Input.GetAxis("Vertical");
        float yon = maxDireksiyonAcisi * Input.GetAxis("Horizontal");
        
        if (fren > 0)
        {
            fren = 0;
        }
        else
        {
            fren *= -1;
        }

        if (motor < 0)
        {
            motor = 0;
        }

        if (oyunAcilisiMi) 
        {
            motor = maxMotorTorku * Time.deltaTime;
            fren = 0;
        }

        if(Time.realtimeSinceStartup > 10) 
        {
            oyunAcilisiMi = false;
            
        }
        
        
        foreach (var teker in tümTekerler)
        {
            teker.motorTorque = motor;
            if (frenAktif) 
            { 
                teker.brakeTorque = fren;
            }
            else
            { 
                teker.brakeTorque = 0;
            }
            
            tekerleriDondurme(teker);
        }

        foreach (var teker in yonVerenTekerler)
        {
            teker.steerAngle = yon;
        }

    }


}

