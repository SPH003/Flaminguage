using NAudio.Wave;
using System.Collections.Generic;

namespace Flaminguage
{
    internal class Naudiohandler
    {
        private IWavePlayer outputDevice;
        private AudioFileReader audioFile;

        private List<string> playlist = new List<string>();
        private int index;

        private bool isPaused = false;
        private bool isDisposed = false;

        // -------------------------
        // DISPOSE PATTERN
        // -------------------------
        public void Dispose()
        {
            if (isDisposed) return;

            StopInternal();
            isDisposed = true;
        }

        // -----------------------------
        // SET PLAYLIST
        // -----------------------------
        public void SetPlaylist(List<string> files, int user_index)
        {
            Stop();
            playlist = files ?? new List<string>();
            index = user_index;
        }

        // -----------------------------
        // PLAY CURRENT SONG
        // -----------------------------
        public void Play()
        {
            if (playlist.Count == 0) return;

            if (isPaused)
            {
                Resume();
                return;
            }

            PlayAtIndex(index);
        }

        private void PlayAtIndex(int i)
        {
            StopInternal();

            if (playlist.Count == 0) return;

            index = i;

            audioFile = new AudioFileReader(playlist[index]);
            outputDevice = new WaveOutEvent();

            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += OnPlaybackStopped;
            outputDevice.Play();

            isPaused = false;
        }

        // -----------------------------
        // AUTO NEXT WHEN SONG ENDS
        // -----------------------------
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            NextInternal();
        }

        // -----------------------------
        // NEXT SONG
        // -----------------------------
        public void Next()
        {
            NextInternal();
        }

        private void NextInternal()
        {
            if (playlist.Count == 0) return;

            index++;

            if (index >= playlist.Count)
                index = 0; // loop playlist

            PlayAtIndex(index);
        }

        // -----------------------------
        // PREVIOUS SONG
        // -----------------------------
        public void Previous()
        {
            if (playlist.Count == 0) return;

            index--;

            if (index < 0)
                index = playlist.Count - 1;

            PlayAtIndex(index);
        }

        // -----------------------------
        // PAUSE
        // -----------------------------
        public void Pause()
        {
            if (outputDevice != null)
            {
                outputDevice.Pause();
                isPaused = true;
            }
        }

        // -----------------------------
        // RESUME
        // -----------------------------
        public void Resume()
        {
            if (outputDevice != null && isPaused)
            {
                outputDevice.Play();
                isPaused = false;
            }
        }

        // -----------------------------
        // STOP COMPLETELY
        // -----------------------------
        public void Stop()
        {
            index = 0;
            StopInternal();
        }

        private void StopInternal()
        {
            isPaused = false;

            if (outputDevice != null)
            {
                outputDevice.PlaybackStopped -= OnPlaybackStopped;
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
        }

        // -----------------------------
        // VOLUME CONTROL
        // -----------------------------
        public void SetVolume(float volume)
        {
            if (audioFile != null)
                audioFile.Volume = volume; // 0.0 - 1.0
        }
    }
}