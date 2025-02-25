using UnityEngine;

public class ControladorObject : MonoBehaviour
{
    [SerializeField] public int objectsCollected = 0;
    public static ControladorObject Instance;
    public GameObject objetoMostrar; 

    private void Awake(){
        if(ControladorObject.Instance == null){
            ControladorObject.Instance = this;
            DontDestroyOnLoad(this.gameObject);

        } else{
            Destroy(gameObject);
        }
    }


    void Start()
    {
        objetoMostrar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(objectsCollected == 3) 
        {
            objetoMostrar.SetActive(true);
        }
    }

    public void collectObject(){
        objectsCollected++;  
    }
}
