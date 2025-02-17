using UnityEngine;

public class MousePainter : MonoBehaviour{
    public Camera cam;
    [Space]
    public bool singleClick;
    [Space]
    public Color paintColor;
    [SerializeField, Tooltip("开火键")]
    public string fireButtonName = "Fire1";

    
    public float radius = 1;
    public float strength = 1;
    public float hardness = 1;

    void Update(){

        bool click;
        click = singleClick ? Input.GetButtonDown(fireButtonName) : Input.GetButton(fireButtonName);

        if (click){
            Vector3 position = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f)){
                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
                transform.position = hit.point;
                Paintable p = hit.collider.GetComponent<Paintable>();
                if(p != null){
                    PaintManager.instance.paint(p, hit.point, radius, hardness, strength, paintColor);
                }
            }
        }

    }

}
