using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Media;

namespace AudioLoop
{
    /// <summary>
    /// 循环播放服务
    /// </summary>
    internal class AudioLoopPlayerService:ServiceBase
    {
        // 默认 5 分钟
        private int _interval = 300000;

        private SoundPlayer _soundPlayer;

        /// <summary>
        /// 声音循环播放器
        /// </summary>
        /// <param name="interval">时间间隔，单位 ms</param>
        public AudioLoopPlayerService(int interval)
        {
            ServiceName  ="AudioLoopPlayerService";
            if(interval>0)_interval = interval;

            _soundPlayer = new SoundPlayer("./sound.mp3");
        }

        public void Start()
        {
            // 发出声音，表示加载成功
            System.Media.SystemSounds.Beep.Play();

            // 每隔 5 分钟播放一次声音
            var timer = new System.Timers.Timer(_interval);
            timer.Elapsed += (sender, e) =>
            {
                // 播放声音
                //System.Media.SystemSounds.Question.Play();                
                _soundPlayer.Play();
            };
            timer.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }
    }
}
