using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DragAndDrop : MonoBehaviour
{
    private bool _isSelected = false;
    private float _selectX, _selectY;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        

        if (transform.parent)
        {
            StockingFactory factory = transform.parent.GetComponent<StockingFactory>();
            if (factory)
            {
                factory.InstantiateStocking();
            }
        }

        _isSelected = true;
        transform.parent = null;
        var v3 = Input.mousePosition;
        v3.z = 0.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        _selectX = v3.x - transform.position.x;
        _selectY = v3.y - transform.position.y;

    }

    void OnMouseDrag()
    {
        if (_isSelected)
        {
            var v3 = Input.mousePosition;
            v3.z = 0.0f;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            transform.position = new Vector3(v3.x - _selectX, v3.y - _selectY, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        _isSelected = false;

        Collider2D myCollider = GetComponent<Collider2D>();
        Collider2D[] snapColliders = new Collider2D[4];
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.GetMask("Snappable"));
        int count = myCollider.OverlapCollider(contactFilter, snapColliders);

        if (count > 0)
        {
            Transform parentTransform = snapColliders[0].transform;
            Vector3 destination = new Vector3(snapColliders[0].transform.position.x,
                snapColliders[0].transform.position.y, transform.position.z);

            for (int i = 1; i < count; ++i)
            {
                Vector3 currentDest = new Vector3(snapColliders[i].transform.position.x,
                    snapColliders[i].transform.position.y, transform.position.z);
                if (Vector3.Distance(transform.position, destination) >
                    Vector3.Distance(transform.position, currentDest))
                {
                    destination = currentDest;
                    parentTransform = snapColliders[i].transform;
                }
            }

            // destroy all existing children of parent
            if (parentTransform.childCount > 0)
            {
                for (int i = 0; i < parentTransform.childCount; ++i)
                {
                    Destroy(parentTransform.GetChild(i).gameObject);
                }
            }

            this.transform.position = destination;
            this.transform.SetParent(parentTransform);

            //GameBoard.instance.UpdateScore();
        }
        else
        {
            Destroy(gameObject);
        }
        GameBoard.instance.UpdateSubmitButton();
    }
}
