using UnityEngine;

public class TriggerEPOCH : MonoBehaviour
{
    public void MoveUp()
    {
        transform.position = transform.position + new Vector3(-40, 40, 0);
    }

    public void MoveDown()
    {
        transform.position = transform.position + new Vector3(40, -40, 0);
    }
}
