using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Pan and Scroll Options")]
    public float panSpeed = 30f; 
    public float panBorderThickness = 10f; 
    public float scrollSpeed = 5f; 

    [Header("Camera Clamp Options")]
    public float minX = 0f;
    public float maxX = 100f;
    public float minY = 10f; 
    public float maxY = 80f; 
    public float minZ = 0f;
    public float maxZ = 100f;


    // Update is called once per frame
    void Update()
    {

      if(GameManager.gameEnded){
         this.enabled = false;
         return;
      }

     if(Input.GetKey("w")){
        transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
     }   
     if(Input.GetKey("s")){
        transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
     }   
     if(Input.GetKey("d")){
        transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
     }   
     if(Input.GetKey("a")){
        transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
     }

     float scroll = Input.GetAxis("Mouse ScrollWheel");
     
     Vector3 pos = transform.position;

     pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
     pos.y = Mathf.Clamp(pos.y, minY, maxY);

     pos.x = Mathf.Clamp(pos.x, minX, maxX);
     pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

     transform.position = pos;
    }
}
