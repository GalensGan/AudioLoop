# AudioLoop

## 简介(Introduction)

AudioLoop(音频循环)是一个可以自定义时间间隔来播放音频的工具。

为什么开发这个工具呢？

前不久，买了一个蓝牙音响接入电脑，方便收到消息后，可以听到提示音。但这个音响有个问题，当一段时间没有音频输入后，它就自动休眠了，而自身又没有关闭功能，所以想了一个曲线救国的方案，每隔一段时间就播放一次静音的音乐，达到阻止休眠的目的。

AudioLoop is a tool that allows you to play audio at custom time intervals.

Why was this tool developed?

Recently, I bought a Bluetooth speaker to connect to my computer so that I could hear notification sounds. However, the speaker has a problem: it automatically goes to sleep when there is no audio input for a period of time, and it does not have a built-in shutdown function. To solve this problem, I came up with a workaround: playing silent music at regular intervals to prevent the speaker from going to sleep.

## 功能(Feature)

功能很简单，就是可以循环播放一段音频，间隔时间可以自定义，音频文件也可以自定义。

The function is very simple, which is to loop a piece of audio with a customizable time interval and customizable audio file.

## 环境(Environment required)

需要 `.Net Framwork v4.6.2` 或更高的版本。

Requires `.Net Framework v4.6.2` or higher.

## 使用(Usage)

从 [releases](https://github.com/GalensGan/AudioLoop/releases) 下载解压，在解压的目录中打开 `cmd`，输入 `./al start` 即可。

## 命令行参数(Options)

### start

| 参数(long option) | 简写(short option) | 描述(description)  | 示例(example)         |
| ----------------- | ------------------ | ------------------ | --------------------- |
| --interval        | -i                 | 设置播放的间隔日期 | `./al start -i 10000` |

