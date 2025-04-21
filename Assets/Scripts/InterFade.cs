using UnityEngine;
using System.Collections;

public class InterFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup _FadeCanvasGroup;
    [SerializeField] private float _fadeDuration = 1f;

    private bool _isOpen = false;

    [ContextMenu("Toggle UI")]
    public void ToogleUI()
    {
        _isOpen = !_isOpen;

        _FadeCanvasGroup.Fade(_isOpen, _fadeDuration);
    }

      //IEnumerator Fade()
    //{
    // float alpha = _isShown ? 0f : 1f;
    //  if(_isShown)
    //    {
    //        while(alpha < 1f)
    //        {
    //            alpha += _fadeSpeed * Time.deltaTime;
    //            _canvasGroup.alpha = alpha;
    //            yield return null;
     //       }
     //   }
     //   else
     //   {
      //      while(alpha > 0f)
      //      {
      //          alpha -= _fadeSpeed * Time.deltaTime;
      //          _canvasGroup.alpha = alpha;
      //          yield return null;
      //      }
      //  }
        
       // yield return new WaitForSeconds(0.5f);
       // Debug.Log("Hello World!");
   // }                                                   

}
