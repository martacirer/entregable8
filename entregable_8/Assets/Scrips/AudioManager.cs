using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    // AudioSource del GameObject
    private AudioSource audioSource;

    // Título del audio que suena
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

        // Muestra el título del audio
        ShowAudioName();
    }

    // Cambia y reproduce la siguiente canción
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

    // Cambia y reproduce la canción anterior
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

    // Empieza y reanuda la canción
    public void PlayAudio()
    {
        
        if (!audioSource.isPlaying)
        {
            
            audioSource.Play();
        }
    }

    // Pausa la canción
    public void PauseAudio()
    {
        audioSource.Pause();
    }

    // Detiene y reinicia la canción actual
    public void StopAudio()
    {
        audioSource.Stop();
    }

    // Reproduce una canción aleatoria
    public void RandomAudio()
    {
        
        int randomIndex = Random.Range(0, audioClips.Length);

         //valor aleatorio
        audioIndex = randomIndex;

        // Reproduce el audio
        StartAudio();
    }

    // Muestra el nombre de la canción
    private void ShowAudioName()
    {
        
        title.GetComponent<TextMeshProUGUI>().text = audioNames[audioIndex];
    }

    // Reproduce el audio
    public void StartAudio()
    {
        // Inserta la canción correspondiente al Index
        audioSource.clip = audioClips[audioIndex];

        // pausa y reanuda el audio
        StopAudio();
        PlayAudio();

        // enseña el nombre del audio
        ShowAudioName();
    }
}