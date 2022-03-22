using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    // AudioSource del GameObject
    private AudioSource audioSource;

    // T�tulo del audio que suena
    public GameObject title;

    // Array  y nombres de los audios
    public AudioClip[] audioClips;
    public string[] audioNames;

    
    private int audioIndex = 0;

    // Al empezar
    void Start()
    {
        // Obtiene la componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Inserta el audio correspondiente
        audioSource.clip = audioClips[audioIndex];

        // Muestra el t�tulo del audio
        ShowAudioName();
    }

    // Cambia y reproduce la siguiente canci�n
    public void NextAudio()
    {
        
        audioIndex++;

        
        if (audioIndex >= audioClips.Length)
        {
            
            audioIndex = 0;
        }

        // Reproduce el audio
        StartAudio();
    }

    // Cambia y reproduce la canci�n anterior
    public void PreviousAudio()
    {
        
        audioIndex--;

        
        if (audioIndex < 0)
        {
            
            audioIndex = audioClips.Length - 1;
        }

        // Reproduce el audio
        StartAudio();
    }

    // Empieza y reanuda la canci�n
    public void PlayAudio()
    {
        
        if (!audioSource.isPlaying)
        {
            
            audioSource.Play();
        }
    }

    // Pausa la canci�n
    public void PauseAudio()
    {
        audioSource.Pause();
    }

    // Detiene y reinicia la canci�n actual
    public void StopAudio()
    {
        audioSource.Stop();
    }

    // Reproduce una canci�n aleatoria
    public void RandomAudio()
    {
        
        int randomIndex = Random.Range(0, audioClips.Length);

         //valor aleatorio
        audioIndex = randomIndex;

        // Reproduce el audio
        StartAudio();
    }

    // Muestra el nombre de la canci�n
    private void ShowAudioName()
    {
        
        title.GetComponent<TextMeshProUGUI>().text = audioNames[audioIndex];
    }

    // Reproduce el audio
    public void StartAudio()
    {
        // Inserta la canci�n correspondiente al Index
        audioSource.clip = audioClips[audioIndex];

        // pausa y reanuda el audio
        StopAudio();
        PlayAudio();

        // ense�a el nombre del audio
        ShowAudioName();
    }
}