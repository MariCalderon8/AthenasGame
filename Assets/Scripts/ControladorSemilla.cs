using UnityEngine;

public class ControladorSemilla : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public bool seedCollected = false;
    public static ControladorSemilla Instance;
    public GameObject objetoMostrar; 

    public AudioSource audioSource;
    public AudioClip collectedSound;

    private void Awake(){
        if(ControladorSemilla.Instance == null){
            ControladorSemilla.Instance = this;
            DontDestroyOnLoad(this.gameObject);

        } else{
            Destroy(gameObject);
        }
    }


    void Start()
    {
        seedCollected = false;
        objetoMostrar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(seedCollected)
        {

        }
    }

    public void collectSeed(){
        seedCollected = true;
        audioSource.PlayOneShot(collectedSound);
        objetoMostrar.SetActive(true);
    }

}
