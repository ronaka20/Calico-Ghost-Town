
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
   public float damage = 20f;
   public float range = 100f ; 
   public Camera mainCam;
   public ParticleSystem muzzleFlash;
   public bool isFiring; 
   public float maxAvailableAmmo = 12f;
   public float bulletsInPistol = 6f;
   
    public Text bulletcount;


    public AudioClip shootSound;
    public AudioClip shootSoundpickup;
    public AudioClip shootSoundempty;
    public float soundIntensity=5f;
    public LayerMask zombieLayer;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }



   void reload(){
       if(maxAvailableAmmo>0){
       bulletsInPistol =6f;
       maxAvailableAmmo = maxAvailableAmmo-6;
       
       }
       else return;

   }
   void fire(){
       RaycastHit targethit;          
       if(Physics.Raycast(mainCam.transform.position,mainCam.transform.forward,out targethit, range)){
           Debug.Log(targethit.transform.name);
           muzzleFlash.Play();
           isFiring = true;
           bulletsInPistol --;
           audioSource.PlayOneShot(shootSound);  
        Collider[] zombies=Physics.OverlapSphere(transform.position,soundIntensity,zombieLayer);
        for(int i=0;i<zombies.Length;i++)
        {
            zombies[i].GetComponent<enemymovement>().OnAware();
        }
           //bulletcount.text = bulletsInPistol.ToString();
           Health enemy=targethit.transform.GetComponent<Health>();
           enemy.Damage(damage);
       }
   }
    void Update()
    {

        bulletcount.text = bulletsInPistol.ToString();
        
        if (Input.GetButtonDown("Fire1")&&maxAvailableAmmo>=0){
            if(bulletsInPistol>0){
               fire();}
               else if(bulletsInPistol==0){
                   reload();
                   if(bulletsInPistol>0){
                   fire();}

               }
        }
        if(maxAvailableAmmo<=0 && bulletsInPistol==0 && Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(shootSoundempty);
        }
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(20,100,200,40),"Ammo:"+bulletsInPistol);
        GUI.Label(new Rect(70,100,200,40),"/"+maxAvailableAmmo);
    }

    public void AmmoIncrease(float number)
    {
        maxAvailableAmmo = maxAvailableAmmo+number;
        audioSource.PlayOneShot(shootSoundpickup);
    }

}
