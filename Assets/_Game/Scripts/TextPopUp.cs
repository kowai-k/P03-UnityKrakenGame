using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopUp : MonoBehaviour
{
    //add headers, explainations too
    [Header("Connections SetUp")]

    [SerializeField] 
        [Tooltip("This is what you are trying to detect, this is usually your player but could be anything")] private Transform target;

    [SerializeField] [Tooltip("This is the text component from the canvas that needs to be linked so that the text changes to what you'd like")] 
        TMP_Text _textConnection;

    [SerializeField] [Tooltip("Connect to the text canvas component")] GameObject _textCanvas;

    [SerializeField] [Tooltip("Connect to the image canvas component")] GameObject _imageCanvas;
    
    [Header("Customizations")]
    [SerializeField] [Tooltip("This will be the text displayed when you enter the detection range")] [TextArea()] string _textToDisplay;
    [SerializeField] [Tooltip("This is how long the text will appear for before going away")] int _secondsToDisplay = 3;
    
    [SerializeField] [Tooltip("Distance the target can be detected from")] [Range(0,100)] private float _range = 2.5f;
   
    //make these two unchangable
    

    void Start()
    {
        _textCanvas.SetActive (false);
        _imageCanvas.SetActive (false);

        _textConnection.text = _textToDisplay;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    void FixedUpdate()
    {

        if (Vector3.Distance(target.position, transform.position) <= _range)
        {
            _textConnection.text = _textToDisplay;
            Debug.Log("Player is within range");

            StartCoroutine(TextPopsUp());
        }
    }

    IEnumerator TextPopsUp()
    {
        _textCanvas.SetActive(true);
        _imageCanvas.SetActive(true);
        yield return new WaitForSeconds(_secondsToDisplay);
        _textCanvas.SetActive(false);
        _imageCanvas.SetActive(false);
    }
}
