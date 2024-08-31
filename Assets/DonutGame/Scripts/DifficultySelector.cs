using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public AudioSource audiosource;  // インスペクターでAudioSourceを割り当て
    public AudioClip start1SE;
    public AudioClip start2SE;
    public AudioClip start3SE;
    public AudioClip start4SE;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void SetDifficultyEasy()
    {
        GameSettings.selectedDifficulty = TypingManager.Difficulty.Easy;
        audiosource.PlayOneShot(start1SE);
        selecter.sel = 1;
        Invoke("GoSelectStage1", 1.0f);
    }

    public void SetDifficultyMedium()
    {
        GameSettings.selectedDifficulty = TypingManager.Difficulty.Medium;
        audiosource.PlayOneShot(start2SE);
        selecter.sel = 2;
        Invoke("GoSelectStage2", 1.0f);
    }

    public void SetDifficultyHard()
    {
        GameSettings.selectedDifficulty = TypingManager.Difficulty.Hard;
        audiosource.PlayOneShot(start3SE);
        selecter.sel = 3;
        Invoke("GoSelectStage3", 1.0f);
    }

    public void SetDifficultyExpert()
    {
        GameSettings.selectedDifficulty = TypingManager.Difficulty.Expert;
        audiosource.PlayOneShot(start4SE);
        selecter.sel = 4;
        Invoke("GoSelectStage4", 1.0f);
    }

    private void GoSelectStage1()
    {
        SceneManager.LoadScene("SampleScene1");
    }

    private void GoSelectStage2()
    {
        SceneManager.LoadScene("SampleScene2");
    }

    private void GoSelectStage3()
    {
        SceneManager.LoadScene("SampleScene3");
    }

    private void GoSelectStage4()
    {
        SceneManager.LoadScene("SampleScene4");
    }
}