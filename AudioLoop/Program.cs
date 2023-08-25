using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AudioLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rootCommand = new RootCommand("SlientAudioLoop command-line app");

            // 启动声音循环播放
            var startCommand = new Command("start", "启动声音循环播放");
            rootCommand.Add(startCommand);
            var intervalOption = new Option<int>(name: "--interval", description: "循环播放时间间隔，默认 300000ms，单位：ms", getDefaultValue: () => 60000);
            intervalOption.AddAlias("-i");

            startCommand.AddOption(intervalOption);
            startCommand.SetHandler(interval =>
            {
                var player = new AudioLoopPlayerService(interval);
                player.Start();
                Console.WriteLine("循环播放声音功能已启动，按任意键退出...");
                Console.ReadLine();
            }, intervalOption);


            // 服务模块
            var serviceCommand = new Command("service", "注册为服务");
            rootCommand.Add(serviceCommand);

            // 注册为服务
            var installCommand = new Command("install", "注册服务");
            serviceCommand.Add(installCommand);
            installCommand.Add(intervalOption);
            installCommand.SetHandler(interval =>
            {
                // 将当前程序注册为服务
                // 调用 cmd sc create SlientAudioLoop binPath= "D:\SlientAudioLoop.exe service start -i 1000"
                // 获取程序路径
                string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string cmd = $"sc create SlientAudioLoop binPath= \"{exePath} service start -i {interval}\" & net start SlientAudioLoop";
                Process.Start("cmd.exe", cmd);
            }, intervalOption);

            // 卸载服务
            var serviceStartCommand = new Command("start", "卸载服务");
            serviceCommand.Add(serviceStartCommand);
            serviceStartCommand.Add(intervalOption);
            serviceStartCommand.SetHandler(interval =>
            {
                var serviceBases = new ServiceBase[] { new AudioLoopPlayerService(interval) };
                ServiceBase.Run(serviceBases);
            }, intervalOption);

            rootCommand.Invoke(args);
        }
    }
}
