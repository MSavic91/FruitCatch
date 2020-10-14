using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOut : MonoBehaviour
{
    private CollectableDataHolder cdh;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            cdh = collision.gameObject.GetComponent<CollectableDataHolder>();
        }
        catch
        {
            Destroy(collision.gameObject);
            return;
        }

        if (cdh.collectableObjectData.LifeIfFallOut != 0)
        {
            Events.instance.CollectableFallOutLifeChangeRaiseEvent(collision.gameObject, cdh.collectableObjectData);
        }
        else
        {
            collision.gameObject.SetActive(false);
        }
        
    }
}
