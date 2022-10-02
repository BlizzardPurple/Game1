using UnityEngine;

public class CamControl : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 10f;
    public float panborderthickness = 10f;
    public float scrollspeed = 5f;
    public float miny = 10f;
    public float maxy = 60f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameEnded)
        {
            doMovement = false;
            this.enabled = false;
            return;
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
            //doMovement = !doMovement;
        if (!doMovement)
            return;

        //if ( Input.GetKey("s") || Input.mousePosition.y >= Screen.height - panborderthickness)
        if ( Input.GetKey("s"))
        {
            // Vector3.forward is same as new Vector3 (0f, 0f, 1f) ...  * panspeed * 
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        { 
            transform.Translate(-Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollspeed * Time.deltaTime * 500;
        pos.y = Mathf.Clamp (pos.y, miny, maxy);
        transform.position = pos;
    }
}
