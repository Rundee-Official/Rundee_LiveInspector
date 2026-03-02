// 1. [SerializeField 인터페이스 문제 해결]
// InputProvider Asset 구조 변경
[CreateAssetMenu(fileName = "InputProviderAsset", menuName = "Input/Provider")]
public class InputProviderAsset : ScriptableObject, IInputProvider {
    [SerializeField] private InputProviderKeyboard _keyboardImpl;
    
    public float Horizontal => _keyboardImpl.Horizontal;
    public float Vertical => _keyboardImpl.Vertical;
    public bool IsJumpPressed => _keyboardImpl.IsJumpPressed;
    public bool IsJumpReleased => _keyboardImpl.IsJumpReleased;
}