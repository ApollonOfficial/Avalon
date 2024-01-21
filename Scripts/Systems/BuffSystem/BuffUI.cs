using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]
public class BuffUI : MonoBehaviour
{
    private Image _icon;
    private Animator _animator;

    public void SetIcon(Sprite icon)
    {
        if(!_icon)
        {
            _icon = GetComponent<Image>();
        }
        _icon.sprite = icon;
    }

    public void PlayEndAnimation()
    {
        if(!_animator)
        {
            _animator = GetComponent<Animator>();
        }
        _animator.SetTrigger("End");
    }
}
