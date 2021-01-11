using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCellScript : MonoBehaviour
{
    public void DestroyCell()
    {
        Destroy(transform.parent.gameObject);
    }
}
