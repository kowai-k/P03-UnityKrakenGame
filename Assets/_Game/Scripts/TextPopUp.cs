using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextPopUp : MonoBehaviour
{
    //Connections are done here
    [Header("Connections SetUp")]

    [SerializeField] 
        [Tooltip("This is what you are trying to detect, this is usually your player but could be anything")] private Transform target;

    [SerializeField] [Tooltip("This is the text component from the canvas that needs to be linked so that the text changes to what you'd like")] 
        TMP_Text _textConnection;

    [SerializeField] [Tooltip("Connect to the text canvas component")] GameObject _textCanvas;

    [SerializeField] [Tooltip("Connect to the image canvas component")] GameObject _imageCanvas;
    
    //Customizable attributes
    [Header("Customizations")]
    [SerializeField] [Tooltip("This will be the text displayed when you enter the detection range")] [TextArea()] string _textToDisplay;

    [SerializeField] [Tooltip("This is how long the text will appear for before going away")] int _secondsToDisplay = 3;
    
    [SerializeField] [Tooltip("Distance the target can be detected from")] [Range(0,100)] private float _range = 2.5f;

    //Audio Source
    //[Header("Audio")]
   // [SerializeField] [Tooltip("Audio clip that plays when target is detected")] AudioSource _audioToPlay;
    

    void Start()
    {
        _textCanvas.SetActive (false);
        _imageCanvas.SetActive (false);
        _textConnection.text = _textToDisplay;
    }


    private void OnDrawGizmosSelected()
    {
        //shows user the range 
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) <= _range)
        {
            //OnEnter.Invoke();
            _textConnection.text = _textToDisplay;
            Debug.Log("Player is within range");
            //AudioPlayer();
            StartCoroutine(TextPopsUp());
        }
    }

    IEnumerator TextPopsUp()
    {
        _textCanvas.SetActive(true);
        _imageCanvas.SetActive(true);
        //AudioPlayer();
        yield return new WaitForSeconds(_secondsToDisplay);
        _textCanvas.SetActive(false);
        _imageCanvas.SetActive(false);
    }

    /*
    private void AudioPlayer()
    {
        AudioSource newSound = Instantiate(_audioToPlay, transform.position, Quaternion.identity);
        Destroy(newSound.gameObject, newSound.clip.length);
        //DestroyImmediate(_audioToPlay, true);
    }
    */
}
