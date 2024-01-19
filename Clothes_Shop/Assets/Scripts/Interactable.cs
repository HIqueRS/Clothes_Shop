using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent _enterTheArea;
    public UnityEvent _exitTheArea;
    public UnityEvent _inTheArea;

    public KeyCode _enterKey;

    private bool _isInArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isInArea)
        {
            if (Input.GetKeyDown(_enterKey))
            {
                _inTheArea.Invoke();
            }
        }
       
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enterTheArea.Invoke();
            _isInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _exitTheArea.Invoke();
            _isInArea = false;
        }
    }

}
