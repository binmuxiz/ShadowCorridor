using UnityEngine;

public class Exit : MonoBehaviour, IInteractable
{
    private const string Message = "나가기";
    private const string WarningMessage = "구급상자를 모두 모야야 한다.";

    public void ShowMessage()
    {
        if (Firstaid.Instance.AllCollected())
        {
            InteractionUI.Instance.Show(Message);
        }
        else
        {
            InteractionUI.Instance.Show(WarningMessage);
        }
    }
    
    public void Interact()
    {
        if (Firstaid.Instance.AllCollected())
        {
            // 게임 종료
            GameEnding.Instance.IsPlayerAtExit = true;
        }
    }
}
