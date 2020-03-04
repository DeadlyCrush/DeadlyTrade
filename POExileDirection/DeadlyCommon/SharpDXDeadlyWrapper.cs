using System;
using SharpDX.Multimedia;
using SharpDX.XAudio2;
using SharpDX.IO;
using System.Reflection;

namespace POExileDirection.DeadlyCommon
{
    public class SharpDXDeadlyWrapper
    {
        private XAudio2 _xAudio2;
        private WaveFormat _waveFormat;
        private AudioBuffer _audioBuffer;
        private SoundStream _soundStream;
        private NativeFileStream _nativeFilestream;
        private SourceVoice _sourceVoice;
        private MasteringVoice _masteringVoice;

        public void SetAudioHandler(string strFileName, int nVolume)
        {
            try
            {
                _xAudio2 = new XAudio2();
                _masteringVoice = new MasteringVoice(_xAudio2); 
                _masteringVoice.SetVolume(nVolume/100f, 0);

                _nativeFilestream = new NativeFileStream(strFileName, NativeFileMode.Open, NativeFileAccess.Read, NativeFileShare.Read);

                _soundStream = new SoundStream(_nativeFilestream);
                _waveFormat = _soundStream.Format;
                _audioBuffer = new AudioBuffer
                {
                    Stream = _soundStream.ToDataStream(),
                    AudioBytes = (int)_soundStream.Length,
                    Flags = BufferFlags.EndOfStream
                };
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        public void Play()
        {
            try
            {
                _sourceVoice = new SourceVoice(_xAudio2, _waveFormat, true);
                _sourceVoice.SubmitSourceBuffer(_audioBuffer, _soundStream.DecodedPacketsInfo);
                _sourceVoice.Start();
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        public void Dispose()
        {
            if (_xAudio2!=null) _xAudio2.Dispose();
            if (_soundStream != null) _soundStream.Dispose();
            if (_nativeFilestream != null) _nativeFilestream.Dispose();
            if (_sourceVoice != null) _sourceVoice.Dispose();
            if (_masteringVoice != null) _masteringVoice.Dispose();
        }
    }
}
