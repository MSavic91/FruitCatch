using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
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
            Destroy(collision.gameObject, 0.1f);
            return;
        }

        if (cdh.collectableObjectData.Points != 0)
        {
            Events.instance.CollectedScoreChangeRaiseEvent(collision.gameObject, cdh.collectableObjectData);
        }

        if (cdh.collectableObjectData.LifeIfCollected != 0)
        {
            Events.instance.CollectedLifeChangeRaiseEvent(collision.gameObject, cdh.collectableObjectData);
        }
        if (cdh.collectableObjectData.TimeAdd != 0)
        {
            Events.instance.CollectedTimeChangeRaiseEvent(collision.gameObject, cdh.collectableObjectData);
        }

        if (cdh.collectableObjectData.Special)
        {
            Events.instance.CollectedInfoChangeRaiseEvent(collision.gameObject, cdh.collectableObjectData);
        }

    }
}
