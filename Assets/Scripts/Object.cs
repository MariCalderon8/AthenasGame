using UnityEngine;

public class Object : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            ControladorObject.Instance.collectObject();
            Destroy(gameObject);
        }
    }
}
